using Adaptive.Intelligence.Shared.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordKeep.UI
{
	public partial class UrlEditDialog : AdaptiveDialogBase
	{
		public UrlEditDialog()
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

			components = null;
			base.Dispose(disposing);
		}
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string UrlValue
		{
			get => UrlText.Text;
			set
			{
				UrlText.Text = value; 
				Invalidate();
			}
		}
		protected override void AssignEventHandlers()
		{
			SaveButton.Click += HandleSaveClicked;
			CloseButton.Click += HandleCancelClicked;
			UrlText.KeyPress += HandleKeyPress;
		}

		private void HandleKeyPress(object? sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)27)
			{
				e.Handled = true;
				HandleCancelClicked(sender, EventArgs.Empty);
			}
			else if (e.KeyChar == (char)13)
			{
				e.Handled = true;
				HandleSaveClicked(sender, EventArgs.Empty);
			}
		}
		private void HandleCancelClicked(object? sender, EventArgs e)
		{
			SetPreLoadState();
			DialogResult = DialogResult.Cancel;
			Close();
		}
		private void HandleSaveClicked(object? sender, EventArgs e)
		{
			SetPreLoadState();
			DialogResult = DialogResult.OK;
			Close();
		}

	}
}
