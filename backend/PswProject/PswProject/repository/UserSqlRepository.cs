using PswProject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.repository
{
    public class UserSqlRepository : UserRepository
    {
        public MyDbContext dbContext { get; set; }

        public UserSqlRepository() { }

        public UserSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(User user)
        {
            int id = dbContext.Users.ToList().Count > 0 ? dbContext.Users.ToList().Max(user => user.Id) + 1 : 1;
            user.Id = id;
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public User findOneByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetOne(string id)
        {
            throw new NotImplementedException();
        }

        public User save(User user)
        {
            throw new NotImplementedException();
        }

        public bool Save(User newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(User editedObject)
        {
            throw new NotImplementedException();
        }
    }
}
