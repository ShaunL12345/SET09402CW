using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.Accounting
{
    public class User
    {
        public int userId { get; set; }
        public int roleId { get; set; }
        public string? fullname { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
        public Role CompanyRole { get; set; }
        public string? address { get; set; }

      
            
        
    }
    public enum Role
    {
        Driver,
        Administrator,
        Customer
    }
}
