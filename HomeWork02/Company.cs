using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork02
    {
    class Company : IEnumerable<Worker>
    {
        List<Worker> workers;
        public int Count
        {
            get => workers.Count;
        }

        public Company()
        {
            workers = new List<Worker>();
        }
        public Company(params Worker[] _workers)
        {
            workers = new List<Worker>();
            AddRange(_workers);
        }
        public Company(List<Worker> _workers)
        {
            workers = new List<Worker>();
            AddRange(_workers);
        }
        public void Add(Worker worker)
        {
            workers.Add(worker);
        }
        public void AddRange(params Worker[] _workers)
        {
            for (int i = 0; i < _workers.Length; i++)
            {
                Add(_workers[i]);
            }
        }
        public void AddRange(List<Worker> _workers)
        {
            for (int i = 0; i < _workers.Count; i++)
            {
                Add(_workers[i]);
            }
        }
        public void Clear()
        {
            workers = null;
        }
        public IEnumerator<Worker> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return workers[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void SortByNames()
        {
            ComparerByName comparatorByName = new ComparerByName();
            ChangeListToArraySortItAndBack(comparatorByName);
        }
        public void SortBySurnames()
        {
            ComparerBySurname comparatorBySurname = new ComparerBySurname();
            ChangeListToArraySortItAndBack(comparatorBySurname);
        }
        public void SortBySalary()
        {
            ComparerBySalary comparatorBySalary = new ComparerBySalary();
            ChangeListToArraySortItAndBack(comparatorBySalary);
        }
        private void ChangeListToArraySortItAndBack(IComparer comparer)
        {
            Worker[] tmp = new Worker[Count];
            for (int i = 0; i < Count; i++)
            {
                tmp[i] = workers[i];
            }
            Array.Sort(tmp, comparer);
            workers.Clear();
            workers = new List<Worker>();
            workers.AddRange(tmp);
        }
    }
}
