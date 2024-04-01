namespace PasswordKeep.UI
{
	partial class NewFileDialog
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
			SaveAsLabel = new Adaptive.Intelligence.Shared.UI.AdvancedLabel();
			PasswordLabel = new Adaptive.Intelligence.Shared.UI.AdvancedLabel();
			ConfirmLabel = new Adaptive.Intelligence.Shared.UI.AdvancedLabel();
			PasswordText = new Adaptive.Intelligence.Shared.UI.PasswordTextBox();
			ConfirmText = new Adaptive.Intelligence.Shared.UI.PasswordTextBox();
			NameLabel = new Adaptive.Intelligence.Shared.UI.AdvancedLabel();
			NameText = new Adaptive.Intelligence.Shared.UI.PasswordTextBox();
			FileNameText = new TextBox();
			EllipseButton = new Button();
			OkButton = new Adaptive.Intelligence.Shared.UI.AIButton();
			CloseButton = new Adaptive.Intelligence.Shared.UI.AIButton();
			ErrorProvider = new ErrorProvider(components);
			ttp = new ToolTip(components);
			DialogHeader = new LoginDialogHeader();
			DividerLine = new Adaptive.Intelligence.Shared.UI.LineControl();
			lineControl1 = new Adaptive.Intelligence.Shared.UI.LineControl();
			PwdImage = new PictureBox();
			UserIdImage = new PictureBox();
			((System.ComponentModel.ISupportInitialize)ErrorProvider).BeginInit();
			((System.ComponentModel.ISupportInitialize)PwdImage).BeginInit();
			((System.ComponentModel.ISupportInitialize)UserIdImage).BeginInit();
			SuspendLayout();
			// 
			// SaveAsLabel
			// 
			SaveAsLabel.AutoSize = true;
			SaveAsLabel.Font = new Font("Segoe UI", 9.75F);
			SaveAsLabel.Location = new Point(52, 90);
			SaveAsLabel.Name = "SaveAsLabel";
			SaveAsLabel.Size = new Size(131, 17);
			SaveAsLabel.TabIndex = 1;
			SaveAsLabel.TabStop = false;
			SaveAsLabel.Text = "&Save the New File As:";
			SaveAsLabel.TextAlign = ContentAlignment.TopCenter;
			// 
			// PasswordLabel
			// 
			PasswordLabel.AutoSize = true;
			PasswordLabel.Font = new Font("Segoe UI", 9.75F);
			PasswordLabel.Location = new Point(52, 222);
			PasswordLabel.Name = "PasswordLabel";
			PasswordLabel.Size = new Size(90, 17);
			PasswordLabel.TabIndex = 7;
			PasswordLabel.TabStop = false;
			PasswordLabel.Text = "File &Password:";
			PasswordLabel.TextAlign = ContentAlignment.TopCenter;
			// 
			// ConfirmLabel
			// 
			ConfirmLabel.AutoSize = true;
			ConfirmLabel.Font = new Font("Segoe UI", 9.75F);
			ConfirmLabel.Location = new Point(55, 281);
			ConfirmLabel.Name = "ConfirmLabel";
			ConfirmLabel.Size = new Size(117, 17);
			ConfirmLabel.TabIndex = 9;
			ConfirmLabel.TabStop = false;
			ConfirmLabel.Text = "&Confirm Password:";
			ConfirmLabel.TextAlign = ContentAlignment.TopCenter;
			// 
			// PasswordText
			// 
			PasswordText.Font = new Font("Segoe UI", 9.75F);
			PasswordText.Location = new Point(55, 242);
			PasswordText.Margin = new Padding(4, 4, 4, 4);
			PasswordText.Name = "PasswordText";
			PasswordText.Size = new Size(450, 25);
			PasswordText.TabIndex = 8;
			ttp.SetToolTip(PasswordText, "Enter the password for the file.");
			// 
			// ConfirmText
			// 
			ConfirmText.Font = new Font("Segoe UI", 9.75F);
			ConfirmText.Location = new Point(55, 302);
			ConfirmText.Margin = new Padding(4, 4, 4, 4);
			ConfirmText.Name = "ConfirmText";
			ConfirmText.Size = new Size(450, 25);
			ConfirmText.TabIndex = 10;
			ttp.SetToolTip(ConfirmText, "Confirm the password entered above.");
			// 
			// NameLabel
			// 
			NameLabel.AutoSize = true;
			NameLabel.Font = new Font("Segoe UI", 9.75F);
			NameLabel.Location = new Point(52, 160);
			NameLabel.Name = "NameLabel";
			NameLabel.Size = new Size(76, 17);
			NameLabel.TabIndex = 5;
			NameLabel.TabStop = false;
			NameLabel.Text = "Your &Name:";
			NameLabel.TextAlign = ContentAlignment.TopCenter;
			// 
			// NameText
			// 
			NameText.Font = new Font("Segoe UI", 9.75F);
			NameText.Location = new Point(55, 180);
			NameText.Margin = new Padding(4, 4, 4, 4);
			NameText.Name = "NameText";
			NameText.Size = new Size(450, 25);
			NameText.TabIndex = 6;
			ttp.SetToolTip(NameText, "Enter your name here.");
			// 
			// FileNameText
			// 
			FileNameText.Location = new Point(55, 110);
			FileNameText.Name = "FileNameText";
			FileNameText.PlaceholderText = "File Name";
			FileNameText.Size = new Size(420, 25);
			FileNameText.TabIndex = 2;
			ttp.SetToolTip(FileNameText, "Enter the path and name of the file, or click the Elipsis button to specify a save location.");
			// 
			// EllipseButton
			// 
			EllipseButton.Location = new Point(475, 109);
			EllipseButton.Name = "EllipseButton";
			EllipseButton.Size = new Size(30, 27);
			EllipseButton.TabIndex = 3;
			EllipseButton.Text = "...";
			EllipseButton.UseVisualStyleBackColor = true;
			// 
			// OkButton
			// 
			OkButton.BorderWidth = 1;
			OkButton.Checked = false;
			OkButton.HoverBorderColor = Color.Gray;
			OkButton.HoverDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			OkButton.HoverEndColor = Color.FromArgb(224, 224, 224);
			OkButton.HoverFont = new Font("Segoe UI", 9.75F);
			OkButton.HoverForeColor = Color.Black;
			OkButton.HoverStartColor = Color.FromArgb(218, 194, 204);
			OkButton.Image = Properties.Resources.Key;
			OkButton.ImageAlign = ContentAlignment.MiddleLeft;
			OkButton.Location = new Point(309, 350);
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
			OkButton.TabIndex = 12;
			OkButton.Text = "OK";
			OkButton.TextImageRelation = TextImageRelation.ImageBeforeText;
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
			CloseButton.Image = Properties.Resources.Cancel16;
			CloseButton.ImageAlign = ContentAlignment.MiddleLeft;
			CloseButton.Location = new Point(415, 350);
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
			CloseButton.TabIndex = 13;
			CloseButton.Text = "Cancel";
			CloseButton.TextImageRelation = TextImageRelation.ImageBeforeText;
			CloseButton.UseVisualStyleBackColor = true;
			// 
			// ErrorProvider
			// 
			ErrorProvider.ContainerControl = this;
			// 
			// DialogHeader
			// 
			DialogHeader.Dock = DockStyle.Top;
			DialogHeader.Location = new Point(0, 0);
			DialogHeader.Name = "DialogHeader";
			DialogHeader.Size = new Size(519, 77);
			DialogHeader.TabIndex = 0;
			DialogHeader.TabStop = false;
			// 
			// DividerLine
			// 
			DividerLine.BevelBottomColor = SystemColors.ControlLight;
			DividerLine.BevelTopColor = SystemColors.ControlDark;
			DividerLine.Direction = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			DividerLine.EndColor = Color.FromArgb(255, 128, 0);
			DividerLine.LineWidth = 3;
			DividerLine.Location = new Point(52, 142);
			DividerLine.Mode = Adaptive.Intelligence.Shared.UI.LineControlMode.Line;
			DividerLine.Name = "DividerLine";
			DividerLine.Orientation = Adaptive.Intelligence.Shared.UI.LineControlOrientation.Horizontal;
			DividerLine.Size = new Size(460, 3);
			DividerLine.StartColor = Color.DodgerBlue;
			DividerLine.TabIndex = 4;
			DividerLine.TabStop = false;
			// 
			// lineControl1
			// 
			lineControl1.BevelBottomColor = SystemColors.ControlLight;
			lineControl1.BevelTopColor = SystemColors.ControlDark;
			lineControl1.Direction = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			lineControl1.EndColor = Color.FromArgb(255, 128, 0);
			lineControl1.LineWidth = 3;
			lineControl1.Location = new Point(0, 336);
			lineControl1.Mode = Adaptive.Intelligence.Shared.UI.LineControlMode.Line;
			lineControl1.Name = "lineControl1";
			lineControl1.Orientation = Adaptive.Intelligence.Shared.UI.LineControlOrientation.Horizontal;
			lineControl1.Size = new Size(520, 3);
			lineControl1.StartColor = Color.DodgerBlue;
			lineControl1.TabIndex = 11;
			lineControl1.TabStop = false;
			// 
			// PwdImage
			// 
			PwdImage.Image = Properties.Resources.PasswordLock;
			PwdImage.Location = new Point(12, 231);
			PwdImage.Name = "PwdImage";
			PwdImage.Size = new Size(32, 32);
			PwdImage.TabIndex = 13;
			PwdImage.TabStop = false;
			// 
			// UserIdImage
			// 
			UserIdImage.Image = Properties.Resources.UserIDKeys;
			UserIdImage.Location = new Point(12, 169);
			UserIdImage.Name = "UserIdImage";
			UserIdImage.Size = new Size(32, 32);
			UserIdImage.TabIndex = 12;
			UserIdImage.TabStop = false;
			// 
			// NewFileDialog
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = CloseButton;
			ClientSize = new Size(519, 395);
			ControlBox = false;
			Controls.Add(PwdImage);
			Controls.Add(UserIdImage);
			Controls.Add(lineControl1);
			Controls.Add(DividerLine);
			Controls.Add(DialogHeader);
			Controls.Add(CloseButton);
			Controls.Add(OkButton);
			Controls.Add(EllipseButton);
			Controls.Add(FileNameText);
			Controls.Add(NameText);
			Controls.Add(NameLabel);
			Controls.Add(ConfirmText);
			Controls.Add(PasswordText);
			Controls.Add(ConfirmLabel);
			Controls.Add(PasswordLabel);
			Controls.Add(SaveAsLabel);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			KeyPreview = true;
			Name = "NewFileDialog";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Create New Security File";
			((System.ComponentModel.ISupportInitialize)ErrorProvider).EndInit();
			((System.ComponentModel.ISupportInitialize)PwdImage).EndInit();
			((System.ComponentModel.ISupportInitialize)UserIdImage).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Adaptive.Intelligence.Shared.UI.AdvancedLabel SaveAsLabel;
		private Adaptive.Intelligence.Shared.UI.AdvancedLabel PasswordLabel;
		private Adaptive.Intelligence.Shared.UI.AdvancedLabel ConfirmLabel;
		private Adaptive.Intelligence.Shared.UI.PasswordTextBox PasswordText;
		private Adaptive.Intelligence.Shared.UI.PasswordTextBox ConfirmText;
		private Adaptive.Intelligence.Shared.UI.AdvancedLabel NameLabel;
		private Adaptive.Intelligence.Shared.UI.PasswordTextBox NameText;
		private TextBox FileNameText;
		private Button EllipseButton;
		private Adaptive.Intelligence.Shared.UI.AIButton OkButton;
		private Adaptive.Intelligence.Shared.UI.AIButton CloseButton;
		private ToolTip ttp;
		private ErrorProvider ErrorProvider;
		private LoginDialogHeader DialogHeader;
		private Adaptive.Intelligence.Shared.UI.LineControl lineControl1;
		private Adaptive.Intelligence.Shared.UI.LineControl DividerLine;
		private PictureBox PwdImage;
		private PictureBox UserIdImage;
	}
}