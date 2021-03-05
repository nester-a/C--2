using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asteroids
{
    class Star : SpaceObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size) { }
        static Random random = new Random();

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.star_1, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
        }

        public override void Update()
        {
            if (Pos.X < 0)
            {
                Pos.X = Game.Width;
                Pos.Y = random.Next(1, Game.Height + 1);
            }
            Pos.X -= 50;
        }
    }
}
