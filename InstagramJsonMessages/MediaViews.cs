﻿using System;
using System.Collections;
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
        ArrayList paths = null;
        public MediaViews()
        {
            InitializeComponent();
        }

        public void Show(int type, ArrayList paths)
        {
            this.paths = paths;
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

        private void listViewsDoubleClick(object sender, EventArgs e)
        {
            ListView current = null;
            //only works if you select each instagram part 1 and part 2 and part3 folders and not root folder

            string chbxName = ((ListView)sender).Name;
            switch (chbxName)
            {
                case "listView1": current = listView1; break;
                case "listView2": current = listView2; break;
                case "listView3": current = listView3; break;
                case "listView4": current = listView4; break;
                case "listView5": current = listView5; break;
                case "listView6": current = listView6; break;
                case "listView7": current = listView7; break;
                default:break;
            }
            foreach (string item in paths)
            {
                if (System.IO.File.Exists(item + "\\" + current.SelectedItems[0].Tag.ToString().Replace("/", "\\")))
                {
                    System.Diagnostics.Process.Start(item + "\\" + current.SelectedItems[0].Tag.ToString().Replace("/", "\\"));
                }
            }
            
        }
    }
}
