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
    class Star : Asteroid
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size) { }
        Random random = new Random();

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.star_1, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
        }

        public override void Update()
        {
            var newSize = random.Next(5, 21);
            Size = new Size(newSize, newSize);
        }
    }
}
