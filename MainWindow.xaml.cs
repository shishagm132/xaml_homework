using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;
using wpf_homework;
using wpf_homework.Models;
using wpf_homework.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;
using PalletesRepository = wpf_homework.PalletesRepository;

namespace wpf_homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PalletesRepository.PalletesChanged += OnPalletesChanged;

            Closing += (_, __)
                => PalletesRepository.PalletesChanged -= OnPalletesChanged;
        }

        void OnPalletesChanged(object? sender,
                               System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        => PalletesDataGrid.ItemsSource = PalletesRepository.ObservablePalletes;

        void OnAddPalleteClick(object sender, RoutedEventArgs e)
        {
            var addPalleteWindow = new AddPalleteWindow();
            addPalleteWindow.ShowDialog();
        }

        void OnRemoveInSelectedRange(object sender, RoutedEventArgs e)
        {
            while (PalletesDataGrid.SelectedItems.Count != 0)
                PalletesRepository.RemoveAt(PalletesDataGrid.SelectedIndex);
        }

        private void OnDataGridHyperLinkClicked(object sender, RoutedEventArgs e)
        {
            var selectedPallete = ((Hyperlink) e.OriginalSource).DataContext as Pallete;

            if (selectedPallete == null) return;

            new PalleteWindow([], selectedPallete).ShowDialog();
        }
    }
}