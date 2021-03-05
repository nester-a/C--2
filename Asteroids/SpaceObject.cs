using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    abstract class SpaceObject : IColission
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        protected SpaceObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public Rectangle Rect => new Rectangle(Pos, Size);

        public bool Colission(IColission obj)
        {
            return obj.Rect.IntersectsWith(this.Rect);
        }

        public abstract void Draw();
        public abstract void Update();
        public virtual void ChangeDirection()
        {
            Dir.X = -Dir.X;
            Dir.Y = -Dir.Y;
        }
    }
}
