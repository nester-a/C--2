﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SApp03
{
    
    interface ICollision
    {
        bool Collision(ICollision obj);

        Rectangle Rect { get; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
