using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Test.DataDriven
{
    public class ContactInfo
    {
        public String subject { get; set; }
        public String email { get; set; }
        public String orderID { get; set; }
        public String message { get; set; }

        public ContactInfo(string subject, string email, string orderID, string message)
        {
            this.subject = subject;
            this.email = email;
            this.orderID = orderID;
            this.message = message;
        }
    }
}
