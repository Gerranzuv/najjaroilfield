using Microsoft.AspNet.Identity.EntityFramework;
using najjar.biz.Context;
using System.Collections.Generic;

namespace najjar.biz.Models
{
    public class ApplicationUser : IdentityUser
    {
        private ApplicationDataContext db = new ApplicationDataContext();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserType{ get; set; }
        public int EmployeeId { get; set; }

        public IEnumerator<ApplicationUser> GetEnumerator()
        {
            foreach(var user in db.Users)
            {
                yield return user;
            }
        }
    }


}