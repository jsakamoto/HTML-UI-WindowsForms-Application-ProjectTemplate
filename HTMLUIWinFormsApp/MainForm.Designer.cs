namespace HTMLUIWinFormsApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BuiltinBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // BuiltinBrowser
            // 
            this.BuiltinBrowser.AllowNavigation = false;
            this.BuiltinBrowser.AllowWebBrowserDrop = false;
            this.BuiltinBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BuiltinBrowser.Location = new System.Drawing.Point(0, 0);
            this.BuiltinBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.BuiltinBrowser.Name = "BuiltinBrowser";
            this.BuiltinBrowser.ScrollBarsEnabled = false;
            this.BuiltinBrowser.Size = new System.Drawing.Size(882, 483);
            this.BuiltinBrowser.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 483);
            this.Controls.Add(this.BuiltinBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser BuiltinBrowser;
    }
}

