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
using Workshop.BLL.Category.Enquiry;
using Workshop.BLL.Category.Operational;
using Workshop.BLL.Customer.Enquiry;
using Workshop.BLL.Customer.Operational;
using Workshop.BLL.Employee.Enquiry;
using Workshop.BLL.Employee.Operational;
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
            // JWT Register
            container.RegisterType<ITokenManager, TokenManager>();
            RegisterDependencies(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        private static void RegisterDependencies(UnityContainer container)
        {
            Task t1 = RegisterMapper(container);
            Task t2 = RegisterBLL(container);
            Task t3 = RegisterValidation(container);
            Task t4 = RegisterRepositories(container);

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

            });
        }

        private static async Task RegisterRepositories(UnityContainer container)
        {
            await Task.Run(() =>
            {
                container.RegisterType<IUnitOfWork, UnitOfWork>();
                container.RegisterType<ICustomerRepository, CustomerRepository>();
                container.RegisterType<ICategoryRepository, CategoryRepository>();
            });
        }

        private static async Task RegisterValidation(UnityContainer container)
        {
            await Task.Run(() =>
            {
                container.RegisterType<IModelStateValidator, ModelStateValidator>();
            });
        }
    }
}