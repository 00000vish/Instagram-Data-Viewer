using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstagramJsonMessages
{
    public partial class MediaViews : Form
    {
        public MediaViews()
        {
            InitializeComponent();
        }

        public void Show(int type)
        {
            listView1.Clear();
            listView2.Clear();
            listView3.Clear();
            listView4.Clear();
            listView5.Clear();
            listView6.Clear();
            listView7.Clear();
            switch (type)
            {
                case 1:
                    tabControl1.TabPages[0].Text = "Direct";
                    tabControl1.TabPages[1].Text = "Posts";
                    tabControl1.TabPages[2].Text = "Stories";
                    tabControl1.TabPages[3].Text = "Videos";
                    listView1.Columns.Add("Caption", 140, HorizontalAlignment.Left);
                    listView1.Columns.Add("Taken At", 140, HorizontalAlignment.Left);
                    listView1.Columns.Add("Path", 260, HorizontalAlignment.Left);
                    listView2.Columns.Add("Caption", 140, HorizontalAlignment.Left);
                    listView2.Columns.Add("Taken At", 140, HorizontalAlignment.Left);
                    listView2.Columns.Add("Path", 260, HorizontalAlignment.Left);
                    listView3.Columns.Add("Caption", 140, HorizontalAlignment.Left);
                    listView3.Columns.Add("Taken At", 140, HorizontalAlignment.Left);
                    listView3.Columns.Add("Path", 260, HorizontalAlignment.Left);
                    listView4.Columns.Add("Caption", 140, HorizontalAlignment.Left);
                    listView4.Columns.Add("Taken At", 140, HorizontalAlignment.Left);
                    listView4.Columns.Add("Path", 260, HorizontalAlignment.Left);
                    Size = new Size(280 + 260 + 50, 500); break;
                case 2:
                    tabControl1.TabPages[0].Text = "Blocked Users";
                    tabControl1.TabPages[1].Text = "Close Friends";
                    tabControl1.TabPages[2].Text = "Restricted Users";
                    tabControl1.TabPages[3].Text = "Follow Requests Sent";
                    tabControl1.TabPages[4].Text = "Followers"; 
                    tabControl1.TabPages[5].Text = "Following";
                    tabControl1.TabPages[6].Text = "Following Hashtags";
                    listView1.Columns.Add("Username", 240, HorizontalAlignment.Left);
                    listView1.Columns.Add("Timestamp", 300, HorizontalAlignment.Left);
                    listView2.Columns.Add("Username", 240, HorizontalAlignment.Left);
                    listView2.Columns.Add("Timestamp", 300, HorizontalAlignment.Left);
                    listView3.Columns.Add("Username", 240, HorizontalAlignment.Left);
                    listView3.Columns.Add("Timestamp", 300, HorizontalAlignment.Left);
                    listView4.Columns.Add("Username", 240, HorizontalAlignment.Left);
                    listView4.Columns.Add("Timestamp", 300, HorizontalAlignment.Left);
                    listView5.Columns.Add("Username", 240, HorizontalAlignment.Left);
                    listView5.Columns.Add("Username", 240, HorizontalAlignment.Left);
                    listView6.Columns.Add("Timestamp", 300, HorizontalAlignment.Left);
                    listView6.Columns.Add("Username", 240, HorizontalAlignment.Left);
                    listView7.Columns.Add("Timestamp", 300, HorizontalAlignment.Left);
                    listView7.Columns.Add("Username", 240, HorizontalAlignment.Left);
                    Size = new Size(280 + 260 + 50, 500); break;
                case 3:
                    tabControl1.TabPages[0].Text = "Saved Media";
                    tabControl1.TabPages[1].Text = "Saved Collections";
                    listView1.Columns.Add("Timestamp", 140, HorizontalAlignment.Left);
                    listView1.Columns.Add("Posted by", 140, HorizontalAlignment.Left);
                    listView2.Columns.Add("Timestamp", 140, HorizontalAlignment.Left);
                    listView2.Columns.Add("Posted by", 140, HorizontalAlignment.Left);
                    Size = new Size(280 + 260 + 50, 500); break;
                default: break;
            }
            Show();
        }

        private void MediaViews_Load(object sender, EventArgs e)
        {

        }
    }
}
