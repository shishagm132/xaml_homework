using System.Collections.ObjectModel;
using System.Collections.Specialized;
using wpf_homework.Models;

namespace wpf_homework
{
    internal class PalletesRepository
    {
        private static ObservableCollection<Pallete> palletesObservable = new ObservableCollection<Pallete>();

        public static ReadOnlyObservableCollection<Pallete> ObservablePalletes
        {
            get => new ReadOnlyObservableCollection<Pallete>(palletesObservable);
        }

        static PalletesRepository()
        {
            // implement loading from DB
        }

        public static void RemoveAt(int index) // implement remove from DB
            => palletesObservable.RemoveAt(index);

        public static void Add(Pallete pallete) // implement add to db
            => palletesObservable.Add(pallete);

        public static event NotifyCollectionChangedEventHandler? PalletesChanged
        {
            add => palletesObservable.CollectionChanged += value;
            remove => palletesObservable.CollectionChanged -= value;
        }
    }
}
