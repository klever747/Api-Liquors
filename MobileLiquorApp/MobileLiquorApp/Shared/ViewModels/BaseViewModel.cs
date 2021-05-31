using Application.MobileApp.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Prism.Mvvm;
using Prism.Navigation;
using System.Threading.Tasks;

namespace MobileLiquorApp.Shared.ViewModels
{
    public abstract class BaseViewModel : BindableBase
    {
        #region Properties

        public INavigationService _navigationService;

        public IUnitOfWork _unitOfWork;

        #endregion Properties

        #region Constructors

        public BaseViewModel()
        {
            _unitOfWork = Startup.ServiceProvider.GetService<IUnitOfWork>();
        }

        public BaseViewModel(INavigationService navigationService)
        {
            _unitOfWork = Startup.ServiceProvider.GetService<IUnitOfWork>();

            _navigationService = navigationService;
        }

        #endregion Constructors

        #region Methods

        public async Task ShowErrorAlert(string message) => await App.Current.MainPage.DisplayAlert("Error", message, "OK");

        #endregion Methods
    }
}
