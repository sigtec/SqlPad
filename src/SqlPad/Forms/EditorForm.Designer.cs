using FastColoredTextBoxNS;

namespace SqlPad.Forms
{
  partial class EditorForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            toolStrip = new ToolStrip();
            toolStripSplitButtonSave = new ToolStripSplitButton();
            saveCopyAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButtonRun = new ToolStripButton();
            toolStripButtonUseTransaction = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButtonLimit = new ToolStripButton();
            toolStripTextBoxLimitRows = new ToolStripTextBox();
            statusStrip = new StatusStrip();
            splitContainer = new SplitContainer();
            editorTextBox = new FastColoredTextBox();
            tabControl = new TabControl();
            tabPageMessages = new TabPage();
            textBoxMessages = new TextBox();
            toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)editorTextBox).BeginInit();
            tabControl.SuspendLayout();
            tabPageMessages.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripSplitButtonSave, toolStripSeparator1, toolStripButtonRun, toolStripButtonUseTransaction, toolStripSeparator2, toolStripButtonLimit, toolStripTextBoxLimitRows });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(800, 25);
            toolStrip.TabIndex = 0;
            toolStrip.Text = "toolStrip1";
            // 
            // toolStripSplitButtonSave
            // 
            toolStripSplitButtonSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripSplitButtonSave.DropDownItems.AddRange(new ToolStripItem[] { saveCopyAsToolStripMenuItem });
            toolStripSplitButtonSave.Image = (Image)resources.GetObject("toolStripSplitButtonSave.Image");
            toolStripSplitButtonSave.ImageTransparentColor = Color.Magenta;
            toolStripSplitButtonSave.Name = "toolStripSplitButtonSave";
            toolStripSplitButtonSave.Size = new Size(32, 22);
            toolStripSplitButtonSave.Text = "Save";
            toolStripSplitButtonSave.ButtonClick += toolStripSplitButtonSave_ButtonClick;
            // 
            // saveCopyAsToolStripMenuItem
            // 
            saveCopyAsToolStripMenuItem.Image = (Image)resources.GetObject("saveCopyAsToolStripMenuItem.Image");
            saveCopyAsToolStripMenuItem.Name = "saveCopyAsToolStripMenuItem";
            saveCopyAsToolStripMenuItem.Size = new Size(154, 22);
            saveCopyAsToolStripMenuItem.Text = "Save Copy As...";
            saveCopyAsToolStripMenuItem.Click += saveCopyAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripButtonRun
            // 
            toolStripButtonRun.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonRun.Image = (Image)resources.GetObject("toolStripButtonRun.Image");
            toolStripButtonRun.ImageTransparentColor = Color.Magenta;
            toolStripButtonRun.Name = "toolStripButtonRun";
            toolStripButtonRun.Size = new Size(23, 22);
            toolStripButtonRun.Text = "Run";
            toolStripButtonRun.ToolTipText = "Run (Selection/Current Statement)";
            toolStripButtonRun.Click += toolStripButtonRun_Click;
            // 
            // toolStripButtonUseTransaction
            // 
            toolStripButtonUseTransaction.CheckOnClick = true;
            toolStripButtonUseTransaction.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonUseTransaction.Image = (Image)resources.GetObject("toolStripButtonUseTransaction.Image");
            toolStripButtonUseTransaction.ImageTransparentColor = Color.Magenta;
            toolStripButtonUseTransaction.Name = "toolStripButtonUseTransaction";
            toolStripButtonUseTransaction.Size = new Size(23, 22);
            toolStripButtonUseTransaction.Text = "use Transaction";
            toolStripButtonUseTransaction.ToolTipText = "Use Transaction";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // toolStripButtonLimit
            // 
            toolStripButtonLimit.Checked = true;
            toolStripButtonLimit.CheckOnClick = true;
            toolStripButtonLimit.CheckState = CheckState.Checked;
            toolStripButtonLimit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonLimit.Image = (Image)resources.GetObject("toolStripButtonLimit.Image");
            toolStripButtonLimit.ImageTransparentColor = Color.Magenta;
            toolStripButtonLimit.Name = "toolStripButtonLimit";
            toolStripButtonLimit.Size = new Size(23, 22);
            toolStripButtonLimit.Text = "Limit Result to First Rows";
            toolStripButtonLimit.CheckedChanged += toolStripButtonLimit_CheckedChanged;
            // 
            // toolStripTextBoxLimitRows
            // 
            toolStripTextBoxLimitRows.MaxLength = 5;
            toolStripTextBoxLimitRows.Name = "toolStripTextBoxLimitRows";
            toolStripTextBoxLimitRows.Size = new Size(50, 25);
            toolStripTextBoxLimitRows.Text = "250";
            toolStripTextBoxLimitRows.TextBoxTextAlign = HorizontalAlignment.Right;
            toolStripTextBoxLimitRows.KeyPress += toolStripTextBoxLimitRows_KeyPress;
            // 
            // statusStrip
            // 
            statusStrip.Location = new Point(0, 428);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(800, 22);
            statusStrip.TabIndex = 1;
            statusStrip.Text = "statusStrip1";
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 25);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(editorTextBox);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(tabControl);
            splitContainer.Size = new Size(800, 403);
            splitContainer.SplitterDistance = 266;
            splitContainer.TabIndex = 2;
            // 
            // editorTextBox
            // 
            editorTextBox.AutoCompleteBracketsList = new char[]
    {
    '(',
    ')',
    '{',
    '}',
    '[',
    ']',
    '"',
    '"',
    '\'',
    '\''
    };
            editorTextBox.AutoIndentCharsPatterns = "";
            editorTextBox.AutoScrollMinSize = new Size(25, 15);
            editorTextBox.BackBrush = null;
            editorTextBox.CharHeight = 15;
            editorTextBox.CharWidth = 7;
            editorTextBox.CommentPrefix = "--";
            editorTextBox.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            editorTextBox.Dock = DockStyle.Fill;
            editorTextBox.Font = new Font("Consolas", 9.75F);
            //editorTextBox.Hotkeys = resources.GetString("editorTextBox.Hotkeys");
            editorTextBox.IsReplaceMode = false;
            editorTextBox.Language = Language.SQL;
            editorTextBox.LeftBracket = '(';
            editorTextBox.Location = new Point(0, 0);
            editorTextBox.Name = "editorTextBox";
            editorTextBox.Paddings = new Padding(0);
            editorTextBox.RightBracket = ')';
            editorTextBox.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            editorTextBox.ServiceColors = (ServiceColors)resources.GetObject("editorTextBox.ServiceColors");
            editorTextBox.Size = new Size(800, 266);
            editorTextBox.TabIndex = 0;
            editorTextBox.Zoom = 100;
            editorTextBox.KeyDown += editorTextBox_KeyDown;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageMessages);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(800, 133);
            tabControl.TabIndex = 0;
            // 
            // tabPageMessages
            // 
            tabPageMessages.Controls.Add(textBoxMessages);
            tabPageMessages.Location = new Point(4, 24);
            tabPageMessages.Name = "tabPageMessages";
            tabPageMessages.Padding = new Padding(3);
            tabPageMessages.Size = new Size(792, 105);
            tabPageMessages.TabIndex = 1;
            tabPageMessages.Text = "Messages";
            tabPageMessages.UseVisualStyleBackColor = true;
            // 
            // textBoxMessages
            // 
            textBoxMessages.Dock = DockStyle.Fill;
            textBoxMessages.Font = new Font("Consolas", 9.75F);
            textBoxMessages.Location = new Point(3, 3);
            textBoxMessages.Multiline = true;
            textBoxMessages.Name = "textBoxMessages";
            textBoxMessages.ReadOnly = true;
            textBoxMessages.ScrollBars = ScrollBars.Both;
            textBoxMessages.Size = new Size(786, 99);
            textBoxMessages.TabIndex = 0;
            textBoxMessages.WordWrap = false;
            // 
            // EditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer);
            Controls.Add(statusStrip);
            Controls.Add(toolStrip);
            Name = "EditorForm";
            Text = "EditorForm";
            WindowState = FormWindowState.Maximized;
            Shown += EditorForm_Shown;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)editorTextBox).EndInit();
            tabControl.ResumeLayout(false);
            tabPageMessages.ResumeLayout(false);
            tabPageMessages.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip;
    private StatusStrip statusStrip;
    private SplitContainer splitContainer;
    private FastColoredTextBox editorTextBox;
    private TabControl tabControl;
    private TabPage tabPageMessages;
    private ToolStripButton toolStripButtonRun;
    private TextBox textBoxMessages;
    private ToolStripButton toolStripButtonUseTransaction;
    private ToolStripSplitButton toolStripSplitButtonSave;
    private ToolStripMenuItem saveCopyAsToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButtonLimit;
        private ToolStripTextBox toolStripTextBoxLimitRows;
    }
}