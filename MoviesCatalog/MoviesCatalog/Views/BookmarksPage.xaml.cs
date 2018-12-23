﻿using MoviesCatalog.Models;
using MoviesCatalog.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
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
        }
        public void DeleteBookmark(Object Sender, EventArgs args)
        {
            Button button = (Button)Sender;
            StackLayout listViewItem = (StackLayout)button.Parent;
            Label label = (Label)listViewItem.Children[0];
            string text = label.Text;
            DeleteId(Convert.ToInt32(text));
            OnAppearing();            
        }
    }
}