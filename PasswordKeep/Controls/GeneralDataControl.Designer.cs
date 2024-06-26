﻿namespace PasswordKeep.UI
{
    partial class GeneralDataControl
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
			DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
			DataGrid = new DataGridView();
			NameCol = new DataGridViewTextBoxColumn();
			DescCol = new DataGridViewTextBoxColumn();
			UrlCol = new DataGridViewLinkColumn();
			UserIdCol = new DataGridViewTextBoxColumn();
			PasswordCol = new DataGridViewTextBoxColumn();
			BalanceCol = new DataGridViewTextBoxColumn();
			LastPaidCol = new DataGridViewTextBoxColumn();
			NextDueCol = new DataGridViewTextBoxColumn();
			AvailableCol = new DataGridViewTextBoxColumn();
			MinimumDueCol = new DataGridViewTextBoxColumn();
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
			dataGridViewCellStyle1.BackColor = Color.LightBlue;
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = Color.Black;
			DataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			DataGrid.AutoGenerateColumns = false;
			DataGrid.BackgroundColor = Color.MidnightBlue;
			DataGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = Color.DodgerBlue;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = Color.White;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			DataGrid.ColumnHeadersHeight = 25;
			DataGrid.Columns.AddRange(new DataGridViewColumn[] { NameCol, DescCol, UrlCol, UserIdCol, PasswordCol, BalanceCol, LastPaidCol, NextDueCol, AvailableCol, MinimumDueCol });
			DataGrid.DataSource = DsProvider;
			dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle13.BackColor = Color.White;
			dataGridViewCellStyle13.Font = new Font("Segoe UI", 9.75F);
			dataGridViewCellStyle13.ForeColor = Color.Black;
			dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
			DataGrid.DefaultCellStyle = dataGridViewCellStyle13;
			DataGrid.Dock = DockStyle.Fill;
			DataGrid.EditMode = DataGridViewEditMode.EditOnEnter;
			DataGrid.EnableHeadersVisualStyles = false;
			DataGrid.GridColor = Color.SkyBlue;
			DataGrid.Location = new Point(0, 0);
			DataGrid.MultiSelect = false;
			DataGrid.Name = "DataGrid";
			DataGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle14.BackColor = Color.DodgerBlue;
			dataGridViewCellStyle14.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			dataGridViewCellStyle14.ForeColor = Color.White;
			dataGridViewCellStyle14.SelectionBackColor = Color.DeepSkyBlue;
			dataGridViewCellStyle14.SelectionForeColor = Color.White;
			dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
			DataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
			DataGrid.RowHeadersWidth = 32;
			dataGridViewCellStyle15.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle15.ForeColor = Color.Black;
			DataGrid.RowsDefaultCellStyle = dataGridViewCellStyle15;
			DataGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
			DataGrid.Size = new Size(1100, 468);
			DataGrid.TabIndex = 1;
			// 
			// NameCol
			// 
			NameCol.DataPropertyName = "Name";
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			NameCol.DefaultCellStyle = dataGridViewCellStyle3;
			NameCol.HeaderText = "Name";
			NameCol.Name = "NameCol";
			NameCol.ToolTipText = "Enter the name for this entry,";
			NameCol.Width = 200;
			// 
			// DescCol
			// 
			DescCol.DataPropertyName = "Description";
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			DescCol.DefaultCellStyle = dataGridViewCellStyle4;
			DescCol.HeaderText = "Description";
			DescCol.Name = "DescCol";
			DescCol.ToolTipText = "Enter a description for this entry.";
			DescCol.Width = 103;
			// 
			// UrlCol
			// 
			UrlCol.ActiveLinkColor = Color.Blue;
			UrlCol.DataPropertyName = "Url";
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
			UrlCol.DefaultCellStyle = dataGridViewCellStyle5;
			UrlCol.HeaderText = "URL";
			UrlCol.LinkBehavior = LinkBehavior.AlwaysUnderline;
			UrlCol.Name = "UrlCol";
			UrlCol.Resizable = DataGridViewTriState.True;
			UrlCol.SortMode = DataGridViewColumnSortMode.Automatic;
			UrlCol.ToolTipText = "Enter the web address (URL) used to log in to this entry.";
			UrlCol.VisitedLinkColor = Color.Navy;
			UrlCol.Width = 300;
			// 
			// UserIdCol
			// 
			UserIdCol.DataPropertyName = "UserId";
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
			UserIdCol.DefaultCellStyle = dataGridViewCellStyle6;
			UserIdCol.HeaderText = "User ID";
			UserIdCol.Name = "UserIdCol";
			UserIdCol.ToolTipText = "Enter the User ID you use to log in to this entry.";
			UserIdCol.Width = 150;
			// 
			// PasswordCol
			// 
			PasswordCol.DataPropertyName = "Password";
			dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
			PasswordCol.DefaultCellStyle = dataGridViewCellStyle7;
			PasswordCol.HeaderText = "Password";
			PasswordCol.Name = "PasswordCol";
			PasswordCol.ToolTipText = "Enter the password you use to log in to this entry.";
			PasswordCol.Width = 150;
			// 
			// BalanceCol
			// 
			BalanceCol.DataPropertyName = "CurrentBalance";
			dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle8.Format = "C2";
			dataGridViewCellStyle8.NullValue = "$0.00";
			BalanceCol.DefaultCellStyle = dataGridViewCellStyle8;
			BalanceCol.HeaderText = "CurrentBalance";
			BalanceCol.Name = "BalanceCol";
			BalanceCol.ToolTipText = "Enter the current balance, if applicable, in US dollars.";
			BalanceCol.Width = 127;
			// 
			// LastPaidCol
			// 
			LastPaidCol.DataPropertyName = "LastPaid";
			dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle9.Format = "d";
			LastPaidCol.DefaultCellStyle = dataGridViewCellStyle9;
			LastPaidCol.HeaderText = "LastPaid";
			LastPaidCol.Name = "LastPaidCol";
			LastPaidCol.ToolTipText = "Enter the last payment date, if applicable, for this entry.";
			LastPaidCol.Width = 83;
			// 
			// NextDueCol
			// 
			NextDueCol.DataPropertyName = "NextDue";
			dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle10.Format = "d";
			NextDueCol.DefaultCellStyle = dataGridViewCellStyle10;
			NextDueCol.HeaderText = "NextDue";
			NextDueCol.Name = "NextDueCol";
			NextDueCol.ToolTipText = "Enter the next due date for this entry.";
			NextDueCol.Width = 87;
			// 
			// AvailableCol
			// 
			AvailableCol.DataPropertyName = "Available";
			dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle11.Format = "C2";
			dataGridViewCellStyle11.NullValue = "$0.00";
			AvailableCol.DefaultCellStyle = dataGridViewCellStyle11;
			AvailableCol.HeaderText = "Available";
			AvailableCol.Name = "AvailableCol";
			AvailableCol.ToolTipText = "Enter the available amount, if applicable, in US dollars.";
			AvailableCol.Width = 90;
			// 
			// MinimumDueCol
			// 
			MinimumDueCol.DataPropertyName = "MinimumDue";
			dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle12.Format = "C2";
			dataGridViewCellStyle12.NullValue = "$0.00";
			MinimumDueCol.DefaultCellStyle = dataGridViewCellStyle12;
			MinimumDueCol.HeaderText = "MinimumDue";
			MinimumDueCol.Name = "MinimumDueCol";
			MinimumDueCol.ToolTipText = "Enter the minimum due, if applicable, in US dollars.";
			MinimumDueCol.Width = 118;
			// 
			// DsProvider
			// 
			DsProvider.DataSource = typeof(Ops.GeneralData);
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
			// GeneralDataControl
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(DataGrid);
			Controls.Add(ActionBar);
			Margin = new Padding(4, 5, 4, 5);
			Name = "GeneralDataControl";
			Size = new Size(1100, 500);
			((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
			((System.ComponentModel.ISupportInitialize)DsProvider).EndInit();
			ResumeLayout(false);
		}

		#endregion
		private BindingSource DsProvider;
		private DataGridView DataGrid;
		private DataGridViewTextBoxColumn NameCol;
		private DataGridViewTextBoxColumn DescCol;
		private DataGridViewLinkColumn UrlCol;
		private DataGridViewTextBoxColumn UserIdCol;
		private DataGridViewTextBoxColumn PasswordCol;
		private DataGridViewTextBoxColumn BalanceCol;
		private DataGridViewTextBoxColumn LastPaidCol;
		private DataGridViewTextBoxColumn NextDueCol;
		private DataGridViewTextBoxColumn AvailableCol;
		private DataGridViewTextBoxColumn MinimumDueCol;
		private AddEditRemoveToolbar ActionBar;
	}
}
