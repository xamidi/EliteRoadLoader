namespace EliteRoadLoader
{
    partial class RoadLoaderForm
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoadLoaderForm));
            this.lblDebug = new System.Windows.Forms.Label();
            this.txtLoaded = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDebug
            // 
            this.lblDebug.AutoSize = true;
            this.lblDebug.Location = new System.Drawing.Point(13, 13);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(150, 13);
            this.lblDebug.TabIndex = 0;
            this.lblDebug.Text = "Drag && drop CSV or TXT here!";
            // 
            // txtLoaded
            // 
            this.txtLoaded.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoaded.Location = new System.Drawing.Point(12, 41);
            this.txtLoaded.Multiline = true;
            this.txtLoaded.Name = "txtLoaded";
            this.txtLoaded.ReadOnly = true;
            this.txtLoaded.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLoaded.Size = new System.Drawing.Size(310, 159);
            this.txtLoaded.TabIndex = 1;
            this.txtLoaded.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectAll_KeyDown);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.Location = new System.Drawing.Point(13, 213);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(259, 40);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "[F4] Copy next system to clipboard + paste + enter\r\n[F5] Copy next system to clip" +
    "board\r\n[F6] Copy previous system to clipboard";
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(280, 8);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(42, 27);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaste.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaste.Location = new System.Drawing.Point(232, 8);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(42, 27);
            this.btnPaste.TabIndex = 4;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // RoadLoaderForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 262);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtLoaded);
            this.Controls.Add(this.lblDebug);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RoadLoaderForm";
            this.Text = "Dragorion\'s Elite Road Loader";
            this.Load += new System.EventHandler(this.RoadLoaderForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.RoadLoaderForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.RoadLoaderForm_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDebug;
        private System.Windows.Forms.TextBox txtLoaded;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnPaste;
    }
}

