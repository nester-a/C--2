﻿using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Asteroids.BattleJournal;

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
        private static Ship _ship;
        private static Timer timer = new Timer();
        private static Fuel _fuel;
        private static BattleJournal _battleJournal;
        private static AddNoteToFIle addNoteToFile;

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

            timer.Interval = 100;
            timer.Start();
            timer.Tick += Timer_Tick;

            form.KeyDown += Form_KeyDown;
            Ship.DieEvent += GameOver;
            AddString += BattleJournal_AddString;
            form.FormClosed += Form_FormClosed;

            //запись в журнал о начале игры
            _battleJournal.AddNote($"{DateTime.Now} Игра началась!");
            _battleJournal.AddNewString();
        }

        private static void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            //запись в журнал о конце игры и закрытие потока
            _battleJournal.AddNote($"{DateTime.Now} Игрок покинул игру.");
            _battleJournal.AddNewString();
            _battleJournal.End();
        }
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.ControlKey)
            {
                _laserBeam = new LaserBeam(new Point(_ship.Rect.X + 128, _ship.Rect.Y + 30), new Point(0, 0), new Size(10, 40));
            }
            if(e.KeyCode == Keys.Up)
            {
                _ship.Up();
            }
            if(e.KeyCode == Keys.Down)
            {
                _ship.Down();
            }
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
                asteroid?.Draw();

            _laserBeam?.Draw();

            if(_ship != null)
            {
                _ship.Draw();
                Buffer.Graphics.DrawString($"Энергия: {_ship.Energy}", SystemFonts.DefaultFont, Brushes.Black, 10, 10);
                Buffer.Graphics.DrawString($"Сбитые астероиды: {_ship.DestroyAsteroidCount}", SystemFonts.DefaultFont, Brushes.Black, 100, 10);
            }

            if (_fuel == null && _ship.DestroyAsteroidCount != 0 && _ship.DestroyAsteroidCount % 5 == 0)
            {
                var x = random.Next(100, 300);
                var y = random.Next(100, 300);
                var randomXDir = random.Next(-4, 4);
                var randomYDir = random.Next(-4, 4);
                _fuel = new Fuel(new Point(x, y), new Point(randomXDir, randomYDir));
            }
            _fuel?.Draw();

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
                asteroid.Update();
            }

            foreach (var asteroid in _asteroids)
            {
                if (_laserBeam != null && asteroid.Colission(_laserBeam))
                {
                    _battleJournal.AddNote($"Лазер попал в астероид по координатам X={asteroid.Rect.X}, Y={asteroid.Rect.Y}");
                    _battleJournal.AddNewString();
                    
                    _asteroids.Remove(asteroid);
                    _laserBeam = null;
                    _ship.IncreaseCount();

                    _battleJournal.AddNote($"Корабль уничтожил астероид. Счёт - {_ship.DestroyAsteroidCount}");
                    _battleJournal.AddNewString();

                    break;
                }
                if (asteroid.Colission(_ship))
                {
                    _battleJournal.AddNote($"Астероид столкнулся с кораблём по координатам X={asteroid.Rect.X}, Y={asteroid.Rect.Y}");
                    _battleJournal.AddNewString();

                    _asteroids.Remove(asteroid);
                    int damage = random.Next(10, 33);
                    _ship.DamageShip(damage);
                    _ship.IncreaseCount();

                    _battleJournal.AddNote($"Корабль получил урон равный {damage}");
                    _battleJournal.AddNewString();
                    _battleJournal.AddNote($"Корабль уничтожил астероид своим корпусом. Счёт - {_ship.DestroyAsteroidCount}");
                    _battleJournal.AddNewString();

                    if (_ship.Energy <= 0)
                    {
                        _ship.Die();
                    }
                    break;
                }
            }

            foreach (var star in _stars)
                star.Update();
            
            _laserBeam?.Update();

            _planet.Update();
            
            _fuel?.Update();

            if(_fuel != null && _laserBeam != null)
            {
                if (_ship.Colission(_fuel) || _laserBeam.Colission(_fuel))
                {
                    _laserBeam = null;
                    int heal = random.Next(20, 50);
                    _ship.HealShip(heal);
                    _fuel = null;

                    _battleJournal.AddNote($"Корабль подобрал топливо и восстановил {heal} энергии.");
                    _battleJournal.AddNewString();
                }
            }
        }
        public static void Load()
        {
            random = new Random();

            _background = new Background(new Point(0, 0), new Size(600, 800));

            _planet = new Planet(new Point(100, 100), new Point(0, 0));

            _asteroids = new List<SpaceObject>();
            for (int i = 0; i < 9; i++)
            {
                var x = random.Next(100, 700);
                var y = random.Next(100, 500);
                var size = random.Next(40, 60);
                var randomXDir = random.Next(-4, 4);
                var randomYDir = random.Next(-4, 4);
                _asteroids.Add(new Asteroid(new Point(x, y), new Point(randomXDir, randomYDir), new Size(size, size)));
            }

            _stars = new List<SpaceObject>();
            for (int i = 0; i < 40; i++)
            {
                var x = random.Next(0, 700);
                var y = random.Next(0, 500);
                var size = random.Next(5, 21);
                _stars.Add(new Star(new Point(x, y), new Point(-i, -i), new Size(size, size)));
            }

            _ship = new Ship(new Point(10, 400), new Point(5, 5));

            _battleJournal = new BattleJournal();

            addNoteToFile = _battleJournal.AddNoteInFile;
        }
        private static void GameOver(object sender, EventArgs e)
        {
            timer.Stop();
            Buffer.Graphics.DrawString("GAME OVER", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.Black, 150, 200);
            _buffer.Render();

            //запись в журнал о конце игры и закрытие потока
            _battleJournal.AddNote($"{DateTime.Now} Корабль уничтожен. Игра закончена");
            _battleJournal.AddNewString();
            _battleJournal.End();
        }
        private static void BattleJournal_AddString(object sender, BattleJournalEventArgs e)
        {
            Debug.WriteLine(DateTime.Now + " " + e.Note);
            addNoteToFile?.Invoke();
        }
    }
}
