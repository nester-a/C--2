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
        private int index;
        //Bitmap PlanetIMG;

        public Planet(Point _pos, Point _dir) : base (_pos, _dir)
        {
            index = random.Next(1, 7);
        }
        public override void Draw()
        {
            switch (index)
            {
                case 1:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.planet_1, new Size(357, 391)), Pos.X, Pos.Y);
                    break;
                case 2:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.planet_2, new Size(267, 150)), Pos.X, Pos.Y);
                    break;
                case 3:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.planet_3, new Size(433, 248)), Pos.X, Pos.Y);
                    break;
                case 4:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.planet_4, new Size(249, 255)), Pos.X, Pos.Y);
                    break;
                case 5:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.planet_5, new Size(352, 365)), Pos.X, Pos.Y);
                    break;
                case 6:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.planet_6, new Size(256, 263)), Pos.X, Pos.Y);
                    break;
            }
        }
        private void RandomPlanet()
        {
            //TODO потом
        }
        public override void Update()
        {
            if (Pos.X < -500)
            {
                index = random.Next(1, 7);
                Pos.X = Game.Width;
                Pos.Y = random.Next(1, Game.Height - Size.Height);
            }
            Pos.X -= 10;
        }
    }
}
