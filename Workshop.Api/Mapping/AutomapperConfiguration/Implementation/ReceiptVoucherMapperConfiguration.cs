using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.CashReceipt.Request;
using Workshop.Entities.ApiModels.CashReceipt.Response;
using Workshop.Entities.DTO.CachReceipt;

namespace Workshop.Api.Mapping.AutomapperConfiguration.Implementation
{
    public class ReceiptVoucherMapperConfiguration : IReceiptVoucherMapperConfiguration
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<W_T_ReceiptVoucher, ReceiptVoucherDTO>();

               //map Req to Db//
               cfg.CreateMap<ReceiptVoucherReq, W_T_ReceiptVoucher>();

               cfg.CreateMap<IEnumerable<W_T_ReceiptVoucher>, ReceiptVoucherResponse>()
                .ForMember(des => des.cachReceiptList, map => map.MapFrom(ser => ser));

               cfg.CreateMap<ReceiptVoucherDTO, ReceiptVoucherResponse>()
               .ForMember(des => des.cachReceiptList, map => map.MapFrom(ser => ser));

               //Map Id
               cfg.CreateMap<W_T_ReceiptVoucher, ReceiptVoucherIDResponse>()
              .ForMember(des => des.CachReceiptID, map => map.MapFrom(ser => ser));

               cfg.CreateMap<ReceiptVoucherDTO, ReceiptVoucherIDResponse>()
               .ForMember(des => des.CachReceiptID, map => map.MapFrom(ser => ser));

           });

            return config.CreateMapper();

        }
    }
}