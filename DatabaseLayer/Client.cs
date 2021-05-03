using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class Client
    {
        private string id;
        private string contract;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string location;

        public Client(string id, string contract, string firstName, string lastName, string phoneNumber, string location)
        {
            this.Id = id;
            this.Contract = contract;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.Location = location;
        }

        public string Id { get => id; set => id = value; }
        public string Contract { get => contract; set => contract = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Location { get => location; set => location = value; }

        private int chrToInt(string word)
        {
            int total = 0;
            foreach (char letter in word)
            {
                total += (int)letter;
            }
            return total;
        }

        public override int GetHashCode()
        {
            return this.chrToInt(this.Id)*this.chrToInt(this.FirstName)*this.chrToInt(this.lastName);
        }
        /*
        public override bool Equals(object obj)
        {
            return GetHashCode() == ((Client)obj).GetHashCode();
        }*/

        public override string ToString()
        {
            return string.Format("{0,-10} {1,-15} {2,-15} {3,-15} {4,-15} {5,-20}", this.id, this.firstName, this.lastName, this.contract, this.phoneNumber, this.location);
        }
    }
}
