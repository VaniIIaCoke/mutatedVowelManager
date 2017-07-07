namespace mutatedVowelManager
{
    partial class Manager
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
            this.dgvPhonebook = new System.Windows.Forms.DataGridView();
            this.btSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btPossi = new System.Windows.Forms.Button();
            this.lbPossibilities = new System.Windows.Forms.ListBox();
            this.btPossibilities = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhonebook)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPhonebook
            // 
            this.dgvPhonebook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhonebook.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPhonebook.Location = new System.Drawing.Point(12, 67);
            this.dgvPhonebook.Name = "dgvPhonebook";
            this.dgvPhonebook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhonebook.Size = new System.Drawing.Size(205, 186);
            this.dgvPhonebook.TabIndex = 0;
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(12, 38);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 23);
            this.btSearch.TabIndex = 1;
            this.btSearch.Text = "suchen";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbSearch.Location = new System.Drawing.Point(12, 12);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(205, 20);
            this.tbSearch.TabIndex = 2;
            // 
            // btPossi
            // 
            this.btPossi.Location = new System.Drawing.Point(94, 38);
            this.btPossi.Name = "btPossi";
            this.btPossi.Size = new System.Drawing.Size(123, 23);
            this.btPossi.TabIndex = 3;
            this.btPossi.Text = "Umlaute konvertieren";
            this.btPossi.UseVisualStyleBackColor = true;
            this.btPossi.Click += new System.EventHandler(this.btPossi_Click);
            // 
            // lbPossibilities
            // 
            this.lbPossibilities.FormattingEnabled = true;
            this.lbPossibilities.Location = new System.Drawing.Point(223, 67);
            this.lbPossibilities.Name = "lbPossibilities";
            this.lbPossibilities.Size = new System.Drawing.Size(179, 186);
            this.lbPossibilities.TabIndex = 4;
            // 
            // btPossibilities
            // 
            this.btPossibilities.Location = new System.Drawing.Point(223, 38);
            this.btPossibilities.Name = "btPossibilities";
            this.btPossibilities.Size = new System.Drawing.Size(178, 23);
            this.btPossibilities.TabIndex = 5;
            this.btPossibilities.Text = "Schreibweisen generieren";
            this.btPossibilities.UseVisualStyleBackColor = true;
            this.btPossibilities.Click += new System.EventHandler(this.btPossibilities_Click);
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 269);
            this.Controls.Add(this.btPossibilities);
            this.Controls.Add(this.lbPossibilities);
            this.Controls.Add(this.btPossi);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.dgvPhonebook);
            this.Name = "Manager";
            this.Text = "Umlaut Manager";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhonebook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPhonebook;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btPossi;
        private System.Windows.Forms.ListBox lbPossibilities;
        private System.Windows.Forms.Button btPossibilities;
    }
}

