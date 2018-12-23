using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static MoviesCatalog.Services.WorkWithFiles;

namespace MoviesCatalog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            switch(AppSettings.Language)
            {
                case ("ru"):
                    language_picker.SelectedIndex = 0;
                    break;
                case ("en"):
                    language_picker.SelectedIndex = 1;
                    break;
                case ("fr"):
                    language_picker.SelectedIndex = 2;
                    break;
            }
            
        }
        private void language_picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppSettings.Language = language_picker.Items[language_picker.SelectedIndex];
            WriteSettings();
        }
    }
}