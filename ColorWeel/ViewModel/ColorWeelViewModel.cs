using System.Collections.ObjectModel;
using System.Windows.Media;
using ColorWeel.View;
using GalaSoft.MvvmLight;

namespace ColorWeel.ViewModel
{
    public class ColorWeelViewModel : ViewModelBase
    {
        private ObservableCollection<PieShape> _items;
        public ObservableCollection<PieShape> Items
        {
            get => _items;
            set => Set(nameof(Items), ref _items, value);

        }

        private int _numberOfColors;
        public int NumberOfColors
        {
            get => _numberOfColors;
            set
            {
                if (value <= 0 || value >= 500) return;
                Set(nameof(NumberOfColors), ref _numberOfColors, value);
                Update();
            }
        }

        public ColorWeelViewModel()
        {
            NumberOfColors = 12;
        }

        public void Update()
        {
            Items = new ObservableCollection<PieShape>();

            double p = 360.0 / (double)_numberOfColors;

            for (int i = _numberOfColors; i > 0; i--)
            {
                var color = ColorConverter.HsvToRgb(i * p, 1.0, 1.0);
                var pie = new PieShape() { Fill = new SolidColorBrush(color) };
                Items.Add(pie);
            }
        }
    }
}
