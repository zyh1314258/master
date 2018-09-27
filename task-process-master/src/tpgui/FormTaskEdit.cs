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

            this.radioButton1.CheckedChanged += new EventHandler(this.radioBtn_CheckedChange);
            this.radioButton2.CheckedChanged += new EventHandler(this.radioBtn_CheckedChange);
            this.radioButton3.CheckedChanged += new EventHandler(this.radioBtn_CheckedChange);
            this.radioButton4.CheckedChanged += new EventHandler(this.radioBtn_CheckedChange);

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
          //拿到add的数据

           radioBtn_CheckedChange(sender,e);
           TaskPriority tp = (TaskPriority)Enum.Parse(typeof(TaskPriority),this.groupBox1.Text);

         /*  string str = null;
           if (radioButton1.Checked == true)
           {
               str = radioButton1.Name;
           }
           else if (radioButton2.Checked == true)
           {
               str = radioButton2.Name;
           }
           else if (radioButton3.Checked == true)
           {
               str = radioButton3.Name;
           }
           else
           {
               str = radioButton4.Name;
           }
*/

            DateTime  dt = Convert.ToDateTime(dateTimePicker1.Text);
            String assignee = textBox2.Text;
            String content = textBox1.Text;

           task = new Task(tp,dt, assignee, content);

           this.Close();
        }

        //添加一个radiobutton事件,可以点一个按钮后，groupbox就会获得我们所选的值，然后把这个值添加进去，。。。
        public void radioBtn_CheckedChange(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
            {
                return;
            }
            string reproprity = string.Empty;
            switch (((RadioButton)sender).Name)
            {
                case "radioButton1":
                    reproprity = "高";
                    this.groupBox1.Text = reproprity;
                    break;
                case "radioButton2":
                    reproprity = "中";
                    this.groupBox1.Text = reproprity;
                    break;
                case "radioButton3":
                    reproprity = "普通";
                    this.groupBox1.Text = reproprity;
                    break;
                case "radioButton4":
                    reproprity = "低";
                    this.groupBox1.Text = reproprity;
                    break;
                default:
                    break;

            }

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void FormTaskEdit_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否取消编辑？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
          
        }
    }
}
