using Microsoft.Maui.Controls;
using NathanApp.Views;

namespace NathanApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            MovieCollection movieCollection = new();

            Movies moviesPage = new(movieCollection);
            AddMovie addMoviePage = new(movieCollection);
            ModifyMovie modifyMovieContent = new(movieCollection);

            MovieContent.ContentTemplate = new DataTemplate(() => moviesPage);
            AddMovieContent.ContentTemplate = new DataTemplate(() => addMoviePage);
            ModifyMovieContent.ContentTemplate = new DataTemplate(() => modifyMovieContent);
        }
    }   
}
