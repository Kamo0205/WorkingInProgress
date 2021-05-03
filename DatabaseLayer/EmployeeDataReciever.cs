using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class EmployeeDataReciever : TemplateDataReciever
    {
        private DatabaseHandler dh;
        public EmployeeDataReciever()
        {
            this.dh = new DatabaseHandler("sen");
        }

        public Dictionary<string, string> getData(object obj)
        {
            Employee employee = (Employee)obj;
            Dictionary<string, string> details = new Dictionary<string, string>();
            details.Add("id", employee.Id);
            details.Add("skill", employee.Skill);
            details.Add("classification", employee.Classfication);
            details.Add("firstName", employee.FirstName);
            details.Add("lastName", employee.LastName);
            details.Add("phoneNumber", employee.PhoneNumber);
            return details;
        }

        public void Add(Dictionary<string, string> entity)
        {
            this.dh.execute(string.Format("Exec AddEmployee @ID = {0}, @FirstName = '{1}', @LastName = '{2}', @Skill = '{3}', @EmployeeClassification = '{4}', @PhoneNumber = '5'",
                entity["id"], entity["firstName"], entity["lastName"], entity["skill"], entity["classfication"], entity["phoneNumber"]));
        }

        public object[] Get()
        {
            List<Employee> eList = new List<Employee>();
            foreach (string line in this.dh.Read("Exec GetEmployees"))
            {
                //Console.WriteLine(line);
                string[] splitText = line.Split(',');
                eList.Add(new Employee(splitText[0], splitText[1], splitText[2], splitText[3], splitText[4], splitText[5]));
            }
            return eList.ToArray();
        }

        public void Remove(string id)
        {
            this.dh.execute(string.Format("Exec RemoveEmployee @ID = {0}", id));
        }

        public void Update(object oldData, Dictionary<string, string> newData)
        {
            
        }
    }
}
