using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;

namespace BuisnessLay
{
    public class DataHandler
    {
        private ClientDataReciever cdr;
        private EmployeeDataReciever edr;
        public DataHandler()
        {
            this.cdr = new ClientDataReciever();
            this.edr = new EmployeeDataReciever();
        }

        public object[] getClients()
        {
            return this.cdr.Get();
        }

        public object[] getEmployees()
        {
            return this.edr.Get();
        }

        public Dictionary<string, string> getClientDetails(object obj)
        {
            return this.cdr.getData(obj);
        }

        public Dictionary<string, string> getEmployeeDetails(object obj)
        {
            return this.edr.getData(obj);
        }

        public void addClient(Dictionary<string, string> newClient)
        {
            this.cdr.Add(newClient);
        }

        public void addEmployee(Dictionary<string, string> newEmployee)
        {
            this.cdr.Add(newEmployee);
        }

        public void removeClient(object client)
        {
            this.cdr.Remove(this.getClientDetails(client)["id"]);
        }

        public void removeEmployee(object employee)
        {
            this.cdr.Remove(this.getEmployeeDetails(employee)["id"]);
        }
    }
}
