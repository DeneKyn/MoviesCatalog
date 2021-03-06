﻿using MoviesCatalog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesCatalog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritePage : ContentPage
    {
        BookmarksViewModel viewModel;

        public FavoritePage(BookmarksViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }


    }
}