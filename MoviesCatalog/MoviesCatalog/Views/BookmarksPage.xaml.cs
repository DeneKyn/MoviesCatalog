using MoviesCatalog.ViewModels;
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
    public partial class BookmarksPage : ContentPage
    {
        BookmarksViewModel viewModel;

        public BookmarksPage(BookmarksViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

       public void DelereAll()
        {
            FileClear();
        }
    }
}