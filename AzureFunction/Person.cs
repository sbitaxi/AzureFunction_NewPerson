

using System;

namespace People.NewPerson
{
    public class Person
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }

    /*
        CompleteRecord is for testing purposes only
        It will be included in the return message
        to Postman but is to be removed with the 
        live app
    
        public string CompleteRecord
        {
            get
            {
                return FirstName + ' ' + LastName + Environment.NewLine +
                        Email + Environment.NewLine +
                        Address + Environment.NewLine +
                        City + ' ' + Province + ' ' + PostalCode;
            }
        }
        */
    }
}