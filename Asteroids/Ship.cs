using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Ship : SpaceObject
    {
        public int Energy { get; private set; } = 100;
        public static event EventHandler DieEvent;
        public int DestroyAsteroidCount { get; private set; } = 0;

        public Ship(Point pos, Point dir):base(pos, dir)
        {
            Size = new Size(128, 63);
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.spaceship, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
        }
        public override void Update()
        {
            //base.Update();
        }
        public void Up()
        {
            if (Pos.Y - Size.Height < 0) Pos.Y = 0;
            if (Pos.Y > 0) Pos.Y -= Size.Height;
        }
        public void Down()
        {
            if (Pos.Y + Size.Height > Game.Height - 63) Pos.Y = Game.Height - 63;

            else if (Pos.Y < Game.Height - 63) Pos.Y += Size.Height;
        }
        public void DamageShip (int damage)
        {
            Energy -= damage;
        }

        //хилим корабль
        public void HealShip (int heal)
        {
            if (Energy + heal > 100)
                Energy = 100;
            else
                Energy += heal;
        }
        public void Die()
        {
            DieEvent?.Invoke(this, new EventArgs());
        }
        public void IncreaseCount()
        {
            DestroyAsteroidCount++;
        }
        public void ResetCount()
        {
            DestroyAsteroidCount = 0;
        }
    }
}
