namespace PasswordKeep.UI
{
	partial class AddEditSecurityQuestionDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components;

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			QuestionLabel = new Adaptive.Intelligence.Shared.UI.AdvancedLabel();
			QuestionText = new TextBox();
			AnswerLabel = new Adaptive.Intelligence.Shared.UI.AdvancedLabel();
			AnswerText = new TextBox();
			ButtonPanel = new SaveCancelBar();
			ErrorProvider = new ErrorProvider(components);
			ttp = new ToolTip(components);
			((System.ComponentModel.ISupportInitialize)ErrorProvider).BeginInit();
			SuspendLayout();
			// 
			// QuestionLabel
			// 
			QuestionLabel.AutoSize = true;
			QuestionLabel.Font = new Font("Segoe UI", 9.75F);
			QuestionLabel.Location = new Point(24, 19);
			QuestionLabel.Name = "QuestionLabel";
			QuestionLabel.Size = new Size(112, 17);
			QuestionLabel.TabIndex = 0;
			QuestionLabel.TabStop = false;
			QuestionLabel.Text = "Security &Question:";
			QuestionLabel.TextAlign = ContentAlignment.TopCenter;
			// 
			// QuestionText
			// 
			QuestionText.Location = new Point(24, 42);
			QuestionText.Name = "QuestionText";
			QuestionText.PlaceholderText = "(Question)";
			QuestionText.Size = new Size(381, 25);
			QuestionText.TabIndex = 1;
			ttp.SetToolTip(QuestionText, "Enter the text of the security question.");
			// 
			// AnswerLabel
			// 
			AnswerLabel.AutoSize = true;
			AnswerLabel.Font = new Font("Segoe UI", 9.75F);
			AnswerLabel.Location = new Point(24, 83);
			AnswerLabel.Name = "AnswerLabel";
			AnswerLabel.Size = new Size(102, 17);
			AnswerLabel.TabIndex = 2;
			AnswerLabel.TabStop = false;
			AnswerLabel.Text = "Security &Answer:";
			AnswerLabel.TextAlign = ContentAlignment.TopCenter;
			// 
			// AnswerText
			// 
			AnswerText.Location = new Point(24, 106);
			AnswerText.Name = "AnswerText";
			AnswerText.PlaceholderText = "(Answer)";
			AnswerText.Size = new Size(381, 25);
			AnswerText.TabIndex = 3;
			ttp.SetToolTip(AnswerText, "Enter the text of your answer to the question.");
			// 
			// ButtonPanel
			// 
			ButtonPanel.CancelEnabled = true;
			ButtonPanel.CancelText = "Cancel";
			ButtonPanel.CancelVisible = true;
			ButtonPanel.Dock = DockStyle.Bottom;
			ButtonPanel.Font = new Font("Segoe UI", 9.75F);
			ButtonPanel.Location = new Point(0, 156);
			ButtonPanel.Margin = new Padding(4, 5, 4, 5);
			ButtonPanel.Name = "ButtonPanel";
			ButtonPanel.SaveEnabled = true;
			ButtonPanel.SaveText = "Save";
			ButtonPanel.SaveVisible = true;
			ButtonPanel.Size = new Size(432, 52);
			ButtonPanel.TabIndex = 4;
			// 
			// ErrorProvider
			// 
			ErrorProvider.ContainerControl = this;
			// 
			// AddEditSecurityQuestionDialog
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(432, 208);
			ControlBox = false;
			Controls.Add(ButtonPanel);
			Controls.Add(AnswerText);
			Controls.Add(AnswerLabel);
			Controls.Add(QuestionText);
			Controls.Add(QuestionLabel);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			KeyPreview = true;
			Name = "AddEditSecurityQuestionDialog";
			StartPosition = FormStartPosition.CenterScreen;
			((System.ComponentModel.ISupportInitialize)ErrorProvider).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Adaptive.Intelligence.Shared.UI.AdvancedLabel QuestionLabel;
		private TextBox QuestionText;
		private Adaptive.Intelligence.Shared.UI.AdvancedLabel AnswerLabel;
		private TextBox AnswerText;
		private SaveCancelBar ButtonPanel;
		private ToolTip ttp;
		private ErrorProvider ErrorProvider;
	}
}