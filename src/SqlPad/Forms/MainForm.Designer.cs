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
            fileToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            selectAllToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            findToolStripMenuItem = new ToolStripMenuItem();
            replaceToolStripMenuItem = new ToolStripMenuItem();
            windowToolStripMenuItem = new ToolStripMenuItem();
            cascadeToolStripMenuItem = new ToolStripMenuItem();
            tileHorizontallyToolStripMenuItem = new ToolStripMenuItem();
            tileVerticallyToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
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
            openInTerminalToolStripMenuItem = new ToolStripMenuItem();
            addNewFileToolStripMenuItem = new ToolStripMenuItem();
            contextMenuTreeViewFileNodes = new ContextMenuStrip(components);
            menuStrip.SuspendLayout();
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
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, windowToolStripMenuItem });
            menuStrip.Location = new Point(3, 3);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(794, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, deleteToolStripMenuItem, selectAllToolStripMenuItem, toolStripSeparator2, undoToolStripMenuItem, redoToolStripMenuItem, toolStripSeparator3, findToolStripMenuItem, replaceToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "&Edit";
            editToolStripMenuItem.DropDownOpening += editToolStripMenuItem_DropDownOpening;
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.Size = new Size(122, 22);
            cutToolStripMenuItem.Text = "Cut";
            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(122, 22);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(122, 22);
            pasteToolStripMenuItem.Text = "Paste";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(122, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.Size = new Size(122, 22);
            selectAllToolStripMenuItem.Text = "Select All";
            selectAllToolStripMenuItem.Click += selectAllToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(119, 6);
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(122, 22);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.Size = new Size(122, 22);
            redoToolStripMenuItem.Text = "Redo";
            redoToolStripMenuItem.Click += redoToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(119, 6);
            // 
            // findToolStripMenuItem
            // 
            findToolStripMenuItem.Name = "findToolStripMenuItem";
            findToolStripMenuItem.Size = new Size(122, 22);
            findToolStripMenuItem.Text = "Find";
            findToolStripMenuItem.Click += findToolStripMenuItem_Click;
            // 
            // replaceToolStripMenuItem
            // 
            replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            replaceToolStripMenuItem.Size = new Size(122, 22);
            replaceToolStripMenuItem.Text = "Replace";
            replaceToolStripMenuItem.Click += replaceToolStripMenuItem_Click;
            // 
            // windowToolStripMenuItem
            // 
            windowToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cascadeToolStripMenuItem, tileHorizontallyToolStripMenuItem, tileVerticallyToolStripMenuItem, toolStripSeparator1 });
            windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            windowToolStripMenuItem.Size = new Size(63, 20);
            windowToolStripMenuItem.Text = "&Window";
            windowToolStripMenuItem.DropDownOpening += windowToolStripMenuItem_DropDownOpening;
            // 
            // cascadeToolStripMenuItem
            // 
            cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            cascadeToolStripMenuItem.Size = new Size(159, 22);
            cascadeToolStripMenuItem.Text = "&Cascade";
            cascadeToolStripMenuItem.Click += cascadeToolStripMenuItem_Click;
            // 
            // tileHorizontallyToolStripMenuItem
            // 
            tileHorizontallyToolStripMenuItem.Name = "tileHorizontallyToolStripMenuItem";
            tileHorizontallyToolStripMenuItem.Size = new Size(159, 22);
            tileHorizontallyToolStripMenuItem.Text = "Tile &Horizontally";
            tileHorizontallyToolStripMenuItem.Click += tileHorizontallyToolStripMenuItem_Click;
            // 
            // tileVerticallyToolStripMenuItem
            // 
            tileVerticallyToolStripMenuItem.Name = "tileVerticallyToolStripMenuItem";
            tileVerticallyToolStripMenuItem.Size = new Size(159, 22);
            tileVerticallyToolStripMenuItem.Text = "Tile &Vertically";
            tileVerticallyToolStripMenuItem.Click += tileVerticallyToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(156, 6);
            // 
            // sidebarPanel
            // 
            sidebarPanel.Controls.Add(tabControlSidebar);
            sidebarPanel.Controls.Add(toolStripSidebar);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(3, 27);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(200, 420);
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
            tabControlSidebar.Size = new Size(200, 395);
            tabControlSidebar.TabIndex = 1;
            // 
            // tabPageFiles
            // 
            tabPageFiles.Controls.Add(treeViewFiles);
            tabPageFiles.Location = new Point(4, 4);
            tabPageFiles.Name = "tabPageFiles";
            tabPageFiles.Padding = new Padding(3);
            tabPageFiles.Size = new Size(192, 367);
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
            treeViewFiles.Size = new Size(186, 361);
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
            splitter.Location = new Point(203, 27);
            splitter.Name = "splitter";
            splitter.Size = new Size(3, 420);
            splitter.TabIndex = 2;
            splitter.TabStop = false;
            // 
            // contextMenuTreeViewDirectoryNodes
            // 
            contextMenuTreeViewDirectoryNodes.Items.AddRange(new ToolStripItem[] { toolStripMenuItemReload, openInWindowsExplorerToolStripMenuItem, openInTerminalToolStripMenuItem, addNewFileToolStripMenuItem });
            contextMenuTreeViewDirectoryNodes.Name = "contextMenuFilesTreeView";
            contextMenuTreeViewDirectoryNodes.Size = new Size(215, 92);
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
            // openInTerminalToolStripMenuItem
            // 
            openInTerminalToolStripMenuItem.Name = "openInTerminalToolStripMenuItem";
            openInTerminalToolStripMenuItem.Size = new Size(214, 22);
            openInTerminalToolStripMenuItem.Text = "Open in Terminal";
            openInTerminalToolStripMenuItem.Click += openInTerminalToolStripMenuItem_Click;
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
            Padding = new Padding(3);
            Text = "SqlPad";
            Shown += MainForm_Shown;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
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
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem windowToolStripMenuItem;
        private ToolStripMenuItem cascadeToolStripMenuItem;
        private ToolStripMenuItem tileHorizontallyToolStripMenuItem;
        private ToolStripMenuItem tileVerticallyToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem findToolStripMenuItem;
        private ToolStripMenuItem replaceToolStripMenuItem;
    }
}
