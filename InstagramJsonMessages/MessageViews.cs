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
    public partial class MessageViews : Form
    {
        public MessageViews()
        {
            InitializeComponent();
        }

        internal void Show(List<Message> data)
        {
            listView1.Items.Clear();
            listView1.Items.Add("Double click to change color!");
            foreach (Message msg in data)
            {
                ListViewItem temp = new ListViewItem();                
                foreach (string item in msg.participants)
                {
                    temp.Text += "<-> " + item + " ";
                }
                if (msg.conversation != null && msg.conversation[0] != null)
                    temp.Text += " : "+ msg.conversation[0].created_at.ToString().Split(' ')[0];
                temp.Text = temp.Text.Substring(3);
                temp.Tag = msg; 
                listView1.Items.Add(temp);               
            }
            Show();
        }
        private Random rnd = new Random();
        private void listView1_Click(object sender, EventArgs e)
        {            
            if(listView1.SelectedItems.Count > 0 && listView1.SelectedItems[0].Tag != null )
            {
                listView2.Items.Clear();
                listView2.Items.Add("").SubItems.Add("Double click messages with picture to open!");
                Message msg = listView1.SelectedItems[0].Tag as Message;
                Dictionary<string, Color> colorCode = new Dictionary<string, Color>();
                foreach (string item in msg.participants)
                {
                    Color randomColor = Color.FromArgb(rnd.Next(130)+90, rnd.Next(130)+90, rnd.Next(130)+90);
                    colorCode.Add(item.ToString(), randomColor);
                    var item1 = new ListViewItem("");
                    item1.SubItems.Add(item.ToString());
                    item1.BackColor = randomColor;
                    listView2.Items.Add(item1);
                }
                foreach (Conversation item in msg.conversation)
                {
                    
                    if (item.media != null) {
                        var item1 = new ListViewItem("↳");
                        item1.SubItems.Add(item.media);
                        item1.BackColor = colorCode[item.sender.ToString()];
                        listView2.Items.Insert(msg.participants.Count+1, item1);
                    }
                    if (item.media_share_url != null)
                    {
                        var item1 = new ListViewItem("↳");
                        item1.SubItems.Add(item.media_share_url);
                        item1.BackColor = colorCode[item.sender.ToString()];
                        listView2.Items.Insert(msg.participants.Count+1, item1);
                    }
                    if (item.media_share_caption != null) {  
                        var item1 = new ListViewItem("↳");
                        item1.SubItems.Add(item.media_share_caption);
                        item1.BackColor = colorCode[item.sender.ToString()];
                        listView2.Items.Insert(msg.participants.Count+1, item1);
                    }
                    if (item.media_owner != null)
                    {
                        var item1 = new ListViewItem("↳");
                        item1.SubItems.Add(item.media_owner);
                        item1.BackColor = colorCode[item.sender.ToString()];
                        listView2.Items.Insert(msg.participants.Count+1, item1);
                    }                                         
                    if (item.story_share != null) {
                        var item1 = new ListViewItem("↳");
                        item1.SubItems.Add(item.story_share);
                        item1.BackColor = colorCode[item.sender.ToString()];
                        listView2.Items.Insert(msg.participants.Count+1, item1);
                    }                  
                    if (item.story_share_type != null) {  
                        var item1 = new ListViewItem("↳");
                        item1.SubItems.Add(item.story_share_type);
                        item1.BackColor = colorCode[item.sender.ToString()];
                        listView2.Items.Insert(msg.participants.Count+1, item1);
                    }
                    if (item.created_at != null)
                    {
                        var item1 = new ListViewItem(item.created_at.ToString());
                        if (item.text != null)
                        {
                            item1.SubItems.Add(item.text);

                        }
                        item1.BackColor = colorCode[item.sender.ToString()];
                        listView2.Items.Insert(msg.participants.Count+1, item1);
                    }
                }
            }            
        }
    }
}
