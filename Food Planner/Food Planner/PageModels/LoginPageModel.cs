using Food_Planner.PageModels.Base;
using Food_Planner.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Food_Planner.PageModels
{
    public class LoginPageModel : PageModelBase
    {
        private ICommand _signInCommand;
        private INavigationService _navigationService;

        public ICommand SignInCommand
        {
            get => _signInCommand;
            set => SetProperty(ref _signInCommand, value);
        }

        public LoginPageModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SignInCommand = new Command(OnSignInAction);
        }

        private void OnSignInAction(object obj)
        {
            _navigationService.NavigateToAsync<DashBoardPageModel>();
        }
    }
}
