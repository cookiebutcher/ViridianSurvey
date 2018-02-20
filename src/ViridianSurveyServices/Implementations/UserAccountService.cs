using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ViridianCode.ViridianSurvey.DataModel;
using ViridianCode.ViridianSurvey.DataRepository.Interfaces;
using ViridianCode.ViridianSurvey.Services.Interfaces;
using ViridianCode.ViridianSurvey.Services.Interfaces.WebModels;

namespace ViridianCode.ViridianSurvey.Services.Implementations
{
    public class UserAccountService : BaseService, IUserAccountService
    {
        public UserAccountService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public WebUserAccount Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = unitOfWork.UserAccounts.SearchFor(x => x.UserName == username).SingleOrDefault();

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return mapper.Map<WebUserAccount>(user);
        }

        public Task<IEnumerable<WebUserAccount>> GetAllUserAccountsAsync()
        {
            throw new NotImplementedException();
        }

        public WebUserAccount Create(WebUserAccount user)
        {
            // validation
            if (string.IsNullOrWhiteSpace(user.Password))
                throw new Exception("Password is required");

            var userFromDb = unitOfWork.UserAccounts.SearchFor(x => x.UserName == user.UserName);
            if (userFromDb != null)
                throw new Exception("Username " + user.UserName + " is already taken");

            CreatePasswordHash(user.Password, out var passwordHash, out var passwordSalt);

            UserAccount newUser = mapper.Map<UserAccount>(user);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;

            unitOfWork.UserAccounts.Add(newUser);
            unitOfWork.Complete();

            return mapper.Map<WebUserAccount>(newUser);
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
