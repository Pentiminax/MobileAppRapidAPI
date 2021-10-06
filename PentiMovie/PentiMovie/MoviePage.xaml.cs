using PentiMovie.Models;
using PentiMovie.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PentiMovie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviePage : ContentPage
    {
        public static async Task<MoviePage> Create(string imdbID)
        {
            var page = new MoviePage();

            Movie movie = await GetMovieAsync(imdbID);

            page.BindingContext = movie;

            return page;
        }

        public MoviePage()
        {
            InitializeComponent();
        }

        private static async Task<Movie> GetMovieAsync(string imdbID)
        {
            Movie movie = await MovieApi.SearchByIdAsync(imdbID);

            return movie;
        }
    }
}