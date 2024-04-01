namespace PasswordKeep.UI
{
    partial class BillsControl
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
			DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
			ActionPanel = new Panel();
			DataGrid = new DataGridView();
			NameCol = new DataGridViewTextBoxColumn();
			DescCol = new DataGridViewTextBoxColumn();
			CompanyCol = new DataGridViewTextBoxColumn();
			UrlCol = new DataGridViewLinkColumn();
			UserIdCol = new DataGridViewTextBoxColumn();
			PasswordCol = new DataGridViewTextBoxColumn();
			OutstandingBalanceCol = new DataGridViewTextBoxColumn();
			LastAmountPaid = new DataGridViewTextBoxColumn();
			NextDueDateCol = new DataGridViewTextBoxColumn();
			LastDatePaidCol = new DataGridViewTextBoxColumn();
			IsAutoPay = new DataGridViewCheckBoxColumn();
			AutoPayDay = new DataGridViewTextBoxColumn();
			DsProvider = new BindingSource(components);
			((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
			((System.ComponentModel.ISupportInitialize)DsProvider).BeginInit();
			SuspendLayout();
			// 
			// ActionPanel
			// 
			ActionPanel.Dock = DockStyle.Bottom;
			ActionPanel.Location = new Point(0, 468);
			ActionPanel.Name = "ActionPanel";
			ActionPanel.Size = new Size(1100, 32);
			ActionPanel.TabIndex = 0;
			// 
			// DataGrid
			// 
			DataGrid.AllowDrop = true;
			DataGrid.AllowUserToOrderColumns = true;
			dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 192, 192);
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = Color.Black;
			dataGridViewCellStyle1.SelectionBackColor = Color.Maroon;
			dataGridViewCellStyle1.SelectionForeColor = Color.White;
			DataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			DataGrid.AutoGenerateColumns = false;
			DataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = Color.Red;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = Color.White;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			DataGrid.ColumnHeadersHeight = 25;
			DataGrid.Columns.AddRange(new DataGridViewColumn[] { NameCol, DescCol, CompanyCol, UrlCol, UserIdCol, PasswordCol, OutstandingBalanceCol, LastAmountPaid, NextDueDateCol, LastDatePaidCol, IsAutoPay, AutoPayDay });
			DataGrid.DataSource = DsProvider;
			dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = SystemColors.Window;
			dataGridViewCellStyle8.Font = new Font("Segoe UI", 9.75F);
			dataGridViewCellStyle8.ForeColor = Color.Black;
			dataGridViewCellStyle8.SelectionBackColor = Color.Maroon;
			dataGridViewCellStyle8.SelectionForeColor = Color.White;
			dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
			DataGrid.DefaultCellStyle = dataGridViewCellStyle8;
			DataGrid.Dock = DockStyle.Fill;
			DataGrid.EditMode = DataGridViewEditMode.EditOnEnter;
			DataGrid.EnableHeadersVisualStyles = false;
			DataGrid.Location = new Point(0, 0);
			DataGrid.Name = "DataGrid";
			DataGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle9.BackColor = Color.Red;
			dataGridViewCellStyle9.Font = new Font("Segoe UI", 9.75F);
			dataGridViewCellStyle9.ForeColor = Color.White;
			dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
			DataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
			DataGrid.RowHeadersWidth = 32;
			DataGrid.Size = new Size(1100, 468);
			DataGrid.TabIndex = 1;
			// 
			// NameCol
			// 
			NameCol.DataPropertyName = "Name";
			NameCol.HeaderText = "Name";
			NameCol.Name = "NameCol";
			NameCol.ToolTipText = "Enter the name for this bill.";
			NameCol.Width = 150;
			// 
			// DescCol
			// 
			DescCol.DataPropertyName = "Description";
			DescCol.HeaderText = "Description";
			DescCol.Name = "DescCol";
			DescCol.ToolTipText = "Enter an optional description.";
			DescCol.Width = 150;
			// 
			// CompanyCol
			// 
			CompanyCol.DataPropertyName = "Company";
			CompanyCol.HeaderText = "Company";
			CompanyCol.Name = "CompanyCol";
			CompanyCol.ToolTipText = "Enter the name of the company the bill is paid to.";
			CompanyCol.Width = 150;
			// 
			// UrlCol
			// 
			UrlCol.DataPropertyName = "Url";
			UrlCol.HeaderText = "Url";
			UrlCol.Name = "UrlCol";
			UrlCol.ToolTipText = "Double-click to edit the web address for paying this bill online.";
			UrlCol.Width = 200;
			// 
			// UserIdCol
			// 
			UserIdCol.DataPropertyName = "UserId";
			UserIdCol.HeaderText = "UserId";
			UserIdCol.Name = "UserIdCol";
			UserIdCol.ToolTipText = "Enter the user name, ID, or email address used to lgin to the online site.";
			// 
			// PasswordCol
			// 
			PasswordCol.DataPropertyName = "Password";
			PasswordCol.HeaderText = "Password";
			PasswordCol.Name = "PasswordCol";
			PasswordCol.ToolTipText = "Enter the password used to lgin to the online site.";
			// 
			// OutstandingBalanceCol
			// 
			OutstandingBalanceCol.DataPropertyName = "OutstandingBalance";
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "C2";
			dataGridViewCellStyle3.NullValue = "$0.00";
			OutstandingBalanceCol.DefaultCellStyle = dataGridViewCellStyle3;
			OutstandingBalanceCol.HeaderText = "OutstandingBalance";
			OutstandingBalanceCol.Name = "OutstandingBalanceCol";
			OutstandingBalanceCol.ToolTipText = "Enter the current outstanding balance on this bill.";
			// 
			// LastAmountPaid
			// 
			LastAmountPaid.DataPropertyName = "LastAmountPaid";
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "C2";
			dataGridViewCellStyle4.NullValue = "$0.00";
			LastAmountPaid.DefaultCellStyle = dataGridViewCellStyle4;
			LastAmountPaid.HeaderText = "LastAmountPaid";
			LastAmountPaid.Name = "LastAmountPaid";
			LastAmountPaid.ToolTipText = "Enter the last amount that was paid.";
			// 
			// NextDueDateCol
			// 
			NextDueDateCol.DataPropertyName = "NextDueDate";
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.Format = "d";
			NextDueDateCol.DefaultCellStyle = dataGridViewCellStyle5;
			NextDueDateCol.HeaderText = "NextDueDate";
			NextDueDateCol.Name = "NextDueDateCol";
			NextDueDateCol.ToolTipText = "Enter the next due date for this bill.";
			// 
			// LastDatePaidCol
			// 
			LastDatePaidCol.DataPropertyName = "LastDatePaid";
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.Format = "d";
			LastDatePaidCol.DefaultCellStyle = dataGridViewCellStyle6;
			LastDatePaidCol.HeaderText = "LastDatePaid";
			LastDatePaidCol.Name = "LastDatePaidCol";
			LastDatePaidCol.ToolTipText = "Enter the date this last bill was paid.";
			// 
			// IsAutoPay
			// 
			IsAutoPay.DataPropertyName = "IsAutoPay";
			IsAutoPay.HeaderText = "IsAutoPay";
			IsAutoPay.Name = "IsAutoPay";
			IsAutoPay.ToolTipText = "Check if the bill is automatically paid.";
			// 
			// AutoPayDay
			// 
			AutoPayDay.DataPropertyName = "AutoPayDay";
			dataGridViewCellStyle7.Format = "#0";
			dataGridViewCellStyle7.NullValue = "0";
			AutoPayDay.DefaultCellStyle = dataGridViewCellStyle7;
			AutoPayDay.HeaderText = "AutoPayDay";
			AutoPayDay.Name = "AutoPayDay";
			AutoPayDay.ToolTipText = "If auto-pay is used, enter the day of the month on which the payment occurs.";
			// 
			// DsProvider
			// 
			DsProvider.DataSource = typeof(Ops.Bill);
			// 
			// BillsControl
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(DataGrid);
			Controls.Add(ActionPanel);
			Margin = new Padding(4, 5, 4, 5);
			Name = "BillsControl";
			Size = new Size(1100, 500);
			((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
			((System.ComponentModel.ISupportInitialize)DsProvider).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Panel ActionPanel;
        private DataGridView DataGrid;
        private BindingSource DsProvider;
		private DataGridViewTextBoxColumn NameCol;
		private DataGridViewTextBoxColumn DescCol;
		private DataGridViewTextBoxColumn CompanyCol;
		private DataGridViewLinkColumn UrlCol;
		private DataGridViewTextBoxColumn UserIdCol;
		private DataGridViewTextBoxColumn PasswordCol;
		private DataGridViewTextBoxColumn OutstandingBalanceCol;
		private DataGridViewTextBoxColumn LastAmountPaid;
		private DataGridViewTextBoxColumn NextDueDateCol;
		private DataGridViewTextBoxColumn LastDatePaidCol;
		private DataGridViewCheckBoxColumn IsAutoPay;
		private DataGridViewTextBoxColumn AutoPayDay;
	}
}
