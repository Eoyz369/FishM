namespace FishM
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox addressBar;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Button closeButton;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.Button selectBackgroundButton;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.ComponentModel.IContainer notifyIconComponents;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem githubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bilibiliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authorToolStripMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing && (notifyIconComponents != null))
            {
                notifyIconComponents.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.addressBar = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.selectBackgroundButton = new System.Windows.Forms.Button();
            this.notifyIconComponents = new System.ComponentModel.Container();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.notifyIconComponents);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.githubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bilibiliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem(); 
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // addressBar
            // 
            this.addressBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.addressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addressBar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressBar.Location = new System.Drawing.Point(10, 10);
            this.addressBar.Name = "addressBar";
            this.addressBar.Size = new System.Drawing.Size(200, 23);
            this.addressBar.TabIndex = 0;
            // 
            // goButton
            // 
            this.goButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.goButton.FlatAppearance.BorderSize = 0;
            this.goButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goButton.ForeColor = System.Drawing.Color.White;
            this.goButton.Location = new System.Drawing.Point(220, 10);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(50, 23);
            this.goButton.TabIndex = 1;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = false;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(71)))), ((int)(((byte)(87)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(280, 10);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(20, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // webView
            // 
            this.webView.CreationProperties = null;
            this.webView.Location = new System.Drawing.Point(10, 40);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(300, 200);
            this.webView.TabIndex = 3;
            this.webView.ZoomFactor = 1D;
            // 
            // selectBackgroundButton
            // 
            this.selectBackgroundButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.selectBackgroundButton.FlatAppearance.BorderSize = 0;
            this.selectBackgroundButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectBackgroundButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectBackgroundButton.ForeColor = System.Drawing.Color.White;
            this.selectBackgroundButton.Location = new System.Drawing.Point(60, 250);
            this.selectBackgroundButton.Name = "selectBackgroundButton";
            this.selectBackgroundButton.Size = new System.Drawing.Size(200, 30);
            this.selectBackgroundButton.TabIndex = 4;
            this.selectBackgroundButton.Text = "Select Background";
            this.selectBackgroundButton.UseVisualStyleBackColor = false;
            this.selectBackgroundButton.Click += new System.EventHandler(this.selectBackgroundButton_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = global::FishM.Properties.Resources.fishM; // 确保图标资源存在
            this.notifyIcon.Text = "FishM";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.githubToolStripMenuItem,
            this.bilibiliToolStripMenuItem,
            this.authorToolStripMenuItem, 
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(150, 92);
            // 
            // githubToolStripMenuItem
            // 
            this.githubToolStripMenuItem.Name = "githubToolStripMenuItem";
            this.githubToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.githubToolStripMenuItem.Text = "Open GitHub";
            this.githubToolStripMenuItem.Click += new System.EventHandler(this.githubToolStripMenuItem_Click);
            // 
            // bilibiliToolStripMenuItem
            // 
            this.bilibiliToolStripMenuItem.Name = "bilibiliToolStripMenuItem";
            this.bilibiliToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.bilibiliToolStripMenuItem.Text = "Bilibili";
            this.bilibiliToolStripMenuItem.Click += new System.EventHandler(this.bilibiliToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // authorToolStripMenuItem
            // 
            this.authorToolStripMenuItem.Name = "authorToolStripMenuItem";
            this.authorToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.authorToolStripMenuItem.Text = "Eoyz369";
            this.authorToolStripMenuItem.Click += new System.EventHandler(this.authorToolStripMenuItem_Click); 
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(320, 350);
            this.Controls.Add(this.selectBackgroundButton);
            this.Controls.Add(this.webView);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.addressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FishM"; 
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}