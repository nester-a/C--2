using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Background
    {
        protected Point Pos;
        protected Size Size;

        public Background(Point _pos, Size _size)
        {
            Pos = _pos;
            Size = _size;
        }
        public void Draw()
        {
            Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.bg1, new Size(Size.Height, Size.Width)), Pos.X, Pos.Y);
        }
    }

    class BackgroundForSplashScreen : Background
    {
        public BackgroundForSplashScreen(Point _pos, Size _size) : base(_pos, _size) { }
        public void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawImage(new Bitmap(Resources.bg1, new Size(Size.Height, Size.Width)), Pos.X, Pos.Y);
        }
    }
}
