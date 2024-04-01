using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace PasswordKeep.UI
{
	/// <summary>
	/// Provides a header control for the login dialog.
	/// </summary>
	/// <seealso cref="System.Windows.Forms.UserControl" />
	public sealed class LoginDialogHeader : UserControl
	{
		#region Private Member Declarations

		private Container components;
		private Color _startColor = Color.FromArgb(255, 0, 79, 210);
		private Color _endColor = Color.FromArgb(255, 136, 181, 255);

		#endregion

		#region Constructor / Dispose Methods		
		/// <summary>
		/// Initializes a new instance of the <see cref="LoginDialogHeader"/> class.
		/// </summary>
		/// <remarks>
		/// This is the default constructor.
		/// </remarks>
		public LoginDialogHeader()
		{
			InitializeComponent();
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			SetStyle(ControlStyles.ResizeRedraw, value: true);
			SetStyle(ControlStyles.Selectable, value: false);
			SetStyle(ControlStyles.UserPaint, value: true);
		}
		/// <summary>
		/// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control" /> and its child controls and optionally releases the managed resources.
		/// </summary>
		/// <param name="disposing"><see langword="true" /> to release both managed and unmanaged resources; <see langword="false" /> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (!IsDisposed && disposing)
			{
				components?.Dispose();
			}

			components = null;
			base.Dispose(disposing);
		}
		#endregion

		#region Protected Method Overrides		
		/// <summary>
		/// Paints the background of the control.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
			DrawInitialBackground(e.Graphics);
			DrawBottomBar(e.Graphics);
		}
		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
		protected override void OnPaint(PaintEventArgs e)
		{
			WriteTitleText(e.Graphics);
		}
		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Invalidate();
		}
		#endregion

		#region Private Methods / Functions		
		/// <summary>
		/// Initializes the component.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		/// <summary>
		/// Draws the initial background.
		/// </summary>
		/// <param name="g">The g.</param>
		private void DrawInitialBackground(Graphics g)
		{
			int width = (int)((float)Width / 4f * 3f);
			int height = Height;

			Rectangle mainRectangle = new Rectangle(0, 0, width + 1, height);
			Rectangle lineRect = new Rectangle(width - 1, 0, Width - width + 1, Height);

			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(lineRect, _endColor, _startColor, LinearGradientMode.Horizontal);
			g.FillRectangle(linearGradientBrush, lineRect);
			linearGradientBrush.Dispose();

			linearGradientBrush = new LinearGradientBrush(mainRectangle, _startColor, _endColor, LinearGradientMode.Horizontal);
			g.FillRectangle(linearGradientBrush, mainRectangle);
			linearGradientBrush.Dispose();
		}
		/// <summary>
		/// Draws the bottom bar.
		/// </summary>
		/// <param name="g">The g.</param>
		private void DrawBottomBar(Graphics g)
		{
			Color color = Color.FromArgb(255, 0, 79, 210);
			Color color2 = Color.FromArgb(255, 240, 143, 13);
			int num = (int)((float)base.Width / 2f);
			int num2 = 8;
			Rectangle rect = new Rectangle(0, base.Height - num2, num + 1, num2);
			Rectangle rect2 = new Rectangle(num, base.Height - num2, base.Width - num, num2);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect2, color2, color, LinearGradientMode.Horizontal);
			g.FillRectangle(linearGradientBrush, rect2);
			linearGradientBrush.Dispose();
			linearGradientBrush = new LinearGradientBrush(rect, color, color2, LinearGradientMode.Horizontal);
			g.FillRectangle(linearGradientBrush, rect);
			linearGradientBrush.Dispose();
		}
		/// <summary>
		/// Writes the title text.
		/// </summary>
		/// <param name="g">The g.</param>
		private void WriteTitleText(Graphics g)
		{
			SolidBrush solidBrush = new SolidBrush(Color.White);
			Color color = Color.FromArgb(100, 128, 128, 128);
			Color color2 = Color.FromArgb(70, 128, 128, 128);
			SolidBrush brush = new SolidBrush(color);
			SolidBrush brush2 = new SolidBrush(color2);
			g.CompositingQuality = CompositingQuality.HighQuality;
			g.InterpolationMode = InterpolationMode.HighQualityBilinear;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			Font font = new Font("OCR A Extended", 24f, FontStyle.Bold);
			SizeF sizeF = g.MeasureString("PASSWORD KEEP", font);
			int num = (int)((float)base.Width / 2f - (float)(int)(sizeF.Width / 2f));
			g.DrawString("PASSWORD KEEP", font, brush2, num + 2, 17f);
			g.DrawString("PASSWORD KEEP", font, brush, num + 1, 16f);
			g.DrawString("PASSWORD KEEP", font, solidBrush, num, 15f);
			solidBrush.Dispose();
			font.Dispose();
		}
		#endregion
	}
}