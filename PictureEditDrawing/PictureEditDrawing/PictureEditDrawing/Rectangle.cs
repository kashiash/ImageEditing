using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureEditDrawing
{
    sealed public class Rectangle : Shape
    {

        /// <summary>
        /// Initializes a new instance of the Rectangle class
        /// </summary>
        public Rectangle()
            : base()
        {

        }



        /// <summary>
        /// Draws this Rectangle
        /// </summary>
        /// <param name="graphics">Current Graphics context</param>
        public override void Draw(Graphics graphics)
        {
            using (Pen pen = new Pen(ForeColor, BorderWidth))
                graphics.DrawRectangle(pen, Math.Min(StartX, EndX), Math.Min(StartY, EndY), Math.Abs(EndX - StartX), Math.Abs(EndY - StartY));

        }   //End the Draw() method
            


    }   //End the Rectangle class
}   //End the PictureEditDrawing namespace
