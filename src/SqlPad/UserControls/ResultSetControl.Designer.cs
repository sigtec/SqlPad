namespace SqlPad.UserControls
{
    partial class ResultSetControl
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultSetControl));
            toolStripDataGrid = new ToolStrip();
            toolStripButtonCopyToClipboard = new ToolStripButton();
            toolStripSplitButtonCopy = new ToolStripSplitButton();
            copyColumnNamesToolStripMenuItem = new ToolStripMenuItem();
            toolStripDropDownButtonSaveResults = new ToolStripDropDownButton();
            excelFileToolStripMenuItem = new ToolStripMenuItem();
            dataGridView = new DataGridView();
            toolStripDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // toolStripDataGrid
            // 
            toolStripDataGrid.GripStyle = ToolStripGripStyle.Hidden;
            toolStripDataGrid.Items.AddRange(new ToolStripItem[] { toolStripButtonCopyToClipboard, toolStripSplitButtonCopy, toolStripDropDownButtonSaveResults });
            toolStripDataGrid.Location = new Point(0, 0);
            toolStripDataGrid.Name = "toolStripDataGrid";
            toolStripDataGrid.Size = new Size(1066, 25);
            toolStripDataGrid.TabIndex = 1;
            toolStripDataGrid.Text = "toolStrip1";
            // 
            // toolStripButtonCopyToClipboard
            // 
            toolStripButtonCopyToClipboard.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonCopyToClipboard.Image = (Image)resources.GetObject("toolStripButtonCopyToClipboard.Image");
            toolStripButtonCopyToClipboard.ImageTransparentColor = Color.Magenta;
            toolStripButtonCopyToClipboard.Name = "toolStripButtonCopyToClipboard";
            toolStripButtonCopyToClipboard.Size = new Size(23, 22);
            toolStripButtonCopyToClipboard.Text = "copy to Clipboard";
            toolStripButtonCopyToClipboard.Click += toolStripButtonCopyToClipboard_Click;
            // 
            // toolStripSplitButtonCopy
            // 
            toolStripSplitButtonCopy.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripSplitButtonCopy.DropDownItems.AddRange(new ToolStripItem[] { copyColumnNamesToolStripMenuItem });
            toolStripSplitButtonCopy.Image = (Image)resources.GetObject("toolStripSplitButtonCopy.Image");
            toolStripSplitButtonCopy.ImageTransparentColor = Color.Magenta;
            toolStripSplitButtonCopy.Name = "toolStripSplitButtonCopy";
            toolStripSplitButtonCopy.Size = new Size(32, 22);
            toolStripSplitButtonCopy.Text = "Copy to Clipboard";
            toolStripSplitButtonCopy.ButtonClick += toolStripSplitButtonCopy_ButtonClick;
            // 
            // copyColumnNamesToolStripMenuItem
            // 
            copyColumnNamesToolStripMenuItem.Name = "copyColumnNamesToolStripMenuItem";
            copyColumnNamesToolStripMenuItem.Size = new Size(188, 22);
            copyColumnNamesToolStripMenuItem.Text = "Copy Column Names";
            copyColumnNamesToolStripMenuItem.Click += copyColumnNamesToolStripMenuItem_Click;
            // 
            // toolStripDropDownButtonSaveResults
            // 
            toolStripDropDownButtonSaveResults.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripDropDownButtonSaveResults.DropDownItems.AddRange(new ToolStripItem[] { excelFileToolStripMenuItem });
            toolStripDropDownButtonSaveResults.Image = (Image)resources.GetObject("toolStripDropDownButtonSaveResults.Image");
            toolStripDropDownButtonSaveResults.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButtonSaveResults.Name = "toolStripDropDownButtonSaveResults";
            toolStripDropDownButtonSaveResults.Size = new Size(29, 22);
            toolStripDropDownButtonSaveResults.Text = "Save Result As...";
            // 
            // excelFileToolStripMenuItem
            // 
            excelFileToolStripMenuItem.Name = "excelFileToolStripMenuItem";
            excelFileToolStripMenuItem.Size = new Size(124, 22);
            excelFileToolStripMenuItem.Text = "Excel-File";
            excelFileToolStripMenuItem.Click += excelFileToolStripMenuItem_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView.Location = new Point(0, 25);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView.Size = new Size(1066, 310);
            dataGridView.TabIndex = 2;
            dataGridView.ColumnAdded += dataGridView_ColumnAdded;
            dataGridView.DataBindingComplete += dataGridView_DataBindingComplete;
            dataGridView.DataError += dataGridView_DataError;
            dataGridView.RowHeaderMouseClick += dataGridView_RowHeaderMouseClick;
            dataGridView.KeyDown += dataGridView_KeyDown;
            // 
            // ResultSetControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView);
            Controls.Add(toolStripDataGrid);
            Name = "ResultSetControl";
            Size = new Size(1066, 335);
            Load += ResultSetControl_Load;
            toolStripDataGrid.ResumeLayout(false);
            toolStripDataGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStripDataGrid;
        private ToolStripDropDownButton toolStripDropDownButtonSaveResults;
        private ToolStripMenuItem excelFileToolStripMenuItem;
        private DataGridView dataGridView;
        private ToolStripButton toolStripButtonCopyToClipboard;
        private ToolStripSplitButton toolStripSplitButtonCopy;
        private ToolStripMenuItem copyColumnNamesToolStripMenuItem;
    }
}
