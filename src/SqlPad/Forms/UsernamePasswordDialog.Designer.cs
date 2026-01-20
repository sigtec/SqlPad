namespace SqlPad.Forms
{
    partial class UsernamePasswordDialog
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
            tableLayoutPanel = new TableLayoutPanel();
            labelUserName = new Label();
            labelPassword = new Label();
            textBoxUserName = new TextBox();
            textBoxPassword = new TextBox();
            okButton = new Button();
            checkBoxRememberCredentials = new CheckBox();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.Controls.Add(labelUserName, 0, 0);
            tableLayoutPanel.Controls.Add(labelPassword, 0, 1);
            tableLayoutPanel.Controls.Add(textBoxUserName, 1, 0);
            tableLayoutPanel.Controls.Add(textBoxPassword, 1, 1);
            tableLayoutPanel.Controls.Add(okButton, 1, 4);
            tableLayoutPanel.Controls.Add(checkBoxRememberCredentials, 1, 3);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.Padding = new Padding(6);
            tableLayoutPanel.RowCount = 5;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Size = new Size(396, 187);
            tableLayoutPanel.TabIndex = 0;
            // 
            // labelUserName
            // 
            labelUserName.AutoSize = true;
            labelUserName.Location = new Point(9, 6);
            labelUserName.Name = "labelUserName";
            labelUserName.Size = new Size(63, 15);
            labelUserName.TabIndex = 0;
            labelUserName.Text = "Username:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(9, 40);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(60, 15);
            labelPassword.TabIndex = 1;
            labelPassword.Text = "Password:";
            // 
            // textBoxUserName
            // 
            textBoxUserName.Dock = DockStyle.Fill;
            textBoxUserName.Location = new Point(129, 9);
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(258, 23);
            textBoxUserName.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Dock = DockStyle.Fill;
            textBoxPassword.Location = new Point(129, 43);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(258, 23);
            textBoxPassword.TabIndex = 3;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // okButton
            // 
            okButton.DialogResult = DialogResult.OK;
            okButton.Location = new Point(129, 145);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 5;
            okButton.Text = "Ok";
            okButton.UseVisualStyleBackColor = true;
            // 
            // checkBoxRememberCredentials
            // 
            checkBoxRememberCredentials.AutoSize = true;
            checkBoxRememberCredentials.Location = new Point(129, 111);
            checkBoxRememberCredentials.Name = "checkBoxRememberCredentials";
            checkBoxRememberCredentials.Size = new Size(213, 19);
            checkBoxRememberCredentials.TabIndex = 4;
            checkBoxRememberCredentials.Text = "remember Username and Password";
            checkBoxRememberCredentials.UseVisualStyleBackColor = true;
            // 
            // UsernamePasswordDialog
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(396, 187);
            Controls.Add(tableLayoutPanel);
            Name = "UsernamePasswordDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "UsernamePasswordDialog";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Label labelUserName;
        private Label labelPassword;
        private TextBox textBoxUserName;
        private TextBox textBoxPassword;
        private Button okButton;
        private CheckBox checkBoxRememberCredentials;
    }
}