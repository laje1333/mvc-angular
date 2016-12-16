using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacdisDeluxeAPI.Models
{
    public class PayerEntity
    {
        [Key]
        public int Id { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public bool Trusted { get; set; }
        public string CustomerNumber { get; set; }
        public ICollection<SaleEntity> Sales { get; internal set; }
    }
}
