namespace PasswordKeep.UI
{
    partial class MainDialog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDialog));
			MainMenu = new MenuStrip();
			FileMenu = new ToolStripMenuItem();
			FileMenuNew = new ToolStripMenuItem();
			FileMenuOpen = new ToolStripMenuItem();
			FileMenuClose = new ToolStripMenuItem();
			FileMenuDiv1 = new ToolStripSeparator();
			FileMenuSave = new ToolStripMenuItem();
			FileMenuSaveAs = new ToolStripMenuItem();
			FileMenuDiv2 = new ToolStripSeparator();
			FileMenuExit = new ToolStripMenuItem();
			MainToolbar = new ToolStrip();
			MainStatus = new StatusStrip();
			MainTabs = new TabControl();
			OriginalTab = new TabPage();
			OriginalDataList = new GeneralDataControl();
			IdProvidersTab = new TabPage();
			IdProviderList = new IdProviderControl();
			GeneralLoginTab = new TabPage();
			GeneralLoginList = new GeneralLoginControl();
			FinAccountsTab = new TabPage();
			FinAccountsList = new FinancialAccountControl();
			BillsTab = new TabPage();
			BillsList = new BillsControl();
			NewButton = new ToolStripButton();
			OpenButton = new ToolStripButton();
			SaveButton = new ToolStripButton();
			SaveAsButton = new ToolStripButton();
			ToolStripDividerA = new ToolStripSeparator();
			ToolStripDividerB = new ToolStripSeparator();
			MainMenu.SuspendLayout();
			MainToolbar.SuspendLayout();
			MainTabs.SuspendLayout();
			OriginalTab.SuspendLayout();
			IdProvidersTab.SuspendLayout();
			GeneralLoginTab.SuspendLayout();
			FinAccountsTab.SuspendLayout();
			BillsTab.SuspendLayout();
			SuspendLayout();
			// 
			// MainMenu
			// 
			MainMenu.Items.AddRange(new ToolStripItem[] { FileMenu });
			MainMenu.Location = new Point(0, 0);
			MainMenu.Name = "MainMenu";
			MainMenu.Size = new Size(1241, 24);
			MainMenu.TabIndex = 0;
			MainMenu.Text = "menuStrip1";
			// 
			// FileMenu
			// 
			FileMenu.DropDownItems.AddRange(new ToolStripItem[] { FileMenuNew, FileMenuOpen, FileMenuClose, FileMenuDiv1, FileMenuSave, FileMenuSaveAs, FileMenuDiv2, FileMenuExit });
			FileMenu.Name = "FileMenu";
			FileMenu.Size = new Size(37, 20);
			FileMenu.Text = "&File";
			// 
			// FileMenuNew
			// 
			FileMenuNew.Image = Properties.Resources.New16;
			FileMenuNew.Name = "FileMenuNew";
			FileMenuNew.ShortcutKeys = Keys.Control | Keys.N;
			FileMenuNew.Size = new Size(246, 22);
			FileMenuNew.Text = "Create &New Secure File...";
			// 
			// FileMenuOpen
			// 
			FileMenuOpen.Image = Properties.Resources.Open16;
			FileMenuOpen.Name = "FileMenuOpen";
			FileMenuOpen.ShortcutKeys = Keys.Control | Keys.O;
			FileMenuOpen.Size = new Size(246, 22);
			FileMenuOpen.Text = "&Open Secure File...";
			// 
			// FileMenuClose
			// 
			FileMenuClose.Name = "FileMenuClose";
			FileMenuClose.Size = new Size(246, 22);
			FileMenuClose.Text = "Close";
			// 
			// FileMenuDiv1
			// 
			FileMenuDiv1.Name = "FileMenuDiv1";
			FileMenuDiv1.Size = new Size(243, 6);
			// 
			// FileMenuSave
			// 
			FileMenuSave.Image = Properties.Resources.Save16;
			FileMenuSave.Name = "FileMenuSave";
			FileMenuSave.ShortcutKeys = Keys.Control | Keys.S;
			FileMenuSave.Size = new Size(246, 22);
			FileMenuSave.Text = "&Save Secure File";
			// 
			// FileMenuSaveAs
			// 
			FileMenuSaveAs.Image = Properties.Resources.SaveAs16;
			FileMenuSaveAs.Name = "FileMenuSaveAs";
			FileMenuSaveAs.Size = new Size(246, 22);
			FileMenuSaveAs.Text = "Save File &As...";
			// 
			// FileMenuDiv2
			// 
			FileMenuDiv2.Name = "FileMenuDiv2";
			FileMenuDiv2.Size = new Size(243, 6);
			// 
			// FileMenuExit
			// 
			FileMenuExit.Name = "FileMenuExit";
			FileMenuExit.ShortcutKeys = Keys.Alt | Keys.F4;
			FileMenuExit.Size = new Size(246, 22);
			FileMenuExit.Text = "E&xit";
			// 
			// MainToolbar
			// 
			MainToolbar.Items.AddRange(new ToolStripItem[] { NewButton, OpenButton, ToolStripDividerA, SaveButton, SaveAsButton, ToolStripDividerB });
			MainToolbar.Location = new Point(0, 24);
			MainToolbar.Name = "MainToolbar";
			MainToolbar.Size = new Size(1241, 25);
			MainToolbar.TabIndex = 1;
			MainToolbar.Text = "toolStrip1";
			// 
			// MainStatus
			// 
			MainStatus.Location = new Point(0, 658);
			MainStatus.Name = "MainStatus";
			MainStatus.Size = new Size(1241, 22);
			MainStatus.TabIndex = 2;
			MainStatus.Text = "statusStrip1";
			// 
			// MainTabs
			// 
			MainTabs.Controls.Add(OriginalTab);
			MainTabs.Controls.Add(IdProvidersTab);
			MainTabs.Controls.Add(GeneralLoginTab);
			MainTabs.Controls.Add(FinAccountsTab);
			MainTabs.Controls.Add(BillsTab);
			MainTabs.Dock = DockStyle.Fill;
			MainTabs.Location = new Point(0, 49);
			MainTabs.Name = "MainTabs";
			MainTabs.SelectedIndex = 0;
			MainTabs.Size = new Size(1241, 609);
			MainTabs.TabIndex = 3;
			MainTabs.Visible = false;
			// 
			// OriginalTab
			// 
			OriginalTab.Controls.Add(OriginalDataList);
			OriginalTab.Location = new Point(4, 26);
			OriginalTab.Name = "OriginalTab";
			OriginalTab.Padding = new Padding(3);
			OriginalTab.Size = new Size(1233, 579);
			OriginalTab.TabIndex = 0;
			OriginalTab.Text = "Original Data";
			OriginalTab.UseVisualStyleBackColor = true;
			// 
			// OriginalDataList
			// 
			OriginalDataList.DataSource = null;
			OriginalDataList.Dock = DockStyle.Fill;
			OriginalDataList.Font = new Font("Segoe UI", 9.75F);
			OriginalDataList.Location = new Point(3, 3);
			OriginalDataList.Margin = new Padding(4, 5, 4, 5);
			OriginalDataList.Name = "OriginalDataList";
			OriginalDataList.Size = new Size(1227, 573);
			OriginalDataList.TabIndex = 0;
			// 
			// IdProvidersTab
			// 
			IdProvidersTab.Controls.Add(IdProviderList);
			IdProvidersTab.Location = new Point(4, 26);
			IdProvidersTab.Name = "IdProvidersTab";
			IdProvidersTab.Padding = new Padding(3);
			IdProvidersTab.Size = new Size(1233, 579);
			IdProvidersTab.TabIndex = 1;
			IdProvidersTab.Text = "IdentityProviders";
			IdProvidersTab.UseVisualStyleBackColor = true;
			// 
			// IdProviderList
			// 
			IdProviderList.DataSource = null;
			IdProviderList.Dock = DockStyle.Fill;
			IdProviderList.Font = new Font("Segoe UI", 9.75F);
			IdProviderList.Location = new Point(3, 3);
			IdProviderList.Margin = new Padding(4, 5, 4, 5);
			IdProviderList.Name = "IdProviderList";
			IdProviderList.Size = new Size(1227, 573);
			IdProviderList.TabIndex = 0;
			// 
			// GeneralLoginTab
			// 
			GeneralLoginTab.Controls.Add(GeneralLoginList);
			GeneralLoginTab.Location = new Point(4, 26);
			GeneralLoginTab.Name = "GeneralLoginTab";
			GeneralLoginTab.Size = new Size(1233, 579);
			GeneralLoginTab.TabIndex = 2;
			GeneralLoginTab.Text = "General Logins";
			GeneralLoginTab.UseVisualStyleBackColor = true;
			// 
			// GeneralLoginList
			// 
			GeneralLoginList.DataSource = null;
			GeneralLoginList.Dock = DockStyle.Fill;
			GeneralLoginList.Font = new Font("Segoe UI", 9.75F);
			GeneralLoginList.Location = new Point(0, 0);
			GeneralLoginList.Margin = new Padding(4, 5, 4, 5);
			GeneralLoginList.Name = "GeneralLoginList";
			GeneralLoginList.Size = new Size(1233, 579);
			GeneralLoginList.TabIndex = 0;
			// 
			// FinAccountsTab
			// 
			FinAccountsTab.Controls.Add(FinAccountsList);
			FinAccountsTab.Location = new Point(4, 26);
			FinAccountsTab.Name = "FinAccountsTab";
			FinAccountsTab.Size = new Size(1233, 579);
			FinAccountsTab.TabIndex = 3;
			FinAccountsTab.Text = "Financial Accounts";
			FinAccountsTab.UseVisualStyleBackColor = true;
			// 
			// FinAccountsList
			// 
			FinAccountsList.DataSource = null;
			FinAccountsList.Dock = DockStyle.Fill;
			FinAccountsList.Font = new Font("Segoe UI", 9.75F);
			FinAccountsList.Location = new Point(0, 0);
			FinAccountsList.Margin = new Padding(4, 5, 4, 5);
			FinAccountsList.Name = "FinAccountsList";
			FinAccountsList.Size = new Size(1233, 579);
			FinAccountsList.TabIndex = 0;
			// 
			// BillsTab
			// 
			BillsTab.Controls.Add(BillsList);
			BillsTab.Location = new Point(4, 26);
			BillsTab.Name = "BillsTab";
			BillsTab.Size = new Size(1233, 579);
			BillsTab.TabIndex = 4;
			BillsTab.Text = "Bills";
			BillsTab.UseVisualStyleBackColor = true;
			// 
			// BillsList
			// 
			BillsList.DataSource = null;
			BillsList.Dock = DockStyle.Fill;
			BillsList.Font = new Font("Segoe UI", 9.75F);
			BillsList.Location = new Point(0, 0);
			BillsList.Margin = new Padding(4, 5, 4, 5);
			BillsList.Name = "BillsList";
			BillsList.Size = new Size(1233, 579);
			BillsList.TabIndex = 0;
			// 
			// NewButton
			// 
			NewButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
			NewButton.Image = Properties.Resources.New16;
			NewButton.ImageTransparentColor = Color.Magenta;
			NewButton.Name = "NewButton";
			NewButton.Size = new Size(23, 22);
			NewButton.Text = "New File";
			NewButton.ToolTipText = "Create a New Secure File";
			// 
			// OpenButton
			// 
			OpenButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
			OpenButton.Image = Properties.Resources.Open16;
			OpenButton.ImageTransparentColor = Color.Magenta;
			OpenButton.Name = "OpenButton";
			OpenButton.Size = new Size(23, 22);
			OpenButton.Text = "Open File";
			OpenButton.ToolTipText = "Open A Secure File";
			// 
			// SaveButton
			// 
			SaveButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
			SaveButton.Image = Properties.Resources.Save16;
			SaveButton.ImageTransparentColor = Color.Magenta;
			SaveButton.Name = "SaveButton";
			SaveButton.Size = new Size(23, 22);
			SaveButton.Text = "Save";
			SaveButton.ToolTipText = "Save the current file.";
			// 
			// SaveAsButton
			// 
			SaveAsButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
			SaveAsButton.Image = Properties.Resources.SaveAs16;
			SaveAsButton.ImageTransparentColor = Color.Magenta;
			SaveAsButton.Name = "SaveAsButton";
			SaveAsButton.Size = new Size(23, 22);
			SaveAsButton.Text = "Save As";
			SaveAsButton.ToolTipText = "Save the current file to a new file.";
			// 
			// ToolStripDividerA
			// 
			ToolStripDividerA.Name = "ToolStripDividerA";
			ToolStripDividerA.Size = new Size(6, 25);
			// 
			// ToolStripDividerB
			// 
			ToolStripDividerB.Name = "ToolStripDividerB";
			ToolStripDividerB.Size = new Size(6, 25);
			// 
			// MainDialog
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1241, 680);
			Controls.Add(MainTabs);
			Controls.Add(MainStatus);
			Controls.Add(MainToolbar);
			Controls.Add(MainMenu);
			Icon = (Icon)resources.GetObject("$this.Icon");
			KeyPreview = true;
			MainMenuStrip = MainMenu;
			Name = "MainDialog";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Password Keep";
			MainMenu.ResumeLayout(false);
			MainMenu.PerformLayout();
			MainToolbar.ResumeLayout(false);
			MainToolbar.PerformLayout();
			MainTabs.ResumeLayout(false);
			OriginalTab.ResumeLayout(false);
			IdProvidersTab.ResumeLayout(false);
			GeneralLoginTab.ResumeLayout(false);
			FinAccountsTab.ResumeLayout(false);
			BillsTab.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip MainMenu;
        private ToolStripMenuItem FileMenu;
        private ToolStrip MainToolbar;
        private StatusStrip MainStatus;
        private ToolStripMenuItem FileMenuNew;
        private ToolStripMenuItem FileMenuOpen;
        private ToolStripMenuItem FileMenuClose;
        private ToolStripSeparator FileMenuDiv1;
        private ToolStripMenuItem FileMenuSave;
        private ToolStripMenuItem FileMenuSaveAs;
        private ToolStripSeparator FileMenuDiv2;
        private ToolStripMenuItem FileMenuExit;
        private TabControl MainTabs;
        private TabPage OriginalTab;
        private TabPage IdProvidersTab;
        private TabPage GeneralLoginTab;
        private TabPage FinAccountsTab;
        private TabPage BillsTab;
        private GeneralDataControl OriginalDataList;
        private IdProviderControl IdProviderList;
        private GeneralLoginControl GeneralLoginList;
        private FinancialAccountControl FinAccountsList;
        private BillsControl BillsList;
		private ToolStripButton NewButton;
		private ToolStripButton OpenButton;
		private ToolStripSeparator ToolStripDividerA;
		private ToolStripButton SaveButton;
		private ToolStripButton SaveAsButton;
		private ToolStripSeparator ToolStripDividerB;
	}
}
