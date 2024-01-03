using System;
using System.Windows.Forms;

namespace SimpleChime;



public partial class ChimeForm : Form {

	private decimal TimerPeriod = 45;

	public ChimeForm() {
		InitializeComponent();

		TimerPeriodInput.Value = 45;

		Timer MyTimer = new();
		MyTimer.Interval = (45 * 60 * 1000); // 45 mins
		MyTimer.Tick += new(TimerRing);
		MyTimer.Start();
	}

	private void TimerPeriodInput_ValueChanged(object sender, EventArgs e) {

		decimal newTimerPeriod = TimerPeriodInput.Value;

		decimal currentTimerValue = 

	}

	private void ResetTime() {

		Timer timer = new();
		timer.Interval = (45 * 60 * 1000); // 45 mins
		timer.Tick += new(TimerRing);
		timer.Start();

		timer.

	}

	private void TimerRing(object sender, EventArgs e) {

	}



}

public class TimerRapper {

	public bool IsRunning { get; private set; } = false;

	public TimeSpan? Duration { get; private set; }

	public decimal TimeElapsed { get; private set; } = 0;

	public decimal TimeLeft { get; private set; } = 0;



	private Timer InternalTimer = new();

	private DateTime? TimeWhenStarted = null;

	private Action Callback;



	public TimerRapper() {

	}

	public void SetTimer(TimeSpan duration, Action onRing) {

		Duration = duration;
		TimeWhenStarted = DateTime.Now;

	}

	public void TimerRings() {



	}

}