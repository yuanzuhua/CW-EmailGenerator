﻿using Autofac;
using AutoMapper;
using EmailGenerator.DataAccess.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CW_EmailGenerator.Common.DIModules
{
    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //register all profile classes in the calling assembly
            builder.RegisterAssemblyTypes(typeof(AutoMapperModule).Assembly).As<Profile>();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                // Load in all our AutoMapper profiles that have been registered
                foreach (var profile in context.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
                cfg.AddProfile(typeof(AutoMapperProfile));
            }))
            .AsSelf()
            .SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                    .As<IMapper>()
                    .InstancePerLifetimeScope();
        }
    }
}