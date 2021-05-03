using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class ClientDataReciever : TemplateDataReciever
    {
        private DatabaseHandler dh;
        public ClientDataReciever()
        {
            this.dh = new DatabaseHandler("sen");
        }

        public Dictionary<string,string> getData(object obj)
        {
            Dictionary<string, string> details = new Dictionary<string, string>();
            Client client = (Client)obj;
            if (client != null)
            {
                details.Add("id", client.Id);
                details.Add("contract", client.Contract);
                details.Add("firstName", client.FirstName);
                details.Add("lastName", client.LastName);
                details.Add("phoneNumber", client.PhoneNumber);
                details.Add("location", client.Location);
            }
            return details;
        }

        public void Add(Dictionary<string, string> entity)
        {
            this.dh.execute(string.Format("Exec AddClient  @ID = {0}, @ServiceLevel = '{1}', @FirstName = '{2}', @LastName = '{3}', @Location = '{4}', @PhoneNumber = '{5}'",
                entity["id"], entity["contract"], entity["firstName"], entity["lastName"], entity["location"], entity["phoneNumber"]));
        }

        public object[] Get()
        {
            List<Client> cList = new List<Client>();
            foreach (string line in this.dh.Read("Exec GetClients"))
            {
                //Console.WriteLine(line);
                string[] splitText = line.Split(',');
                cList.Add(new Client(splitText[0], splitText[1], splitText[2], splitText[3], splitText[4], splitText.Length == 6 ? splitText[5] : splitText[5]+", "+splitText[6]));
            }
            return cList.ToArray();
        }

        public void Remove(string id)
        {
            this.dh.execute(string.Format("Exec RemoveClient @ID = {0}", id));
        }

        public void Update(object oldData, Dictionary<string, string> newData)
        {
            
        }
    }
}
