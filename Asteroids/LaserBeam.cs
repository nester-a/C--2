using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class LaserBeam : SpaceObject
    {
        public LaserBeam(Point pos, Point dir, Size size) : base (pos, dir, size)
        {

        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.laserBeam, new Size(Size.Height, Size.Width)), Pos.X, Pos.Y);
        }

        public override void Update()
        {
            Pos.X += 1;
        }
    }
}
