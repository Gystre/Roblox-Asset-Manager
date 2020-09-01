namespace Roblox_Asset_Manager_by_Kyle
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PanelTop = new System.Windows.Forms.Panel();
            this.ButtonDeleteRow = new System.Windows.Forms.Button();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.ButtonSubmit = new System.Windows.Forms.Button();
            this.TBNotes = new System.Windows.Forms.TextBox();
            this.TBName = new System.Windows.Forms.TextBox();
            this.TBLink = new System.Windows.Forms.TextBox();
            this.LName = new System.Windows.Forms.Label();
            this.LNotes = new System.Windows.Forms.Label();
            this.LLink = new System.Windows.Forms.Label();
            this.ImagePreview = new System.Windows.Forms.PictureBox();
            this.DGDatabase = new System.Windows.Forms.DataGridView();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ToolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGDatabase)).BeginInit();
            this.StatusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTop
            // 
            this.PanelTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelTop.AutoSize = true;
            this.PanelTop.BackColor = System.Drawing.Color.Silver;
            this.PanelTop.Controls.Add(this.ButtonDeleteRow);
            this.PanelTop.Controls.Add(this.ButtonClear);
            this.PanelTop.Controls.Add(this.ButtonSubmit);
            this.PanelTop.Controls.Add(this.TBNotes);
            this.PanelTop.Controls.Add(this.TBName);
            this.PanelTop.Controls.Add(this.TBLink);
            this.PanelTop.Controls.Add(this.LName);
            this.PanelTop.Controls.Add(this.LNotes);
            this.PanelTop.Controls.Add(this.LLink);
            this.PanelTop.Controls.Add(this.ImagePreview);
            this.PanelTop.Location = new System.Drawing.Point(0, 27);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(954, 189);
            this.PanelTop.TabIndex = 0;
            // 
            // ButtonDeleteRow
            // 
            this.ButtonDeleteRow.Font = new System.Drawing.Font("Segoe UI Emoji", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDeleteRow.Location = new System.Drawing.Point(838, 65);
            this.ButtonDeleteRow.Name = "ButtonDeleteRow";
            this.ButtonDeleteRow.Size = new System.Drawing.Size(104, 44);
            this.ButtonDeleteRow.TabIndex = 9;
            this.ButtonDeleteRow.Text = "Delete Row";
            this.ButtonDeleteRow.UseVisualStyleBackColor = true;
            this.ButtonDeleteRow.Click += new System.EventHandler(this.ButtonDeleteRow_Click);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonClear.Location = new System.Drawing.Point(838, 12);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(104, 44);
            this.ButtonClear.TabIndex = 8;
            this.ButtonClear.Text = "Clear";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // ButtonSubmit
            // 
            this.ButtonSubmit.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSubmit.Location = new System.Drawing.Point(12, 146);
            this.ButtonSubmit.Name = "ButtonSubmit";
            this.ButtonSubmit.Size = new System.Drawing.Size(128, 40);
            this.ButtonSubmit.TabIndex = 7;
            this.ButtonSubmit.Text = "🔥Add👌";
            this.ButtonSubmit.UseVisualStyleBackColor = true;
            this.ButtonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // TBNotes
            // 
            this.TBNotes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNotes.Location = new System.Drawing.Point(235, 114);
            this.TBNotes.Multiline = true;
            this.TBNotes.Name = "TBNotes";
            this.TBNotes.Size = new System.Drawing.Size(597, 58);
            this.TBNotes.TabIndex = 6;
            // 
            // TBName
            // 
            this.TBName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBName.Location = new System.Drawing.Point(235, 65);
            this.TBName.Name = "TBName";
            this.TBName.Size = new System.Drawing.Size(351, 29);
            this.TBName.TabIndex = 5;
            // 
            // TBLink
            // 
            this.TBLink.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBLink.Location = new System.Drawing.Point(235, 12);
            this.TBLink.Name = "TBLink";
            this.TBLink.Size = new System.Drawing.Size(597, 29);
            this.TBLink.TabIndex = 4;
            this.TBLink.Text = "https://roblox.com/library/";
            this.TBLink.TextChanged += new System.EventHandler(this.TextBoxLink_Changed);
            // 
            // LName
            // 
            this.LName.AutoSize = true;
            this.LName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LName.Location = new System.Drawing.Point(147, 59);
            this.LName.Name = "LName";
            this.LName.Size = new System.Drawing.Size(89, 32);
            this.LName.TabIndex = 3;
            this.LName.Text = "Name*";
            // 
            // LNotes
            // 
            this.LNotes.AutoSize = true;
            this.LNotes.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNotes.Location = new System.Drawing.Point(147, 108);
            this.LNotes.Name = "LNotes";
            this.LNotes.Size = new System.Drawing.Size(78, 32);
            this.LNotes.TabIndex = 2;
            this.LNotes.Text = "Notes";
            // 
            // LLink
            // 
            this.LLink.AutoSize = true;
            this.LLink.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLink.Location = new System.Drawing.Point(157, 12);
            this.LLink.Name = "LLink";
            this.LLink.Size = new System.Drawing.Size(68, 32);
            this.LLink.TabIndex = 1;
            this.LLink.Text = "Link*";
            // 
            // ImagePreview
            // 
            this.ImagePreview.BackColor = System.Drawing.Color.White;
            this.ImagePreview.ImageLocation = "";
            this.ImagePreview.Location = new System.Drawing.Point(12, 12);
            this.ImagePreview.Name = "ImagePreview";
            this.ImagePreview.Size = new System.Drawing.Size(128, 128);
            this.ImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagePreview.TabIndex = 0;
            this.ImagePreview.TabStop = false;
            // 
            // DGDatabase
            // 
            this.DGDatabase.AllowUserToAddRows = false;
            this.DGDatabase.AllowUserToDeleteRows = false;
            this.DGDatabase.AllowUserToOrderColumns = true;
            this.DGDatabase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGDatabase.Location = new System.Drawing.Point(0, 222);
            this.DGDatabase.Name = "DGDatabase";
            this.DGDatabase.ReadOnly = true;
            this.DGDatabase.Size = new System.Drawing.Size(954, 428);
            this.DGDatabase.TabIndex = 1;
            this.DGDatabase.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGDatabase_CellContentClick);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 653);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(954, 24);
            this.StatusStrip.TabIndex = 2;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // ToolStripLabel
            // 
            this.ToolStripLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ToolStripLabel.Name = "ToolStripLabel";
            this.ToolStripLabel.Size = new System.Drawing.Size(68, 19);
            this.ToolStripLabel.Text = "by Kyle!!!!";
            this.ToolStripLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(954, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 677);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.DGDatabase);
            this.Controls.Add(this.PanelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.PanelTop.ResumeLayout(false);
            this.PanelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGDatabase)).EndInit();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelTop;
        private System.Windows.Forms.TextBox TBNotes;
        private System.Windows.Forms.TextBox TBName;
        private System.Windows.Forms.TextBox TBLink;
        private System.Windows.Forms.Label LName;
        private System.Windows.Forms.Label LNotes;
        private System.Windows.Forms.Label LLink;
        private System.Windows.Forms.PictureBox ImagePreview;
        private System.Windows.Forms.DataGridView DGDatabase;
        private System.Windows.Forms.Button ButtonSubmit;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripLabel;
        private System.Windows.Forms.Button ButtonClear;
        private System.Windows.Forms.Button ButtonDeleteRow;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

