namespace HelloMaui.Stores
{
    public abstract class BaseStore
    {
        public event Action CurrentItemChanged;

        protected virtual void SetCurrentItem<T>(ref T oldItem, T newItem)
        {
            if (!EqualityComparer<T>.Default.Equals(oldItem, newItem))
            {
                oldItem = newItem;
                OnCurrentItemChanged();
            }
        }

        protected virtual void OnCurrentItemChanged()
        {
            CurrentItemChanged?.Invoke();
        }
    }
}
