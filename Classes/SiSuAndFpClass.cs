using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECForGames.Classes
{
    class SiSuAndFpClass
    {
        protected static string name;

        protected static string password;

        protected static string gmail;

        ExceptionError ee = new ExceptionError();

        public SiSuAndFpClass()
        { }

        public SiSuAndFpClass(string username, string userpassword)
        {
            try
            {
                name = username;

                password = userpassword;
            }
            catch (Exception)
            {
                ee.Show();

                throw;
            }
        }

        public SiSuAndFpClass(string username, string userpassword, string usergmail)
        {
            try
            {
                name = username;

                password = userpassword;

                gmail = usergmail;
            }
            catch (Exception)
            {
                ee.Show();

                throw;
            }
        }
    }
}
