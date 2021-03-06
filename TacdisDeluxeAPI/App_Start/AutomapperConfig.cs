﻿using AutoMapper;
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
                cfg.CreateMap<IdAndAmountEntity, IdAndAmountDto>();
                cfg.CreateMap<PartEntity, PartDto>();
                cfg.CreateMap<SaleEntity, SalesDto>();
                cfg.CreateMap<InvoiceEntity, InvoiceDto>();
                cfg.CreateMap<InvoiceRowEntity, InvoiceRowDto>();
                cfg.CreateMap<PayerEntity, PayerDto>();
                cfg.CreateMap<SalesmanEntity, SalesmanDto>();
                cfg.CreateMap<WorkOrderEntity, WorkOrderDto>();
                cfg.CreateMap<WoJobEntity, WoJobDto>();
                cfg.CreateMap<List<InvoiceEntity>, List<InvoiceDto>>();
                cfg.CreateMap<List<InvoiceRowEntity>, List<InvoiceRowDto>>();
                cfg.CreateMap<List<WorkOrderEntity>, List<WorkOrderDto>>();
                cfg.CreateMap<List<WoJobEntity>, List<WoJobDto>>();

                cfg.CreateMap<IdAndAmountDto, IdAndAmountEntity>();
                cfg.CreateMap<PartDto, PartEntity>();
                cfg.CreateMap<InvoiceDto, InvoiceEntity>();
                cfg.CreateMap<InvoiceRowDto,InvoiceRowEntity >();
                cfg.CreateMap<PayerDto, PayerEntity>();
                cfg.CreateMap<SalesmanDto, SalesmanEntity>();
                cfg.CreateMap<WorkOrderDto, WorkOrderEntity>();
                cfg.CreateMap<WoJobDto, WoJobEntity>();
                cfg.CreateMap<List<InvoiceDto>, List<InvoiceEntity>>();
                cfg.CreateMap<List<InvoiceRowDto>, List<InvoiceRowEntity>>();
                cfg.CreateMap<List<WorkOrderDto>, List<WorkOrderEntity>>();
                cfg.CreateMap<List<WoJobDto>, List<WoJobEntity>>();
            });
            //AutoMapper.Configuration
            //Mapper.CreateMap<InvoiceEntity, InvoideDto>();
        }
    }
}
