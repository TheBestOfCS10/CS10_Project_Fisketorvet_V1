using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS10_Project_Fisketorvet_V1.Pages.Shared
{
    //used to store info about the user that is logged in
    public class CurrentUser : Models.Customer
    {
        const string JsonFileName = @"C:\Users\Radu\Source\Repos\TheBestOfCS10\CS10_Project_Fisketorvet_V1\Data\LoggedInUser.json";
        static Models.Customer _user = Helpers.JsonFileReaderSingle<Models.Customer>.ReadJson(JsonFileName);
        public static Models.Customer User
        {
            get { return _user; }
            set { _user = value; }
        }
        //string[] validate = new string[2];
        //public string[] Validate
        //{
        //    get { validate[0]= Email;
        //        validate[1]= Password;
        //        return validate; }
        //}
        static public bool Exists
        {
            get {
                return User.Email != null;
            }
        }
        static public void ChangeUser(Models.Customer user, bool remainloggedin)
        {
            foreach(Models.Customer c in Models.Customer.Catalog.Values)
            {
                if (c.Email == user.Email) user = c;
            }
            User = user;
            if(remainloggedin) Helpers.JsonFileWritterSingle<Models.Customer>.WriteToJson(User, JsonFileName);
        }
    }
}
