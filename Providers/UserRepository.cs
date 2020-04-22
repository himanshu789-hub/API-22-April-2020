using CarPoolAPI.RepositoryInterfaces;
using CarPoolAPI.Models;
using System.Linq;
using System.Collections.Generic;
using CarPoolAPI.PostModel;
namespace CarPoolAPI.RepositoryProcessory
{
    public class UserRepository : IUserRepository
    {
        CarPoolContext _context;
        public UserRepository(CarPoolContext context) => _context = context;

        public User Create(UserDTO pUser)
        {
            User user = new User
            {
                Name = pUser.Name,
                Password = pUser.Password,
                Age = pUser.Age,
                Gender = pUser.Gender,
                ImageUploadedName = pUser.ImageUploadedName,
                Active = true,
                EmailId=pUser.EmailId
            };
            var addedUser = _context.Users.Add(user);
            _context.SaveChanges();

            return addedUser.Entity;
        }   //DONE
        public User Update(UserDTO user){
         User User =   _context.Users.FirstOrDefault(e=>e.Id==user.Id);
         User.Name = user.Name;
         User.ImageUploadedName = user.ImageUploadedName;
         User.EmailId = user.EmailId;  
         User.Age = user.Age;
         User.Gender = user.Gender;
         User.Password = user.Password;
        _context.SaveChanges();
        return User;
        }
        public bool Delete(int userId)
        {
            using (var context = new CarPoolContext())
            {
                context.Users.FirstOrDefault(e => e.Id == userId).Active = false;
                context.SaveChanges();
            }
            return true;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        } //DONE

        public User GetById(int userId)
        {
            return _context.Users.Find(userId);
        }   //DONE

        public User LogIn(string emailId, string password)
        {
            return _context.Users.Where(e => e.EmailId == emailId && e.Password == password).Single() ;
        }

    }
}
