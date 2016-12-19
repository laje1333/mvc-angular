using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacdisDeluxeAPI.DTO;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI
{
    public static class AutomapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<SaleEntity, SalesDto>();
                cfg.CreateMap<InvoiceEntity, InvoiceDto>();
            });
            //AutoMapper.Configuration
            //Mapper.CreateMap<InvoiceEntity, InvoideDto>();
        }
    }
}
