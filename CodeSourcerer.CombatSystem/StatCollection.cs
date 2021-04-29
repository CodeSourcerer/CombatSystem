using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CodeSourcerer.CombatSystem
{
    public class StatCollection : IEnumerable<CharacterStat>, IList<CharacterStat>
    {
        public delegate void StatCollectionChanged(object sender, StatCollectionChangedEventArgs e);

        public event StatCollectionChanged OnStatCollectionChanged;

        private List<CharacterStat> _stats = new List<CharacterStat>();

        public CharacterStat this[int index] { get => _stats[index]; set => _stats[index] = value; }

        public int Count => _stats.Count;

        public bool IsReadOnly => false;

        public StatCollection()
        {

        }

        public void Add(CharacterStat item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            _stats.Add(item);

            OnStatCollectionChanged?.Invoke(this, new StatCollectionChangedEventArgs(item));
        }

        public void AddRange(IEnumerable<CharacterStat> stats)
        {
            if (stats == null) throw new ArgumentNullException(nameof(stats));

            foreach (var stat in stats)
                Add(stat);
        }

        public void Clear()
        {
            var stats = (from s in _stats
                         select s).ToList();
            _stats.Clear();

            stats.ForEach(stat => OnStatCollectionChanged?.Invoke(this, new StatCollectionChangedEventArgs(stat)));
        }

        public bool Contains(CharacterStat item) => _stats.Contains(item);

        public void CopyTo(CharacterStat[] array, int arrayIndex) => _stats.CopyTo(array, arrayIndex);

        public IEnumerator<CharacterStat> GetEnumerator() => _stats.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _stats.GetEnumerator();

        public int IndexOf(CharacterStat item) => _stats.IndexOf(item);

        public void Insert(int index, CharacterStat item)
        {
            _stats.Insert(index, item);

            OnStatCollectionChanged?.Invoke(this, new StatCollectionChangedEventArgs(item));
        }

        public bool Remove(CharacterStat item)
        {
            bool removed = _stats.Remove(item);

            OnStatCollectionChanged?.Invoke(this, new StatCollectionChangedEventArgs(item));

            return removed;
        }

        public void RemoveAt(int index)
        {
            var stat = _stats[index];

            _stats.RemoveAt(index);

            OnStatCollectionChanged?.Invoke(this, new StatCollectionChangedEventArgs(stat));
        }

        public void ForEach(Action<CharacterStat> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            _stats.ForEach(action);
        }

        public ReadOnlyCollection<CharacterStat> AsReadOnly() => _stats.AsReadOnly();

        public override string ToString()
        {
            StringBuilder sbStats = new StringBuilder(250);
            _stats.ForEach(stat => sbStats.AppendLine(stat.ToString()));
            return sbStats.ToString();
        }
    }
}
