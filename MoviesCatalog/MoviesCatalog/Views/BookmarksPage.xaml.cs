using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoviesCatalog.Models;
using MoviesCatalog.ViewModels;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using static MoviesCatalog.Services.WorkWithFiles;
using System.Collections.ObjectModel;
using Lottie.Forms;

namespace MoviesCatalog.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookmarksPage : ContentPage
    {
        BookmarksViewModel viewModel;
        public ObservableCollection<Movie> movies = new ObservableCollection<Movie>();
        public BookmarksPage(BookmarksViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

       public void DelereAll()
        {
            FileClear();
            viewModel = new BookmarksViewModel();
            BindingContext = viewModel;
        }
        
        protected override void OnAppearing()
        {
            viewModel = new BookmarksViewModel();
            base.OnAppearing();            
            BindingContext  = viewModel;
            ToolDelete.Text = Resource.RemoveAll;
            //Title = Resource.Bookmarks;

        }
        public void DeleteBookmark(Object Sender, EventArgs args)
        {
            Image button = (Image)Sender;
            StackLayout listViewItem = (StackLayout)button.Parent;
            Label label = (Label)listViewItem.Children[0];
            string text = label.Text;
            DeleteId(Convert.ToInt32(text));
            OnAppearing();            
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var movie = args.SelectedItem as Movie;
            if (movie == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(movie)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }
    }
}