using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class BattleJournal
    {
        List<string> journal;
        public int Current
        {
            get => journal.Count;
        }

        public delegate void WriteEventHandler(object sender, BattleJournalEventArgs e);
        public static event WriteEventHandler AddString;

        public BattleJournal()
        {
            journal = new List<string>();
        }

        public void AddNote(string note)
        {
            journal.Add(note + Environment.NewLine);
        }
        public void AddNewString()
        {
            AddString?.Invoke(this, new BattleJournalEventArgs(journal[Current - 1]));
        }
        public void ReviewJournal()
        {
            foreach (var note in journal)
            {
                Console.WriteLine(note);
            }
        }
    }
}
