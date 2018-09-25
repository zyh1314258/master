using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xworks.taskprocess
{
	class Task
	{ 
        public Task(){}
      public   Task(TaskPriority taskpriority,DateTime duetime,string assignee,string content)
        {
            Priority = taskpriority;
            DueTime = duetime;
            Assignee = assignee;
            Content = content;

        }
        public Guid Id { get; set; }//唯一识别ID
        public string Author { get; set; }//提交者
        public DateTime SubmitTime { get; set; }//提交时间
        public TaskPriority Priority { get; set; }//优先度
        public DateTime DueTime { get; set; }//预定日
        public string Assignee { get; set; }//作业者
        public string Content { get; set; }//内容
        public string HandlingNote { get; set; }//处理内容
        public TaskStatus Status { get; set; }
        public string Checker { get; set; }//确认者
        public DateTime CheckTime { get; set; }//确认时间



         public string GetTaskString(string sep)
        {
            return Id.ToString()+ sep + Author + sep + SubmitTime.ToString("yyyy-MM-dd") + sep +
             Enum.GetName(typeof(TaskStatus), Priority) + sep + DueTime.ToString("yyyy-MM-dd") + sep + Assignee + sep +
                Content+sep+HandlingNote+sep+Enum.GetName(typeof(TaskStatus),Status)+sep+
                Checker + sep + CheckTime.ToString("yyyy-MM-dd");
        }

	}

    
}
