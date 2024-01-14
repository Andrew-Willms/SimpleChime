using System;
using System.Timers;
using static SimpleChime.TimerState;

namespace SimpleChime;



public class TimerEventArgs : EventArgs {

	public required TimeSpan Duration { get; set; }

	public required TimeSpan TimeElapsed { get; set; }

	public required TimerState State { get; set; }

}



public enum TimerState {
	Stopped,
	Running,
	Paused,
	Complete
}



public class SimpleTimer {

	public TimeSpan Duration { get; private set; }

	public TimerState State { get; private set; } = Stopped;

	public TimeSpan TimeElapsed => State switch {
		Stopped => PreviousTimeElapsed,
		Running => PreviousTimeElapsed.Add(DateTime.Now.Subtract(TimeLastStarted)),
		Paused => PreviousTimeElapsed,
		Complete => Duration,
		_ => throw new ArgumentOutOfRangeException()
	};

	public TimeSpan TimeRemaining => Duration - TimeElapsed;



	public event EventHandler? OnRing;

	public event EventHandler? OnStop;

	public event EventHandler? OnStart;

	public event EventHandler? OnPause;
	
	public event EventHandler? OnResume;



	private readonly Timer InternalTimer = new();

	private TimeSpan PreviousTimeElapsed = TimeSpan.Zero;

	private DateTime TimeLastStarted;



	public bool Start(TimeSpan duration) {

		if (State is not (Stopped or Complete)) {
			return false;
		}

		State = Running;
		Duration = duration;
		TimeLastStarted = DateTime.Now;

		InternalTimer.Interval = Duration.TotalMilliseconds;
		InternalTimer.Start();

		InternalTimer.Elapsed += OnTimerRings;

		OnStart?.Invoke(this, new TimerEventArgs {
			Duration = Duration,
			TimeElapsed = TimeSpan.Zero,
			State = State
		});

		return true;
	}

	public bool Stop() {

		if (State is not (Running or Paused)) {
			return false;
		}

		State = Stopped;
		PreviousTimeElapsed = PreviousTimeElapsed.Add(DateTime.Now.Subtract(TimeLastStarted));
		InternalTimer.Stop();

		OnStop?.Invoke(this, new TimerEventArgs {
			Duration = Duration,
			TimeElapsed = PreviousTimeElapsed,
			State = State
		});

		return true;
	}

	public bool Pause() {

		if (State is not Running) {
			return false;
		}

		State = Paused;
		PreviousTimeElapsed = PreviousTimeElapsed.Add(DateTime.Now.Subtract(TimeLastStarted));
		InternalTimer.Stop();

		OnPause?.Invoke(this, new TimerEventArgs {
			Duration = Duration,
			TimeElapsed = PreviousTimeElapsed,
			State = State
		});

		return true;
	}

	public bool Resume() {

		if (State is not Paused) {
			return false;
		}

		State = Running;
		TimeLastStarted = DateTime.Now;

		InternalTimer.Interval = TimeRemaining.TotalMilliseconds;
		InternalTimer.Start();

		OnResume?.Invoke(this, new TimerEventArgs {
			Duration = Duration,
			TimeElapsed = PreviousTimeElapsed,
			State = State
		});

		return true;
	}

	private void OnTimerRings(object? sender, EventArgs e) {

		State = Complete;

		OnRing?.Invoke(this, new TimerEventArgs {
			Duration = Duration,
			TimeElapsed = TimeElapsed,
			State = State
		});
	}

	public void AddTime(TimeSpan timeToAdd) {
		throw new NotImplementedException();
	}

	public void RemoveTime(TimeSpan timeToRemove) {
		throw new NotImplementedException();
	}

}