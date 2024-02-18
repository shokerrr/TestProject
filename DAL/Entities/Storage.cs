using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Storage
    {
        [Key]
        public int Id { get; set; }
        public int Code { get; set; }
        public string Value { get; set; } = "";
    }
}
