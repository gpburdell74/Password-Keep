namespace PasswordKeep.UI
{ 
	partial class UrlEditDialog
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
			UrlText = new TextBox();
			SaveButton = new Adaptive.Intelligence.Shared.UI.AIButton();
			CloseButton = new Adaptive.Intelligence.Shared.UI.AIButton();
			SuspendLayout();
			// 
			// UrlText
			// 
			UrlText.Location = new Point(5, 5);
			UrlText.Name = "UrlText";
			UrlText.Size = new Size(400, 25);
			UrlText.TabIndex = 0;
			// 
			// SaveButton
			// 
			SaveButton.BorderWidth = 1;
			SaveButton.Checked = false;
			SaveButton.HoverBorderColor = Color.Gray;
			SaveButton.HoverDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			SaveButton.HoverEndColor = Color.FromArgb(224, 224, 224);
			SaveButton.HoverFont = new Font("Segoe UI", 9.75F);
			SaveButton.HoverForeColor = Color.Black;
			SaveButton.HoverStartColor = Color.FromArgb(218, 194, 204);
			SaveButton.Location = new Point(406, 5);
			SaveButton.Name = "SaveButton";
			SaveButton.NormalBorderColor = Color.Gray;
			SaveButton.NormalDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			SaveButton.NormalEndColor = Color.Silver;
			SaveButton.NormalFont = new Font("Segoe UI", 9.75F);
			SaveButton.NormalForeColor = Color.Black;
			SaveButton.NormalStartColor = Color.FromArgb(248, 248, 248);
			SaveButton.PressedBorderColor = Color.Gray;
			SaveButton.PressedDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			SaveButton.PressedEndColor = Color.FromArgb(174, 45, 61);
			SaveButton.PressedFont = new Font("Segoe UI", 9.75F);
			SaveButton.PressedForeColor = Color.White;
			SaveButton.PressedStartColor = Color.Gray;
			SaveButton.Size = new Size(40, 25);
			SaveButton.TabIndex = 1;
			SaveButton.Text = "Save";
			SaveButton.UseVisualStyleBackColor = true;
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
			CloseButton.Location = new Point(445, 5);
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
			CloseButton.Size = new Size(50, 25);
			CloseButton.TabIndex = 2;
			CloseButton.Text = "Cancel";
			CloseButton.UseVisualStyleBackColor = true;
			// 
			// UrlEditDialog
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = CloseButton;
			ClientSize = new Size(501, 35);
			ControlBox = false;
			Controls.Add(CloseButton);
			Controls.Add(SaveButton);
			Controls.Add(UrlText);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			KeyPreview = true;
			Name = "UrlEditDialog";
			StartPosition = FormStartPosition.CenterScreen;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox UrlText;
		private Adaptive.Intelligence.Shared.UI.AIButton SaveButton;
		private Adaptive.Intelligence.Shared.UI.AIButton CloseButton;
	}
}