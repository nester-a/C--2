using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class MyButton
    {
        internal bool isSelected = false;
        protected Point Pos;
        protected Size Size;

        public MyButton(Point _pos, Size _size)
        {
            Pos = _pos;
            Size = _size;
        }
        public virtual void Draw()
        {
            
        }
        public virtual void Update()
        {
            if (isSelected == true)
                isSelected = false;
            else
                isSelected = true;
        }
    }
    class StartButton : MyButton
    {
        public StartButton(Point _pos, Size _size) : base (_pos, _size)
        {

        }
        public override void Draw()
        {
            if(isSelected == true)
            {
                SplashScreen.Buffer.Graphics.DrawImage(new Bitmap(Resources.buttonNewGameSelected, new Size(Size.Height, Size.Width)), Pos.X, Pos.Y);
            }
            else
            {
                SplashScreen.Buffer.Graphics.DrawImage(new Bitmap(Resources.buttonNewGame, new Size(Size.Height, Size.Width)), Pos.X, Pos.Y);
            }
        }
        public override void Update()
        {
            base.Update();
        }
    }
    class ExitButton : MyButton
    {
        public ExitButton(Point _pos, Size _size) : base(_pos, _size)
        {

        }
        public override void Draw()
        {
            if (isSelected == true)
            {
                SplashScreen.Buffer.Graphics.DrawImage(new Bitmap(Resources.buttonExitSelected, new Size(Size.Height, Size.Width)), Pos.X, Pos.Y);
            }
            else
            {
                SplashScreen.Buffer.Graphics.DrawImage(new Bitmap(Resources.buttonExit, new Size(Size.Height, Size.Width)), Pos.X, Pos.Y);
            }
        }
        public override void Update()
        {
            base.Update();
        }
    }
    class RecordButton : MyButton
    {
        public RecordButton(Point _pos, Size _size) : base(_pos, _size)
        {

        }
        public override void Draw()
        {
            if (isSelected == true)
            {
                SplashScreen.Buffer.Graphics.DrawImage(new Bitmap(Resources.buttonRecordSelected, new Size(Size.Height, Size.Width)), Pos.X, Pos.Y);
            }
            else
            {
                SplashScreen.Buffer.Graphics.DrawImage(new Bitmap(Resources.buttonRecord, new Size(Size.Height, Size.Width)), Pos.X, Pos.Y);
            }
        }
        public override void Update()
        {
            base.Update();
        }
    }
}
