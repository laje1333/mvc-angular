using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TacdisDeluxeAPI.Controllers;
using TacdisDeluxeAPI.DTO;
using TacdisDeluxeAPI.Mockdata.InvoiceData;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.Tests.Controllers
{
    [TestClass]
    class InvoiceControllerTests
    {
        [TestMethod]
        public void PostInvoice_Mapping()
        {
            InvoiceController controller = new InvoiceController();
            var response = controller.CreatInvoice(new InvoiceDto());
            Assert.IsNotNull(response);

        }
    }
}
