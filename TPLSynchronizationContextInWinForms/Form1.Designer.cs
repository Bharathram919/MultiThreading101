namespace TPLSynchronizationContextInWinForms
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
            this.lstBox = new System.Windows.Forms.ListBox();
            this.btnInvokeRequired = new System.Windows.Forms.Button();
            this.btnSyncContext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstBox
            // 
            this.lstBox.FormattingEnabled = true;
            this.lstBox.Location = new System.Drawing.Point(12, 12);
            this.lstBox.Name = "lstBox";
            this.lstBox.Size = new System.Drawing.Size(382, 251);
            this.lstBox.TabIndex = 0;
            // 
            // btnInvokeRequired
            // 
            this.btnInvokeRequired.Location = new System.Drawing.Point(13, 280);
            this.btnInvokeRequired.Name = "btnInvokeRequired";
            this.btnInvokeRequired.Size = new System.Drawing.Size(186, 27);
            this.btnInvokeRequired.TabIndex = 1;
            this.btnInvokeRequired.Text = "InvokeRequired";
            this.btnInvokeRequired.UseVisualStyleBackColor = true;
            this.btnInvokeRequired.Click += new System.EventHandler(this.btnInvokeRequired_Click);
            // 
            // btnSyncContext
            // 
            this.btnSyncContext.Location = new System.Drawing.Point(205, 280);
            this.btnSyncContext.Name = "btnSyncContext";
            this.btnSyncContext.Size = new System.Drawing.Size(189, 27);
            this.btnSyncContext.TabIndex = 1;
            this.btnSyncContext.Text = "SyncContext";
            this.btnSyncContext.UseVisualStyleBackColor = true;
            this.btnSyncContext.Click += new System.EventHandler(this.btnSyncContext_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 343);
            this.Controls.Add(this.btnSyncContext);
            this.Controls.Add(this.btnInvokeRequired);
            this.Controls.Add(this.lstBox);
            this.Name = "Form1";
            this.Text = "TPLSynchronizationContextInWinForms";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstBox;
        private System.Windows.Forms.Button btnInvokeRequired;
        private System.Windows.Forms.Button btnSyncContext;
    }
}

