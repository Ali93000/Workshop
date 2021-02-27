using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Validation;
using Unity;
using Unity.WebApi;
using Workshop.Api.JWTImplementation;
using Workshop.Api.Mapping.AutomapperConfiguration.Implementation;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.Api.Mapping.Request;
using Workshop.Api.Mapping.Response;
using Workshop.Api.Validation.Configuration;
using Workshop.BLL.Branch.Enquiry;
using Workshop.BLL.Branch.Operational;
using Workshop.BLL.CachReceipt.Enquiry;
using Workshop.BLL.CachReceipt.Operational;
using Workshop.BLL.Category.Enquiry;
using Workshop.BLL.Category.Operational;
using Workshop.BLL.Customer.Enquiry;
using Workshop.BLL.Customer.Operational;
using Workshop.BLL.Employee.Enquiry;
using Workshop.BLL.Employee.Operational;
using Workshop.BLL.Item.Enquiry;
using Workshop.BLL.Item.Operational;
using Workshop.BLL.PaymentVoucher.Enquiry;
using Workshop.BLL.PaymentVoucher.Operational;
using Workshop.BLL.Services.Enquiry;
using Workshop.BLL.Services.Operational;
using Workshop.BLL.User.Enquiry;
using Workshop.BLL.User.Operational;
using Workshop.BLL.Vendor.Enquiry;
using Workshop.BLL.Vendor.Operational;
using Workshop.DAL.Mapping.Request;
using Workshop.DAL.Mapping.Response;
using Workshop.DAL.Repository.Implementation;
using Workshop.DAL.Repository.Intefaces;
using Workshop.DAL.Repository.UnitOfWork;

namespace Workshop.Api.IOC
{
    public static class Bootstrapper
    {
        public static void Initialize()
        {
            var container = new UnityContainer();
           
            RegisterDependencies(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        private static void RegisterDependencies(UnityContainer container)
        {
            Task t1 = RegisterMapper(container);
            Task t2 = RegisterBLL(container);
            Task t3 = RegisterValidation(container);
            Task t4 = RegisterRepositories(container);
            //Task t5 = RegisterJWT(container);

            Task.WaitAll(t1, t2, t3, t4);
        }

        
        private static async Task RegisterMapper(UnityContainer container)
        {
            await Task.Run(() =>
            {
                // Customer
                container.RegisterType<ICustomerMapperConfiguration, CustomerMapperConfiguration>();
                container.RegisterType<ICustomerReqMappingRequest, CustomerReqMappingRequest>();
                container.RegisterType<ICustomerMappingResponse, CustomerMappingResponse>();
                // Employee
                container.RegisterType<IEmployeeMapperConfiguration, EmployeeMapperConfiguration>();
                container.RegisterType<IEmployeeMappingResponse, EmployeeMappingResponse>();
                container.RegisterType<IEmployeeReqMappingRequest, EmployeeReqMappingRequest>();
                // Category
                container.RegisterType<ICategoryMapperConfiguration, CategoryMapperConfiguration>();
                container.RegisterType<ICategoryReqMappingRequest, CategoryReqMappingRequest>();
                container.RegisterType<ICategoryMappingResponse, CategoryMappingResponse>();
                // Items
                container.RegisterType<IItemMapperConfiguration, ItemMapperConfiguration>();
                container.RegisterType<IItemReqMappingRequest, ItemReqMappingRequest>();
                container.RegisterType<IItemMappingResponse, ItemMappingResponse>();
                // Items
                container.RegisterType<IUserMapperConfiguration, UserMapperConfiguration>();
                container.RegisterType<IUserReqMappingRequest, UserReqMappingRequest>();
                container.RegisterType<IUserMappingResponse, UserMappingResponse>();
                // Branch
                container.RegisterType<IBranchMapperConfiguration, BranchMapperConfiguration>();
                container.RegisterType<IBranchReqMappingRequest, BranchReqMappingRequest>();
                container.RegisterType<IBranchMappingResponse, BranchMappingResponse>();
                // Vendor
                container.RegisterType<IVendorMapperConfiguration, VendorMapperConfiguration>();
                container.RegisterType<IVendorReqMappingRequest, VendorReqMappingRequest>();
                container.RegisterType<IVendorMappingResponse, VendorMappingResponse>();
                //Services
                container.RegisterType<IServicesMapperConfiguration, ServicesMapperConfiguration>();
                container.RegisterType<IServicesrMappingResponse, ServicesMappingResponse>();
                container.RegisterType<IServicesReqMappingRequest, ServicesReqMappingRequest>();
                //ReceiptVoucher
                container.RegisterType<IReceiptVoucherMapperConfiguration, ReceiptVoucherMapperConfiguration>();
                container.RegisterType<IReceiptVoucherMappingResponse, ReceiptVoucerMappingResponse>();
                container.RegisterType<IReceiptVoucherMappingRequest, ReceiptVoucherRequest>();
                //PaymentVoucher
                container.RegisterType<IPaymentVoucherMapperConfiguration, PaymentVoucherMapperConfiguration>();
                container.RegisterType<IPaymentVoucherMappingResponse, PaymentVoucherMappingResponse>();
                container.RegisterType<IPaymentVoucherRequest, PaymentVoucherRequest>();
            });
        }

        private static async Task RegisterBLL(UnityContainer container)
        {
            await Task.Run(() =>
            {
                // Customer
                container.RegisterType<ICustomerEnquiryFunc, CustomerEnquiryFunc>();
                container.RegisterType<ICustomerOperationalFunc, CustomerOperationalFunc>();
                // Employee
                container.RegisterType<IEmployeeEnquiryFunc, EmployeeEnquiryFunc>();
                container.RegisterType<IEmployeeOperationaFunc, EmployeeOperationaFunc>();
                // Category
                container.RegisterType<ICategoryEnquiryFunc, CategoryEnquiryFunc>();
                container.RegisterType<ICategoryOperationalFunc, CategoryOperationalFunc>();
                // Items
                container.RegisterType<IItemEnquiryFunc, ItemEnquiryFunc>();
                container.RegisterType<IItemOperationalFunc, ItemOperationalFunc>();
                // User
                container.RegisterType<IUserEnquiryFunc, UserEnquiryFunc>();
                container.RegisterType<IUserOperationalFunc, UserOperationalFunc>();
                // Branch
                container.RegisterType<IBranchEnquiryFunc, BranchEnquiryFunc>();
                container.RegisterType<IBranchOperationalFunc, BranchOperationalFunc>();
                // Vendors
                container.RegisterType<IVendorEnquiryFunc, VendorEnquiryFunc>();
                container.RegisterType<IVendorOperationalFunc, VendorOperationalFunc>();
                //Services
                container.RegisterType<IServicesEnquiryFunc, ServicesEnquiryFunc>();
                container.RegisterType<IServicesOperationalFunc, ServicesOperationalFunc>();
                // Receipt Voucher
                container.RegisterType<IReceiptVoucherEnquiryFunc, ReceiptVoucherEnquiryFunc>();
                container.RegisterType<IReceiptVoucherOperationalFunc, ReceiptVoucherOperationalFunc>();
                //Paymenyt Voucher
                container.RegisterType<IPaymentVoucherEnquiryFunc, PaymentVoucherEnquiryFunc>();
                container.RegisterType<IPaymentVoucherOperationalFunc, PaymentVoucherOperationalFunc>();


            });
        }

        private static async Task RegisterRepositories(UnityContainer container)
        {
            await Task.Run(() =>
            {
                container.RegisterType<IUnitOfWork, UnitOfWork>();
                container.RegisterType<ICustomerRepository, CustomerRepository>();
                container.RegisterType<ICategoryRepository, CategoryRepository>();
                container.RegisterType<IItemRepository, ItemRepository>();
                container.RegisterType<IUserRepository, UserRepository>();
                container.RegisterType<IBranchRepository, BranchRepository>();
                container.RegisterType<IVendorRepository, VendorRepository>();
                container.RegisterType<IServicesRepository, ServicesRepository>();
                container.RegisterType<IReceiptVoucherReopsitry, ReceiptVoucherRepository>();
                container.RegisterType<IPaymentVoucherReopsitry, PaymentVoucherReopsitry>();
            });
        }

        private static async Task RegisterValidation(UnityContainer container)
        {
            await Task.Run(() =>
            {
                container.RegisterType<IModelStateValidator, ModelStateValidator>();
            });
        }

        //public static async Task RegisterJWT(UnityContainer container)
        //{
        //    await Task.Run(() => 
        //    {
        //        container.RegisterType<ITokenManager, TokenManager>();
        //    });
        //}
    }
}