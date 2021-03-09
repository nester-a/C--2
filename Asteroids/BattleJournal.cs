using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class BattleJournal
    {
        public delegate void AddNoteToFIle();

        List<string> journal;
        string fileName;
        StreamWriter writer;
        FileStream fileStream;
        bool isEnd;

        public int Current
        {
            get => journal.Count;
        }

        public delegate void WriteEventHandler(object sender, BattleJournalEventArgs e);
        public static event WriteEventHandler AddString;

        public BattleJournal()
        {
            journal = new List<string>();
            fileName = $"battle_journal.txt";
            fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            writer = new StreamWriter(fileStream, System.Text.Encoding.UTF8);
            isEnd = false;
        }

        public void AddNote(string note)
        {
            journal.Add(note);
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
        public void AddNoteInFile()
        {
            if (!isEnd)
            {
                writer.WriteLine(journal[Current - 1]);
            }
        }
        public void WriteInFile()
        {
            for (int i = 0; i < journal.Count; i++)
            {
                writer.WriteLine(journal[i]);
            }
        }
        public void End()
        {
            if (!isEnd)
            {
                writer.WriteLine(Environment.NewLine);
                writer.Close();
                isEnd = true;
            }
        }
    }
}
