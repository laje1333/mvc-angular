using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.DTO
{
    public class PayerDto
    {
        public int Id { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public bool Trusted { get; set; }
        public int CustomerNumber { get; set; }
        public string StreeatAddress { get; set; }
        public string ZipCity { get; set; }
        public string Country { get; set; }
    }
}