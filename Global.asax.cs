using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using AutoMapper;
using The2r.Models;
using The2r.Dtos;
using The2r.App_Start;

namespace The2r
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Activity, ActivityDto>();
                cfg.CreateMap<ActivityDto, Activity>();
                cfg.CreateMap<ActivityType, ActivityTypeDto>();
                cfg.CreateMap<ActivityTypeDto, ActivityType>();
                cfg.CreateMap<ActivityType, SubscriptionDto>();
                cfg.CreateMap<ApplicationUser, ApplicationUserDto>();
                cfg.CreateMap<ApplicationUserDto, ApplicationUser>();
                cfg.CreateMap<EnrollmentDto, Enrollment>();
                cfg.CreateMap<Enrollment, EnrollmentDto>();
                cfg.AddProfile<MappingProfile>();
            });

            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
