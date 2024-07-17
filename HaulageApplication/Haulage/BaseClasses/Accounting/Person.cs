using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.Accounting
{
    //Class to contain Person functionality of the application
    public class Person
    {
        //Variables to contain the attributes of users that interact with the application
        string name, emailAddress;
        int phoneNumber;
        public Guid id;

        //Enum to contain the roles of users that interact with the system
        enum Role
        { driver, 
          administrator, 
          customer }
        
        public Person() { }


    }
}
