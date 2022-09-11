using System;
using System.Linq;
using TimeWork.Models;
using Xamarin.Forms;

namespace TimeWork.Views
{

    public partial class NotePage : ContentPage
    {
        public NotePage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            collectionView.ItemsSource = await App.NotesDb.GetNotesAsync();

        }
        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(NoteAddingPage));
        }

        private async void OnSelectionChaged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Note note = (Note)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(NoteAddingPage)}?{nameof(NoteAddingPage.ItemID)}={note.Id.ToString()}");
            }
        }
    }
}