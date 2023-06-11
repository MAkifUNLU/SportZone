using SportZone.Service.Data;
using SportZone.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportZone.Service.Core
{
    public class LoginService
    {
        private readonly AppDbContext _db;
        public LoginService(AppDbContext db)
        {
            _db = db;
        }
       
        public User CheckUser(LoginViewModel viewModel)
        {
            var user = _db.Users.FirstOrDefault(p => p.Email == viewModel.Email && p.Password == viewModel.Password);
                return user;
        }
       
    }
}
