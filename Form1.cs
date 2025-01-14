using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace FishM
{
    public partial class Form1 : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        // 定义快捷键的 ID
        private const int HOTKEY_ID = 9000;

        // 引入 user32.dll 的 RegisterHotKey 和 UnregisterHotKey 方法
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public Form1()
        {
            InitializeComponent();
            this.Text = "FishM"; // 设置窗体标题为 FishM
            notifyIcon.Text = "FishM"; // 设置托盘图标的名称为 FishM
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // 初始化 WebView2
                await webView.EnsureCoreWebView2Async(null);
                webView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
                webView.CoreWebView2.Navigate("https://eoyz369.github.io/"); // 默认主页
            }
            catch (Exception ex)
            {
                MessageBox.Show("WebView2 初始化失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 隐藏任务栏图标
            this.ShowInTaskbar = false;

            // 设置托盘菜单
            notifyIcon.ContextMenuStrip = contextMenuStrip;

            // 注册全局快捷键 Alt+Q
            RegisterHotKey(this.Handle, HOTKEY_ID, 0x0001, (int)Keys.Q); // 0x0001 表示 Alt 键
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312; // 热键消息

            // 捕获热键消息
            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOTKEY_ID)
            {
                // 切换窗口状态
                ToggleWindowState();
            }

            base.WndProc(ref m);
        }

        private void ToggleWindowState()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Show();
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 注销全局快捷键
            UnregisterHotKey(this.Handle, HOTKEY_ID);
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            // 跳转到地址栏中的 URL
            string url = addressBar.Text;
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "https://" + url;
            }
            webView.CoreWebView2.Navigate(url);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // 关闭窗口
            this.Close();
        }

        private void selectBackgroundButton_Click(object sender, EventArgs e)
        {
            // 选择背景图片
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // 开始拖动窗口
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // 拖动窗口
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // 停止拖动窗口
            dragging = false;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            // 双击托盘图标切换窗口状态
            ToggleWindowState();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // 快捷键切换窗口状态（Alt+Q）
            if (e.Alt && e.KeyCode == Keys.Q)
            {
                ToggleWindowState();
            }
        }

        private void githubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/Eoyz369/FishM",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法打开浏览器: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bilibiliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://space.bilibili.com/20698881",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法打开浏览器: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://eoyz369.github.io/", 
                    UseShellExecute = true 
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法打开浏览器: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 退出程序
            Application.Exit();
        }

        private void CoreWebView2_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            if (!e.IsSuccess)
            {
                MessageBox.Show("导航失败: " + e.WebErrorStatus.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}