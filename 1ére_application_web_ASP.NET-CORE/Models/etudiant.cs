using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1ére_application_web_ASP.NET_CORE.Models
{
    public class etudiant
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string cin { get; set; }
        public string adress { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
