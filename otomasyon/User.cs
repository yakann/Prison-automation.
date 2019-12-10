using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otomasyon
{
    public class User
    {
        int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        string _name;

        public string kullaniciadim
        {
            get { return _name; }
            set { _name = value; }
        }
        string _password;

        public string sifrem
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
