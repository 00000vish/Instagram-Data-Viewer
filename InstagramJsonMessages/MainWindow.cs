using System;
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
    public partial class MainWindow : Form
    {
        
        Profile user;
        AccountHistory logins;
        CommentHistory comments;
        List<ContactInfo> contacts;
        Connections follows;
        Media pics;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Show(ArrayList data)
        {
            this.user = (Profile)data[0];
            this.logins = (AccountHistory)data[1]; ;
            this.comments = (CommentHistory)data[2]; ;
            this.contacts = (List<ContactInfo>)data[3]; ;
            this.follows = (Connections)data[4]; ;
            this.pics = (Media)data[5];
            Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text =
                "name= " + user.name + "\n" +
                "username= " + user.username + "\n" +
                "gender= " + user.gender + "\n" +
                "biography= " + user.biography + "\n" +
                "email=" + user.email + "\n" +
                "date_joined= " + user.date_joined + "\n" +
                "private_account= " + user.private_account.ToString() + "\n" +
                "profile_pic_url= " + user.profile_pic_url + "\n";
            pictureBox1.ImageLocation = user.profile_pic_url;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            CommonForm lhf = new CommonForm();
            lhf.Show(2);
            foreach (Login item in logins.login_history)
            {
                lhf.listView1.Items.Add(item.ip_address).SubItems.Add(item.timestamp);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CommonForm cf = new CommonForm();
            cf.Show(1);
            foreach (Object item in comments.media_comments)
            {
                Newtonsoft.Json.Linq.JArray converted = (Newtonsoft.Json.Linq.JArray)item;
                ListViewItem item1 = new ListViewItem(converted.First.ToString());
                item1.SubItems.Add(converted.First.Next.Next.ToString());
                item1.SubItems.Add(converted.First.Next.ToString());
                cf.listView1.Items.Add(item1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MediaViews mv = new MediaViews();
            mv.Show(1);
            if (pics.direct != null)
            {
                foreach (Picture item in pics.direct)
                {
                    ListViewItem item1 = new ListViewItem(item.caption);
                    item1.SubItems.Add(item.taken_at);
                    item1.SubItems.Add(item.path);
                    mv.listView1.Items.Add(item1);
                }
            }
            if (pics.photos != null)
            {
                foreach (Picture item in pics.photos)
                {
                    ListViewItem item1 = new ListViewItem(item.caption);
                    item1.SubItems.Add(item.taken_at);
                    item1.SubItems.Add(item.path);
                    mv.listView2.Items.Add(item1);
                }
            }
            if (pics.stories != null)
            {
                foreach (Picture item in pics.stories)
                {
                    ListViewItem item1 = new ListViewItem(item.caption);
                    item1.SubItems.Add(item.taken_at);
                    item1.SubItems.Add(item.path);
                    mv.listView3.Items.Add(item1);
                }
            }
            if (pics.videos != null)
            {
                foreach (Picture item in pics.videos)
                {
                    ListViewItem item1 = new ListViewItem(item.caption);
                    item1.SubItems.Add(item.taken_at);
                    item1.SubItems.Add(item.path);
                    mv.listView4.Items.Add(item1);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CommonForm cf = new CommonForm();
            cf.Show(3);
            foreach (ContactInfo item in contacts)
            {
                ListViewItem item1 = new ListViewItem(item.first_name);
                item1.SubItems.Add(item.last_name);
                item1.SubItems.Add(item.contact);
                cf.listView1.Items.Add(item1);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MediaViews mv = new MediaViews();
            mv.Show(2);
            if (follows.blocked_users != null)
            {
                foreach (object item in follows.blocked_users)
                {
                    if (item != null)
                    {
                        KeyValuePair<string, string> convered = (KeyValuePair<string, string>)item;
                        ListViewItem item1 = new ListViewItem(convered.Key);
                        item1.SubItems.Add(convered.Value);
                        mv.listView1.Items.Add(item1);

                    }
                }
            }
            if (follows.close_friends != null)
            {
                foreach (object item in follows.close_friends)
                {
                    if (item != null)
                    {
                        KeyValuePair<string, string> convered = (KeyValuePair<string, string>)item;
                        ListViewItem item1 = new ListViewItem(convered.Key);
                        item1.SubItems.Add(convered.Value);
                        mv.listView2.Items.Add(item1);

                    }
                }
            }
            if (follows.restricted_users != null)
            {
                foreach (object item in follows.restricted_users)
                {
                    if (item != null)
                    {
                        KeyValuePair<string, string> convered = (KeyValuePair<string, string>)item;
                        ListViewItem item1 = new ListViewItem(convered.Key);
                        item1.SubItems.Add(convered.Value);
                        mv.listView3.Items.Add(item1);

                    }
                }
            }
            if (follows.follow_requests_sent != null)
            {
                foreach (object item in follows.follow_requests_sent)
                {
                    if (item != null)
                    {
                        KeyValuePair<string, string> convered = (KeyValuePair<string, string>)item;
                        ListViewItem item1 = new ListViewItem(convered.Key);
                        item1.SubItems.Add(convered.Value);
                        mv.listView4.Items.Add(item1);

                    }
                }
            }
            if (follows.followers != null)
            {
                foreach (object item in follows.followers)
                {
                    if (item != null)
                    {
                        KeyValuePair<string, string> convered = (KeyValuePair<string, string>)item;
                        ListViewItem item1 = new ListViewItem(convered.Key);
                        item1.SubItems.Add(convered.Value);
                        mv.listView5.Items.Add(item1);

                    }
                }
            }
            if (follows.following != null)
            {
                foreach (object item in follows.following)
                {
                    if (item != null)
                    {
                        KeyValuePair<string, string> convered = (KeyValuePair<string, string>)item;
                        ListViewItem item1 = new ListViewItem(convered.Key);
                        item1.SubItems.Add(convered.Value);
                        mv.listView6.Items.Add(item1);

                    }
                }
            }
            if (follows.following_hashtags != null)
            {
                foreach (object item in follows.following_hashtags)
                {
                    if (item != null)
                    {
                        KeyValuePair<string, string> convered = (KeyValuePair<string, string>)item;
                        ListViewItem item1 = new ListViewItem(convered.Key);
                        item1.SubItems.Add(convered.Value);
                        mv.listView7.Items.Add(item1);

                    }
                }
            }
        }
    }
}
