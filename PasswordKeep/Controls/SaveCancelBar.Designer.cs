namespace PasswordKeep.UI
{
	partial class SaveCancelBar
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components;

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			ButtonPanel = new Panel();
			ButtonAlignPanel = new Panel();
			SaveButton = new Adaptive.Intelligence.Shared.UI.AIButton();
			Seperator = new Panel();
			CloseButton = new Adaptive.Intelligence.Shared.UI.AIButton();
			ButtonLine = new Adaptive.Intelligence.Shared.UI.LineControl();
			ButtonPanel.SuspendLayout();
			ButtonAlignPanel.SuspendLayout();
			SuspendLayout();
			// 
			// ButtonPanel
			// 
			ButtonPanel.Controls.Add(ButtonAlignPanel);
			ButtonPanel.Controls.Add(ButtonLine);
			ButtonPanel.Dock = DockStyle.Bottom;
			ButtonPanel.Location = new Point(0, 0);
			ButtonPanel.MaximumSize = new Size(0, 46);
			ButtonPanel.MinimumSize = new Size(0, 46);
			ButtonPanel.Name = "ButtonPanel";
			ButtonPanel.Size = new Size(915, 46);
			ButtonPanel.TabIndex = 13;
			// 
			// ButtonAlignPanel
			// 
			ButtonAlignPanel.Controls.Add(SaveButton);
			ButtonAlignPanel.Controls.Add(Seperator);
			ButtonAlignPanel.Controls.Add(CloseButton);
			ButtonAlignPanel.Dock = DockStyle.Right;
			ButtonAlignPanel.Location = new Point(690, 2);
			ButtonAlignPanel.Name = "ButtonAlignPanel";
			ButtonAlignPanel.Padding = new Padding(0, 5, 5, 5);
			ButtonAlignPanel.Size = new Size(225, 44);
			ButtonAlignPanel.TabIndex = 3;
			// 
			// SaveButton
			// 
			SaveButton.BorderWidth = 1;
			SaveButton.Checked = false;
			SaveButton.Dock = DockStyle.Right;
			SaveButton.HoverBorderColor = Color.Gray;
			SaveButton.HoverDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			SaveButton.HoverEndColor = Color.FromArgb(224, 224, 224);
			SaveButton.HoverFont = new Font("Segoe UI", 9.75F);
			SaveButton.HoverForeColor = Color.Black;
			SaveButton.HoverStartColor = Color.FromArgb(218, 194, 204);
			SaveButton.Image = Properties.Resources.Save16;
			SaveButton.ImageAlign = ContentAlignment.MiddleLeft;
			SaveButton.Location = new Point(5, 5);
			SaveButton.Margin = new Padding(3, 3, 5, 3);
			SaveButton.Name = "SaveButton";
			SaveButton.NormalBorderColor = Color.Gray;
			SaveButton.NormalDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			SaveButton.NormalEndColor = Color.Silver;
			SaveButton.NormalFont = new Font("Segoe UI", 9.75F);
			SaveButton.NormalForeColor = Color.Black;
			SaveButton.NormalStartColor = Color.FromArgb(248, 248, 248);
			SaveButton.Padding = new Padding(0, 0, 5, 0);
			SaveButton.PressedBorderColor = Color.Gray;
			SaveButton.PressedDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			SaveButton.PressedEndColor = Color.FromArgb(174, 45, 61);
			SaveButton.PressedFont = new Font("Segoe UI", 9.75F);
			SaveButton.PressedForeColor = Color.White;
			SaveButton.PressedStartColor = Color.Gray;
			SaveButton.Size = new Size(105, 34);
			SaveButton.TabIndex = 0;
			SaveButton.Text = "Save";
			SaveButton.TextImageRelation = TextImageRelation.ImageBeforeText;
			SaveButton.UseVisualStyleBackColor = true;
			// 
			// Seperator
			// 
			Seperator.Dock = DockStyle.Right;
			Seperator.Location = new Point(110, 5);
			Seperator.Name = "Seperator";
			Seperator.Size = new Size(5, 34);
			Seperator.TabIndex = 5;
			// 
			// CloseButton
			// 
			CloseButton.BorderWidth = 1;
			CloseButton.Checked = false;
			CloseButton.Dock = DockStyle.Right;
			CloseButton.HoverBorderColor = Color.Gray;
			CloseButton.HoverDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			CloseButton.HoverEndColor = Color.FromArgb(224, 224, 224);
			CloseButton.HoverFont = new Font("Segoe UI", 9.75F);
			CloseButton.HoverForeColor = Color.Black;
			CloseButton.HoverStartColor = Color.FromArgb(218, 194, 204);
			CloseButton.Image = Properties.Resources.Cancel16;
			CloseButton.ImageAlign = ContentAlignment.MiddleLeft;
			CloseButton.Location = new Point(115, 5);
			CloseButton.Name = "CloseButton";
			CloseButton.NormalBorderColor = Color.Gray;
			CloseButton.NormalDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			CloseButton.NormalEndColor = Color.Silver;
			CloseButton.NormalFont = new Font("Segoe UI", 9.75F);
			CloseButton.NormalForeColor = Color.Black;
			CloseButton.NormalStartColor = Color.FromArgb(248, 248, 248);
			CloseButton.PressedBorderColor = Color.Gray;
			CloseButton.PressedDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			CloseButton.PressedEndColor = Color.FromArgb(174, 45, 61);
			CloseButton.PressedFont = new Font("Segoe UI", 9.75F);
			CloseButton.PressedForeColor = Color.White;
			CloseButton.PressedStartColor = Color.Gray;
			CloseButton.Size = new Size(105, 34);
			CloseButton.TabIndex = 2;
			CloseButton.Text = "Cancel";
			CloseButton.TextImageRelation = TextImageRelation.ImageBeforeText;
			CloseButton.UseVisualStyleBackColor = true;
			// 
			// ButtonLine
			// 
			ButtonLine.BevelBottomColor = SystemColors.ControlLight;
			ButtonLine.BevelTopColor = SystemColors.ControlDark;
			ButtonLine.Direction = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			ButtonLine.Dock = DockStyle.Top;
			ButtonLine.EndColor = SystemColors.ControlLight;
			ButtonLine.LineWidth = 2;
			ButtonLine.Location = new Point(0, 0);
			ButtonLine.Mode = Adaptive.Intelligence.Shared.UI.LineControlMode.Line;
			ButtonLine.Name = "ButtonLine";
			ButtonLine.Orientation = Adaptive.Intelligence.Shared.UI.LineControlOrientation.Horizontal;
			ButtonLine.Size = new Size(915, 2);
			ButtonLine.StartColor = Color.DodgerBlue;
			ButtonLine.TabIndex = 0;
			// 
			// SaveCancelBar
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(ButtonPanel);
			Name = "SaveCancelBar";
			Size = new Size(915, 46);
			ButtonPanel.ResumeLayout(false);
			ButtonAlignPanel.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private Panel ButtonPanel;
		private Panel ButtonAlignPanel;
		private Adaptive.Intelligence.Shared.UI.AIButton SaveButton;
		private Panel Seperator;
		private Adaptive.Intelligence.Shared.UI.AIButton CloseButton;
		private Adaptive.Intelligence.Shared.UI.LineControl ButtonLine;
	}
}
