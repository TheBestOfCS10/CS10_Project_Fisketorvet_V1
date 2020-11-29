using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS10_Project_Fisketorvet_V1.Pages.Shared
{
    public class CurrentUser
    {
        const string JsonFileName = @"Data\LoggedInUser.json";
        static int _user;
        public CurrentUser()
        {
            try
            {
                _user = Helpers.JsonFileHelper<int>.ReadJsonSingle(JsonFileName);
            }
            catch
            {
                _user = 0;
            }
        }
        public static int User
        {
            get { return _user; }
            set { _user = value; }
        }
        static public bool Exists
        {
            get
            {
                return User != 0;
            }
        }
        static public void ChangeUser(Models.Customer user, bool remainloggedin)
        {
            foreach (Models.Customer c in Models.Customer.Catalog.Values)
            {
                if (c.Email == user.Email) user = c;
            }
            User = user.ID;
            if (remainloggedin) Helpers.JsonFileHelper<int>.WriteToJsonSingle(User, JsonFileName);
        }
        static public void LogOut()
        {
            User = 0;
            Helpers.JsonFileHelper<int>.WriteToJsonSingle(User, JsonFileName);
        }
    }
}
