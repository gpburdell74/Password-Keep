namespace PasswordKeep.UI
{
    partial class IdProviderControl
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
			DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			ActionPanel = new Panel();
			DataGrid = new DataGridView();
			DsProvider = new BindingSource(components);
			identityServiceTypeListBindingSource = new BindingSource(components);
			NameCol = new DataGridViewTextBoxColumn();
			DescCol = new DataGridViewTextBoxColumn();
			IdServiceCol = new DataGridViewComboBoxColumn();
			UrlCol = new DataGridViewLinkColumn();
			UserIdCol = new DataGridViewTextBoxColumn();
			PasswordCol = new DataGridViewTextBoxColumn();
			EmailCol = new DataGridViewTextBoxColumn();
			MfaCol = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
			((System.ComponentModel.ISupportInitialize)DsProvider).BeginInit();
			((System.ComponentModel.ISupportInitialize)identityServiceTypeListBindingSource).BeginInit();
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
			dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 192);
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = Color.Black;
			DataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			DataGrid.AutoGenerateColumns = false;
			DataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = Color.DarkGreen;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = Color.White;
			dataGridViewCellStyle2.SelectionBackColor = Color.YellowGreen;
			dataGridViewCellStyle2.SelectionForeColor = Color.Black;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			DataGrid.Columns.AddRange(new DataGridViewColumn[] { NameCol, DescCol, IdServiceCol, UrlCol, UserIdCol, PasswordCol, EmailCol, MfaCol });
			DataGrid.DataSource = DsProvider;
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = Color.White;
			dataGridViewCellStyle6.Font = new Font("Segoe UI", 9.75F);
			dataGridViewCellStyle6.ForeColor = Color.Black;
			dataGridViewCellStyle6.SelectionBackColor = Color.Green;
			dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
			DataGrid.DefaultCellStyle = dataGridViewCellStyle6;
			DataGrid.Dock = DockStyle.Fill;
			DataGrid.EditMode = DataGridViewEditMode.EditOnEnter;
			DataGrid.EnableHeadersVisualStyles = false;
			DataGrid.Location = new Point(0, 0);
			DataGrid.Name = "DataGrid";
			DataGrid.Size = new Size(1100, 468);
			DataGrid.TabIndex = 1;
			// 
			// DsProvider
			// 
			DsProvider.DataSource = typeof(Ops.IdentityProvider);
			// 
			// identityServiceTypeListBindingSource
			// 
			identityServiceTypeListBindingSource.DataSource = typeof(Ops.IdentityServiceSelectionList);
			// 
			// NameCol
			// 
			NameCol.DataPropertyName = "Name";
			NameCol.HeaderText = "Name";
			NameCol.Name = "NameCol";
			NameCol.Width = 150;
			// 
			// DescCol
			// 
			DescCol.DataPropertyName = "Description";
			DescCol.HeaderText = "Description";
			DescCol.Name = "DescCol";
			DescCol.Width = 200;
			// 
			// IdServiceCol
			// 
			IdServiceCol.DataPropertyName = "IdentityService";
			IdServiceCol.DataSource = identityServiceTypeListBindingSource;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			IdServiceCol.DefaultCellStyle = dataGridViewCellStyle3;
			IdServiceCol.DisplayMember = "Name";
			IdServiceCol.HeaderText = "Identity Service Provider";
			IdServiceCol.Name = "IdServiceCol";
			IdServiceCol.Resizable = DataGridViewTriState.True;
			IdServiceCol.SortMode = DataGridViewColumnSortMode.Automatic;
			IdServiceCol.ValueMember = "Service";
			IdServiceCol.Width = 200;
			// 
			// UrlCol
			// 
			UrlCol.ActiveLinkColor = Color.Turquoise;
			UrlCol.DataPropertyName = "Url";
			UrlCol.HeaderText = "Url";
			UrlCol.Name = "UrlCol";
			UrlCol.Resizable = DataGridViewTriState.True;
			UrlCol.SortMode = DataGridViewColumnSortMode.Automatic;
			UrlCol.Width = 300;
			// 
			// UserIdCol
			// 
			UserIdCol.DataPropertyName = "UserId";
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			UserIdCol.DefaultCellStyle = dataGridViewCellStyle4;
			UserIdCol.HeaderText = "User Id";
			UserIdCol.Name = "UserIdCol";
			UserIdCol.Width = 200;
			// 
			// PasswordCol
			// 
			PasswordCol.DataPropertyName = "Password";
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
			PasswordCol.DefaultCellStyle = dataGridViewCellStyle5;
			PasswordCol.HeaderText = "Password";
			PasswordCol.Name = "PasswordCol";
			PasswordCol.Width = 200;
			// 
			// EmailCol
			// 
			EmailCol.DataPropertyName = "AssociatedEmail";
			EmailCol.HeaderText = "Associated Email";
			EmailCol.Name = "EmailCol";
			// 
			// MfaCol
			// 
			MfaCol.DataPropertyName = "MFAPhoneNumber";
			MfaCol.HeaderText = "MFA Phone Number";
			MfaCol.Name = "MfaCol";
			// 
			// IdProviderControl
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(DataGrid);
			Controls.Add(ActionPanel);
			Margin = new Padding(4, 5, 4, 5);
			Name = "IdProviderControl";
			Size = new Size(1100, 500);
			((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
			((System.ComponentModel.ISupportInitialize)DsProvider).EndInit();
			((System.ComponentModel.ISupportInitialize)identityServiceTypeListBindingSource).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Panel ActionPanel;
        private DataGridView DataGrid;
        private BindingSource DsProvider;
		private DataGridViewTextBoxColumn NameCol;
		private DataGridViewTextBoxColumn DescCol;
		private DataGridViewComboBoxColumn IdServiceCol;
		private BindingSource identityServiceTypeListBindingSource;
		private DataGridViewLinkColumn UrlCol;
		private DataGridViewTextBoxColumn UserIdCol;
		private DataGridViewTextBoxColumn PasswordCol;
		private DataGridViewTextBoxColumn EmailCol;
		private DataGridViewTextBoxColumn MfaCol;
	}
}
