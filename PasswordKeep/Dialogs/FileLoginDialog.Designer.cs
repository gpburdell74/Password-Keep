namespace PasswordKeep.UI
{
	partial class FileLoginDialog
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
			DialogHeader = new LoginDialogHeader();
			NameLabel = new Adaptive.Intelligence.Shared.UI.AdvancedLabel();
			PasswordLabel = new Adaptive.Intelligence.Shared.UI.AdvancedLabel();
			PasswordText = new Adaptive.Intelligence.Shared.UI.PasswordTextBox();
			NameText = new TextBox();
			UserIdImage = new PictureBox();
			PwdImage = new PictureBox();
			DividerLine = new Adaptive.Intelligence.Shared.UI.LineControl();
			OkButton = new Adaptive.Intelligence.Shared.UI.AIButton();
			CloseButton = new Adaptive.Intelligence.Shared.UI.AIButton();
			ttp = new ToolTip(components);
			ErrorProvider = new ErrorProvider(components);
			((System.ComponentModel.ISupportInitialize)UserIdImage).BeginInit();
			((System.ComponentModel.ISupportInitialize)PwdImage).BeginInit();
			((System.ComponentModel.ISupportInitialize)ErrorProvider).BeginInit();
			SuspendLayout();
			// 
			// DialogHeader
			// 
			DialogHeader.Dock = DockStyle.Top;
			DialogHeader.Location = new Point(0, 0);
			DialogHeader.Name = "DialogHeader";
			DialogHeader.Size = new Size(460, 77);
			DialogHeader.TabIndex = 0;
			DialogHeader.TabStop = false;
			// 
			// NameLabel
			// 
			NameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			NameLabel.Location = new Point(52, 90);
			NameLabel.Name = "NameLabel";
			NameLabel.Size = new Size(385, 20);
			NameLabel.TabIndex = 1;
			NameLabel.TabStop = false;
			NameLabel.Text = "Enter Your &Name:";
			NameLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// PasswordLabel
			// 
			PasswordLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			PasswordLabel.Location = new Point(52, 160);
			PasswordLabel.Name = "PasswordLabel";
			PasswordLabel.Size = new Size(385, 20);
			PasswordLabel.TabIndex = 3;
			PasswordLabel.TabStop = false;
			PasswordLabel.Text = "Enter the File &Password:";
			PasswordLabel.TextAlign = ContentAlignment.MiddleLeft;
			ttp.SetToolTip(PasswordLabel, "Enter the password for this file.");
			// 
			// PasswordText
			// 
			PasswordText.Font = new Font("Segoe UI", 9.75F);
			PasswordText.Location = new Point(55, 185);
			PasswordText.Margin = new Padding(4, 4, 4, 4);
			PasswordText.Name = "PasswordText";
			PasswordText.Size = new Size(385, 25);
			PasswordText.TabIndex = 4;
			ttp.SetToolTip(PasswordText, "Enter the password for this file.");
			// 
			// NameText
			// 
			NameText.Location = new Point(55, 115);
			NameText.Name = "NameText";
			NameText.Size = new Size(385, 25);
			NameText.TabIndex = 2;
			ttp.SetToolTip(NameText, "Enter the name or user ID of the person associated with this file.");
			// 
			// UserIdImage
			// 
			UserIdImage.Image = Properties.Resources.User_ID_Keys;
			UserIdImage.Location = new Point(18, 97);
			UserIdImage.Name = "UserIdImage";
			UserIdImage.Size = new Size(32, 32);
			UserIdImage.TabIndex = 5;
			UserIdImage.TabStop = false;
			// 
			// PwdImage
			// 
			PwdImage.Image = Properties.Resources.Password_Lock;
			PwdImage.Location = new Point(18, 168);
			PwdImage.Name = "PwdImage";
			PwdImage.Size = new Size(32, 32);
			PwdImage.TabIndex = 6;
			PwdImage.TabStop = false;
			// 
			// DividerLine
			// 
			DividerLine.BevelBottomColor = SystemColors.ControlLight;
			DividerLine.BevelTopColor = SystemColors.ControlDark;
			DividerLine.Direction = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			DividerLine.EndColor = Color.FromArgb(255, 128, 0);
			DividerLine.LineWidth = 3;
			DividerLine.Location = new Point(0, 240);
			DividerLine.Mode = Adaptive.Intelligence.Shared.UI.LineControlMode.Line;
			DividerLine.Name = "DividerLine";
			DividerLine.Orientation = Adaptive.Intelligence.Shared.UI.LineControlOrientation.Horizontal;
			DividerLine.Size = new Size(460, 3);
			DividerLine.StartColor = Color.DodgerBlue;
			DividerLine.TabIndex = 7;
			DividerLine.TabStop = false;
			// 
			// OkButton
			// 
			OkButton.BorderWidth = 1;
			OkButton.Checked = false;
			OkButton.Enabled = false;
			OkButton.HoverBorderColor = Color.Gray;
			OkButton.HoverDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			OkButton.HoverEndColor = Color.FromArgb(224, 224, 224);
			OkButton.HoverFont = new Font("Segoe UI", 9.75F);
			OkButton.HoverForeColor = Color.Black;
			OkButton.HoverStartColor = Color.FromArgb(218, 194, 204);
			OkButton.Image = Properties.Resources.Key;
			OkButton.ImageAlign = ContentAlignment.MiddleLeft;
			OkButton.Location = new Point(245, 255);
			OkButton.Name = "OkButton";
			OkButton.NormalBorderColor = Color.Gray;
			OkButton.NormalDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			OkButton.NormalEndColor = Color.Silver;
			OkButton.NormalFont = new Font("Segoe UI", 9.75F);
			OkButton.NormalForeColor = Color.Black;
			OkButton.NormalStartColor = Color.FromArgb(248, 248, 248);
			OkButton.PressedBorderColor = Color.Gray;
			OkButton.PressedDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			OkButton.PressedEndColor = Color.FromArgb(174, 45, 61);
			OkButton.PressedFont = new Font("Segoe UI", 9.75F);
			OkButton.PressedForeColor = Color.White;
			OkButton.PressedStartColor = Color.Gray;
			OkButton.Size = new Size(90, 32);
			OkButton.TabIndex = 5;
			OkButton.Text = "OK";
			OkButton.TextImageRelation = TextImageRelation.ImageBeforeText;
			ttp.SetToolTip(OkButton, "Click here to log in to the file and load the contents.");
			OkButton.UseVisualStyleBackColor = true;
			// 
			// CloseButton
			// 
			CloseButton.BorderWidth = 1;
			CloseButton.Checked = false;
			CloseButton.HoverBorderColor = Color.Gray;
			CloseButton.HoverDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			CloseButton.HoverEndColor = Color.FromArgb(224, 224, 224);
			CloseButton.HoverFont = new Font("Segoe UI", 9.75F);
			CloseButton.HoverForeColor = Color.Black;
			CloseButton.HoverStartColor = Color.FromArgb(218, 194, 204);
			CloseButton.Image = Properties.Resources.cancel_16x16;
			CloseButton.ImageAlign = ContentAlignment.MiddleLeft;
			CloseButton.Location = new Point(350, 255);
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
			CloseButton.Size = new Size(90, 32);
			CloseButton.TabIndex = 6;
			CloseButton.Text = "Cancel";
			CloseButton.TextImageRelation = TextImageRelation.ImageBeforeText;
			ttp.SetToolTip(CloseButton, "Click here to Cancel.");
			CloseButton.UseVisualStyleBackColor = true;
			// 
			// ErrorProvider
			// 
			ErrorProvider.ContainerControl = this;
			// 
			// FileLoginDialog
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(460, 300);
			ControlBox = false;
			Controls.Add(CloseButton);
			Controls.Add(OkButton);
			Controls.Add(DividerLine);
			Controls.Add(PwdImage);
			Controls.Add(UserIdImage);
			Controls.Add(NameText);
			Controls.Add(PasswordText);
			Controls.Add(PasswordLabel);
			Controls.Add(NameLabel);
			Controls.Add(DialogHeader);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			KeyPreview = true;
			Margin = new Padding(4, 5, 4, 5);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "FileLoginDialog";
			StartPosition = FormStartPosition.CenterScreen;
			((System.ComponentModel.ISupportInitialize)UserIdImage).EndInit();
			((System.ComponentModel.ISupportInitialize)PwdImage).EndInit();
			((System.ComponentModel.ISupportInitialize)ErrorProvider).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private LoginDialogHeader DialogHeader;
		private Adaptive.Intelligence.Shared.UI.AdvancedLabel NameLabel;
		private Adaptive.Intelligence.Shared.UI.AdvancedLabel PasswordLabel;
		private Adaptive.Intelligence.Shared.UI.PasswordTextBox PasswordText;
		private TextBox NameText;
		private PictureBox UserIdImage;
		private PictureBox PwdImage;
		private Adaptive.Intelligence.Shared.UI.LineControl DividerLine;
		private Adaptive.Intelligence.Shared.UI.AIButton OkButton;
		private Adaptive.Intelligence.Shared.UI.AIButton CloseButton;
		private ToolTip ttp;
		private ErrorProvider ErrorProvider;
	}
}