namespace PasswordKeep.UI
{
    partial class FinancialAccountControl
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
			components = new System.ComponentModel.Container();
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
			DataGrid = new DataGridView();
			NameCol = new DataGridViewTextBoxColumn();
			DescCol = new DataGridViewTextBoxColumn();
			AccountTypeCol = new DataGridViewComboBoxColumn();
			CompanyCol = new DataGridViewTextBoxColumn();
			UrlCol = new DataGridViewLinkColumn();
			UserIdCol = new DataGridViewTextBoxColumn();
			PasswordCol = new DataGridViewTextBoxColumn();
			OutstandingBalanceCol = new DataGridViewTextBoxColumn();
			LastAmountPaidColumn = new DataGridViewTextBoxColumn();
			LastDatePaidCol = new DataGridViewTextBoxColumn();
			NextDueDateCol = new DataGridViewTextBoxColumn();
			CreditAvailableCol = new DataGridViewTextBoxColumn();
			MinPaymentCol = new DataGridViewTextBoxColumn();
			IsAutoPayCol = new DataGridViewCheckBoxColumn();
			AutoPayDayCol = new DataGridViewTextBoxColumn();
			DsProvider = new BindingSource(components);
			ActionBar = new AddEditRemoveToolbar();
			((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
			((System.ComponentModel.ISupportInitialize)DsProvider).BeginInit();
			SuspendLayout();
			// 
			// DataGrid
			// 
			DataGrid.AllowDrop = true;
			DataGrid.AllowUserToOrderColumns = true;
			dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 224, 192);
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = Color.Black;
			DataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			DataGrid.AutoGenerateColumns = false;
			DataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = Color.Tomato;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = Color.White;
			dataGridViewCellStyle2.SelectionBackColor = Color.Sienna;
			dataGridViewCellStyle2.SelectionForeColor = Color.White;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			DataGrid.ColumnHeadersHeight = 25;
			DataGrid.Columns.AddRange(new DataGridViewColumn[] { NameCol, DescCol, AccountTypeCol, CompanyCol, UrlCol, UserIdCol, PasswordCol, OutstandingBalanceCol, LastAmountPaidColumn, LastDatePaidCol, NextDueDateCol, CreditAvailableCol, MinPaymentCol, IsAutoPayCol, AutoPayDayCol });
			DataGrid.DataSource = DsProvider;
			dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle11.BackColor = Color.White;
			dataGridViewCellStyle11.Font = new Font("Segoe UI", 9.75F);
			dataGridViewCellStyle11.ForeColor = Color.Black;
			dataGridViewCellStyle11.SelectionBackColor = Color.IndianRed;
			dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
			DataGrid.DefaultCellStyle = dataGridViewCellStyle11;
			DataGrid.Dock = DockStyle.Fill;
			DataGrid.EditMode = DataGridViewEditMode.EditOnEnter;
			DataGrid.EnableHeadersVisualStyles = false;
			DataGrid.Location = new Point(0, 0);
			DataGrid.Name = "DataGrid";
			DataGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle12.BackColor = Color.Tomato;
			dataGridViewCellStyle12.Font = new Font("Segoe UI", 9.75F);
			dataGridViewCellStyle12.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
			DataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
			DataGrid.RowHeadersWidth = 32;
			DataGrid.Size = new Size(1100, 468);
			DataGrid.TabIndex = 1;
			// 
			// NameCol
			// 
			NameCol.DataPropertyName = "Name";
			NameCol.HeaderText = "Name";
			NameCol.Name = "NameCol";
			NameCol.ToolTipText = "Enter the name for this account.";
			NameCol.Width = 150;
			// 
			// DescCol
			// 
			DescCol.DataPropertyName = "Description";
			DescCol.HeaderText = "Description";
			DescCol.Name = "DescCol";
			DescCol.ToolTipText = "Enter a description for this account.";
			DescCol.Width = 150;
			// 
			// AccountTypeCol
			// 
			AccountTypeCol.DataPropertyName = "AccountType";
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
			AccountTypeCol.DefaultCellStyle = dataGridViewCellStyle3;
			AccountTypeCol.HeaderText = "Account Type";
			AccountTypeCol.Name = "AccountTypeCol";
			AccountTypeCol.Resizable = DataGridViewTriState.True;
			AccountTypeCol.SortMode = DataGridViewColumnSortMode.Automatic;
			AccountTypeCol.ToolTipText = "Select the type of account.";
			// 
			// CompanyCol
			// 
			CompanyCol.DataPropertyName = "Company";
			CompanyCol.HeaderText = "Company Name";
			CompanyCol.Name = "CompanyCol";
			CompanyCol.ToolTipText = "Enter the company name for this account.";
			CompanyCol.Width = 150;
			// 
			// UrlCol
			// 
			UrlCol.DataPropertyName = "Url";
			UrlCol.HeaderText = "Web Address";
			UrlCol.Name = "UrlCol";
			UrlCol.Resizable = DataGridViewTriState.True;
			UrlCol.SortMode = DataGridViewColumnSortMode.Automatic;
			UrlCol.ToolTipText = "Enter the URL for logging into the website for managing this account.";
			UrlCol.Width = 150;
			// 
			// UserIdCol
			// 
			UserIdCol.DataPropertyName = "UserId";
			UserIdCol.HeaderText = "User ID";
			UserIdCol.Name = "UserIdCol";
			UserIdCol.ToolTipText = "Enter the user name, Id, or email address for logging into the website for managing this account.";
			// 
			// PasswordCol
			// 
			PasswordCol.DataPropertyName = "Password";
			PasswordCol.HeaderText = "Password";
			PasswordCol.Name = "PasswordCol";
			PasswordCol.ToolTipText = "Enter the password for logging into the website for managing this account.";
			// 
			// OutstandingBalanceCol
			// 
			OutstandingBalanceCol.DataPropertyName = "OutstandingBalance";
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "C2";
			dataGridViewCellStyle4.NullValue = "$0.00";
			OutstandingBalanceCol.DefaultCellStyle = dataGridViewCellStyle4;
			OutstandingBalanceCol.HeaderText = "Outstanding Balance";
			OutstandingBalanceCol.Name = "OutstandingBalanceCol";
			OutstandingBalanceCol.ToolTipText = "Enter the outstanding balance for this account.";
			// 
			// LastAmountPaidColumn
			// 
			LastAmountPaidColumn.DataPropertyName = "LastAmountPaid";
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "C2";
			dataGridViewCellStyle5.NullValue = "$0.00";
			LastAmountPaidColumn.DefaultCellStyle = dataGridViewCellStyle5;
			LastAmountPaidColumn.HeaderText = "Last Amount Paid";
			LastAmountPaidColumn.Name = "LastAmountPaidColumn";
			LastAmountPaidColumn.ToolTipText = "Enter the last amount that was paid to this account.";
			// 
			// LastDatePaidCol
			// 
			LastDatePaidCol.DataPropertyName = "LastDatePaid";
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.Format = "d";
			LastDatePaidCol.DefaultCellStyle = dataGridViewCellStyle6;
			LastDatePaidCol.HeaderText = "Last Date Paid";
			LastDatePaidCol.Name = "LastDatePaidCol";
			LastDatePaidCol.ToolTipText = "Enter the last date a payment was made.";
			// 
			// NextDueDateCol
			// 
			NextDueDateCol.DataPropertyName = "NextDueDate";
			dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle7.Format = "d";
			NextDueDateCol.DefaultCellStyle = dataGridViewCellStyle7;
			NextDueDateCol.HeaderText = "Next Due Date";
			NextDueDateCol.Name = "NextDueDateCol";
			NextDueDateCol.ToolTipText = "Enter the next due date.";
			// 
			// CreditAvailableCol
			// 
			CreditAvailableCol.DataPropertyName = "CreditAvailable";
			dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle8.Format = "C2";
			dataGridViewCellStyle8.NullValue = "$0.00";
			CreditAvailableCol.DefaultCellStyle = dataGridViewCellStyle8;
			CreditAvailableCol.HeaderText = "Credit Available";
			CreditAvailableCol.Name = "CreditAvailableCol";
			CreditAvailableCol.ToolTipText = "Enter the amount of credit available.";
			// 
			// MinPaymentCol
			// 
			MinPaymentCol.DataPropertyName = "MinimumPayment";
			dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle9.Format = "C2";
			dataGridViewCellStyle9.NullValue = "$0.00";
			MinPaymentCol.DefaultCellStyle = dataGridViewCellStyle9;
			MinPaymentCol.HeaderText = "Minimum Payment";
			MinPaymentCol.Name = "MinPaymentCol";
			MinPaymentCol.ToolTipText = "Enter the next minimum payment value.";
			// 
			// IsAutoPayCol
			// 
			IsAutoPayCol.DataPropertyName = "IsAutoPay";
			IsAutoPayCol.HeaderText = "Auto Pay?";
			IsAutoPayCol.Name = "IsAutoPayCol";
			IsAutoPayCol.ToolTipText = "Check here if this account is paid via auto-pay.";
			IsAutoPayCol.Width = 80;
			// 
			// AutoPayDayCol
			// 
			AutoPayDayCol.DataPropertyName = "AutoPayDay";
			dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle10.Format = "#0";
			dataGridViewCellStyle10.NullValue = "0";
			AutoPayDayCol.DefaultCellStyle = dataGridViewCellStyle10;
			AutoPayDayCol.HeaderText = "Auto Pay Day";
			AutoPayDayCol.MaxInputLength = 2;
			AutoPayDayCol.Name = "AutoPayDayCol";
			AutoPayDayCol.ToolTipText = "If auto-pay is used, enter the day of the month the transaction occurs.";
			// 
			// DsProvider
			// 
			DsProvider.DataSource = typeof(Data.Entity.FinancialAccountEntry);
			// 
			// ActionBar
			// 
			ActionBar.Dock = DockStyle.Bottom;
			ActionBar.EditEnabled = false;
			ActionBar.Font = new Font("Segoe UI", 9.75F);
			ActionBar.Location = new Point(0, 468);
			ActionBar.MaximumSize = new Size(0, 32);
			ActionBar.MinimumSize = new Size(332, 32);
			ActionBar.Name = "ActionBar";
			ActionBar.RemoveEnabled = false;
			ActionBar.Size = new Size(1100, 32);
			ActionBar.TabIndex = 2;
			// 
			// FinancialAccountControl
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(DataGrid);
			Controls.Add(ActionBar);
			Margin = new Padding(4, 5, 4, 5);
			Name = "FinancialAccountControl";
			Size = new Size(1100, 500);
			((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
			((System.ComponentModel.ISupportInitialize)DsProvider).EndInit();
			ResumeLayout(false);
		}

		#endregion
		private DataGridView DataGrid;
        private BindingSource DsProvider;
        private DataGridViewTextBoxColumn LastAmountPaidCol;
		private DataGridViewTextBoxColumn NameCol;
		private DataGridViewTextBoxColumn DescCol;
		private DataGridViewComboBoxColumn AccountTypeCol;
		private DataGridViewTextBoxColumn CompanyCol;
		private DataGridViewLinkColumn UrlCol;
		private DataGridViewTextBoxColumn UserIdCol;
		private DataGridViewTextBoxColumn PasswordCol;
		private DataGridViewTextBoxColumn OutstandingBalanceCol;
		private DataGridViewTextBoxColumn LastAmountPaidColumn;
		private DataGridViewTextBoxColumn LastDatePaidCol;
		private DataGridViewTextBoxColumn NextDueDateCol;
		private DataGridViewTextBoxColumn CreditAvailableCol;
		private DataGridViewTextBoxColumn MinPaymentCol;
		private DataGridViewCheckBoxColumn IsAutoPayCol;
		private DataGridViewTextBoxColumn AutoPayDayCol;
		private AddEditRemoveToolbar ActionBar;
	}
}
