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
            GeneralLoginTab = new TabPage();
            FinAccountsTab = new TabPage();
            BillsTab = new TabPage();
            IdProviderList = new IdProviderControl();
            GeneralLoginList = new GeneralLoginControl();
            FinAccountsList = new FinancialAccountControl();
            BillsList = new BillsControl();
            MainMenu.SuspendLayout();
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
            FileMenuNew.Name = "FileMenuNew";
            FileMenuNew.Size = new Size(123, 22);
            FileMenuNew.Text = "&New";
            // 
            // FileMenuOpen
            // 
            FileMenuOpen.Name = "FileMenuOpen";
            FileMenuOpen.Size = new Size(123, 22);
            FileMenuOpen.Text = "&Open";
            // 
            // FileMenuClose
            // 
            FileMenuClose.Name = "FileMenuClose";
            FileMenuClose.Size = new Size(123, 22);
            FileMenuClose.Text = "Close";
            // 
            // FileMenuDiv1
            // 
            FileMenuDiv1.Name = "FileMenuDiv1";
            FileMenuDiv1.Size = new Size(120, 6);
            // 
            // FileMenuSave
            // 
            FileMenuSave.Name = "FileMenuSave";
            FileMenuSave.Size = new Size(123, 22);
            FileMenuSave.Text = "&Save";
            // 
            // FileMenuSaveAs
            // 
            FileMenuSaveAs.Name = "FileMenuSaveAs";
            FileMenuSaveAs.Size = new Size(123, 22);
            FileMenuSaveAs.Text = "Save &As...";
            // 
            // FileMenuDiv2
            // 
            FileMenuDiv2.Name = "FileMenuDiv2";
            FileMenuDiv2.Size = new Size(120, 6);
            // 
            // FileMenuExit
            // 
            FileMenuExit.Name = "FileMenuExit";
            FileMenuExit.Size = new Size(123, 22);
            FileMenuExit.Text = "E&xit";
            // 
            // MainToolbar
            // 
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
            OriginalDataList.Dock = DockStyle.Fill;
            OriginalDataList.Font = new Font("Segoe UI", 9.75F);
            OriginalDataList.Location = new Point(3, 3);
            OriginalDataList.Margin = new Padding(4, 5, 4, 5);
            OriginalDataList.DataSource = null;
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
            // IdProviderList
            // 
            IdProviderList.Dock = DockStyle.Fill;
            IdProviderList.Font = new Font("Segoe UI", 9.75F);
            IdProviderList.Location = new Point(3, 3);
            IdProviderList.Margin = new Padding(4, 5, 4, 5);
            IdProviderList.Name = "IdProviderList";
            IdProviderList.Size = new Size(1227, 573);
            IdProviderList.TabIndex = 0;
            // 
            // GeneralLoginList
            // 
            GeneralLoginList.Dock = DockStyle.Fill;
            GeneralLoginList.Location = new Point(0, 0);
            GeneralLoginList.Name = "GeneralLoginList";
            GeneralLoginList.Size = new Size(1233, 579);
            GeneralLoginList.TabIndex = 0;
            // 
            // FinAccountsList
            // 
            FinAccountsList.Dock = DockStyle.Fill;
            FinAccountsList.Location = new Point(0, 0);
            FinAccountsList.Name = "FinAccountsList";
            FinAccountsList.Size = new Size(1233, 579);
            FinAccountsList.TabIndex = 0;
            // 
            // BillsList
            // 
            BillsList.Dock = DockStyle.Fill;
            BillsList.Location = new Point(0, 0);
            BillsList.Name = "BillsList";
            BillsList.Size = new Size(1233, 579);
            BillsList.TabIndex = 0;
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
            KeyPreview = true;
            MainMenuStrip = MainMenu;
            Name = "MainDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            MainMenu.ResumeLayout(false);
            MainMenu.PerformLayout();
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
    }
}
