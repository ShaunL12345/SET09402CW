using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.Accounting
{
    public class Person
    {
        string name, emailAddress;
        int phoneNumber;
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        enum Role
        { driver, 
          administrator, 
          customer }
        
        public Person() { }


    }
}
