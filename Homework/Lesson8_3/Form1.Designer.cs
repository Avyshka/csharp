
namespace Lesson8_3
{
    partial class Form1
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lbxDatabase = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxAnswer = new System.Windows.Forms.CheckBox();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LightGreen;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(784, 80);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add question";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.IndianRed;
            this.btnRemove.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRemove.ForeColor = System.Drawing.Color.MistyRose;
            this.btnRemove.Location = new System.Drawing.Point(0, 80);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(784, 40);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove question";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtQuestion
            // 
            this.txtQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.txtQuestion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtQuestion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtQuestion.ForeColor = System.Drawing.Color.Yellow;
            this.txtQuestion.Location = new System.Drawing.Point(0, 24);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(784, 99);
            this.txtQuestion.TabIndex = 4;
            this.txtQuestion.TextChanged += new System.EventHandler(this.txtQuestion_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.BackColor = System.Drawing.Color.White;
            this.menuFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuNew,
            this.subMenuOpen,
            this.subMenuSave,
            this.subMenuSaveAs,
            this.toolStripSeparator1,
            this.subMenuExit});
            this.menuFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "File";
            // 
            // subMenuNew
            // 
            this.subMenuNew.BackColor = System.Drawing.Color.White;
            this.subMenuNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.subMenuNew.Name = "subMenuNew";
            this.subMenuNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.subMenuNew.Size = new System.Drawing.Size(146, 22);
            this.subMenuNew.Text = "New";
            this.subMenuNew.Click += new System.EventHandler(this.subMenuNew_Click);
            // 
            // subMenuOpen
            // 
            this.subMenuOpen.BackColor = System.Drawing.Color.White;
            this.subMenuOpen.Name = "subMenuOpen";
            this.subMenuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.subMenuOpen.Size = new System.Drawing.Size(146, 22);
            this.subMenuOpen.Text = "Open";
            this.subMenuOpen.Click += new System.EventHandler(this.subMenuOpen_Click);
            // 
            // subMenuSave
            // 
            this.subMenuSave.BackColor = System.Drawing.Color.White;
            this.subMenuSave.Name = "subMenuSave";
            this.subMenuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.subMenuSave.Size = new System.Drawing.Size(146, 22);
            this.subMenuSave.Text = "Save";
            this.subMenuSave.Click += new System.EventHandler(this.subMenuSave_Click);
            // 
            // subMenuSaveAs
            // 
            this.subMenuSaveAs.Name = "subMenuSaveAs";
            this.subMenuSaveAs.Size = new System.Drawing.Size(146, 22);
            this.subMenuSaveAs.Text = "Save As...";
            this.subMenuSaveAs.Click += new System.EventHandler(this.subMenuSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.White;
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // subMenuExit
            // 
            this.subMenuExit.BackColor = System.Drawing.Color.White;
            this.subMenuExit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.subMenuExit.Name = "subMenuExit";
            this.subMenuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.subMenuExit.Size = new System.Drawing.Size(146, 22);
            this.subMenuExit.Text = "Exit";
            this.subMenuExit.Click += new System.EventHandler(this.subMenuExit_Click);
            // 
            // lbxDatabase
            // 
            this.lbxDatabase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbxDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxDatabase.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbxDatabase.FormattingEnabled = true;
            this.lbxDatabase.ItemHeight = 21;
            this.lbxDatabase.Location = new System.Drawing.Point(0, 123);
            this.lbxDatabase.Margin = new System.Windows.Forms.Padding(8);
            this.lbxDatabase.Name = "lbxDatabase";
            this.lbxDatabase.Size = new System.Drawing.Size(784, 438);
            this.lbxDatabase.TabIndex = 7;
            this.lbxDatabase.SelectedIndexChanged += new System.EventHandler(this.lbxDatabase_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 441);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 120);
            this.panel1.TabIndex = 9;
            // 
            // cbxAnswer
            // 
            this.cbxAnswer.AutoSize = true;
            this.cbxAnswer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.cbxAnswer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbxAnswer.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.cbxAnswer.Location = new System.Drawing.Point(714, 100);
            this.cbxAnswer.Name = "cbxAnswer";
            this.cbxAnswer.Size = new System.Drawing.Size(73, 23);
            this.cbxAnswer.TabIndex = 3;
            this.cbxAnswer.Text = "Beard!";
            this.cbxAnswer.UseVisualStyleBackColor = false;
            this.cbxAnswer.CheckedChanged += new System.EventHandler(this.cbxAnswer_CheckedChanged);
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(121, 20);
            this.menuAbout.Text = "About the program";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.cbxAnswer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbxDatabase);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Beard! A lie!";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem subMenuNew;
        private System.Windows.Forms.ToolStripMenuItem subMenuOpen;
        private System.Windows.Forms.ToolStripMenuItem subMenuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem subMenuExit;
        private System.Windows.Forms.ListBox lbxDatabase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbxAnswer;
        private System.Windows.Forms.ToolStripMenuItem subMenuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
    }
}

