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
                cfg.CreateMap<List<InvoiceEntity>,List<InvoiceDto>>();
                cfg.CreateMap<List<InvoiceRowEntity>, List<InvoiceRowDto>>();
                cfg.CreateMap<InvoiceRowEntity, InvoiceRowDto>();
                cfg.CreateMap<PayerEntity, PayerDto>();
                cfg.CreateMap<SalesmanEntity, SalesmanDto>();

                cfg.CreateMap<InvoiceDto, InvoiceEntity>();
                cfg.CreateMap<List<InvoiceDto>,List<InvoiceEntity>>();
                cfg.CreateMap<List<InvoiceRowDto>, List<InvoiceRowEntity>>();
                cfg.CreateMap<InvoiceRowDto,InvoiceRowEntity >();
                cfg.CreateMap<PayerDto, PayerEntity>();
                cfg.CreateMap<SalesmanDto, SalesmanEntity>();
            });
            //AutoMapper.Configuration
            //Mapper.CreateMap<InvoiceEntity, InvoideDto>();
        }
    }
}
