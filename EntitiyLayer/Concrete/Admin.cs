using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public String UserName { get; set; }
        public String Passaword { get; set; }
        public String Name { get; set; }
        public String ShortDescription { get; set; }
        public String ImageURL { get; set; }
        public String Role { get; set; }
    }
}
