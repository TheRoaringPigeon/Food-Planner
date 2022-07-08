using Food_Planner.Pages;
using Food_Planner.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TinyIoC;
using Xamarin.Forms;

namespace Food_Planner.PageModels.Base
{
    public class PageModelLocator
    {
        static TinyIoCContainer _container;
        static Dictionary<Type, Type> _viewLookup;

        static PageModelLocator()
        {
            _container = new TinyIoCContainer();
            _viewLookup = new Dictionary<Type, Type>();

            // Register pages and page models
            
            Register<DashBoardPageModel, DashboardPage>();
            Register<LoginPageModel, LoginPage>();
            Register<ProfilePageModel, ProfilePage>();
            Register<RecipiesPageModel, RecipiesPage>();
            Register<SettingsPageModel, SettingsPage>();
            Register<SummaryPageModel, SummaryPage>();


            // Register services (services are registered as Singletons by default)
            _container.Register<INavigationService, NavigationService>();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        public static Page CreatePageFor(Type pageModelType)
        {
            var pageType = _viewLookup[pageModelType];
            var page = (Page)Activator.CreateInstance(pageType);
            var pageModel = _container.Resolve(pageModelType);
            page.BindingContext = pageModel;
            return page;
        }

        private static void Register<TPageModel, TPage>() where TPageModel : PageModelBase where TPage : Page
        {
            _viewLookup.Add(typeof(TPageModel), typeof(TPage));
            _container.Register<TPageModel>();
        }
    }
}
