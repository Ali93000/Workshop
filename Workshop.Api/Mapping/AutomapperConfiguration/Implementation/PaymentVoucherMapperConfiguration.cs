using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.PaymentVoucher.Request;
using Workshop.Entities.ApiModels.PaymentVoucher.Response;
using Workshop.Entities.DTO.PaymentVoucher;

namespace Workshop.Api.Mapping.AutomapperConfiguration.Implementation
{
    public class PaymentVoucherMapperConfiguration : IPaymentVoucherMapperConfiguration
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<W_T_PaymentVoucher, PaymentVoucherDTO>();

                cfg.CreateMap<IEnumerable<W_T_PaymentVoucher>, PaymentVoucherResponse>()
                .ForMember(des => des.PaymentVoucherList, map => map.MapFrom(src => src));

                cfg.CreateMap<PaymentVoucherDTO, PaymentVoucherResponse>()
                .ForMember(des => des.PaymentVoucherList, map => map.MapFrom(src => src));

                ///ID////
                cfg.CreateMap<W_T_PaymentVoucher, PaymentVoucherIDResponse>()
                .ForMember(dec => dec.PaymentVoucherID, map => map.MapFrom(src => src));

                cfg.CreateMap<PaymentVoucherDTO, PaymentVoucherIDResponse>()
                .ForMember(dec => dec.PaymentVoucherID, map => map.MapFrom(src => src));
                ///////////////// map req to db///////////
                cfg.CreateMap<PaymentVoucherReq, W_T_PaymentVoucher>();

            });

            return config.CreateMapper();
        }
    }
}
