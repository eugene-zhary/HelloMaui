using HelloMaui.Models;

namespace HelloMaui.Stores
{
    public class NoteStore : BaseStore
    {
        private NoteModel _currentNote = new();
        public NoteModel CurrentNote
        {
            get => _currentNote;
            set => SetCurrentItem(ref _currentNote, value);
        }
    }
}
