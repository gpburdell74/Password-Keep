namespace PasswordKeep.UI
{
	partial class AddGeneralDataDialog
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
			NameLabel = new Adaptive.Intelligence.Shared.UI.AdvancedLabel();
			DescLabel = new Adaptive.Intelligence.Shared.UI.AdvancedLabel();
			UrlLabel = new Adaptive.Intelligence.Shared.UI.AdvancedLabel();
			UserIdLabel = new Adaptive.Intelligence.Shared.UI.AdvancedLabel();
			PasswordLabel = new Adaptive.Intelligence.Shared.UI.AdvancedLabel();
			panel3 = new Panel();
			panel4 = new Panel();
			UserIdText = new Adaptive.Intelligence.Shared.UI.PasswordTextBox();
			PasswordText = new Adaptive.Intelligence.Shared.UI.PasswordTextBox();
			NameText = new TextBox();
			DescText = new TextBox();
			UrlText = new TextBox();
			ButtonPanel = new Panel();
			ButtonLine = new Adaptive.Intelligence.Shared.UI.LineControl();
			aiButton3 = new Adaptive.Intelligence.Shared.UI.AIButton();
			ItemHeader = new ItemHeaderControl();
			sectionTitleHeader1 = new Adaptive.Intelligence.Shared.UI.SectionTitleHeader();
			SecurityHeader = new Adaptive.Intelligence.Shared.UI.SectionTitleHeader();
			NextDueLabel = new Adaptive.Intelligence.Shared.UI.AdvancedLabel();
			LastPaidLabel = new Adaptive.Intelligence.Shared.UI.AdvancedLabel();
			MinDueLabel = new Adaptive.Intelligence.Shared.UI.AdvancedLabel();
			AvailableLabel = new Adaptive.Intelligence.Shared.UI.AdvancedLabel();
			CurrentText = new TextBox();
			AvailableText = new TextBox();
			NextDateLabel = new DateTimePicker();
			LastPaidDate = new DateTimePicker();
			MinDueText = new TextBox();
			advancedLabel5 = new Adaptive.Intelligence.Shared.UI.AdvancedLabel();
			ButtonAlignPanel = new Panel();
			CloseButton = new Adaptive.Intelligence.Shared.UI.AIButton();
			SaveButton = new Adaptive.Intelligence.Shared.UI.AIButton();
			Seperator = new Panel();
			panel3.SuspendLayout();
			panel4.SuspendLayout();
			ButtonPanel.SuspendLayout();
			ButtonAlignPanel.SuspendLayout();
			SuspendLayout();
			// 
			// NameLabel
			// 
			NameLabel.Font = new Font("Segoe UI", 9.75F);
			NameLabel.ForeColor = Color.DimGray;
			NameLabel.Location = new Point(0, 82);
			NameLabel.Name = "NameLabel";
			NameLabel.Size = new Size(100, 25);
			NameLabel.TabIndex = 0;
			NameLabel.TabStop = false;
			NameLabel.Text = "&name:";
			NameLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// DescLabel
			// 
			DescLabel.Font = new Font("Segoe UI", 9.75F);
			DescLabel.ForeColor = Color.DimGray;
			DescLabel.Location = new Point(0, 113);
			DescLabel.Name = "DescLabel";
			DescLabel.Size = new Size(100, 25);
			DescLabel.TabIndex = 2;
			DescLabel.TabStop = false;
			DescLabel.Text = "&description:";
			DescLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// UrlLabel
			// 
			UrlLabel.Font = new Font("Segoe UI", 9.75F);
			UrlLabel.ForeColor = Color.DimGray;
			UrlLabel.Location = new Point(0, 144);
			UrlLabel.Name = "UrlLabel";
			UrlLabel.Size = new Size(100, 25);
			UrlLabel.TabIndex = 4;
			UrlLabel.TabStop = false;
			UrlLabel.Text = "url / &address:";
			UrlLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// UserIdLabel
			// 
			UserIdLabel.Font = new Font("Segoe UI", 9.75F);
			UserIdLabel.ForeColor = Color.DimGray;
			UserIdLabel.Location = new Point(0, 176);
			UserIdLabel.Name = "UserIdLabel";
			UserIdLabel.Size = new Size(100, 25);
			UserIdLabel.TabIndex = 6;
			UserIdLabel.TabStop = false;
			UserIdLabel.Text = "&user name:";
			UserIdLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// PasswordLabel
			// 
			PasswordLabel.Font = new Font("Segoe UI", 9.75F);
			PasswordLabel.ForeColor = Color.DimGray;
			PasswordLabel.Location = new Point(0, 209);
			PasswordLabel.Name = "PasswordLabel";
			PasswordLabel.Size = new Size(100, 25);
			PasswordLabel.TabIndex = 8;
			PasswordLabel.TabStop = false;
			PasswordLabel.Text = "&password:";
			PasswordLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// panel3
			// 
			panel3.Controls.Add(NextDueLabel);
			panel3.Controls.Add(LastPaidLabel);
			panel3.Controls.Add(MinDueLabel);
			panel3.Controls.Add(AvailableLabel);
			panel3.Controls.Add(CurrentText);
			panel3.Controls.Add(AvailableText);
			panel3.Controls.Add(NextDateLabel);
			panel3.Controls.Add(LastPaidDate);
			panel3.Controls.Add(MinDueText);
			panel3.Controls.Add(advancedLabel5);
			panel3.Controls.Add(sectionTitleHeader1);
			panel3.Location = new Point(13, 248);
			panel3.Name = "panel3";
			panel3.Size = new Size(412, 185);
			panel3.TabIndex = 10;
			// 
			// panel4
			// 
			panel4.Controls.Add(SecurityHeader);
			panel4.Controls.Add(aiButton3);
			panel4.Location = new Point(13, 439);
			panel4.Name = "panel4";
			panel4.Size = new Size(412, 136);
			panel4.TabIndex = 11;
			// 
			// UserIdText
			// 
			UserIdText.Font = new Font("Segoe UI", 9.75F);
			UserIdText.Location = new Point(100, 176);
			UserIdText.Margin = new Padding(4, 4, 4, 4);
			UserIdText.Name = "UserIdText";
			UserIdText.PlaceholderText = "(User ID or Login Name)";
			UserIdText.Size = new Size(325, 25);
			UserIdText.TabIndex = 7;
			// 
			// PasswordText
			// 
			PasswordText.Font = new Font("Segoe UI", 9.75F);
			PasswordText.Location = new Point(100, 209);
			PasswordText.Margin = new Padding(4, 4, 4, 4);
			PasswordText.Name = "PasswordText";
			PasswordText.PlaceholderText = "(Password)";
			PasswordText.Size = new Size(325, 25);
			PasswordText.TabIndex = 9;
			// 
			// NameText
			// 
			NameText.Location = new Point(100, 82);
			NameText.Name = "NameText";
			NameText.Size = new Size(325, 25);
			NameText.TabIndex = 1;
			// 
			// DescText
			// 
			DescText.Location = new Point(100, 113);
			DescText.Name = "DescText";
			DescText.Size = new Size(325, 25);
			DescText.TabIndex = 3;
			// 
			// UrlText
			// 
			UrlText.Location = new Point(100, 144);
			UrlText.Name = "UrlText";
			UrlText.Size = new Size(325, 25);
			UrlText.TabIndex = 5;
			// 
			// ButtonPanel
			// 
			ButtonPanel.Controls.Add(ButtonAlignPanel);
			ButtonPanel.Controls.Add(ButtonLine);
			ButtonPanel.Dock = DockStyle.Bottom;
			ButtonPanel.Location = new Point(0, 583);
			ButtonPanel.Name = "ButtonPanel";
			ButtonPanel.Size = new Size(432, 46);
			ButtonPanel.TabIndex = 12;
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
			ButtonLine.Size = new Size(432, 2);
			ButtonLine.StartColor = Color.DodgerBlue;
			ButtonLine.TabIndex = 0;
			// 
			// aiButton3
			// 
			aiButton3.BorderWidth = 1;
			aiButton3.Checked = false;
			aiButton3.HoverBorderColor = Color.Gray;
			aiButton3.HoverDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			aiButton3.HoverEndColor = Color.FromArgb(224, 224, 224);
			aiButton3.HoverFont = new Font("Segoe UI", 9.75F);
			aiButton3.HoverForeColor = Color.Black;
			aiButton3.HoverStartColor = Color.FromArgb(218, 194, 204);
			aiButton3.Location = new Point(122, 53);
			aiButton3.Name = "aiButton3";
			aiButton3.NormalBorderColor = Color.Gray;
			aiButton3.NormalDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			aiButton3.NormalEndColor = Color.Silver;
			aiButton3.NormalFont = new Font("Segoe UI", 9.75F);
			aiButton3.NormalForeColor = Color.Black;
			aiButton3.NormalStartColor = Color.FromArgb(248, 248, 248);
			aiButton3.PressedBorderColor = Color.Gray;
			aiButton3.PressedDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			aiButton3.PressedEndColor = Color.FromArgb(174, 45, 61);
			aiButton3.PressedFont = new Font("Segoe UI", 9.75F);
			aiButton3.PressedForeColor = Color.White;
			aiButton3.PressedStartColor = Color.Gray;
			aiButton3.Size = new Size(75, 23);
			aiButton3.TabIndex = 24;
			aiButton3.Text = "aiButton3";
			aiButton3.UseVisualStyleBackColor = true;
			// 
			// ItemHeader
			// 
			ItemHeader.BackColor = Color.White;
			ItemHeader.Dock = DockStyle.Top;
			ItemHeader.Font = new Font("Segoe UI", 9.75F);
			ItemHeader.ForeColor = Color.Black;
			ItemHeader.Location = new Point(0, 0);
			ItemHeader.Margin = new Padding(4, 4, 4, 4);
			ItemHeader.Name = "ItemHeader";
			ItemHeader.Size = new Size(432, 78);
			ItemHeader.TabIndex = 0;
			// 
			// sectionTitleHeader1
			// 
			sectionTitleHeader1.Location = new Point(0, 4);
			sectionTitleHeader1.Margin = new Padding(4);
			sectionTitleHeader1.Name = "sectionTitleHeader1";
			sectionTitleHeader1.Size = new Size(412, 18);
			sectionTitleHeader1.TabIndex = 8;
			sectionTitleHeader1.Text = "Financial Data:";
			// 
			// SecurityHeader
			// 
			SecurityHeader.Dock = DockStyle.Top;
			SecurityHeader.Location = new Point(0, 0);
			SecurityHeader.Margin = new Padding(4);
			SecurityHeader.Name = "SecurityHeader";
			SecurityHeader.Size = new Size(412, 18);
			SecurityHeader.TabIndex = 9;
			SecurityHeader.Text = "Security Questions";
			// 
			// NextDueLabel
			// 
			NextDueLabel.Font = new Font("Segoe UI", 9.75F);
			NextDueLabel.ForeColor = Color.DimGray;
			NextDueLabel.Location = new Point(5, 153);
			NextDueLabel.Name = "NextDueLabel";
			NextDueLabel.Size = new Size(100, 25);
			NextDueLabel.TabIndex = 38;
			NextDueLabel.TabStop = false;
			NextDueLabel.Text = "ne&xt due date:";
			NextDueLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// LastPaidLabel
			// 
			LastPaidLabel.Font = new Font("Segoe UI", 9.75F);
			LastPaidLabel.ForeColor = Color.DimGray;
			LastPaidLabel.Location = new Point(5, 122);
			LastPaidLabel.Name = "LastPaidLabel";
			LastPaidLabel.Size = new Size(100, 25);
			LastPaidLabel.TabIndex = 37;
			LastPaidLabel.TabStop = false;
			LastPaidLabel.Text = "&last paid:";
			LastPaidLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// MinDueLabel
			// 
			MinDueLabel.Font = new Font("Segoe UI", 9.75F);
			MinDueLabel.ForeColor = Color.DimGray;
			MinDueLabel.Location = new Point(5, 91);
			MinDueLabel.Name = "MinDueLabel";
			MinDueLabel.Size = new Size(100, 25);
			MinDueLabel.TabIndex = 36;
			MinDueLabel.TabStop = false;
			MinDueLabel.Text = "minimum &due:";
			MinDueLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// AvailableLabel
			// 
			AvailableLabel.Font = new Font("Segoe UI", 9.75F);
			AvailableLabel.ForeColor = Color.DimGray;
			AvailableLabel.Location = new Point(5, 60);
			AvailableLabel.Name = "AvailableLabel";
			AvailableLabel.Size = new Size(100, 25);
			AvailableLabel.TabIndex = 35;
			AvailableLabel.TabStop = false;
			AvailableLabel.Text = "avai&lable:";
			AvailableLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// CurrentText
			// 
			CurrentText.Location = new Point(105, 29);
			CurrentText.Name = "CurrentText";
			CurrentText.Size = new Size(300, 25);
			CurrentText.TabIndex = 34;
			// 
			// AvailableText
			// 
			AvailableText.Location = new Point(105, 60);
			AvailableText.Name = "AvailableText";
			AvailableText.Size = new Size(300, 25);
			AvailableText.TabIndex = 33;
			// 
			// NextDateLabel
			// 
			NextDateLabel.Location = new Point(105, 153);
			NextDateLabel.Name = "NextDateLabel";
			NextDateLabel.Size = new Size(300, 25);
			NextDateLabel.TabIndex = 32;
			// 
			// LastPaidDate
			// 
			LastPaidDate.Location = new Point(105, 122);
			LastPaidDate.Name = "LastPaidDate";
			LastPaidDate.Size = new Size(300, 25);
			LastPaidDate.TabIndex = 31;
			// 
			// MinDueText
			// 
			MinDueText.Location = new Point(105, 91);
			MinDueText.Name = "MinDueText";
			MinDueText.Size = new Size(300, 25);
			MinDueText.TabIndex = 30;
			// 
			// advancedLabel5
			// 
			advancedLabel5.Font = new Font("Segoe UI", 9.75F);
			advancedLabel5.ForeColor = Color.DimGray;
			advancedLabel5.Location = new Point(5, 29);
			advancedLabel5.Name = "advancedLabel5";
			advancedLabel5.Size = new Size(100, 25);
			advancedLabel5.TabIndex = 29;
			advancedLabel5.TabStop = false;
			advancedLabel5.Text = "current &value:";
			advancedLabel5.TextAlign = ContentAlignment.MiddleRight;
			// 
			// ButtonAlignPanel
			// 
			ButtonAlignPanel.Controls.Add(SaveButton);
			ButtonAlignPanel.Controls.Add(Seperator);
			ButtonAlignPanel.Controls.Add(CloseButton);
			ButtonAlignPanel.Dock = DockStyle.Right;
			ButtonAlignPanel.Location = new Point(207, 2);
			ButtonAlignPanel.Name = "ButtonAlignPanel";
			ButtonAlignPanel.Padding = new Padding(0, 5, 5, 5);
			ButtonAlignPanel.Size = new Size(225, 44);
			ButtonAlignPanel.TabIndex = 3;
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
			// AddGeneralDataDialog
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(432, 629);
			ControlBox = false;
			Controls.Add(ItemHeader);
			Controls.Add(ButtonPanel);
			Controls.Add(UrlText);
			Controls.Add(DescText);
			Controls.Add(NameText);
			Controls.Add(PasswordText);
			Controls.Add(UserIdText);
			Controls.Add(panel4);
			Controls.Add(panel3);
			Controls.Add(PasswordLabel);
			Controls.Add(UserIdLabel);
			Controls.Add(UrlLabel);
			Controls.Add(DescLabel);
			Controls.Add(NameLabel);
			ForeColor = Color.Black;
			FormBorderStyle = FormBorderStyle.FixedDialog;
			KeyPreview = true;
			Margin = new Padding(4, 5, 4, 5);
			Name = "AddGeneralDataDialog";
			StartPosition = FormStartPosition.CenterScreen;
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel4.ResumeLayout(false);
			ButtonPanel.ResumeLayout(false);
			ButtonAlignPanel.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Adaptive.Intelligence.Shared.UI.AdvancedLabel NameLabel;
		private Adaptive.Intelligence.Shared.UI.AdvancedLabel DescLabel;
		private Adaptive.Intelligence.Shared.UI.AdvancedLabel UrlLabel;
		private Adaptive.Intelligence.Shared.UI.AdvancedLabel UserIdLabel;
		private Adaptive.Intelligence.Shared.UI.AdvancedLabel PasswordLabel;
		private Panel panel3;
		private Panel panel4;
		private Adaptive.Intelligence.Shared.UI.PasswordTextBox UserIdText;
		private Adaptive.Intelligence.Shared.UI.PasswordTextBox PasswordText;
		private TextBox NameText;
		private TextBox DescText;
		private TextBox UrlText;
		private Panel ButtonPanel;
		private Adaptive.Intelligence.Shared.UI.LineControl ButtonLine;
		private Adaptive.Intelligence.Shared.UI.AIButton aiButton3;
		private ItemHeaderControl ItemHeader;
		private Adaptive.Intelligence.Shared.UI.SectionTitleHeader sectionTitleHeader1;
		private Adaptive.Intelligence.Shared.UI.SectionTitleHeader SecurityHeader;
		private Adaptive.Intelligence.Shared.UI.AdvancedLabel NextDueLabel;
		private Adaptive.Intelligence.Shared.UI.AdvancedLabel LastPaidLabel;
		private Adaptive.Intelligence.Shared.UI.AdvancedLabel MinDueLabel;
		private Adaptive.Intelligence.Shared.UI.AdvancedLabel AvailableLabel;
		private TextBox CurrentText;
		private TextBox AvailableText;
		private DateTimePicker NextDateLabel;
		private DateTimePicker LastPaidDate;
		private TextBox MinDueText;
		private Adaptive.Intelligence.Shared.UI.AdvancedLabel advancedLabel5;
		private Panel ButtonAlignPanel;
		private Adaptive.Intelligence.Shared.UI.AIButton CloseButton;
		private Adaptive.Intelligence.Shared.UI.AIButton SaveButton;
		private Panel Seperator;
	}
}