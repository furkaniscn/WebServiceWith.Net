using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using test.Controllers;
using test.Entity;
using System.Data.Entity;
using System.Web.Services.Protocols;

namespace test
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WebService : System.Web.Services.WebService
    {
        public List<Result> Results = new List<Result>();
        private readonly dbContext db = new dbContext();


        [WebMethod]
        public List<Result> UserAdd(string authorizedUser, string authorizedPassword, List<NewUser> itemUsers)
        {
            List<Result> Results = new List<Result>();
            try
            {
                if (authorizedUser != "furkan" || authorizedPassword != "furkan123")
                {
                    Result unauthorizedResult = new Result
                    {
                        Success = false,
                        Message = "Yetkisiz erişim!"
                    };
                    Results.Add(unauthorizedResult);
                    return Results;
                }

                foreach (NewUser item in itemUsers)
                {
                    if (item.UserName == "" || item.Password == "")
                    {
                        Result set_data = new Result
                        {
                            Success = false,
                            Message = "Yeni Kullanıcı Adı veya Yeni Parola Boş Geçilemez..!"
                        };
                        Results.Add(set_data);
                        return Results;
                    }

                    Users setdata = new Users
                    {
                        UserName = item.UserName,
                        Password = item.Password
                    };
                    db.Users.Add(setdata);
                    db.SaveChanges();

                    Result succesResult = new Result
                    {
                        Success = true,
                        Message = "Sen Bu işi Biliyon Oğlum..!"
                    };
                    Results.Add(succesResult);
                }
                return Results;
            }
            catch (Exception ex)
            {
                var set_data = new Result
                {
                    Success = false,
                    Message = ex.Message
                };
                Results.Add(set_data);
                return Results;
            }
        }


        [WebMethod]
        public List<Result> UserDelete(string authorizedUser, string authorizedPassword, int userIdToDelete)
        {
            try
            {
                if (authorizedUser != "furkan" || authorizedPassword != "furkan123")
                {
                    Result unauthorizedResult = new Result
                    {
                        Success = false,
                        Message = "Yetkisiz erişim!"
                    };
                    Results.Add(unauthorizedResult);
                    return Results;
                }

                Users user = db.Users.FirstOrDefault(x => x.id == userIdToDelete);

                if (user == null)
                {
                    Result setResult = new Result
                    {
                        Success = false,
                        Message = "Silinecek kullanıcı bulunamadı."
                    };
                    Results.Add(setResult);
                    return Results;
                }

                db.Users.Remove(user);
                db.SaveChanges();

                Result successResult = new Result
                {
                    Success = true,
                    Message = "Kullanıcı başarıyla silindi."
                };
                Results.Add(successResult);

                return Results;
            }
            catch (Exception ex)
            {
                Result errorResult = new Result
                {
                    Success = false,
                    Message = ex.Message
                };
                Results.Add(errorResult);
                return Results;
            }
        }


        [WebMethod]
        public List<Users> GetUsers()
        {
            try
            {
                List<Users> users = db.Users.ToList();
                return users;
            }
            catch (Exception ex)
            {
                Result errorResult = new Result
                {
                    Success = false,
                    Message = "Kullanıcıları getirirken bir hata oluştu: " + ex.Message
                };
                Results.Add(errorResult);

                return new List<Users>();
            }
        }

        [WebMethod]
        public List<Result> UpdateUser(string authorizedUser, string authorizedPassword, int userIdToUpdate, string newUserName, string newPassword)
        {
            try
            {
                if (authorizedUser != "furkan" || authorizedPassword != "furkan123")
                {
                    Result unauthorizedResult = new Result
                    {
                        Success = false,
                        Message = "Yetkisiz erişim!"
                    };
                    Results.Add(unauthorizedResult);
                    return Results;
                }

                if (string.IsNullOrEmpty(newUserName) || string.IsNullOrEmpty(newPassword))
                {
                    Result setResult = new Result
                    {
                        Success = false,
                        Message = "Yeni kullanıcı bilgileri boş geçilemez."
                    };
                    Results.Add(setResult);
                    return Results;
                }

                Users user = db.Users.FirstOrDefault(x => x.id == userIdToUpdate);

                if (user == null)
                {
                    Result setResult = new Result
                    {
                        Success = false,
                        Message = "Güncellenecek kullanıcı bulunamadı."
                    };
                    Results.Add(setResult);
                    return Results;
                }

                user.UserName = newUserName;
                user.Password = newPassword;
                db.SaveChanges();

                Result successResult = new Result
                {
                    Success = true,
                    Message = "Kullanıcı başarıyla güncellendi."
                };
                Results.Add(successResult);

                return Results;
            }
            catch (Exception ex)
            {
                Result errorResult = new Result
                {
                    Success = false,
                    Message = ex.Message
                };
                Results.Add(errorResult);
                return Results;
            }
        }

    }
}
