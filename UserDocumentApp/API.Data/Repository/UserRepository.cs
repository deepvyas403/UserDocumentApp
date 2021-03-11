using API.Core.IRepository;
using API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Data.Repository
{
    public class UserRepository : IDataRepository<User>
    {
        readonly UserDocumentDBContext _dbContext;
        public UserRepository(UserDocumentDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Created By : Deep Vyas | 11-Mar-2021
        /// Description : To Add user document
        /// </summary>
        public void Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Created By : Deep Vyas | 11-Mar-2021
        /// Description : To Delete user document
        /// </summary>
        public void Delete(User user)
        {
            User userInfo = this.Get(user.UserId);
            userInfo.IsActive = false;
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Created By : Deep Vyas | 11-Mar-2021
        /// Description : To get user document based on Identity
        /// </summary>
        public User Get(int id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.UserId == id);
        }

        /// <summary>
        /// Created By : Deep Vyas | 11-Mar-2021
        /// Description : To get all user documents
        /// </summary>
        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.Select(x => Convert.ToBoolean(x.IsActive)) as IEnumerable<User>;
        }
    }
}
