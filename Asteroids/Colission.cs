using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public interface IColission
    {
        bool Colission(IColission obj);
        Rectangle Rect { get; }
    }
}
