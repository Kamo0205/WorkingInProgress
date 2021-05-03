using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class Employee
    {
        private string id;
        private string firstName;
        private string lastName;
        private string skill;
        private string classfication;
        private string phoneNumber;

        public string Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Skill { get => skill; set => skill = value; }
        public string Classfication { get => classfication; set => classfication = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        public Employee(string id, string skill, string firstName, string lastName, string classfication, string phoneNumber)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.skill = skill;
            this.classfication = classfication;
            this.phoneNumber = phoneNumber;
        }

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
            return this.chrToInt(this.id) * this.chrToInt(this.firstName) * this.chrToInt(this.lastName);
        }
        /*
        public override bool Equals(object obj)
        {
            return GetHashCode() == ((Employee)obj).GetHashCode();
        }*/

        public override string ToString()
        {
            return string.Format("{0,-10} {1,-15} {2,-15} {3,-15} {4,-15} {5,-15}", this.id, this.firstName, this.lastName, this.skill, this.classfication, this.phoneNumber);
        }
    }
}
