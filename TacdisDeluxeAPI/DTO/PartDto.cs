using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TacdisDeluxeAPI.DTO
{
    public class PartDto
    {
        public PartDto()
        {
            Sales = new List<SalesDto>();
        }

        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public string ItemDesc { get; set; }
        public double VAT { get; set; }
        public bool SpecFsg { get; set; }

        [IgnoreDataMember]
        public List<SalesDto> Sales { get; set; }
    }
}
