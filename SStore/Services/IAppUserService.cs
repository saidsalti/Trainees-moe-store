using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using SStore.Model.Data;
using SStore.Model.Data.Dtos;
using SStore.Model.Data.Entities;
using SStore.Model.Data.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SStore.Services
{
    public interface IAppUserService
    {
        int InsertUser(AppUser appUser);
        void UpdateUser(AppUser appUser);
        void DeleteUser(AppUser appUser);
        List<AppUserDto> GetAppUsers();
        AppUser? FindById(int id);
        bool IsReadyUserNameAdded(string userName);
        public bool IsReadyEmailAdded(string email);
        (GlobalDataModel? globalData, string? error) Login(string email, string password);

    }

    public class AppUserService : IAppUserService
    {
        private readonly StoreDbContext _db;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public AppUserService(StoreDbContext db,IHttpContextAccessor contextAccessor,IConfiguration configuration)
        {
            this._db = db;
            this._contextAccessor = contextAccessor;
            this._configuration = configuration;
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
                LastName = s.LastName,
                PhoneNumber = s.PhoneNumber,
              
            }).ToList();
        }
        public bool IsReadyUserNameAdded(string userName)
        {
            return _db.AppUsers.Any(m=>m.UserName == userName.Trim().ToLower());
        }
        public bool IsReadyEmailAdded(string email)
        {
            return _db.AppUsers.Any(m => m.Email == email.Trim().ToLower());
        }
        public int InsertUser(AppUser appUser)
        {
           
                var canConnect = _db.Database.EnsureCreated();
                _db.AppUsers.Add(appUser);
               var result= _db.SaveChanges();
            return result;
            
        }

        public void UpdateUser(AppUser appUser)
        {
            _db.AppUsers.Update(appUser);
            _db.SaveChanges();
        }


        public (GlobalDataModel?globalData,string? error )Login(string email,string password)
        {
            var errorMessage = "عذرا خطأ باسم المستخدم أو كلمة المرور";
            var user = _db.AppUsers.Where(m=>m.Email!.Trim().ToLower()== email.Trim().ToLower()).FirstOrDefault();
            if (user == null)
                return (null,errorMessage);
            if(user.Password!=password)
                return (null,errorMessage);
            var globalData = new GlobalDataModel
            {
                Email = user.Email,
                UserId = user.Id,
                Name = user.FirstName + " " + user.LastName,
            };
            return (globalData!, null);

        }

        private async Task ffff(string email, string password)
        {
            var authResult = Login(email, password);
            if(!string.IsNullOrEmpty(authResult.error))
            {
                throw new Exception(authResult.error);
            }
            if ( authResult.globalData!=null)
            {
                // Create claims
                var claims = new List<Claim>
             {
            new Claim(ClaimTypes.Name, authResult!.globalData!.UserId!.ToString()!)
        };
                var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

                // Create token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JwtSecret")!);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claimsIdentity,
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                // Save JWT in a cookie
                _contextAccessor.HttpContext!.Response.Cookies.Append("jwt", tokenString, new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(1),
                    SameSite = SameSiteMode.Strict
                });
                // Set authentication cookie
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };
                await _contextAccessor.HttpContext!.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);


                // Redirect to home page with token
               // NavigationManager.NavigateTo($"/?token={tokenString}");
            }
            else
            {
                // Show error message
                throw new Exception("خطأ يرجى المحاولة لاحقا");
            }
        }
    }
    

}

