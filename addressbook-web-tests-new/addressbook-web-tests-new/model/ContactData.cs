using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests

{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>

    {
       public string lastname;
        public string firstname;
        public string allPhones;

        public ContactData(string lastname, string firstname)
        {
            LastName = lastname;
            FirstName = firstname;

        }
        public string LastName { get; set; }
      
        public string FirstName { get; set; }
       
        public string Id { get; set; }

        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }

        public string AllPhones 
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set 
            {
                allPhones = value;
            } }


        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }


        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (lastname == other.lastname & firstname == other.firstname);



        }
        public override int GetHashCode()
        {
            return LastName.GetHashCode() & FirstName.GetHashCode();

        }
        public override String ToString()
        {
            return ("lastName = " + LastName) + " " + ("firstName = " + FirstName);
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (LastName.CompareTo(other.LastName) == 0)

            {
                if (FirstName.CompareTo(other.FirstName) == 0)
                {
                    return FirstName.CompareTo(other.FirstName);
                }
                return LastName.CompareTo(other.LastName);
            }
            return 0;
        }
    }
}
    













        
    


    