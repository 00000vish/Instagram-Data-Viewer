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
        InstagramData prasedData;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Show(InstagramData data)
        {
            this.prasedData = data;
            Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text =
                "name= " + prasedData.user.name + "\n" +
                "username= " + prasedData.user.username + "\n" +
                "gender= " + prasedData.user.gender + "\n" +
                "biography= " + prasedData.user.biography + "\n" +
                "email=" + prasedData.user.email + "\n" +
                "date_joined= " + prasedData.user.date_joined + "\n" +
                "private_account= " + prasedData.user.private_account.ToString() + "\n" +
                "profile_pic_url= " + prasedData.user.profile_pic_url + "\n";
            pictureBox1.ImageLocation = prasedData.user.profile_pic_url;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            CommonForm lhf = new CommonForm();
            lhf.Show(2);
            foreach (Login item in prasedData.logins.login_history)
            {
                lhf.listView1.Items.Add(item.ip_address).SubItems.Add(item.timestamp);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CommonForm cf = new CommonForm();
            cf.Show(1);
            foreach (Object item in prasedData.comments.media_comments)
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
            if (prasedData.pics.direct != null)
            {
                foreach (Picture item in prasedData.pics.direct)
                {
                    ListViewItem item1 = new ListViewItem(item.caption);
                    item1.SubItems.Add(item.taken_at);
                    item1.SubItems.Add(item.path);
                    mv.listView1.Items.Add(item1);
                }
            }
            if (prasedData.pics.photos != null)
            {
                foreach (Picture item in prasedData.pics.photos)
                {
                    ListViewItem item1 = new ListViewItem(item.caption);
                    item1.SubItems.Add(item.taken_at);
                    item1.SubItems.Add(item.path);
                    mv.listView2.Items.Add(item1);
                }
            }
            if (prasedData.pics.stories != null)
            {
                foreach (Picture item in prasedData.pics.stories)
                {
                    ListViewItem item1 = new ListViewItem(item.caption);
                    item1.SubItems.Add(item.taken_at);
                    item1.SubItems.Add(item.path);
                    mv.listView3.Items.Add(item1);
                }
            }
            if (prasedData.pics.videos != null)
            {
                foreach (Picture item in prasedData.pics.videos)
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
            foreach (ContactInfo item in prasedData.contacts)
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
            if (prasedData.follows.blocked_users != null)
            {
                foreach (object item in prasedData.follows.blocked_users)
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
            if (prasedData.follows.close_friends != null)
            {
                foreach (object item in prasedData.follows.close_friends)
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
            if (prasedData.follows.restricted_users != null)
            {
                foreach (object item in prasedData.follows.restricted_users)
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
            if (prasedData.follows.follow_requests_sent != null)
            {
                foreach (object item in prasedData.follows.follow_requests_sent)
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
            if (prasedData.follows.followers != null)
            {
                foreach (object item in prasedData.follows.followers)
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
            if (prasedData.follows.following != null)
            {
                foreach (object item in prasedData.follows.following)
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
            if (prasedData.follows.following_hashtags != null)
            {
                foreach (object item in prasedData.follows.following_hashtags)
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

        private void button1_Click(object sender, EventArgs e)
        {
            CommonForm cf = new CommonForm();
            cf.Show(4);
            foreach (Object item in prasedData.likes.media_likes)
            {
                Newtonsoft.Json.Linq.JArray converted = (Newtonsoft.Json.Linq.JArray)item;
                ListViewItem item1 = new ListViewItem(converted.First.ToString());
                item1.SubItems.Add(converted.Last.ToString());
                cf.listView1.Items.Add(item1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MediaViews mv = new MediaViews();
            mv.Show(3);
            if (prasedData.saved.saved_collections != null)
            {
                foreach (object item in prasedData.saved.saved_collections)
                {
                    if (item != null)
                    {
                        Newtonsoft.Json.Linq.JArray converted = (Newtonsoft.Json.Linq.JArray)item;
                        ListViewItem item1 = new ListViewItem(converted.First.ToString());
                        item1.SubItems.Add(converted.Last.ToString());
                        mv.listView1.Items.Add(item1);

                    }
                }
            }
            if (prasedData.saved.saved_media != null)
            {
                foreach (object item in prasedData.saved.saved_media)
                {
                    if (item != null)
                    {
                        Newtonsoft.Json.Linq.JArray converted = (Newtonsoft.Json.Linq.JArray)item;
                        ListViewItem item1 = new ListViewItem(converted.First.ToString());
                        item1.SubItems.Add(converted.Last.ToString());
                        mv.listView1.Items.Add(item1);

                    }
                }
            }
        }

    }
}
