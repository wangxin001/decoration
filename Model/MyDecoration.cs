using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
  public  class MyDecoration
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string process;

        public string Process
        {
            get { return process; }
            set { process = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private string starttime;

        public string Starttime
        {
            get { return starttime; }
            set { starttime = value; }
        }
        private string endtime;

        public string Endtime
        {
            get { return endtime; }
            set { endtime = value; }
        }
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private string createTime;

        public string CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }
    }
}
