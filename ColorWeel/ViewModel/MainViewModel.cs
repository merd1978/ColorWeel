using GalaSoft.MvvmLight;

namespace ColorWeel.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ColorWeelViewModel ColorWeelViewModel { get; }

        public MainViewModel()
        {
            ColorWeelViewModel = new ColorWeelViewModel();
        }
    }
}
