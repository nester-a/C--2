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
            timer.Interval = 100;
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

            _buffer.Graphics.FillEllipse(Brushes.Red, new Rectangle(100, 100, 200, 200));

            foreach (var asteroid in _asteroids)
                asteroid.Draw();

            foreach (var star in _stars)
                star.Draw(); // Переопределенный метод Draw

            _buffer.Render();
        }

        public static void Update()
        {
            foreach (var asteroid in _asteroids)
                asteroid.Update();

            foreach (var star in _stars)
                star.Update(); // Переопределенный метод Update
        }

        public static void Load()
        {
            var random = new Random();
            _asteroids = new Asteroid[15];
            for (int i = 0; i < _asteroids.Length; i++)
            {
                var size = random.Next(10, 40);
                _asteroids[i] = new Asteroid(new Point(600, i *20), new Point(-i, -i), new Size(size, size));
            }
            _stars = new Asteroid[20];
            for (int i = 0; i < _stars.Length; i++)
            {
                _stars[i] = new Star(new Point(600, i * 40), new Point(-i, -i), new Size(3, 3));
            }

        }

    }
}
