using System.Collections.ObjectModel;
using System.Windows;
using wpf_homework.Models;
using Color = wpf_homework.Models.Color;

namespace wpf_homework.Windows
{
    /// <summary>
    /// Interaction logic for PalleteWindow.xaml
    /// </summary>
    public partial class PalleteWindow : Window
    {
        ObservableCollection<Color> colors;

        public PalleteWindow(Color[] colors, Pallete pallete)
        {
            InitializeComponent();
            this.colors = new ObservableCollection<Color>(colors);
            PalleteName.Content = pallete.Name;
            PalleteDescription.Text = pallete.Description;
        }
    }
}
