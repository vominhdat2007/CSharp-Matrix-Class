namespace TestProject
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
            this.mTextResult = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // mTextResult
            // 
            this.mTextResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTextResult.Location = new System.Drawing.Point(0, 0);
            this.mTextResult.Name = "mTextResult";
            this.mTextResult.Size = new System.Drawing.Size(460, 414);
            this.mTextResult.TabIndex = 0;
            this.mTextResult.Text = "";
            this.mTextResult.WordWrap = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 414);
            this.Controls.Add(this.mTextResult);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Testing Matrix Class";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox mTextResult;
    }
}

