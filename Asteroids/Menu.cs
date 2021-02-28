using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Menu
    {
        MyButton[] Buttons;
        public int Count { get; private set; }
        public MyButton this[int i]
        {
            get => Buttons[i];
            private set => Buttons[i] = value;
        }
        public Menu(params MyButton[] _buttons)
        {
            Buttons = _buttons;
            Count = _buttons.Length;
        }
        public void Draw()
        {
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].Draw();
            }
        }
    }
}
