using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    abstract class SpaceObject : IColission
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        protected SpaceObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            if (Pos.X < 0) throw new GameObjectException("Ошибка! Координаты по X позиции КосмическогоОбъекта не могут быть отрицательными.");
            if (Pos.Y < 0) throw new GameObjectException("Ошибка! Координаты по Y позиции КосмическогоОбъекта не могут быть отрицательными.");
            if (Pos.X > Game.Width + 100) throw new GameObjectException("Ошибка! Координаты по X позиции КосмическогоОбъекта не могут быть больше ширины окна.");
            if (Pos.Y > Game.Height + 100) throw new GameObjectException("Ошибка! Координаты по X позиции КосмическогоОбъекта не могут быть больше ширины окна.");

            Dir = dir;

            Size = size;
            if (size.Width < 0) throw new GameObjectException("Ошибка! Ширина КосмическогоОбъекта не может быть отрицательной.");
            if (size.Width > Game.Width) throw new GameObjectException("Ошибка! Ширина КосмическогоОбъекта не может превышать ширину окна в два раза.");
            if (size.Height < 0) throw new GameObjectException("Ошибка! Высота КосмическогоОбъекта не может быть отрицательной.");
            if (size.Width > Game.Width) throw new GameObjectException("Ошибка! Высота КосмическогоОбъекта не может превышать высоту окна в два раза.");
        }

        public Rectangle Rect => new Rectangle(Pos, Size);

        public bool Colission(IColission obj)
        {
            return obj.Rect.IntersectsWith(this.Rect);
        }

        public abstract void Draw();
        public abstract void Update();
        public virtual void ChangeDirection()
        {
            //
        }
    }
}
