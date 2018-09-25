using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace xworks.taskprocess
{
	class TaskFile
	{
		public List<Task> LoadTasks(string filePath)
		{
			List<Task> Tasks = new List<Task>();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(filePath);
            XmlNodeList tasknodes = xmldoc.DocumentElement.ChildNodes;
            foreach (XmlNode tasknode in tasknodes)
            {
                XmlNodeList taskdetails = tasknode.ChildNodes;
                Task ts = new Task();
                foreach (XmlNode taskdetail in taskdetails)
                {
                    if (taskdetail.Name == "Id")
                    {
                        ts.Id =Guid.Parse(taskdetail.Value);
                    }
                    else if (taskdetail.Name == "Author")
                    {
                        ts.Author = taskdetail.InnerText;

                    }
                    else if (taskdetail.Name == "SubmitTime")
                    {
                        ts.SubmitTime =DateTime.ParseExact(taskdetail.InnerText ,"yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                    }
                    else if (taskdetail.Name == "Priority")
                    {
                        ts.Priority =(TaskPriority)Enum.Parse(typeof(TaskPriority), taskdetail.InnerText);

                    }
                    else if (taskdetail.Name == "DueTime")
                    {
                        ts.DueTime = DateTime.ParseExact(taskdetail.InnerText, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                    }
                    else if (taskdetail.Name == "Assignee")
                    {
                        ts.Assignee = taskdetail.InnerText;

                    }
                    else if (taskdetail.Name == "Content")
                    {
                        ts.Content = taskdetail.InnerText;
                    }
                    else if (taskdetail.Name == "HandlingNote")
                    {
                        ts.HandlingNote = taskdetail.InnerText;
                    }
                    else if (taskdetail.Name =="Status")
                    {
                        ts.Status =(TaskStatus)Enum.Parse(typeof(TaskStatus), taskdetail.InnerText);
                    }
                    else if (taskdetail.Name == "Checker")
                    {
                        ts.Checker = taskdetail.InnerText;

                    }
                    else
                    {
                        ts.CheckTime = DateTime.ParseExact(taskdetail.InnerText, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                    }
                        
              
                }
                Tasks.Add(ts);
            }


			//TODO
			return Tasks;
		}


        public static void SaveTasks(List<Task> tasks)
        {
            string path = "";
            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.Indent = true;
            writerSettings.IndentChars = (" ");
            XmlWriter writeXml = null;

            try
            {
                writeXml = XmlWriter.Create(path, writerSettings);
                writeXml.WriteStartDocument();//开头
                writeXml.WriteStartElement("tasks");

                foreach (Task task in tasks)
                {
                    writeXml.WriteStartElement("task");
                    writeXml.WriteAttributeString("id", task.Id.ToString());
                    writeXml.WriteElementString("Author",task.Author);
                    writeXml.WriteElementString("SubmitTime", task.SubmitTime.ToString("yyyy-MM-dd"));
                    writeXml.WriteElementString("Priority", Enum.GetName(typeof(TaskStatus),task.Priority));
                    writeXml.WriteElementString("DueTime", task.DueTime.ToString("yyyy-MM-dd"));
                    writeXml.WriteElementString("Assignee", task.Assignee);
                    writeXml.WriteElementString("Content", task.Content);
                    writeXml.WriteElementString("HandlingNote", task.HandlingNote);
                    writeXml.WriteElementString("Status", Enum.GetName(typeof(TaskStatus), task.Status));
                    writeXml.WriteElementString("Checker", task.Checker);
                    writeXml.WriteElementString("CheckTime", task.CheckTime.ToString("yyyy-MM-dd"));
                }
                writeXml.WriteEndElement();
            }
            catch(XmlException ex)
            {
                MessageBox.Show(ex.Message, "xml Error ");
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "IO Exception");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Occurred");
            }
            finally
            {
                if (writeXml != null)
                    writeXml.Close();
            }
        }

	}
}
