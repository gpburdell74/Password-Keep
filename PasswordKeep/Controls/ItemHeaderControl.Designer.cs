using Adaptive.Intelligence.Shared.UI;

namespace PasswordKeep.UI
{
	partial class ItemHeaderControl
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
			ItemImage = new PictureBox();
			ContentPanel = new Panel();
			RatingDisplay = new RatingControl();
			TitleLabel = new AdvancedLabel();
			((System.ComponentModel.ISupportInitialize)ItemImage).BeginInit();
			ContentPanel.SuspendLayout();
			SuspendLayout();
			// 
			// ItemImage
			// 
			ItemImage.Dock = DockStyle.Left;
			ItemImage.Location = new Point(0, 0);
			ItemImage.Name = "ItemImage";
			ItemImage.Size = new Size(64, 78);
			ItemImage.SizeMode = PictureBoxSizeMode.Zoom;
			ItemImage.TabIndex = 3;
			ItemImage.TabStop = false;
			ItemImage.Visible = false;
			// 
			// ContentPanel
			// 
			ContentPanel.Controls.Add(RatingDisplay);
			ContentPanel.Controls.Add(TitleLabel);
			ContentPanel.Dock = DockStyle.Top;
			ContentPanel.Location = new Point(64, 0);
			ContentPanel.Name = "ContentPanel";
			ContentPanel.Size = new Size(314, 79);
			ContentPanel.TabIndex = 5;
			// 
			// RatingDisplay
			// 
			RatingDisplay.Font = new Font("Segoe UI", 9.75F);
			RatingDisplay.Location = new Point(6, 35);
			RatingDisplay.MaximumSize = new Size(250, 42);
			RatingDisplay.MinimumSize = new Size(170, 42);
			RatingDisplay.Name = "RatingDisplay";
			RatingDisplay.Padding = new Padding(5);
			RatingDisplay.Rating = 1;
			RatingDisplay.Size = new Size(250, 42);
			RatingDisplay.TabIndex = 6;
			// 
			// TitleLabel
			// 
			TitleLabel.Dock = DockStyle.Top;
			TitleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			TitleLabel.Location = new Point(0, 0);
			TitleLabel.Name = "TitleLabel";
			TitleLabel.Shadow = true;
			TitleLabel.Size = new Size(314, 32);
			TitleLabel.TabIndex = 5;
			TitleLabel.TabStop = false;
			TitleLabel.Text = "Secure Data Entry";
			TitleLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// ItemHeaderControl
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			Controls.Add(ContentPanel);
			Controls.Add(ItemImage);
			ForeColor = Color.Black;
			Name = "ItemHeaderControl";
			Size = new Size(378, 78);
			((System.ComponentModel.ISupportInitialize)ItemImage).EndInit();
			ContentPanel.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private PictureBox ItemImage;
		private Panel ContentPanel;
		private AdvancedLabel TitleLabel;
		private RatingControl RatingDisplay;
	}
}
