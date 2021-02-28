using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Planet
    {
        protected Point Pos;
        protected Size Size;
        private Random rnd = new Random();

        public Planet(Point _pos, Size _size)
        {
            Pos = _pos;
            Size = _size;
        }
        public void Draw()
        {
            Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.planet_2, new Size(Size.Height, Size.Width)), Pos.X, Pos.Y);
        }
        private void RandomPlanet()
        {
            //TODO потом
        }
        public void Update()
        {
            Size tmp = Size.Empty;
            if (Size.Height - 3 < 3 || Size.Width - 2 < 2)
            {
                tmp = new Size(600, 900);
            }
            else
            {
                tmp = new Size(Size.Width - 2, Size.Height - 3);
            }
            Size = tmp;
        }
    }
}
