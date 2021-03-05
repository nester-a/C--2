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
        private static List<SpaceObject> _asteroids;
        private static List<SpaceObject> _stars;
        private static Planet _planet;
        private static Background _background;
        private static LaserBeam _laserBeam;
        private static Random random;



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
            if(Width <= 0 || Width > 1000)
            {
                throw new ArgumentOutOfRangeException("Ошибка ширины окна", "Заданы неверные размеры ширины окна.");
            }
            Height = form.ClientSize.Height;
            if (Height <= 0 || Height > 1000)
            {
                throw new ArgumentOutOfRangeException("Ошибка высоты окна", "Заданы неверные размеры высоты окна.");
            }

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

            _background.Draw();

            foreach (var star in _stars)
                star.Draw();

            _planet.Draw();

            foreach (var asteroid in _asteroids)
                asteroid.Draw();

            _laserBeam.Draw();//лазер

            _buffer.Render();
        }
        public static void Update()
        {
            for (int i = 0; i < _asteroids.Count; i++)
            {
                for (int j = 0; j < _asteroids.Count; j++)
                {
                    if (i == j) continue;
                    if (_asteroids[i].Colission(_asteroids[j]))
                    {
                        _asteroids[i].ChangeDirection();
                        _asteroids[j].ChangeDirection();
                        _asteroids[i].Update();
                        _asteroids[j].Update();
                    }
                    _asteroids[i].Update();
                }
            }
            foreach (var asteroid in _asteroids)
            {
                if (asteroid.Colission(_laserBeam))
                {
                    //создание новых астероидов при столкновении с лазером
                    //var x = random.Next(0, 801);
                    //var y = random.Next(0, 601);
                    //var size = random.Next(10, 40);
                    //_asteroids.Add(new Asteroid(new Point(x, y), new Point(1, 1), new Size(size, size)));

                    _asteroids.Remove(asteroid);
                    break;
                }
            }

            foreach (var star in _stars)
                star.Update();

            _laserBeam.Update();

            _planet.Update();
        }
        public static void Load()
        {
            random = new Random();

            _background = new Background(new Point(0, 0), new Size(600, 800));

            _planet = new Planet(new Point(100, 100), new Point(0, 0), new Size(200, 300));

            _asteroids = new List<SpaceObject>();
            for (int i = 0; i < 15; i++)
            {
                var x = random.Next(0, 801);
                var y = random.Next(0, 601);
                var size = random.Next(10, 40);
                _asteroids.Add(new Asteroid(new Point(x, y), new Point(1, 1), new Size(size, size)));
            }

            _stars = new List<SpaceObject>();
            for (int i = 0; i < 40; i++)
            {
                var x = random.Next(0, 801);
                var y = random.Next(0, 601);
                var size = random.Next(5, 21);
                _stars.Add(new Star(new Point(x, y), new Point(-i, -i), new Size(size, size)));
            }

            _laserBeam = new LaserBeam(new Point(100, 200), new Point(0, 0), new Size(20, 40));
        }
    }
}
