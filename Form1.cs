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

        // �����ݼ��� ID
        private const int HOTKEY_ID = 9000;

        // ���� user32.dll �� RegisterHotKey �� UnregisterHotKey ����
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public Form1()
        {
            InitializeComponent();
            this.Text = "FishM"; // ���ô������Ϊ FishM
            notifyIcon.Text = "FishM"; // ��������ͼ�������Ϊ FishM
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // ��ʼ�� WebView2
                await webView.EnsureCoreWebView2Async(null);
                webView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
                webView.CoreWebView2.Navigate("https://eoyz369.github.io/"); // Ĭ����ҳ
            }
            catch (Exception ex)
            {
                MessageBox.Show("WebView2 ��ʼ��ʧ��: " + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // ����������ͼ��
            this.ShowInTaskbar = false;

            // �������̲˵�
            notifyIcon.ContextMenuStrip = contextMenuStrip;

            // ע��ȫ�ֿ�ݼ� Alt+Q
            RegisterHotKey(this.Handle, HOTKEY_ID, 0x0001, (int)Keys.Q); // 0x0001 ��ʾ Alt ��
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312; // �ȼ���Ϣ

            // �����ȼ���Ϣ
            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOTKEY_ID)
            {
                // �л�����״̬
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
            // ע��ȫ�ֿ�ݼ�
            UnregisterHotKey(this.Handle, HOTKEY_ID);
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            // ��ת����ַ���е� URL
            string url = addressBar.Text;
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "https://" + url;
            }
            webView.CoreWebView2.Navigate(url);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // �رմ���
            this.Close();
        }

        private void selectBackgroundButton_Click(object sender, EventArgs e)
        {
            // ѡ�񱳾�ͼƬ
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
            // ��ʼ�϶�����
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // �϶�����
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // ֹͣ�϶�����
            dragging = false;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            // ˫������ͼ���л�����״̬
            ToggleWindowState();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // ��ݼ��л�����״̬��Alt+Q��
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
                MessageBox.Show("�޷��������: " + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("�޷��������: " + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("�޷��������: " + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // �˳�����
            Application.Exit();
        }

        private void CoreWebView2_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            if (!e.IsSuccess)
            {
                MessageBox.Show("����ʧ��: " + e.WebErrorStatus.ToString(), "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}