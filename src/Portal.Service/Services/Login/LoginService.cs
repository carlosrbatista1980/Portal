using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Portal.Core.Enums;
using Portal.Core.Helpers;
using Portal.Data;
using Portal.Data.Data;
using Portal.Service.Base;

namespace Portal.Service.Services.Login
{
    public class LoginService : ServiceBase
    {
        public PortalDbContext _context;
        public IConfiguration _configuration;

        public LoginService(PortalDbContext context) : base(context)
        {
            _context = context;
        }

        public LoginService() : this(new PortalDbContext(new DbContextOptions<PortalDbContext>()))
        {
        }

        /*
        public bool IsUserAlreadyRegistered(LoginViewModel obj)
        {
            //SecretMD5Key must be "b49d6c03fe471ee720b5a4d56c5a9bf2" for secretKey below
            //SecretKey = 2011 and password = 123

            var passwordMd5 = GetPasswordMD5Hash(obj.password);
            var accountExist = _context.Account.Select(account => new { account.account, account.password }).FirstOrDefault(account => account.account == obj.account && account.password == passwordMd5);

            if (accountExist != null)
            {
                return true;
            }

            return false;
        }

        public ServiceEnums.SignUpState TryCreateAccount(LoginViewModel obj)
        {
            var ac = new Account();

            MapHelper.MapFrom(obj, ac);
            ac.IP_user = "127.0.0.1";
            ac.block = 0;
            ac.password2 = !string.IsNullOrEmpty(obj.password) ? obj.password : "0";
            ac.phone = DateTime.Now.TimeOfDay.ToString();
            ac.last_login_server_idx = 1;
            ac.point = 1;
            ac.datePassword = DateTime.Now;

            var accountExist = _context.Account.Select(account => new { account.account, account.email }).FirstOrDefault(account => account.account == obj.account || account.email == obj.email);
            //var emailExist = _context.Account.Select(account => new { account.email }).FirstOrDefault(account => account.email == obj.email);

            if (string.IsNullOrEmpty(accountExist?.account) && string.IsNullOrEmpty(accountExist?.email))
            {
                var newRecord = new Account();
                MapHelper.MapFrom(obj, newRecord);

                //This fields cannot be null in database and must be filled.
                newRecord.IP_user = "127.0.0.1";
                newRecord.block = 0;
                newRecord.password2 = !string.IsNullOrEmpty(obj.password) ? obj.password : "0";
                newRecord.phone = DateTime.Now.TimeOfDay.ToString();
                newRecord.last_login_server_idx = 1;
                newRecord.point = 1;
                newRecord.datePassword = DateTime.Now;

                try
                {
                    _context.Account.Add(newRecord);
                    _context.SaveChanges();
                    obj.dateRegisterCreated = DateTime.Now;
                    return ServiceEnums.SignUpState.Success;
                }
                catch (DbUpdateException ex)
                {
                    return ServiceEnums.SignUpState.InternalError;
                }
            }

            return ServiceEnums.SignUpState.Exists;
        }


        //todo: Compare password hash
        public string GetPasswordMD5Hash(string password)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var secretKey = configuration["SecretMD5Key:SecretKey"];

            var bytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(secretKey + password));
            StringBuilder builder = new StringBuilder();

            foreach (var item in bytes)
            {
                builder.Append(item.ToString("x2"));
            }

            return builder.ToString();
        }

    */
    }
}
