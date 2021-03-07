using Asteroids.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    static class Game
    {
        static BaseObject[] _asteroids;
        static BaseObject[] _stars;
        static Bullet _bullet;
        static Ship ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(45, 50));
        static Timer timer = new Timer();
        static Random random = new Random();

        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
        }
        public static void Init(Form form)
        {          
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();

            timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;

            form.KeyDown += Form_KeyDown;
            Ship.DieEvent += Finish;
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                _bullet = new Bullet(new Point(ship.Rect.X + 10, ship.Rect.Y + 23), new Point(5, 0), new Size(54, 9));
            }
            if (e.KeyCode == Keys.Up)
            {
                ship.Up();
            }
            if (e.KeyCode == Keys.Down)
            {
                ship.Down();
            }
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);

            foreach (var obj in _stars)
                obj.Draw();

            Buffer.Graphics.DrawImage(new Bitmap(Resources.planet, new Size(200, 200)), 100, 100);

            foreach (var obj in _asteroids)
                if (obj != null)
                    obj.Draw();

            if (_bullet != null)
                _bullet.Draw();


            if (ship != null)
            {
                ship.Draw();
                //new Font("Arial", 18);
                Buffer.Graphics.DrawString($"Energy: {ship.Energy}", SystemFonts.DefaultFont, Brushes.White, 10, 10);
            }

            Buffer.Render();
        }

        public static void Load()
        {
            //_bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(54, 9));

            var random = new Random();
            _asteroids = new Asteroid[15];
            for (int i = 0; i < _asteroids.Length; i++)
            {
                var size = random.Next(10, 40);
                _asteroids[i] = new Asteroid(new Point(600, i * 20), new Point(-i, -i), new Size(size, size));
            }
            _stars = new Star[20];
            for (int i = 0; i < _stars.Length; i++)
                _stars[i] = new Star(new Point(600, i * 40), new Point(-i, -i), new Size(3, 3));
        }

        public static void Update()
        {
            //foreach (var asteroid in _asteroids)
            //{
            //    asteroid.Update();
            //    if (asteroid.Collision(_bullet))
            //    {

            //    }
            //}

            //for( int i = 0; i < _asteroids.Length; i++)
            //{
            //    _asteroids[i].Update();
            //    if (_asteroids[i].Collision(_bullet))
            //    {
            //        System.Media.SystemSounds.Hand.Play();
            //        Debug.WriteLine($"{i} -> X:{_asteroids[i].Rect.X} Y:{_asteroids[i].Rect.Y}");
            //    }
            //}

            for (int i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null)
                    continue;

                _asteroids[i].Update();


                // Столкноывение пули с астероидом
                if (_bullet != null &&  _asteroids[i].Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    Debug.WriteLine($"{i} -> X:{_asteroids[i].Rect.X} Y:{_asteroids[i].Rect.Y}");
                    _asteroids[i] = null;
                    _bullet = null;

                    continue;
                }

                if (_asteroids[i].Collision(ship))
                {
                    ship.EnergyLow(random.Next(1, 11));
                    if (ship.Energy <= 0)
                        ship.Die();
                }

            }

            foreach (var obj in _stars)
                obj.Update();

            if (_bullet != null)
            _bullet.Update();
        }

        private static void Finish(object sender, EventArgs e)
        {
            timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }

    }
}
