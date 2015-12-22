namespace TPLUncaughtExceptionInWinForms
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
            this.btnStartTask = new System.Windows.Forms.Button();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.btnHandleException = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartTask
            // 
            this.btnStartTask.Location = new System.Drawing.Point(27, 290);
            this.btnStartTask.Name = "btnStartTask";
            this.btnStartTask.Size = new System.Drawing.Size(201, 23);
            this.btnStartTask.TabIndex = 0;
            this.btnStartTask.Text = "Start Task 1";
            this.btnStartTask.UseVisualStyleBackColor = true;
            this.btnStartTask.Click += new System.EventHandler(this.btnStartTask_Click);
            // 
            // lstResults
            // 
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(12, 12);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(233, 251);
            this.lstResults.TabIndex = 1;
            // 
            // btnHandleException
            // 
            this.btnHandleException.Location = new System.Drawing.Point(27, 319);
            this.btnHandleException.Name = "btnHandleException";
            this.btnHandleException.Size = new System.Drawing.Size(201, 23);
            this.btnHandleException.TabIndex = 2;
            this.btnHandleException.Text = "Start Task 2";
            this.btnHandleException.UseVisualStyleBackColor = true;
            this.btnHandleException.Click += new System.EventHandler(this.btnHandleException_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 392);
            this.Controls.Add(this.btnHandleException);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.btnStartTask);
            this.Name = "Form1";
            this.Text = "TPLUncaughtExceptionInWinForms";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartTask;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Button btnHandleException;
    }
}

