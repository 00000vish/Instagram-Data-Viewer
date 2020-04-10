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
    public partial class CommonForm : Form
    {
        public CommonForm()
        {
            InitializeComponent();
        }

        public void Show(int types)
        {
            listView1.Clear();
            switch(types){
                case 1:listView1.Columns.Add("Time", 140, HorizontalAlignment.Left);
                    listView1.Columns.Add("@", 140, HorizontalAlignment.Left);
                    listView1.Columns.Add("Comment", 260, HorizontalAlignment.Left); 
                    Size = new Size(280+260+50, 500); break;
                case 2: listView1.Columns.Add("IP Address", 140, HorizontalAlignment.Left);
                    listView1.Columns.Add("Timestamp", 160, HorizontalAlignment.Left);
                    Size = new Size(280+60, 500); break;
                case 3:
                    listView1.Columns.Add("First Name", 140, HorizontalAlignment.Left);
                    listView1.Columns.Add("Last Name", 160, HorizontalAlignment.Left);
                    listView1.Columns.Add("Contact", 160, HorizontalAlignment.Left);
                    Size = new Size(280 + 160 + 60, 500); break;
                case 4:
                    listView1.Columns.Add("Timestamp", 140, HorizontalAlignment.Left);
                    listView1.Columns.Add("Posted by", 160, HorizontalAlignment.Left);
                    Size = new Size(280 + 60, 500); break;
                case 5:
                    listView1.Columns.Add("Timestamp", 140, HorizontalAlignment.Left);
                    listView1.Columns.Add("Type", 80, HorizontalAlignment.Left);
                    listView1.Columns.Add("Searched", 160, HorizontalAlignment.Left);
                    Size = new Size(280 + 120, 500); break;
                default: break;
            }
            Show();
        }

        private void CommonForm_Load(object sender, EventArgs e)
        {

        }
    }
}
