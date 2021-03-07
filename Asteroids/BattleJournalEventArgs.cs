using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class BattleJournalEventArgs : EventArgs
    {
        public string Note { get; set; }
        public BattleJournalEventArgs(string note)
        {
            Note = note;
        }
    }
}
