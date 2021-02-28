using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    static class SplashScreen
    {
        private static BufferedGraphicsContext _context;
        private static BufferedGraphics _buffer;
        private static StarForSpalshScreen[] _stars;
        private static BackgroundForSplashScreen _background;
        private static MyButton _start;
        private static MyButton _record;
        private static MyButton _exit;
        private static Menu _menu;

        public static int Width { get; set; }
        public static int Height { get; set; }
        public static BufferedGraphics Buffer
        {
            get => _buffer;
        }

        static SplashScreen() { }

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

            _background.Draw();

            foreach (var star in _stars)
                star.Draw();

            _menu.Draw();

            _buffer.Render();
        }
        public static void Update()
        {
            var random = new Random();
            var randomStar = random.Next(0, _stars.Length);
            _stars[randomStar].Update();

            
        }
        public static void Load()
        {
            var random = new Random();

            _background = new BackgroundForSplashScreen(new Point(0, 0), new Size(600, 800));

            _stars = new StarForSpalshScreen[40];
            for (int i = 0; i < _stars.Length; i++)
            {
                var x = random.Next(0, 801);
                var y = random.Next(0, 601);
                var size = random.Next(5, 21);
                _stars[i] = new StarForSpalshScreen(new Point(x, y), new Point(-i, -i), new Size(size, size));
            }

            _start = new StartButton(new Point(300, 200), new Size(100, 200));
            _record = new RecordButton(new Point(300, 300), new Size(100, 200));
            _exit = new ExitButton(new Point(300, 400), new Size(100, 200));
            _menu = new Menu(_start, _record, _exit);
        }
    }
}
