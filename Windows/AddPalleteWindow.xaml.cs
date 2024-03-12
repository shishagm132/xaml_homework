using System.Windows;
using System.Windows.Controls;
using wpf_homework.Models;

namespace wpf_homework.Windows
{
    /// <summary>
    /// Interaction logic for AddPalleteWindow.xaml
    /// </summary>
    public partial class AddPalleteWindow : Window
    {
        Pallete pallete = new (0, "", "");

        public AddPalleteWindow()
        {
            DataContext = pallete;
            InitializeComponent();
        }

        private void OnSavePalleteClick(object sender, RoutedEventArgs e)
        {
            string[]? errors = ValidatePallete();

            if (errors != null)
            {
                MessageBox.Show(string.Join("\n", errors), "Ошибка создания");
                return;
            }

            PalletesRepository.Add(pallete);
            Close();
        }

        private string[]? ValidatePallete()
        {
            // description or name is empty, name is exist at the same time
            string[] errors = new string[3];

            if (pallete.Name == "")
                errors[0] = "Имя палитры - обязательное поле.";

            if (PalletesRepository.ObservablePalletes.Any(element => element.Name == pallete.Name))
                errors[1] = "Такое имя палитры уже существует.";

            if (pallete.Description.Length < 10)
                errors[2] = "Длина описания не может быть меньше 10 символов.";            

            return errors.All(string.IsNullOrEmpty) ? null : errors;
        }
    }
}