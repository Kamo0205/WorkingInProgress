using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class JobDataReciever : TemplateDataReciever
    {
        private DatabaseHandler dh;
        public JobDataReciever()
        {
            this.dh = new DatabaseHandler("sen");
        }

        public void Add(Dictionary<string, string> entity)
        {
            
        }

        public object[] Get()
        {
            return new object[] { };
        }

        public Dictionary<string, string> getData(object obj)
        {
            throw new NotImplementedException();
            Dictionary<string, string> details = new Dictionary<string, string>();
            Job job = (Job)job;
        }

        public void Remove(string id)
        {
            
        }

        public void Update(object oldData, Dictionary<string, string> newData)
        {
            
        }
    }
}
