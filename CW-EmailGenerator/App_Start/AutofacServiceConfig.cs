﻿using Autofac;
using CW_EmailGenerator.Common.DIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CW_EmailGenerator.App_Start
{
    public class AutofacServiceConfig
    {
        public static void RegisterServices(ContainerBuilder builder)
        {
            // Usually you're only interested in exposing the type
            // http://stackoverflow.com/questions/15226536/register-generic-type-with-autofac
            // via its interface:
            //builder.RegisterType<AccountService>().As<IAccountService>();
            //builder.RegisterType<PersonService>().As<IPersonService>();
            //builder.RegisterType<PostService>().As<IPostService>();
            //builder.RegisterType<StoreService>().As<IStoreService>();

            //builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();

            ////builder.RegisterGeneric(typeof(BaseRepository<>)).AsSelf();
            //builder.RegisterType<PersonRepository>().As<BaseRepository<PersonDo>>();
            //builder.RegisterType<AccountRepository>().As<BaseRepository<AccountDo>>();
            //builder.RegisterType<StoreRepository>().As<BaseRepository<StoreDo>>();

            // Module Registrations for log4net and AutoMapper
            builder.RegisterModule(new LoggingModule());
            builder.RegisterModule(new AutoMapperModule());

            // Provider
            //builder.RegisterType<HttpClientProvider>().As<IHttpClientProvider>();

            //builder.RegisterType<PersonRepository>().As<IBaseRepository>();
            // However, if you want BOTH services (not as common)
            // you can say so:
            //builder.RegisterType<IAccountService>().AsSelf().As<IService>();

        }
    }
}