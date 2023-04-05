using SStore.Model.Data;
using SStore.Model.Data.Dtos;
using SStore.Model.Data.Entities;

namespace SStore.Services
{
    public interface IAppUserService
    {
        void InsertUser(AppUser appUser);
        void UpdateUser(AppUser appUser);
        void DeleteUser(AppUser appUser);
        List<AppUserDto> GetAppUsers();
        AppUser? FindById(int id);   


    }

    public class AppUserService : IAppUserService
    {
        private readonly StoreDbContext _db;

        public AppUserService(StoreDbContext db)
        {
            this._db = db;
        }
        public void DeleteUser(AppUser appUser)
        {

           _db.AppUsers.Remove(appUser);
            _db.SaveChanges();
        }

        public AppUser? FindById(int id)
        {
            return _db.AppUsers.Where(m => m.Id == id).Take(1).SingleOrDefault();
           
        }

        public List<AppUserDto> GetAppUsers()
        {
         return   _db.AppUsers.Select(s => new AppUserDto
            {
                Id = s.Id,
                Email = s.Email,
                FirstName = s.FirstName,
                IsActive = s.IsActive,
                LastName = s.LastName,
                PhoneNumber = s.PhoneNumber,
                UserName = s.UserName
            }).ToList();
        }

        public void InsertUser(AppUser appUser)
        {
            try
            {
                var canConnect = _db.Database.EnsureCreated();
                _db.AppUsers.Add(appUser);
               var result= _db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public void UpdateUser(AppUser appUser)
        {
            _db.AppUsers.Update(appUser);
            _db.SaveChanges();
        }
    }

}

