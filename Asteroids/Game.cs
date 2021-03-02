using Asteroids.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    static class Game
    {
        //static Asteroid[] _objs;
        //static Asteroid[] _stars;
        static BaseObject[] _objs;
        static BaseObject[] _stars;
        static Bullet _bullet;


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

            Timer timer = new Timer { Interval = 100 };
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
            Buffer.Graphics.Clear(Color.Black);

            foreach (BaseObject obj in _stars)
                obj.Draw();

            Buffer.Graphics.DrawImage(new Bitmap(Resources.planet, new Size(200, 200)), 100, 100);

            foreach (BaseObject obj in _objs)
                obj.Draw();

            _bullet.Draw();

            Buffer.Render();
        }

        public static void Load()
        {

            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(54, 9));
            
            var random = new Random();
            _objs = new BaseObject[15];
            for (int i = 0; i < _objs.Length; i++)
            {
                var size = random.Next(10, 40);
                _objs[i] = new Asteroid(new Point(600, i * 20), new Point(-i, -i), new Size(size, size));
            }
            _stars = new BaseObject[20];
            for (int i = 0; i < _stars.Length; i++)
                _stars[i] = new Star(new Point(600, i * 40), new Point(-i, -i), new Size(3, 3));
        }

        public static void Update()
        {
            foreach (BaseObject asteroid in _objs)
            {
                asteroid.Update();
                if (asteroid.Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    Debug.WriteLine("Пересечение астероида и пули!");
                }
            }
                
            foreach (BaseObject obj in _stars)
                obj.Update();

            _bullet.Update();
        }

    }
}
