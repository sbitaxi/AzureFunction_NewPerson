using System;
using Microsoft.EntityFrameworkCore;

namespace People.NewPerson
{
    public class AddNewPersonSproc
    {

        private readonly MyContext _context;

        public AddNewPersonSproc(MyContext myContext)
        {
            _context = myContext;
        }

        public async void ExecuteSproc(Person person)
        {
            await _context.Database.ExecuteSqlRawAsync(
                    @"AddNewPerson @FirstName,
                                @LastName, 
                                @Email, 
                                @Address, 
                                @City, 
                                @Province,
                                @PostalCode", 
                        person.FirstName,
                        person.LastName,
                        person.Email,
                        person.Address,
                        person.City,
                        person.Province,
                        person.PostalCode
                        );
        }
    }    
}
