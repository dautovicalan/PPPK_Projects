namespace PPPK_Vjezba_03
{
    partial class MainForm
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
            this.TbQueryInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnRunQuery = new System.Windows.Forms.Button();
            this.BtnDeleteAll = new System.Windows.Forms.Button();
            this.TcWindow = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DgResults = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LblMessage = new System.Windows.Forms.Label();
            this.CbDatabases = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TcWindow.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgResults)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbQueryInput
            // 
            this.TbQueryInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbQueryInput.Location = new System.Drawing.Point(26, 46);
            this.TbQueryInput.Multiline = true;
            this.TbQueryInput.Name = "TbQueryInput";
            this.TbQueryInput.Size = new System.Drawing.Size(1114, 249);
            this.TbQueryInput.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Insert Your Query Here";
            // 
            // BtnRunQuery
            // 
            this.BtnRunQuery.Location = new System.Drawing.Point(1025, 301);
            this.BtnRunQuery.Name = "BtnRunQuery";
            this.BtnRunQuery.Size = new System.Drawing.Size(115, 36);
            this.BtnRunQuery.TabIndex = 2;
            this.BtnRunQuery.Text = "Run Query";
            this.BtnRunQuery.UseVisualStyleBackColor = true;
            this.BtnRunQuery.Click += new System.EventHandler(this.BtnRunQuery_Click);
            // 
            // BtnDeleteAll
            // 
            this.BtnDeleteAll.Location = new System.Drawing.Point(904, 301);
            this.BtnDeleteAll.Name = "BtnDeleteAll";
            this.BtnDeleteAll.Size = new System.Drawing.Size(115, 36);
            this.BtnDeleteAll.TabIndex = 3;
            this.BtnDeleteAll.Text = "Delete All";
            this.BtnDeleteAll.UseVisualStyleBackColor = true;
            this.BtnDeleteAll.Click += new System.EventHandler(this.BtnDeleteAll_Click);
            // 
            // TcWindow
            // 
            this.TcWindow.Controls.Add(this.tabPage1);
            this.TcWindow.Controls.Add(this.tabPage2);
            this.TcWindow.Location = new System.Drawing.Point(26, 381);
            this.TcWindow.Name = "TcWindow";
            this.TcWindow.SelectedIndex = 0;
            this.TcWindow.Size = new System.Drawing.Size(1114, 242);
            this.TcWindow.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DgResults);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1106, 216);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Results";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DgResults
            // 
            this.DgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgResults.Location = new System.Drawing.Point(3, 3);
            this.DgResults.Name = "DgResults";
            this.DgResults.Size = new System.Drawing.Size(1100, 210);
            this.DgResults.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LblMessage);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1106, 216);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Messages";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LblMessage
            // 
            this.LblMessage.AutoSize = true;
            this.LblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblMessage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblMessage.Location = new System.Drawing.Point(3, 3);
            this.LblMessage.Name = "LblMessage";
            this.LblMessage.Size = new System.Drawing.Size(0, 13);
            this.LblMessage.TabIndex = 0;
            // 
            // CbDatabases
            // 
            this.CbDatabases.FormattingEnabled = true;
            this.CbDatabases.Location = new System.Drawing.Point(1015, 13);
            this.CbDatabases.Name = "CbDatabases";
            this.CbDatabases.Size = new System.Drawing.Size(121, 21);
            this.CbDatabases.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(910, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select Database";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 635);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CbDatabases);
            this.Controls.Add(this.TcWindow);
            this.Controls.Add(this.BtnDeleteAll);
            this.Controls.Add(this.BtnRunQuery);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TbQueryInput);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TcWindow.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgResults)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbQueryInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnRunQuery;
        private System.Windows.Forms.Button BtnDeleteAll;
        private System.Windows.Forms.TabControl TcWindow;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DgResults;
        private System.Windows.Forms.Label LblMessage;
        private System.Windows.Forms.ComboBox CbDatabases;
        private System.Windows.Forms.Label label2;
    }
}

