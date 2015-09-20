using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using WeedAngel.Models.Abstract;
using WeedAngel.Models.Repo;

namespace WeedAngel
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();
      container.RegisterType<IUserRepository, UserRepository>();
      container.RegisterType<IDispensaryRepository, DispensaryRepository>();
      container.RegisterType<IDoctorRepository, DoctorRepository>();    
      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}