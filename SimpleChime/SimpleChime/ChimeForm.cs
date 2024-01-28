using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace SimpleChime;



public partial class ChimeForm : Form {

	private readonly TimeSpan TimeToAdd = TimeSpan.FromMinutes(5);
	private readonly TimeSpan TimeToRemove = TimeSpan.FromMinutes(5);
	private const string AlarmPath = "alarm.wav";

	private TimeSpan TimerPeriod = TimeSpan.FromMinutes(45);

	private readonly SimpleTimer Timer = new();

	private bool TimerIsPaused;



	public ChimeForm() {

		InitializeComponent();

		TimerPeriodInput.Value = TimerPeriod.Minutes;

		Timer.Start(TimerPeriod);
		Timer.OnRing += OnTimerRing;

		Timer labelUpdateTier = new();
		labelUpdateTier.Tick += UpdateRemainingTimeLabelAndRemoveTimeButton;
		labelUpdateTier.Interval = 110;
		labelUpdateTier.Start();
	}



	private void TimerPeriodInputChanged(object? sender, EventArgs e) {

		TimerPeriod = TimeSpan.FromMinutes((double)TimerPeriodInput.Value);
	}

	private void TimerPeriodInput_KeyPressed(object? sender, KeyPressEventArgs e) {

		if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.') {
			e.Handled = true;
		}

		if (e.KeyChar == '.' && TimerPeriodInput.Text.Contains('.')) {
			e.Handled = true;
		}
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
		UpdateRemainingTimeLabelAndRemoveTimeButton(null!, null!);
	}

	private void AddTime(object? sender, EventArgs e) {

		Timer.AddTime(TimeToAdd);
		UpdateRemainingTimeLabelAndRemoveTimeButton(null!, null!);
	}

	private void RemoveTime(object? sender, EventArgs e) {

		Timer.RemoveTime(TimeToRemove);
		UpdateRemainingTimeLabelAndRemoveTimeButton(null!, null!);
	}

	private void OnTimerRing(object? sender, EventArgs e) {

		SoundPlayer player = File.Exists(AlarmPath)
			? new(AlarmPath)
			: new(Properties.Resources.meow);

		try {
			player.Play();

		} catch {
			SystemSounds.Exclamation.Play();
		}

		RestartTimer(null!, null!);
	}

	private void UpdateRemainingTimeLabelAndRemoveTimeButton(object? sender, EventArgs e) {

		string formatString = Timer.TimeRemaining switch {
			{ Days : > 1 } => "d' days 'h':'mm':'ss",
			{ Days : > 0 } => "d' day 'h':'mm':'ss",
			{ Hours : > 0 } => "h':'mm':'ss",
			_ => "m':'ss",
		};

		TimeToRingLabel.Text = $@"{Timer.TimeRemaining.ToString(formatString)} remaining";

		RemoveTimeButton.Enabled = Timer.TimeRemaining > TimeToRemove;
	}

	private void TimerPeriodLabel_Click(object sender, EventArgs e) {

	}



	private void ChimeForm_Resize(object sender, EventArgs e) {

		if (WindowState != FormWindowState.Minimized) {
			return;
		}

		SystemTrayIcon.Visible = true;
		ShowInTaskbar = false;
	}

	private void SystemTrayIcon_MouseClick(object sender, MouseEventArgs e) {

		WindowState = FormWindowState.Normal;
		SystemTrayIcon.Visible = false;
		ShowInTaskbar = true;
	}

}