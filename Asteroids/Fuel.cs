using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Fuel : SpaceObject
    {
        public Fuel(Point pos, Point dir) : base(pos, dir)
        {
            Size = new Size(40, 59);
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.fuel, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;

            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width - Size.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height - Size.Height) Dir.Y = -Dir.Y;
            if (Pos.X + Size.Width > Game.Width - Size.Width) Pos.X = Game.Width - Size.Width;
            if (Pos.Y + Size.Height > Game.Height - Size.Height) Pos.Y = Game.Height - Size.Height;
        }
    }
}
