namespace PasswordKeep.UI
{
	partial class AddEditRemoveToolbar
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
			AddButton = new Adaptive.Intelligence.Shared.UI.AIButton();
			EditButton = new Adaptive.Intelligence.Shared.UI.AIButton();
			RemoveButton = new Adaptive.Intelligence.Shared.UI.AIButton();
			SuspendLayout();
			// 
			// AddButton
			// 
			AddButton.BorderWidth = 1;
			AddButton.Checked = false;
			AddButton.HoverBorderColor = Color.Gray;
			AddButton.HoverDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			AddButton.HoverEndColor = Color.FromArgb(224, 224, 224);
			AddButton.HoverFont = new Font("Segoe UI", 9.75F);
			AddButton.HoverForeColor = Color.Black;
			AddButton.HoverStartColor = Color.FromArgb(218, 194, 204);
			AddButton.Image = Properties.Resources.New16;
			AddButton.ImageAlign = ContentAlignment.MiddleLeft;
			AddButton.Location = new Point(3, 3);
			AddButton.Name = "AddButton";
			AddButton.NormalBorderColor = Color.Gray;
			AddButton.NormalDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			AddButton.NormalEndColor = Color.Silver;
			AddButton.NormalFont = new Font("Segoe UI", 9.75F);
			AddButton.NormalForeColor = Color.Black;
			AddButton.NormalStartColor = Color.FromArgb(248, 248, 248);
			AddButton.PressedBorderColor = Color.Gray;
			AddButton.PressedDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			AddButton.PressedEndColor = Color.FromArgb(174, 45, 61);
			AddButton.PressedFont = new Font("Segoe UI", 9.75F);
			AddButton.PressedForeColor = Color.White;
			AddButton.PressedStartColor = Color.Gray;
			AddButton.Size = new Size(100, 25);
			AddButton.TabIndex = 0;
			AddButton.Text = "&Add Entry";
			AddButton.TextImageRelation = TextImageRelation.ImageBeforeText;
			AddButton.UseVisualStyleBackColor = true;
			// 
			// EditButton
			// 
			EditButton.BorderWidth = 1;
			EditButton.Checked = false;
			EditButton.Enabled = false;
			EditButton.HoverBorderColor = Color.Gray;
			EditButton.HoverDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			EditButton.HoverEndColor = Color.FromArgb(224, 224, 224);
			EditButton.HoverFont = new Font("Segoe UI", 9.75F);
			EditButton.HoverForeColor = Color.Black;
			EditButton.HoverStartColor = Color.FromArgb(218, 194, 204);
			EditButton.Image = Properties.Resources.Edit16;
			EditButton.ImageAlign = ContentAlignment.MiddleLeft;
			EditButton.Location = new Point(109, 3);
			EditButton.Name = "EditButton";
			EditButton.NormalBorderColor = Color.Gray;
			EditButton.NormalDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			EditButton.NormalEndColor = Color.Silver;
			EditButton.NormalFont = new Font("Segoe UI", 9.75F);
			EditButton.NormalForeColor = Color.Black;
			EditButton.NormalStartColor = Color.FromArgb(248, 248, 248);
			EditButton.PressedBorderColor = Color.Gray;
			EditButton.PressedDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			EditButton.PressedEndColor = Color.FromArgb(174, 45, 61);
			EditButton.PressedFont = new Font("Segoe UI", 9.75F);
			EditButton.PressedForeColor = Color.White;
			EditButton.PressedStartColor = Color.Gray;
			EditButton.Size = new Size(100, 25);
			EditButton.TabIndex = 1;
			EditButton.Text = "&Edit Entry";
			EditButton.TextImageRelation = TextImageRelation.ImageBeforeText;
			EditButton.UseVisualStyleBackColor = true;
			// 
			// RemoveButton
			// 
			RemoveButton.BorderWidth = 1;
			RemoveButton.Checked = false;
			RemoveButton.Enabled = false;
			RemoveButton.HoverBorderColor = Color.Gray;
			RemoveButton.HoverDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			RemoveButton.HoverEndColor = Color.FromArgb(224, 224, 224);
			RemoveButton.HoverFont = new Font("Segoe UI", 9.75F);
			RemoveButton.HoverForeColor = Color.Black;
			RemoveButton.HoverStartColor = Color.FromArgb(218, 194, 204);
			RemoveButton.Image = Properties.Resources.Delete16;
			RemoveButton.ImageAlign = ContentAlignment.MiddleLeft;
			RemoveButton.Location = new Point(215, 3);
			RemoveButton.Name = "RemoveButton";
			RemoveButton.NormalBorderColor = Color.Gray;
			RemoveButton.NormalDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			RemoveButton.NormalEndColor = Color.Silver;
			RemoveButton.NormalFont = new Font("Segoe UI", 9.75F);
			RemoveButton.NormalForeColor = Color.Black;
			RemoveButton.NormalStartColor = Color.FromArgb(248, 248, 248);
			RemoveButton.PressedBorderColor = Color.Gray;
			RemoveButton.PressedDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			RemoveButton.PressedEndColor = Color.FromArgb(174, 45, 61);
			RemoveButton.PressedFont = new Font("Segoe UI", 9.75F);
			RemoveButton.PressedForeColor = Color.White;
			RemoveButton.PressedStartColor = Color.Gray;
			RemoveButton.Size = new Size(112, 25);
			RemoveButton.TabIndex = 2;
			RemoveButton.Text = "&Remove Entry";
			RemoveButton.TextImageRelation = TextImageRelation.ImageBeforeText;
			RemoveButton.UseVisualStyleBackColor = true;
			// 
			// AddEditRemoveToolbar
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(RemoveButton);
			Controls.Add(EditButton);
			Controls.Add(AddButton);
			Margin = new Padding(3);
			MaximumSize = new Size(0, 32);
			MinimumSize = new Size(332, 32);
			Name = "AddEditRemoveToolbar";
			Size = new Size(332, 32);
			ResumeLayout(false);
		}

		#endregion

		private Adaptive.Intelligence.Shared.UI.AIButton AddButton;
		private Adaptive.Intelligence.Shared.UI.AIButton EditButton;
		private Adaptive.Intelligence.Shared.UI.AIButton RemoveButton;
	}
}
