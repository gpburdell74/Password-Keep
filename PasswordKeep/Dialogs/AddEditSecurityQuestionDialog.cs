using Adaptive.Intelligence.Shared.UI;
using System.ComponentModel;

namespace PasswordKeep.UI
{
	/// <summary>
	/// Provides a dialog for editing a security question and answer pair.
	/// </summary>
	/// <seealso cref="AdaptiveDialogBase" />
	public partial class AddEditSecurityQuestionDialog : AdaptiveDialogBase
	{
		#region Constructor / Dispose Methods		
		/// <summary>
		/// Initializes a new instance of the <see cref="AddEditSecurityQuestionDialog"/> class.
		/// </summary>
		/// <remarks>
		/// This is the default constructor.
		/// </remarks>
		public AddEditSecurityQuestionDialog()
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
		#endregion

		#region Public Properties		
		/// <summary>
		/// Gets or sets the answer text.
		/// </summary>
		/// <value>
		/// A string containing the answer text.
		/// </value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string Answer
		{
			get => AnswerText.Text;
			set
			{
				AnswerText.Text = value;
				Invalidate();
				SetState();
			}
		}
		/// <summary>
		/// Gets or sets the question text.
		/// </summary>
		/// <value>
		/// A string containing the question text.
		/// </value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string Question
		{
			get => QuestionText.Text;
			set
			{
				QuestionText.Text = value;
				Invalidate();
				SetState();
			}

		}
		#endregion

		#region Protected Method Overrides		
		/// <summary>
		/// Assigns the event handlers for the controls on the dialog.
		/// </summary>
		protected override void AssignEventHandlers()
		{
			AnswerText.TextChanged += HandleGenericControlChange;
			QuestionText.TextChanged += HandleGenericControlChange;

			ButtonPanel.SaveClicked += HandleSaveClicked;
			ButtonPanel.CancelClicked += HandleCancelClicked;
		}
		/// <summary>
		/// Removes the event handlers for the controls on the dialog.
		/// </summary>
		/// <returns></returns>
		protected override void RemoveEventHandlers()
		{
			AnswerText.TextChanged -= HandleGenericControlChange;
			QuestionText.TextChanged -= HandleGenericControlChange;

			ButtonPanel.SaveClicked -= HandleSaveClicked;
			ButtonPanel.CancelClicked -= HandleCancelClicked;

		}
		/// <summary>
		/// When implemented in a derived class, sets the display state for the controls on the dialog based on
		/// current conditions.
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// This is called by <see cref="SetState" /> after <see cref="SetSecurityState" /> is called.
		/// </remarks>
		protected override void SetDisplayState()
		{
			ErrorProvider.Clear();
			if (QuestionText.Text.Length == 0 && AnswerText.Text.Length == 0)
			{
				ErrorProvider.SetError(QuestionText, "Either a question or an answer must be provided.");
				ButtonPanel.SaveEnabled = false;
			}
			else
				ButtonPanel.SaveEnabled = true;
		}
		/// <summary>
		/// Sets the state of the UI controls before the data content is loaded.
		/// </summary>
		/// <returns></returns>
		protected override void SetPreLoadState()
		{
			Cursor = Cursors.WaitCursor;
			QuestionText.Enabled = false;
			AnswerText.Enabled = false;
			ButtonPanel.Enabled = false;
			Application.DoEvents();
			SuspendLayout();
		}
		/// <summary>
		/// Sets the state of the UI controls after the data content is loaded.
		/// </summary>
		protected override void SetPostLoadState()
		{
			Cursor = Cursors.Default;
			QuestionText.Enabled = true;
			AnswerText.Enabled = true;
			ButtonPanel.Enabled = true;
			ResumeLayout();
		}
		#endregion

		#region Private Event Handlers		
		/// <summary>
		/// Handles the event when the Cancel button is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleCancelClicked(object? sender, EventArgs e)
		{
			SetPreLoadState();
			DialogResult = DialogResult.Cancel;
			Close();
		}
		/// <summary>
		/// Handles the event when the Cancel button is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleSaveClicked(object? sender, EventArgs e)
		{
			SetPreLoadState();
			DialogResult = DialogResult.OK;
			Close();
		}
		#endregion
	}
}