using BandApp.Models;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace BandApp.Utils
{
    public sealed class BandDataManager
    {
        private static readonly BandDataManager _instance = new BandDataManager();
        public static BandDataManager Instance
        {
            get { return _instance; }
        }

        private readonly ObservableCollection<BandMember> _members = new ObservableCollection<BandMember>();
        private readonly List<IObserver> _observers = new List<IObserver>();

        private BandDataManager() { }

        public ObservableCollection<BandMember> Members
        {
            get { return _members; }
        }

        public void AddMember(BandMember member)
        {
            member.Id = _members.Count + 1;
            _members.Add(member);
            NotifyObservers(); 
        }

        public void RemoveMember(BandMember member)
        {
            _members.Remove(member);
            NotifyObservers(); 
        }

        public void ClearMembers()
        {
            _members.Clear();
            NotifyObservers(); 
        }

        
        public void RegisterObserver(IObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void UnregisterObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_members);
            }
        }
    }
}
