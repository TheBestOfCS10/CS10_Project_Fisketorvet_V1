using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS10_Project_Fisketorvet_V1.Pages.LoggedInUser
{
    public class CurrentUser
    {
        const string JsonFileName = @"Data\LoggedInUser.json";
        static int[] _user = new int[2]; //user[0] is id, user[1] is not admin/admin
        public CurrentUser()
        {
            try
            {
                _user = Helpers.JsonFileHelper<int[]>.ReadJsonSingle(JsonFileName);
            }
            catch
            {
                _user[0] = 0;
            }
        }
        public static int[] User
        {
            get { return _user; }
            set { _user = value; }
        }
        static public bool Exists
        {
            get
            {
                return User[0] != 0;
            }
        }
        static public bool HasBankAccount
        {
            get
            {
                if (Exists)
                {
                    if (User[1] == 1)
                    {
                        return Models.Admin.AdminCatalog[User[0]].Account != null;
                    }
                    else return Models.Customer.Catalog[User[0]].Account != null;
                }
                else return false;
            }
        }
        static public bool HasBasket
        {
            get
            {
                if (Exists)
                {
                    if (User[1] == 1)
                    {
                        return false;
                    }
                    else return Models.Customer.Catalog[User[0]].BasketID != 0;
                }
                else return false;
            }
        }

        static public void ChangeUser(Models.Customer user, bool remainloggedin)
        {
            bool isAdmin = false;
            foreach (Models.Customer c in Models.Customer.Catalog.Values)
            {
                if (c.Email == user.Email)
                {
                    user = c;
                    break;
                }
            }
            foreach (Models.Admin c in Models.Admin.AdminCatalog.Values)
            {
                if (c.Email == user.Email)
                {
                    user = c;
                    isAdmin = true;
                    break;
                }
            }
            if (isAdmin)
            {
                User[0] = user.ID;
                User[1] = 1;
            }
            else
            {
                User[0] = user.ID;
            }
            if (remainloggedin) Helpers.JsonFileHelper<int[]>.WriteToJsonSingle(User, JsonFileName);
        }
        static public void LogOut()
        {
            User[0] = 0;
            User[1] = 0;
            Helpers.JsonFileHelper<int[]>.WriteToJsonSingle(User, JsonFileName);
        }
    }
}
