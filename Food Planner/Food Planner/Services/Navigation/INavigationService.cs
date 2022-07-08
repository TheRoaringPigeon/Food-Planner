using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Food_Planner.Services.Navigation
{
    public interface INavigationService
    {
        /// <summary>
        /// Navigation method to push onto the Navigation Stack
        /// </summary>
        /// <typeparam name="TPageModelBase"></typeparam>
        /// <param name="navigationData"></param>
        /// <param name="setRoot"></param>
        /// <returns></returns>
        Task NavigateToAsync<TPageModelBase>(object navigationData = null, bool setRoot = false);

        /// <summary>
        /// Navigation method to pop current page off of the Naviagation Stack
        /// </summary>
        /// <returns></returns>
        Task GoBackAsync();
    }
}
