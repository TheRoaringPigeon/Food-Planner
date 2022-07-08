using Food_Planner.PageModels;
using Food_Planner.PageModels.Base;
using Food_Planner.Services.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Food_Planner
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        Task InitNavigation()
        {
            var navService = PageModelLocator.Resolve<INavigationService>();
            return navService.NavigateToAsync<LoginPageModel>();
        }
        protected override async void OnStart()
        {
            await InitNavigation();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
