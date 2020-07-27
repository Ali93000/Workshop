﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Validation;
using Unity;
using Unity.WebApi;
using Workshop.Api.Mapping.AutomapperConfiguration.Implementation;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.Api.Validation.Configuration;
using Workshop.BLL.Customer.Enquiry;
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

            Task.WaitAll(t1, t2, t3, t4);
        }

        

        private static async Task RegisterMapper(UnityContainer container)
        {
            await Task.Run(() =>
            {
                container.RegisterType<ICustomerMapperConfiguration, CustomerMapperConfiguration>();
            });
        }

        private static async Task RegisterBLL(UnityContainer container)
        {
            await Task.Run(() =>
            {
                container.RegisterType<ICustomerEnquiryFunc, CustomerEnquiryFunc>();
            });
        }

        private static async Task RegisterRepositories(UnityContainer container)
        {
            await Task.Run(() =>
            {
                container.RegisterType<IUnitOfWork, UnitOfWork>();
                container.RegisterType<ICustomerRepository, ICustomerRepository>();
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