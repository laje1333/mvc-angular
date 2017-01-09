using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacdisDeluxeAPI.Models
{
    [Table("Salesman")]
    public class SalesmanEntity
    {
        public SalesmanEntity()
        {
            Sales = new List<SaleEntity>();
        }

        [Key]
        public int Id { get; set; }

        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string StreeatAddress { get; set; }
        public string ZipCity { get; set; }
        public string Country { get; set; }
        public ICollection<SaleEntity> Sales { get; set; }
    }
}
