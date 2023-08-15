using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin:IEntity
    {
        public int AdminID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool Status { get; set; }
    }
}
