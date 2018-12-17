using MoviesCatalog.Models;
using MoviesCatalog.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesCatalog.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActorDetailPage : ContentPage
	{
         ActorDetailViewModel viewModel;
        
        public ActorDetailPage(ActorDetailViewModel viewModel)
        {
            InitializeComponent();    
            BindingContext = this.viewModel = viewModel;
        }

        public ActorDetailPage()
        {
            InitializeComponent();

            var movie = new Cast
            {
                Name = "Item 1",
            };

            viewModel = new ActorDetailViewModel(movie);
            BindingContext = viewModel;
        }
    }
}