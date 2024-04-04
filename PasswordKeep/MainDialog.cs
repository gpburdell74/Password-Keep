using Adaptive.Intelligence.Shared.UI;
using PasswordKeep.Ops;
using System.IO;

namespace PasswordKeep.UI
{
	/// <summary>
	/// Provides the main dialog for the application.
	/// </summary>
	/// <seealso cref="AdaptiveDialogBase" />
	public partial class MainDialog : AdaptiveDialogBase
    {
        #region Private Member declarations        
        /// <summary>
        /// The current data set being edited.
        /// </summary>
        private CryptoDataManager? _dataManager;
        /// <summary>
        /// The fully-qualified path and name of the file to be read from/written to.
        /// </summary>
        private string? _fileName;
        /// <summary>
        /// The data has been modified since last save flag.
        /// </summary>
        private bool _modified;
        #endregion

        #region Constructor / Dispose Methods        
        /// <summary>
        /// Initializes a new instance of the <see cref="MainDialog"/> class.
        /// </summary>
        /// <remarks>
        /// This is the default constructor.
        /// </remarks>
        public MainDialog()
        {
            InitializeComponent();
        }
        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed && disposing)
            {
                components?.Dispose();
                _dataManager?.Dispose();

			}

            components = null;
            _dataManager = null;
			_fileName = null;
            base.Dispose(disposing);
        }
        #endregion

        #region Protected Method Overrides        
        /// <summary>
        /// Assigns the event handlers for the controls on the dialog.
        /// </summary>
        protected override void AssignEventHandlers()
        {
            // File Menu.
            FileMenuNew.Click += HandleFileMenuNewClicked;
            FileMenuOpen.Click += HandleFileMenuOpenClicked;
            FileMenuClose.Click += HandleFileMenuCloseClicked;
            FileMenuSaveAs.Click += HandleFileMenuSaveAsClicked;
            FileMenuSave.Click += HandleFileMenuSaveClicked;
            FileMenuExit.Click += HandleFileMenuExitClicked;

            // Tool Strip - File Section
            NewButton.Click += HandleFileMenuNewClicked;
            OpenButton.Click += HandleFileMenuOpenClicked;
            SaveButton.Click += HandleFileMenuSaveClicked;
            SaveAsButton.Click += HandleFileMenuSaveAsClicked;
        }
        /// <summary>
        /// Removes the event handlers for the controls on the dialog.
        /// </summary>
        protected override void RemoveEventHandlers()
        {
            // File Menu.
            FileMenuNew.Click -= HandleFileMenuNewClicked;
            FileMenuOpen.Click -= HandleFileMenuOpenClicked;
            FileMenuClose.Click -= HandleFileMenuCloseClicked;
            FileMenuSaveAs.Click -= HandleFileMenuSaveAsClicked;
            FileMenuSave.Click -= HandleFileMenuSaveClicked;
            FileMenuExit.Click -= HandleFileMenuExitClicked;

			// Tool Strip - File Section
			NewButton.Click -= HandleFileMenuNewClicked;
			OpenButton.Click -= HandleFileMenuOpenClicked;
			SaveButton.Click -= HandleFileMenuSaveClicked;
			SaveAsButton.Click -= HandleFileMenuSaveAsClicked;
		}
		/// <summary>
		/// Sets the display state for the controls on the dialog based on
		/// current conditions.
		/// </summary>
		/// <remarks>
		/// This is called by <see cref="AdaptiveDialogBase.SetState" /> after <see cref="AdaptiveDialogBase.SetSecurityState" /> is called.
		/// </remarks>
		protected override void SetDisplayState()
        {
            bool fileIsOpen = (_dataManager != null);

            MainTabs.Visible = fileIsOpen;

            FileMenuClose.Visible = fileIsOpen;
            FileMenuDiv1.Visible = fileIsOpen;
            FileMenuSave.Visible = fileIsOpen;
            FileMenuSaveAs.Visible = fileIsOpen;

            SaveButton.Visible = fileIsOpen;
			SaveAsButton.Visible = fileIsOpen;
			ToolStripDividerB.Visible = fileIsOpen;

			if (fileIsOpen)
                Text = "Password Keep - [" + Path.GetFileName(_fileName) + "]";
            else
                Text = "Password Keep";
        }
		/// <summary>
		/// Sets the state of the UI controls before the data content is loaded.
		/// </summary>
		protected override void SetPreLoadState()
		{
            Cursor = Cursors.WaitCursor;
            MainTabs.Enabled = false;
            Application.DoEvents();
            SuspendLayout();
		}
		/// <summary>
		/// Sets the state of the UI controls after the data content is loaded.
		/// </summary>
		protected override void SetPostLoadState()
		{
			Cursor = Cursors.Default;
            MainTabs.Enabled = true;
            ResumeLayout();
		}
		#endregion

		#region Private Event Handlers

		#region File Menu        
		/// <summary>
		/// Handles the event when the File Menu -> New item is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleFileMenuNewClicked(object? sender, EventArgs e)
        {
            SetPreLoadState();

            // Ensure any data changes are either saved or discarded.
            bool canContinue = CheckAndSave();
            if (canContinue)
            {
				SecureFileParameters? newParams = CreateNewFileParameters();
                if (newParams != null)
                {
                    // Close any open items and set the UI State accordingly.
                    CloseOpenData();
                    SetState();

                    // Create a new instance, and set the UI state accordingly.
                    _dataManager = new CryptoDataManager(newParams);
                    _fileName = newParams.FileName;
                    SetOpenData();

                    // Save the file to disk.
                    Save();

                    SetState();
                }
            }
            SetPostLoadState();
            SetState();
        }
        /// <summary>
        /// Handles the event when the File Menu -> Open item is clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void HandleFileMenuOpenClicked(object? sender, EventArgs e)
        {
            // Ensure any data changes are either saved or discarded.
            bool canContinue = CheckAndSave();
            if (canContinue)
            {
                SetState();
                SetPreLoadState();

                // Select the file to open.
                OpenFileDialog dialog = DialogProvider.CreateOpenFileDialog();
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    SecureFileParameters? newParams = CreateOpenFileParameters(dialog.FileName);
                    if (newParams != null)
                    {
                        // Close any open items.
                        CloseOpenData();

                        // Read the file.
                        _fileName = dialog.FileName;
                        _dataManager = new CryptoDataManager(newParams);
                        _dataManager.Load(_fileName);

                        if (_dataManager != null)
                        {
                            // Set the UI state accordingly.
                            SetOpenData();
                        }
                    }
                }
                dialog.Dispose();
            }
            SetPostLoadState();
			SetState();
		}
        /// <summary>
        /// Handles the event when the File Menu -> Close item is clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void HandleFileMenuCloseClicked(object? sender, EventArgs e)
        {
            // Ensure any data changes are either saved or discarded.
            bool canContinue = CheckAndSave();
            if (canContinue)
            {
                // Close any open items and set the UI State accordingly.
                CloseOpenData();
                SetState();
            }
        }
        /// <summary>
        /// Handles the event when the File Menu -> Save item is clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void HandleFileMenuSaveClicked(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_fileName))
                HandleFileMenuSaveAsClicked(sender, e);
            else
                Save();
        }
		/// <summary>
		/// Handles the event when the File Menu -> Save As item is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleFileMenuSaveAsClicked(object? sender, EventArgs e)
		{
			SaveFileDialog dialog = DialogProvider.CreateSaveFileDialog(_fileName);
			DialogResult result = dialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				_fileName = dialog.FileName;
				Save();
			}
		}
		/// <summary>
		/// Handles the event when the File Menu -> Exit item is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleFileMenuExitClicked(object? sender, EventArgs e)
        {
            SetPreLoadState();
            Close();
        }
		#endregion

		#endregion

		#region Private Method / Functions        
		/// <summary>
		/// Saves the current file.
		/// </summary>
		private void Save()
        {
            Text = "PasswordKeep - [" + _fileName + "]";
            if (_dataManager != null && !string.IsNullOrEmpty(_fileName))
                _dataManager.Save(_fileName);
            _modified = false;
        }
        /// <summary>
        /// Ensures the open data set file is closed and disposed, and sets the UI state accordingly.
        /// </summary>
        private void CloseOpenData()
        {
            // Remove event handlers from the data editors.
            OriginalDataList.Changed -= HandleDataChanged;
            IdProviderList.Changed -= HandleDataChanged;
            BillsList.Changed -= HandleDataChanged;
            FinAccountsList.Changed -= HandleDataChanged;
            GeneralLoginList.Changed -= HandleDataChanged;

            OriginalDataList.DataSource = null;
			IdProviderList.DataSource = null;
			BillsList.DataSource = null;
			FinAccountsList.DataSource = null;
			GeneralLoginList.DataSource = null;

			_dataManager?.Dispose();
			_dataManager = null;
            _modified = false;
        }
        private void SetOpenData()
        {
			// Remove event handlers.
			OriginalDataList.Changed -= HandleDataChanged;
			IdProviderList.Changed -= HandleDataChanged;
			BillsList.Changed -= HandleDataChanged;
			FinAccountsList.Changed -= HandleDataChanged;
			GeneralLoginList.Changed -= HandleDataChanged;

			// Remove original.
			_modified = false;

			// Set the new data source references.
			if (_dataManager != null)
			{
				OriginalDataList.DataSource = _dataManager.GeneralDataEntries;
				IdProviderList.DataSource = _dataManager.IdentityProviders;
				BillsList.DataSource = _dataManager.Bills;
				FinAccountsList.DataSource = _dataManager.FinancialAccounts;
				GeneralLoginList.DataSource = _dataManager.GeneralLogins;

				// Re-add event handlers.
				OriginalDataList.Changed += HandleDataChanged;
				IdProviderList.Changed += HandleDataChanged;
				BillsList.Changed += HandleDataChanged;
				FinAccountsList.Changed += HandleDataChanged;
				GeneralLoginList.Changed += HandleDataChanged;
			}

			//Ensure visible.
			SetState();
		}
        private void HandleDataChanged(object? sender, EventArgs e) 
        {
            _modified = true;

        }

        private bool CheckAndSave()
        {
            bool canContinue = true;

            if (_modified)
            {
                DialogResult result = MessageBox.Show("There are unsaved changes.  Save them now?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                {
                    canContinue = false;
                }
                else if (result == DialogResult.Yes)
                {
                    HandleFileMenuSaveClicked(null, EventArgs.Empty);
                }
            }
            return canContinue;
        }
		/// <summary>
		/// Prompts the user to create a new file and enter the appropriate parameters.
		/// </summary>
		/// <returns>
        /// A <see cref="SecureFileParameters"/> instance containing the user-entered data,
        /// or <b>null</b> if the user cancels.
        /// </returns>
		private SecureFileParameters? CreateNewFileParameters()
        {
            SecureFileParameters? fileParams = null;

			NewFileDialog dialog = new NewFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileParams = new SecureFileParameters
                {
                    FileName = dialog.FileName,
                    UserId = dialog.UserName,
                    Password = dialog.PasswordValue
                };
			}
            dialog.Dispose();
            return fileParams;
        }
		/// <summary>
		/// Prompts the user to login to a file after one is selected.
		/// </summary>
        /// <param name="selectedFile">
        /// A string containing the fully-qualified path and name of the file.
        /// </param>
		/// <returns>
		/// A <see cref="SecureFileParameters"/> instance containing the user-entered data,
		/// or <b>null</b> if the user cancels.
		/// </returns>
		private SecureFileParameters? CreateOpenFileParameters(string selectedFile)
		{
			SecureFileParameters? fileParams = null;

			FileLoginDialog dialog = new FileLoginDialog();
			DialogResult result = dialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				fileParams = new SecureFileParameters
				{
					FileName = selectedFile,
					UserId = dialog.UserId,
					Password = dialog.Password
				};
			}
			dialog.Dispose();

			return fileParams;
		}
		#endregion
	}
}
