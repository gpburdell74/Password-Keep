using Adaptive.Intelligence.Shared.UI;
using System.ComponentModel;

namespace PasswordKeep.UI
{
	/// <summary>
	/// Provides a standard header dialog for Add/Edit item dialogs.
	/// </summary>
	/// <seealso cref="Adaptive.Intelligence.Shared.UI.AdaptiveControlBase" />
	public partial class ItemHeaderControl : AdaptiveControlBase
	{
		#region Private Member Declarations		
		/// <summary>
		/// The generic title value.
		/// </summary>
		private const string GenericTitle = "Secure Data Entry";

		/// <summary>
		/// The image or icon to display.
		/// </summary>
		private Image? _image = null;
		/// <summary>
		/// The name of the entry.
		/// </summary>
		private string? _name;
		/// <summary>
		/// The rating for the entry.
		/// </summary>
		private int _rating = 0;
		#endregion

		#region Constructor / Dispose Methods
		/// <summary>
		/// Initializes a new instance of the <see cref="ItemHeaderControl"/> class.
		/// </summary>
		/// <remarks>
		/// This is the default constructor.
		/// </remarks>
		public ItemHeaderControl()
		{
			InitializeComponent();
		}
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (!IsDisposed && disposing)
			{
				components?.Dispose();
			}

			_image = null;
			_name = null;
			components = null;
			base.Dispose(disposing);
		}
		#endregion

		#region Public Properties		
		/// <summary>
		/// Gets or sets the reference to the image to be displayed.
		/// </summary>
		/// <value>
		/// The <see cref="Image"/> associated with the item, or <b>null</b>.
		/// </value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Image? Image
		{
			get => _image;

			set
			{
				// Clear old memory.
				_image?.Dispose();
				_image = null;

				if (value == null)
				{
					ItemImage.Visible = false;
				}
				else
				{
					_image = value;
					ItemImage.Image = value;
					ItemImage.Visible = true;
				}
				Invalidate();
			}
		}
		/// <summary>
		/// Gets or sets the name of the item being represented/
		/// </summary>
		/// <value>
		/// A string containing the name of the item being represented.
		/// </value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string? ItemName
		{
			get => _name;
			set
			{
				_name = value;
				if (string.IsNullOrEmpty(value))
					TitleLabel.Text = GenericTitle;
				else
					TitleLabel.Text = _name;
				Invalidate();
			}
		}
		/// <summary>
		/// Gets or sets the rating value.
		/// </summary>
		/// <value>
		/// An integer specifying the rating value in the range zero (0) to five (5).
		/// </value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Rating
		{
			get => RatingDisplay.Rating;
			set
			{
				RatingDisplay.Rating = value;
				Invalidate();
			}

		}
		#endregion
	}
}
