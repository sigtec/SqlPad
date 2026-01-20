namespace SqlPad.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip = new MenuStrip();
            sidebarPanel = new Panel();
            tabControlSidebar = new TabControl();
            tabPageFiles = new TabPage();
            treeViewFiles = new TreeView();
            imageList = new ImageList(components);
            tabPageParameters = new TabPage();
            propertyGridParameters = new PropertyGrid();
            toolStripSidebar = new ToolStrip();
            toolStripComboBoxConnection = new ToolStripComboBox();
            toolStripButtonConnect = new ToolStripButton();
            splitter = new Splitter();
            contextMenuTreeViewDirectoryNodes = new ContextMenuStrip(components);
            toolStripMenuItemReload = new ToolStripMenuItem();
            openInWindowsExplorerToolStripMenuItem = new ToolStripMenuItem();
            addNewFileToolStripMenuItem = new ToolStripMenuItem();
            contextMenuTreeViewFileNodes = new ContextMenuStrip(components);
            openInTerminalToolStripMenuItem = new ToolStripMenuItem();
            sidebarPanel.SuspendLayout();
            tabControlSidebar.SuspendLayout();
            tabPageFiles.SuspendLayout();
            tabPageParameters.SuspendLayout();
            toolStripSidebar.SuspendLayout();
            contextMenuTreeViewDirectoryNodes.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // sidebarPanel
            // 
            sidebarPanel.Controls.Add(tabControlSidebar);
            sidebarPanel.Controls.Add(toolStripSidebar);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 24);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(200, 426);
            sidebarPanel.TabIndex = 1;
            // 
            // tabControlSidebar
            // 
            tabControlSidebar.Alignment = TabAlignment.Bottom;
            tabControlSidebar.Controls.Add(tabPageFiles);
            tabControlSidebar.Controls.Add(tabPageParameters);
            tabControlSidebar.Dock = DockStyle.Fill;
            tabControlSidebar.Location = new Point(0, 25);
            tabControlSidebar.Name = "tabControlSidebar";
            tabControlSidebar.SelectedIndex = 0;
            tabControlSidebar.Size = new Size(200, 401);
            tabControlSidebar.TabIndex = 1;
            // 
            // tabPageFiles
            // 
            tabPageFiles.Controls.Add(treeViewFiles);
            tabPageFiles.Location = new Point(4, 4);
            tabPageFiles.Name = "tabPageFiles";
            tabPageFiles.Padding = new Padding(3);
            tabPageFiles.Size = new Size(192, 373);
            tabPageFiles.TabIndex = 0;
            tabPageFiles.Text = "Files";
            tabPageFiles.UseVisualStyleBackColor = true;
            // 
            // treeViewFiles
            // 
            treeViewFiles.Dock = DockStyle.Fill;
            treeViewFiles.ImageIndex = 0;
            treeViewFiles.ImageList = imageList;
            treeViewFiles.LabelEdit = true;
            treeViewFiles.Location = new Point(3, 3);
            treeViewFiles.Name = "treeViewFiles";
            treeViewFiles.SelectedImageIndex = 0;
            treeViewFiles.Size = new Size(186, 367);
            treeViewFiles.StateImageList = imageList;
            treeViewFiles.TabIndex = 0;
            treeViewFiles.AfterLabelEdit += treeViewFiles_AfterLabelEdit;
            treeViewFiles.AfterCollapse += treeViewFiles_AfterCollapse;
            treeViewFiles.BeforeExpand += treeViewFiles_BeforeExpand;
            treeViewFiles.AfterExpand += treeViewFiles_AfterExpand;
            treeViewFiles.NodeMouseClick += treeViewFiles_NodeMouseClick;
            treeViewFiles.NodeMouseDoubleClick += treeViewFiles_NodeMouseDoubleClick;
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageStream = (ImageListStreamer)resources.GetObject("imageList.ImageStream");
            imageList.TransparentColor = Color.Transparent;
            imageList.Images.SetKeyName(0, "AddTextFile.png");
            imageList.Images.SetKeyName(1, "Database.png");
            imageList.Images.SetKeyName(2, "ExcelWorksheetView.png");
            imageList.Images.SetKeyName(3, "FolderClosed.png");
            imageList.Images.SetKeyName(4, "FolderOpened.png");
            imageList.Images.SetKeyName(5, "JsonFile.png");
            imageList.Images.SetKeyName(6, "MarkdownFile.png");
            imageList.Images.SetKeyName(7, "ResultsToGrid.png");
            imageList.Images.SetKeyName(8, "ResultsToTextFile.png");
            imageList.Images.SetKeyName(9, "TextFile.png");
            imageList.Images.SetKeyName(10, "XmlFile.png");
            imageList.Images.SetKeyName(11, "Lock.png");
            // 
            // tabPageParameters
            // 
            tabPageParameters.Controls.Add(propertyGridParameters);
            tabPageParameters.Location = new Point(4, 4);
            tabPageParameters.Name = "tabPageParameters";
            tabPageParameters.Padding = new Padding(3);
            tabPageParameters.Size = new Size(192, 373);
            tabPageParameters.TabIndex = 1;
            tabPageParameters.Text = "Parameters";
            tabPageParameters.UseVisualStyleBackColor = true;
            // 
            // propertyGridParameters
            // 
            propertyGridParameters.BackColor = SystemColors.Control;
            propertyGridParameters.Dock = DockStyle.Fill;
            propertyGridParameters.Location = new Point(3, 3);
            propertyGridParameters.Name = "propertyGridParameters";
            propertyGridParameters.Size = new Size(186, 367);
            propertyGridParameters.TabIndex = 0;
            // 
            // toolStripSidebar
            // 
            toolStripSidebar.GripStyle = ToolStripGripStyle.Hidden;
            toolStripSidebar.Items.AddRange(new ToolStripItem[] { toolStripComboBoxConnection, toolStripButtonConnect });
            toolStripSidebar.Location = new Point(0, 0);
            toolStripSidebar.Name = "toolStripSidebar";
            toolStripSidebar.Size = new Size(200, 25);
            toolStripSidebar.TabIndex = 0;
            toolStripSidebar.Text = "toolStrip1";
            // 
            // toolStripComboBoxConnection
            // 
            toolStripComboBoxConnection.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBoxConnection.Name = "toolStripComboBoxConnection";
            toolStripComboBoxConnection.Size = new Size(121, 25);
            // 
            // toolStripButtonConnect
            // 
            toolStripButtonConnect.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonConnect.Image = (Image)resources.GetObject("toolStripButtonConnect.Image");
            toolStripButtonConnect.ImageTransparentColor = Color.Magenta;
            toolStripButtonConnect.Name = "toolStripButtonConnect";
            toolStripButtonConnect.Size = new Size(23, 22);
            toolStripButtonConnect.Text = "Connect";
            toolStripButtonConnect.CheckedChanged += toolStripButtonConnect_CheckedChanged;
            toolStripButtonConnect.Click += toolStripButtonConnect_Click;
            // 
            // splitter
            // 
            splitter.Location = new Point(200, 24);
            splitter.Name = "splitter";
            splitter.Size = new Size(3, 426);
            splitter.TabIndex = 2;
            splitter.TabStop = false;
            // 
            // contextMenuTreeViewDirectoryNodes
            // 
            contextMenuTreeViewDirectoryNodes.Items.AddRange(new ToolStripItem[] { toolStripMenuItemReload, openInWindowsExplorerToolStripMenuItem, openInTerminalToolStripMenuItem, addNewFileToolStripMenuItem });
            contextMenuTreeViewDirectoryNodes.Name = "contextMenuFilesTreeView";
            contextMenuTreeViewDirectoryNodes.Size = new Size(215, 114);
            // 
            // toolStripMenuItemReload
            // 
            toolStripMenuItemReload.Name = "toolStripMenuItemReload";
            toolStripMenuItemReload.Size = new Size(214, 22);
            toolStripMenuItemReload.Text = "Reload";
            toolStripMenuItemReload.Click += toolStripMenuItemReload_Click;
            // 
            // openInWindowsExplorerToolStripMenuItem
            // 
            openInWindowsExplorerToolStripMenuItem.Name = "openInWindowsExplorerToolStripMenuItem";
            openInWindowsExplorerToolStripMenuItem.Size = new Size(214, 22);
            openInWindowsExplorerToolStripMenuItem.Text = "Open in Windows Explorer";
            openInWindowsExplorerToolStripMenuItem.Click += openInWindowsExplorerToolStripMenuItem_Click;
            // 
            // addNewFileToolStripMenuItem
            // 
            addNewFileToolStripMenuItem.Name = "addNewFileToolStripMenuItem";
            addNewFileToolStripMenuItem.Size = new Size(214, 22);
            addNewFileToolStripMenuItem.Text = "Add new File";
            addNewFileToolStripMenuItem.Click += addNewFileToolStripMenuItem_Click;
            // 
            // contextMenuTreeViewFileNodes
            // 
            contextMenuTreeViewFileNodes.Name = "contextMenuTreeViewFileNodes";
            contextMenuTreeViewFileNodes.Size = new Size(61, 4);
            // 
            // openInTerminalToolStripMenuItem
            // 
            openInTerminalToolStripMenuItem.Name = "openInTerminalToolStripMenuItem";
            openInTerminalToolStripMenuItem.Size = new Size(214, 22);
            openInTerminalToolStripMenuItem.Text = "Open in Terminal";
            openInTerminalToolStripMenuItem.Click += openInTerminalToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitter);
            Controls.Add(sidebarPanel);
            Controls.Add(menuStrip);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            Text = "SqlPad";
            Shown += MainForm_Shown;
            sidebarPanel.ResumeLayout(false);
            sidebarPanel.PerformLayout();
            tabControlSidebar.ResumeLayout(false);
            tabPageFiles.ResumeLayout(false);
            tabPageParameters.ResumeLayout(false);
            toolStripSidebar.ResumeLayout(false);
            toolStripSidebar.PerformLayout();
            contextMenuTreeViewDirectoryNodes.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private Panel sidebarPanel;
        private Splitter splitter;
        private TabControl tabControlSidebar;
        private TabPage tabPageFiles;
        private TabPage tabPageParameters;
        private ToolStrip toolStripSidebar;
        private TreeView treeViewFiles;
        private ContextMenuStrip contextMenuTreeViewDirectoryNodes;
        private ToolStripMenuItem toolStripMenuItemReload;
        private ImageList imageList;
        private ToolStripMenuItem openInWindowsExplorerToolStripMenuItem;
        private PropertyGrid propertyGridParameters;
        private ToolStripMenuItem addNewFileToolStripMenuItem;
        private ToolStripComboBox toolStripComboBoxConnection;
        private ToolStripButton toolStripButtonConnect;
        private ContextMenuStrip contextMenuTreeViewFileNodes;
        private ToolStripMenuItem openInTerminalToolStripMenuItem;
    }
}
