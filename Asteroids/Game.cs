using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public static class Game
    {
        private static BufferedGraphicsContext _context;
        private static BufferedGraphics _buffer;
        private static Asteroid[] _asteroids;
        private static Asteroid[] _stars;
        private static Planet _planet;
        private static Background _background;

        public static int Width { get; set; }
        public static int Height { get; set; }
        public static BufferedGraphics Buffer
        {
            get { return _buffer; }
        }

        static Game() { }

        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            _buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static void Draw()
        {
            _buffer.Graphics.Clear(Color.Black);

            _background.Draw();

            foreach (var star in _stars)
                star.Draw();

            _planet.Draw();

            foreach (var asteroid in _asteroids)
                asteroid.Draw();

            _buffer.Render();
        }
        public static void Update()
        {
            foreach (var asteroid in _asteroids)
                asteroid.Update();

            var random = new Random();
            var randomStar = random.Next(0, _stars.Length);
            _stars[randomStar].Update();

            _planet.Update();
        }
        public static void Load()
        {
            var random = new Random();

            _background = new Background(new Point(0, 0), new Size(600, 800));

            _planet = new Planet(new Point(100, 100), new Size(200, 300));

            _asteroids = new Asteroid[15];
            for (int i = 0; i < _asteroids.Length; i++)
            {
                var x = random.Next(0, 801);
                var y = random.Next(0, 601);
                var size = random.Next(10, 40);
                _asteroids[i] = new Asteroid(new Point(x, y), new Point(-i, -i), new Size(size, size));
            }

            _stars = new Asteroid[40];
            for (int i = 0; i < _stars.Length; i++)
            {
                var x = random.Next(0, 801);
                var y = random.Next(0, 601);
                var size = random.Next(5, 21);
                _stars[i] = new Star(new Point(x, y), new Point(-i, -i), new Size(size, size));
            }
        }
    }
}
