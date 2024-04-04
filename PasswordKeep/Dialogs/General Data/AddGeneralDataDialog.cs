﻿using Adaptive.Intelligence.Shared.UI;
using PasswordKeep.Ops;
using PasswordKeep.Ops.IO.Network;
using System.ComponentModel;

namespace PasswordKeep.UI
{
#pragma warning disable CS4014

	/// <summary>
	/// Provides a dialog for adding a new General Data object to the user's list.
	/// </summary>
	/// <seealso cref="AdaptiveDialogBase" />
	public partial class AddGeneralDataDialog : AdaptiveDialogBase
	{
		#region Private Member Declarations		
		/// <summary>
		/// The new instance being edited.
		/// </summary>
		private GeneralData? _newInstance;
		#endregion

		#region Constructor / Dispose Methods		
		/// <summary>
		/// Initializes a new instance of the <see cref="AddGeneralDataDialog"/> class.
		/// </summary>
		/// <remarks>
		/// This is the default constructor.
		/// </remarks>
		public AddGeneralDataDialog()
		{
			InitializeComponent();
			_newInstance = new GeneralData();
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

			_newInstance = null;
			components = null;
			base.Dispose(disposing);
		}
		#endregion

		#region Public Properties		
		/// <summary>
		/// Gets the reference to the new <see cref="GeneralData"/> instance.
		/// </summary>
		/// <value>
		/// The <see cref="GeneralData"/> instance being added, or <b>null</b> if canceled.
		/// </value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public GeneralData? Data => _newInstance;
		#endregion

		#region Protected Method Overrides		
		/// <summary>
		/// Assigns the event handlers for the controls on the dialog.
		/// </summary>
		protected override void AssignEventHandlers()
		{
			// Text Boxes.
			NameText.TextChanged += HandleGenericControlChange;
			DescText.TextChanged += HandleGenericControlChange;
			UrlText.LostFocus += HandleUrlTextChange;
			UserIdText.TextChanged += HandleGenericControlChange;
			PasswordText.TextChanged += HandleGenericControlChange;
			CurrentText.TextChanged += HandleGenericControlChange;
			MinDueText.TextChanged += HandleGenericControlChange;
			AvailableText.TextChanged += HandleGenericControlChange;
			LastPaidDate.ValueChanged += HandleGenericControlChange;
			NextDueDate.ValueChanged += HandleGenericControlChange;


			// Security Questions.
			QuestionList.SelectedIndexChanged += HandleGenericControlChange;
			AddQuestionButton.Click += HandleAddQuestionButtonClicked;
			EditQuestionButton.Click += HandleEditQuestionButtonClicked;
			DeleteQuestionButton.Click += HandleDeleteQuestionButtonClicked;

			// Save / Cancel
			SaveButton.Click += HandleSaveClicked;
			CloseButton.Click += HandleCloseClicked;
		}
		/// <summary>
		/// Removes the event handlers for the controls on the dialog.
		/// </summary>
		protected override void RemoveEventHandlers()
		{
			// Text Boxes.
			NameText.TextChanged -= HandleGenericControlChange;
			DescText.TextChanged -= HandleGenericControlChange;
			UrlText.LostFocus -= HandleUrlTextChange;
			UserIdText.TextChanged -= HandleGenericControlChange;
			PasswordText.TextChanged -= HandleGenericControlChange;
			CurrentText.TextChanged -= HandleGenericControlChange;
			MinDueText.TextChanged -= HandleGenericControlChange;
			AvailableText.TextChanged -= HandleGenericControlChange;
			LastPaidDate.ValueChanged -= HandleGenericControlChange;
			NextDueDate.ValueChanged -= HandleGenericControlChange;

			// Security Questions.
			QuestionList.SelectedIndexChanged -= HandleGenericControlChange;
			AddQuestionButton.Click -= HandleAddQuestionButtonClicked;
			EditQuestionButton.Click -= HandleEditQuestionButtonClicked;
			DeleteQuestionButton.Click -= HandleDeleteQuestionButtonClicked;

			// Save / Cancel
			SaveButton.Click -= HandleSaveClicked;
			CloseButton.Click -= HandleCloseClicked;
		}
		/// <summary>
		///Sets the display state for the controls on the dialog based on
		/// current conditions.
		/// </summary>
		/// <remarks>
		/// This is called by <see cref="M:Adaptive.Intelligence.Shared.UI.AdaptiveDialogBase.SetState" /> after <see cref="M:Adaptive.Intelligence.Shared.UI.AdaptiveDialogBase.SetSecurityState" /> is called.
		/// </remarks>
		protected override void SetDisplayState()
		{
			bool canEdit = QuestionList.SelectedItems.Count > 0;

			ErrorProvider.Clear();
			if (NameText.Text.Length > 0)
			{
				ItemHeader.ItemName = NameText.Text;
				SaveButton.Enabled = true;
			}
			else
			{
				ErrorProvider.SetError(NameText, "A name for this entry must be added.");
				ItemHeader.ItemName = string.Empty;
				SaveButton.Enabled = false;

			}
			EditQuestionButton.Enabled = canEdit;
			DeleteQuestionButton.Enabled = canEdit;
		}
		#endregion


		#region Private Event Handlers
		/// <summary>
		/// Handles the event when the Add Security Question button is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleAddQuestionButtonClicked(object? sender, EventArgs e)
		{
			SetPreLoadState();
			if (_newInstance != null)
			{
				AddEditSecurityQuestionDialog dialog = new AddEditSecurityQuestionDialog();
				DialogResult result = dialog.ShowDialog();
				if (result == DialogResult.OK)
				{
					_newInstance.AddSecurityQuestionAndAnswer(dialog.Question, dialog.Answer);

					ListViewItem item = new ListViewItem();
					item.Text = dialog.Question;
					item.SubItems.Add(dialog.Answer);
					item.Tag = _newInstance.SecurityQuestionCount;

					QuestionList.Items.Add(item);
				}
				dialog.Dispose();
			}
			SetState();
			SetPostLoadState();
		}
		/// <summary>
		/// Handles the event when the Edit Security Question button is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleEditQuestionButtonClicked(object? sender, EventArgs e)
		{
			if (QuestionList.SelectedItems.Count > 0 && _newInstance != null)
			{ 
				SetPreLoadState();
				ListViewItem item = (ListViewItem)QuestionList.SelectedItems[0];
				int index = (int)item.Tag;

				AddEditSecurityQuestionDialog dialog = new AddEditSecurityQuestionDialog();
				dialog.Question = _newInstance.SecurityQuestions[index];
				dialog.Answer = _newInstance.SecurityAnswers[index];
				DialogResult result = dialog.ShowDialog();
				if (result == DialogResult.OK)
				{
					_newInstance.SecurityQuestions[index] = dialog.Question;
					_newInstance.SecurityAnswers[index] = dialog.Answer;

					item.Text = dialog.Question;
					item.SubItems[1].Text = dialog.Answer;
				}
				dialog.Dispose();
			}
			
			SetState();
			SetPostLoadState();

		}
		/// <summary>
		/// Handles the event when the Delete Security Question button is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleDeleteQuestionButtonClicked(object? sender, EventArgs e)
		{
			SetPreLoadState();
			if (QuestionList.SelectedItems.Count > 0 && _newInstance != null)
			{
				ListViewItem item = (ListViewItem)QuestionList.SelectedItems[0];
				int index = (int)item.Tag;
				DialogResult result = MessageBox.Show("Delete the security question and answer?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (result == DialogResult.Yes)
				{
					QuestionList.Items.Remove(item);
					_newInstance.RemoveSecurityQuestionAndAnswer(index);
					SetState();
				}
			}
			SetPostLoadState();
		}
		/// <summary>
		/// Handles the event when the Cancel/Close button is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleSaveClicked(object? sender, EventArgs e)
		{
			SetPreLoadState();
			SaveContentToInstance();
			DialogResult = DialogResult.OK;
			Close();
		}
		/// <summary>
		/// Handles the event when the Cancel/Close button is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleCloseClicked(object? sender, EventArgs e)
		{
			SetPreLoadState();
			_newInstance?.Dispose();
			_newInstance = null;
			DialogResult = DialogResult.Cancel;
			Close();
		}
		/// <summary>
		/// Handles the event when the URL text box's text content changes.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleUrlTextChange(object? sender, EventArgs e)
		{
			string urlToValidate = UrlText.Text;
			if (!urlToValidate.ToLower().StartsWith("http") && 
				urlToValidate.IndexOf("://") == -1)
			{
				urlToValidate = "http://" + urlToValidate;
			}

			bool isValid = ValidateUrlEntry(urlToValidate);
			if (isValid)
			{
				// Attempt to download the site icon.

				StartIconFetchAsync(UrlText.Text);
			}
		}
		#endregion

		#region Private Methods / Functions		
		/// <summary>
		/// Starts the process of downloading the web icon for the specified URL.
		/// </summary>
		/// <param name="url">
		/// A string containing the URL value.
		/// </param>
		private async Task StartIconFetchAsync(string url)
		{
			Image? iconImage = await WebIconFetcher.FetchIconImageAsync(url).ConfigureAwait(false);
			if (iconImage != null)
			{
				ContinueInMainThread(() =>
				{
					ItemHeader.Image = iconImage;
				});
			}
		}
		/// <summary>
		/// Attempts to validate the specified string is a valid URL.
		/// </summary>
		/// <param name="urlToValidate">
		/// A string containing the URL to validate.
		/// </param>
		/// <returns>
		/// <b>true</b> if the URL is valid; otherwise, returns <b>false</b>.
		/// </returns>
		private static bool ValidateUrlEntry(string urlToValidate)
		{
			bool isValid = false;
			Uri? uri = null;

			try
			{
				uri = new Uri(urlToValidate);
			}
			catch (UriFormatException)
			{
				// Bad URL.
				uri = null;
			}

			if (uri != null)
			{
				isValid = Uri.CheckSchemeName(uri.Scheme);
				if (isValid)
				{
					UriHostNameType nameType = Uri.CheckHostName(uri.Host);
					isValid = (nameType != UriHostNameType.Unknown);
				}
			}
			return isValid;
		}
		/// <summary>
		/// Saves the content in the dialog to the data object.
		/// </summary>
		private void SaveContentToInstance()
		{
			if (_newInstance == null)
				_newInstance = new GeneralData();

			_newInstance.Name = NameText.Text;
			_newInstance.Description = DescText.Text;
			_newInstance.Url = UrlText.Text;
			_newInstance.UserId = UserIdText.Text;
			_newInstance.Password = PasswordText.Text;
			_newInstance.Available = float.Parse(AvailableText.Text);
			_newInstance.CurrentBalance = float.Parse(CurrentText.Text);
			_newInstance.MinimumDue = float.Parse(MinDueText.Text);
			_newInstance.NextDue = NextDueDate.Value;
			_newInstance.LastPaid = LastPaidDate.Value;
		}
		#endregion
	}
}
