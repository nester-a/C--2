using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class GameObjectException : ArgumentException
    {
        public GameObjectException(string message) : base (message)
        {

        }
    }
}
