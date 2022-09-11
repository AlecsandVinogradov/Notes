using System;
using TimeWork.Models;
using Xamarin.Forms;

namespace TimeWork.Views
{
    [QueryProperty(nameof(ItemID), nameof(ItemID))]
    public partial class NoteAddingPage : ContentPage
    {
        public string ItemID
        {
            set
            {
                LoadNote(value);
            }
        }
        public NoteAddingPage()
        {
            InitializeComponent();
            BindingContext = new Note();
        }
        private async void LoadNote(string value)
        {
            try
            {
                int id = Convert.ToInt32(value);
                Note note = await App.NotesDb.GetNotesAsync(id);
                BindingContext = note;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void OnSaveButton_Clicked(object sendler, EventArgs e)
        {
            Note note = (Note)BindingContext;
            note.DateTime = DateTime.UtcNow;
            if (!string.IsNullOrWhiteSpace(note.Text))
            {
                await App.NotesDb.SaveNoteAsync(note);
            }
            await Shell.Current.GoToAsync("..");
        }
        private async void OnDeleteButton_Clicked(object sendler, EventArgs e)
        {
            Note note = (Note)BindingContext;
            await App.NotesDb.DeleteNote(note);
            await Shell.Current.GoToAsync("..");
        }

    }
}