using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstagramJsonMessages
{
    public partial class ProcessDataWindow : Form
    {
        ArrayList paths = new ArrayList();
        public ProcessDataWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                paths.Add(fbd.SelectedPath);
                button1.Text = "Add another folder";
                this.Size = new Size(this.Size.Width, this.Size.Height + 20);
                updateLabelDumpList();
            }
        }
        
        private void updateLabelDumpList()
        {
            label1.Text = "";
            foreach (var item in paths)
            {
                label1.Text += item.ToString().Split('\\')[item.ToString().Split('\\').Length-1] + "\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            MainWindow fm1 = new MainWindow();
            this.Hide();
            fm1.Show(lookForData());
        }

        private InstagramData lookForData()
        {
            List<string> logins = new List<string>();
            List<string> comments = new List<string>();
            List<string> connections = new List<string>();
            List<string> contacts = new List<string>();
            List<string> profile = new List<string>();
            List<string> media = new List<string>();
            List<string> likes = new List<string>();
            List<string> saved = new List<string>();
            List<string> search = new List<string>();
            List<string> msgs = new List<string>();

            foreach (string item in paths)
            {
                logins.AddRange(Directory.GetFiles(item, "*account_history.json", SearchOption.AllDirectories));
                connections.AddRange(Directory.GetFiles(item, "*connections.json", SearchOption.AllDirectories));
                contacts.AddRange(Directory.GetFiles(item, "*contacts.json", SearchOption.AllDirectories));
                profile.AddRange(Directory.GetFiles(item, "*profile.json", SearchOption.AllDirectories));
                media.AddRange(Directory.GetFiles(item, "*media.json", SearchOption.AllDirectories));
                comments.AddRange(Directory.GetFiles(item, "*comments.json", SearchOption.AllDirectories));
                likes.AddRange(Directory.GetFiles(item, "*likes.json", SearchOption.AllDirectories));
                saved.AddRange(Directory.GetFiles(item, "*saved.json", SearchOption.AllDirectories));
                search.AddRange(Directory.GetFiles(item, "*searches.json", SearchOption.AllDirectories));
                msgs.AddRange(Directory.GetFiles(item, "*messages.json", SearchOption.AllDirectories));
            }

            JSONReader reader = new JSONReader();
            InstagramData temp = new InstagramData();
            Media pics = null;

            if (logins.Count() == 1 && comments.Count() == 1 && connections.Count() == 1 && contacts.Count() == 1 && profile.Count() == 1 && likes.Count() == 1)
            {
                temp.user = (reader.getProfile(File.ReadAllText(profile[0])));
                temp.logins = (reader.praseLoginHistory(File.ReadAllText(logins[0])));
                temp.comments = (reader.praseCommentHistory(File.ReadAllText(comments[0])));
                temp.contacts = (reader.praseContacts(File.ReadAllText(contacts[0])));
                temp.follows = (reader.praseConnections(File.ReadAllText(connections[0])));
                temp.likes = (reader.praseLikes(File.ReadAllText(likes[0])));
                temp.saved = (reader.praseSaved(File.ReadAllText(saved[0])));
                temp.search = (reader.praseSearch(File.ReadAllText(search[0])));
                temp.msgs = (reader.praseMessages(File.ReadAllText(msgs[0])));
            }

            foreach (string item in media)
            {
                if (pics != null)
                {
                    pics.joinData(reader.praseMedia(File.ReadAllText(item)));
                }
                else
                {
                    pics = reader.praseMedia(File.ReadAllText(item));
                }
            }
            temp.pics = pics;
            temp.pathes = paths;
            return temp;
        }
    }
}
