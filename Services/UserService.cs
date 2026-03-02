using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogapi.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace blogapi.Services
{
    public class UserService
    {
    private readonly Context _context;

    public UserService(Context context)
    {
        _context = context;
    }
        internal bool AddUser(CreateAccountDTO userToAdd)
        {
            throw new NotImplementedException();
        }
    }
}