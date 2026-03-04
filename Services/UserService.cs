using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using blogapi.Models;
using blogapi.Models.DTO;
using blogapi.Services.Context;
using Microsoft.EntityFrameworkCore;

namespace blogapi.Services
{
    public class UserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        //We need help method to check user exist in our database
        public bool DoesUserExist(string username)
        {
            // Check our table to see  if user name exist
            return _context.UserInfo.SingleOrDefault(user => user.Username == username) != null;
        }
        public bool AddUser(CreateAccountDTO userToAdd)
        {
            bool result = false;
            if (userToAdd.Username != null && !DoesUserExist(userToAdd.Username))
            {
                UserModel newUser = new UserModel();

                var hashPassword = HashPassword(userToAdd.Password);

                newUser.Id = userToAdd.Id;
                newUser.Username = userToAdd.Username;
                newUser.Salt = hashPassword.Salt;
                newUser.Hash = hashPassword.Hash;
                _context.Add(newUser);

                result = _context.SaveChanges() != 0;
            }

            return result;

            //We are going to need Hash our function help us hash our password
            //To set our newUser Id = UserToAdd.Id
            //Username
            //Salt
            //Hash

            // Then we add it out DataContext
            //Save our Changes
            //Return a bool to return true or false 
        }

        //Function that help hash our password
        public PasswordDTO HashPassword(string? password)
        {
            PasswordDTO newHashedPassword = new PasswordDTO();
            byte[] SaltBytes = new byte[64];

            var provider = RandomNumberGenerator.Create();
            provider.GetNonZeroBytes(SaltBytes);

            var Salt = Convert.ToBase64String(SaltBytes);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password ?? "", SaltBytes, 10000, HashAlgorithmName.SHA256);
            var Hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            newHashedPassword.Salt = Salt;
            newHashedPassword.Hash = Hash;

            return newHashedPassword;
        }

        //Helper function to verify password
        public bool verifyUserPassword(string? Password, string? StoredHash, string? StoreSalt)
        {
            if (StoreSalt == null)
            {
                return false;
            }
            var SaltBytes = Convert.FromBase64String(StoreSalt);
            var rfc2898DriveBytes = new Rfc2898DeriveBytes(Password ?? "", SaltBytes, 10000, HashAlgorithmName.SHA256);

            var newHash = Convert.ToBase64String(rfc2898DriveBytes.GetBytes(256));

            return newHash == StoredHash;

        }




    }
}