using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xworks.taskprocess
{
    public partial class FormTaskEdit : Form


    {
        ListViewItem oldItem = new ListViewItem();
		public FormTaskEdit()
		{
			InitializeComponent();
		}
        private Task task = null;
      /*  public Task GetNewTask()
       {
            this.ShowDialog();
            return task;
        }
        */
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
       //     Task ts = new Task();

          
          //拿到add的数据
            //优先权不会弄
            TaskPriority tp = (TaskPriority)Enum.Parse(typeof(TaskPriority), radioButton1.Text);

            DateTime  dt = Convert.ToDateTime(dateTimePicker1.Text);
            String assignee = textBox2.Text;
            String content = textBox1.Text;
       //     ts.DueTime = dt;
         //   ts.Assignee = assignee;
           // ts.Content = content;

           task = new Task(tp,dt, assignee, content);

           this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
