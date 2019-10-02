using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FigureCollections
{
   public class Square : Rectangle, IPrint
    {
        public Square(double size)
            : base(size, size)
        {
            this.Type = "Квадрат";
        }
    }
}
