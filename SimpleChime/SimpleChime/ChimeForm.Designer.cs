using System.Drawing;
using System.Windows.Forms;

namespace SimpleChime;



partial class ChimeForm {

	/// <summary>
	///  Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	///  Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing) {
		if (disposing && (components != null)) {
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	///  Required method for Designer support - do not modify
	///  the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
		TimerPeriodInput = new NumericUpDown();
		TimerPeriodLabel = new Label();
		TimeToRingLabel = new Label();
		ResetTimerButton = new Button();
		RemoveTimeButton = new Button();
		AddTimeButton = new Button();
		PauseResumeButton = new Button();
		((System.ComponentModel.ISupportInitialize)TimerPeriodInput).BeginInit();
		SuspendLayout();
		// 
		// TimerPeriodInput
		// 
		TimerPeriodInput.Location = new Point(94, 63);
		TimerPeriodInput.Name = "TimerPeriodInput";
		TimerPeriodInput.Size = new Size(120, 23);
		TimerPeriodInput.TabIndex = 0;
		TimerPeriodInput.ValueChanged += TimerPeriodInputChanged;
		// 
		// TimerPeriodLabel
		// 
		TimerPeriodLabel.AutoSize = true;
		TimerPeriodLabel.Location = new Point(220, 65);
		TimerPeriodLabel.Name = "TimerPeriodLabel";
		TimerPeriodLabel.Size = new Size(130, 15);
		TimerPeriodLabel.TabIndex = 1;
		TimerPeriodLabel.Text = "minutes between rings.";
		TimerPeriodLabel.Click += TimerPeriodLabel_Click;
		// 
		// TimeToRingLabel
		// 
		TimeToRingLabel.AutoSize = true;
		TimeToRingLabel.Location = new Point(94, 118);
		TimeToRingLabel.Name = "TimeToRingLabel";
		TimeToRingLabel.Size = new Size(100, 15);
		TimeToRingLabel.TabIndex = 2;
		TimeToRingLabel.Text = "0:45:00 remaining";
		// 
		// ResetTimerButton
		// 
		ResetTimerButton.Location = new Point(220, 114);
		ResetTimerButton.Name = "ResetTimerButton";
		ResetTimerButton.Size = new Size(93, 23);
		ResetTimerButton.TabIndex = 3;
		ResetTimerButton.Text = "Restart Timer";
		ResetTimerButton.UseVisualStyleBackColor = true;
		ResetTimerButton.Click += RestartTimer;
		// 
		// RemoveTimeButton
		// 
		RemoveTimeButton.Location = new Point(220, 168);
		RemoveTimeButton.Name = "RemoveTimeButton";
		RemoveTimeButton.Size = new Size(75, 23);
		RemoveTimeButton.TabIndex = 4;
		RemoveTimeButton.Text = "- 5 mins";
		RemoveTimeButton.UseVisualStyleBackColor = true;
		RemoveTimeButton.Click += RemoveTime;
		// 
		// AddTimeButton
		// 
		AddTimeButton.Location = new Point(301, 168);
		AddTimeButton.Name = "AddTimeButton";
		AddTimeButton.Size = new Size(75, 23);
		AddTimeButton.TabIndex = 5;
		AddTimeButton.Text = "+ 5 mins";
		AddTimeButton.UseVisualStyleBackColor = true;
		AddTimeButton.Click += AddTime;
		// 
		// PauseResumeButton
		// 
		PauseResumeButton.Location = new Point(94, 168);
		PauseResumeButton.Name = "PauseResumeButton";
		PauseResumeButton.Size = new Size(75, 23);
		PauseResumeButton.TabIndex = 6;
		PauseResumeButton.Text = "Pause Timer";
		PauseResumeButton.UseVisualStyleBackColor = true;
		PauseResumeButton.Click += ToggleTimerPaused;
		// 
		// ChimeForm
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(800, 450);
		Controls.Add(PauseResumeButton);
		Controls.Add(AddTimeButton);
		Controls.Add(RemoveTimeButton);
		Controls.Add(ResetTimerButton);
		Controls.Add(TimeToRingLabel);
		Controls.Add(TimerPeriodLabel);
		Controls.Add(TimerPeriodInput);
		Name = "ChimeForm";
		Text = "SimpleChime";
		((System.ComponentModel.ISupportInitialize)TimerPeriodInput).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private NumericUpDown TimerPeriodInput;
	private Label TimerPeriodLabel;
	private Label TimeToRingLabel;
	private Button ResetTimerButton;
	private Button RemoveTimeButton;
	private Button AddTimeButton;
	private Button PauseResumeButton;
}