using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Timereport.Controllers
{
    internal class AdminUser
    {
        private Func<Task<IActionResult>> identityUser;

        public AdminUser(Func<Task<IActionResult>> identityUser)
        {
            this.identityUser = identityUser;
        }
    }
}