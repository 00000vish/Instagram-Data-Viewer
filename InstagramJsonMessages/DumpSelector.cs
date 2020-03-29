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
    public partial class DumpSelector : Form
    {
        ArrayList paths = new ArrayList();
        public DumpSelector()
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

            foreach (string item in paths)
            {
                logins.AddRange(Directory.GetFiles(item, "*account_history.json", SearchOption.AllDirectories));
                connections.AddRange(Directory.GetFiles(item, "*connections.json", SearchOption.AllDirectories));
                contacts.AddRange(Directory.GetFiles(item, "*contacts.json", SearchOption.AllDirectories));
                profile.AddRange(Directory.GetFiles(item, "*profile.json", SearchOption.AllDirectories));
                media.AddRange(Directory.GetFiles(item, "*media.json", SearchOption.AllDirectories));
                comments.AddRange(Directory.GetFiles(item, "*comments.json", SearchOption.AllDirectories));
            }

            return processData(logins, comments, connections, contacts, profile, media);
        }
        private InstagramData processData(List<string> l, List<string> c, List<string> cc,
            List<string> ccc, List<string> p, List<string> m)
        {
            JSONReader reader = new JSONReader();
            InstagramData temp = new InstagramData(); 
            Media pics = null;

            if (l.Count() ==1  && c.Count() == 1 && cc.Count() ==1 && ccc.Count() == 1 && p.Count() == 1)
            {
                temp.user = (reader.getProfile(File.ReadAllText(p[0])));
                temp.logins = (reader.praseLoginHistory(File.ReadAllText(l[0])));
                temp.comments = (reader.praseCommentHistory(File.ReadAllText(c[0])));
                temp.contacts = (reader.praseContacts(File.ReadAllText(ccc[0])));
                temp.follows = (reader.praseConnections(File.ReadAllText(cc[0])));
            }

            foreach (string item in m)
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
            temp.pics =  pics ;
            return temp;
        }
    }
}
