using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Chat_2Ball.Methods
{
    public class Users
    {
        [WebMethod]
        public static void AddUsers(string connectionId, string name)
        {
            try
            {
                using (var db = new Context.ContextDB())
                {
                    var user = db.Users.FirstOrDefault(u => u.Name == name);                                            //Поиск существующего пользователя по Базе Данных
                    if (null == user)                                                                                   //Если такового не существует
                    {
                        db.Users.Add(new Models.Users { ConnectionId = connectionId, Name = name });                    //Добавляем пользователя в БД
                        db.SaveChanges();                                                                               //Сохраняем изменения в БД
                    }
                }
            }
            catch { }

        }


    }
}