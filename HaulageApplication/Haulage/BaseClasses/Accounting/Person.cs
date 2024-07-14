using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.Accounting
{
    //class to hold person functionality (Administrator / Customer / Driver will inherit)
    public class Person
    {
        //Variables to hold person attributes that admin / customer / driver will inherit
        string name, emailAddress;
        int phoneNumber;
        public Guid id;

        //Enum to hold roles of the users interacting with the application
        enum Role
        { driver, 
          administrator, 
          customer }
        
        public Person() { }


    }
}
