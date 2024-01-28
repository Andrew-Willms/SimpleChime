using System;
using System.Windows.Forms;

namespace SimpleChime;



public partial class ChimeForm : Form {

	private TimeSpan TimerPeriod = TimeSpan.FromMinutes(5);

	private readonly SimpleTimer Timer = new();

	private bool TimerIsPaused;



	public ChimeForm() {

		InitializeComponent();

		TimerPeriodInput.Value = TimerPeriod.Minutes;

		Timer.Start(TimerPeriod);
		Timer.OnRing += OnTimerRing;

		Timer labelUpdateTier = new();
		labelUpdateTier.Tick += UpdateRemainingTimeLabel;
		labelUpdateTier.Interval = 190;
		labelUpdateTier.Start();
	}



	private void TimerPeriodInputChanged(object? sender, EventArgs e) {

		TimerPeriod = TimeSpan.FromMinutes((double)TimerPeriodInput.Value);

	}

	private void ToggleTimerPaused(object? sender, EventArgs e) {

		if (TimerIsPaused) {

			TimerIsPaused = false;
			PauseResumeButton.Text = @"Pause Timer";
			Timer.Resume();
			return;
		}

		TimerIsPaused = true;
		PauseResumeButton.Text = @"Resume Timer";
		Timer.Pause();
	}

	private void RestartTimer(object? sender, EventArgs e) {

		Timer.Stop();
		Timer.Start(TimerPeriod);
		TimerIsPaused = false;
		PauseResumeButton.Text = @"Pause Timer";
	}

	private void AddTime(object? sender, EventArgs e) {

		Timer.AddTime(TimeSpan.FromMinutes(10));
	}

	private void RemoveTime(object? sender, EventArgs e) {

		Timer.RemoveTime(TimeSpan.FromMinutes(10));
	}

	private static void OnTimerRing(object? sender, EventArgs e) {

		System.Media.SoundPlayer player = new("meow.mp3");
		player.Play();
	}

	private void UpdateRemainingTimeLabel(object? sender, EventArgs e) {

		string formatString = Timer.TimeRemaining switch {
			{ Days : > 1 } => "d' days 'h':'mm':'ss",
			{ Days : > 0 } => "d' day 'h':'mm':'ss",
			{ Hours : > 0 } => "h':'mm':'ss",
			_ => "m':'ss",
		};

		TimeToRingLabel.Text = $@"{Timer.TimeRemaining.ToString(formatString)} remaining";
	}

	private void TimerPeriodLabel_Click(object sender, EventArgs e) {

	}

}