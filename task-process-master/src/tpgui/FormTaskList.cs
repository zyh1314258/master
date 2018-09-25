using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace xworks.taskprocess
{
    public partial class FormTaskList : Form
    {
        public FormTaskList()
        {
            InitializeComponent();
        }
        private List<Task> tasks = new List<Task>();
		private void _toolStripButtonOpen_Click(object sender, EventArgs e)
		{
			TaskFile tf = new TaskFile();
            string path = "";
           
         OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
            }
             List<Task> tasks = tf.LoadTasks(path);
              listView1.Items.Clear();
             int i = 0;
         
             foreach (Task t in tasks)
             {
                 i++;
                 //add to list view
                 //TODO
                 ListViewItem lvi = new ListViewItem();
                 lvi.SubItems[0].Text = i.ToString();
                 lvi.SubItems.Add(t.Author);
                 lvi.SubItems.Add(t.SubmitTime.ToString());
                 //lvi.SubItems.Add(x.DueTime.ToString());
                 lvi.SubItems.Add(t.Content);
                 lvi.SubItems.Add(t.HandlingNote);
                 lvi.SubItems.Add(Enum.GetName(typeof(TaskStatus), t.Status));
                 lvi.SubItems.Add("");
                 lvi.SubItems.Add(t.Assignee);
                 lvi.SubItems.Add(t.CheckTime.ToString());
                 lvi.SubItems.Add(t.Checker);
                 listView1.Items.Add(lvi);
             }

		}

        private void FillTaskListView()
        {
         listView1.Items.Clear();

           foreach (Task t in tasks)
            {
              string taskString = t.GetTaskString("#");
                char[] delimiter = { '#' };
                string[] taskStrings = taskString.Split(delimiter);
                ListViewItem item = new ListViewItem(taskStrings);
                listView1.Items.Add(item);

            }
/*
            int i = 0;

            foreach (Task t in tasks)
            {
                i++;
                //add to list view
                //TODO
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems[0].Text = i.ToString();
                lvi.SubItems.Add(t.Author);
                lvi.SubItems.Add(t.SubmitTime.ToString());
                //lvi.SubItems.Add(x.DueTime.ToString());
                lvi.SubItems.Add(t.Content);
                lvi.SubItems.Add(t.HandlingNote);
                lvi.SubItems.Add(Enum.GetName(typeof(TaskStatus), t.Status));
                lvi.SubItems.Add("");
                lvi.SubItems.Add(t.Assignee);
                lvi.SubItems.Add(t.CheckTime.ToString());
                lvi.SubItems.Add(t.Checker);
                listView1.Items.Add(lvi);
            }
*/
        }

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
           // TaskFile ts = new TaskFile();
			FormTaskEdit f = new FormTaskEdit();
            	f.ShowDialog();

            Task task =new Task();
            if (task != null)
            {
                tasks.Add(task);
                TaskFile.SaveTasks(tasks);
                FillTaskListView();
            }
		



		}

		private void toolStripButton8_Click(object sender, EventArgs e)
		{
			FormTaskEdit f = new FormTaskEdit();
			f.ShowDialog();
		}

		private void toolStripButton7_Click(object sender, EventArgs e)
		{
			FormTaskProcess f = new FormTaskProcess();
			f.ShowDialog();
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			FormTaskConfirm f = new FormTaskConfirm();
			f.ShowDialog();
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			FormLinkFile f = new FormLinkFile();
			f.ShowDialog();
		}

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
           int currentIndex = 0;
            if (this.listView1.SelectedItems.Count > 0)//判断listview有被选中项
            {
                currentIndex = this.listView1.SelectedItems[0].Index;//取当前选中项的index
                listView1.Items[currentIndex].Remove();
            } 

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            List<Task> tasks=new List<Task>();//怎么才能把listview里的数据保存到list中呢。。
          

            TaskFile.SaveTasks(tasks);
        }
    }
}
