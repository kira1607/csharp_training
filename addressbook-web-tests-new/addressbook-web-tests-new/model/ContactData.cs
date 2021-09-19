using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests

{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>

    {
        private string lastname;
        private string middlename = "";
        private string firstname;
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string address2 = "";
        private string phone2 = "";
        private string notes = "";
        private string bday = "";
        private string bmonth = "";
        private string byear = "";
        private string aday = "";
        private string amonyh = "";
        private string ayear = "";

        public ContactData(string lastname, string firstname)
        {
            this.lastname = lastname;
            this.firstname = firstname;

        }
        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
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
    













        
    


    