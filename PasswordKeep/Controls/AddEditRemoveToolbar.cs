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
	/// <summary>
	/// Provides a simple control for containing Add, Edit, and Delete buttons.
	/// </summary>
	/// <seealso cref="Adaptive.Intelligence.Shared.UI.AdaptiveControlBase" />
	public partial class AddEditRemoveToolbar : AdaptiveControlBase
	{
		public AddEditRemoveToolbar()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

	}
}
