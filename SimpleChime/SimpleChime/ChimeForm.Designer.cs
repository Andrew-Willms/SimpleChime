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
		((System.ComponentModel.ISupportInitialize)TimerPeriodInput).BeginInit();
		SuspendLayout();
		// 
		// TimerPeriodInput
		// 
		TimerPeriodInput.Location = new Point(94, 63);
		TimerPeriodInput.Name = "TimerPeriodInput";
		TimerPeriodInput.Size = new Size(120, 23);
		TimerPeriodInput.TabIndex = 0;
		TimerPeriodInput.ValueChanged += TimerPeriodInput_ValueChanged;
		// 
		// TimerPeriodLabel
		// 
		TimerPeriodLabel.AutoSize = true;
		TimerPeriodLabel.Location = new Point(220, 65);
		TimerPeriodLabel.Name = "TimerPeriodLabel";
		TimerPeriodLabel.Size = new Size(38, 15);
		TimerPeriodLabel.TabIndex = 1;
		TimerPeriodLabel.Text = "label1";
		// 
		// TimeToRingLabel
		// 
		TimeToRingLabel.AutoSize = true;
		TimeToRingLabel.Location = new Point(94, 106);
		TimeToRingLabel.Name = "TimeToRingLabel";
		TimeToRingLabel.Size = new Size(38, 15);
		TimeToRingLabel.TabIndex = 2;
		TimeToRingLabel.Text = "label2";
		// 
		// ResetTimerButton
		// 
		ResetTimerButton.Location = new Point(220, 102);
		ResetTimerButton.Name = "ResetTimerButton";
		ResetTimerButton.Size = new Size(75, 23);
		ResetTimerButton.TabIndex = 3;
		ResetTimerButton.Text = "Reset Timer";
		ResetTimerButton.UseVisualStyleBackColor = true;
		// 
		// RemoveTimeButton
		// 
		RemoveTimeButton.Location = new Point(94, 147);
		RemoveTimeButton.Name = "RemoveTimeButton";
		RemoveTimeButton.Size = new Size(75, 23);
		RemoveTimeButton.TabIndex = 4;
		RemoveTimeButton.Text = "- 10 mins";
		RemoveTimeButton.UseVisualStyleBackColor = true;
		// 
		// AddTimeButton
		// 
		AddTimeButton.Location = new Point(220, 147);
		AddTimeButton.Name = "AddTimeButton";
		AddTimeButton.Size = new Size(75, 23);
		AddTimeButton.TabIndex = 5;
		AddTimeButton.Text = "+ 10 mins";
		AddTimeButton.UseVisualStyleBackColor = true;
		// 
		// ChimeForm
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(800, 450);
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
}