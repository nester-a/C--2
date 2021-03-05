using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Planet : SpaceObject
    {
        private static Random random = new Random();
        //Bitmap PlanetIMG;

        public Planet(Point _pos, Point _dir, Size _size) : base (_pos, _dir, _size)
        {
            //здесь будет рандомизация планеты
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.planet_2, new Size(Size.Height, Size.Width)), Pos.X, Pos.Y);
        }
        private void RandomPlanet()
        {
            //TODO потом
        }
        public override void Update()
        {
            if (Pos.X < -500)
            {
                Pos.X = Game.Width;
                Pos.Y = random.Next(1, Game.Height + 1);
            }
            Pos.X -= 10;
        }
    }
}
