using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class Job
    {
        private string id;
        private string clientName;
        private string status;
        private DateTime startDate;
        private DateTime endDate;
        private string details;

        public Job(string id, string clientName, string status, DateTime startDate, DateTime endDate, string details)
        {
            this.Id = id;
            this.ClientName = clientName;
            this.Status = status;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Details = details;
        }

        public string Id { get => id; set => id = value; }
        public string ClientName { get => clientName; set => clientName = value; }
        public string Status { get => status; set => status = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public string Details { get => details; set => details = value; }

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   clientName == job.clientName &&
                   status == job.status &&
                   startDate == job.startDate &&
                   endDate == job.endDate &&
                   details == job.details;
        }

        public override int GetHashCode()
        {
            int hashCode = -221042558;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(clientName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(status);
            hashCode = hashCode * -1521134295 + startDate.GetHashCode();
            hashCode = hashCode * -1521134295 + endDate.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(details);
            return hashCode;
        }
    }
}
