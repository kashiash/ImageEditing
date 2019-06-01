using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureEditDrawing
{
    sealed public class Ellipse : Shape
    {

        /// <summary>
        /// Initializes a new instance of the Ellipse class
        /// </summary>
        public Ellipse()
            : base()
        {

        }



        /// <summary>
        /// Draws this Ellipse
        /// </summary>
        /// <param name="graphics">Current Graphics context</param>
        public override void Draw(Graphics graphics)
        {
            using (Pen pen = new Pen(ForeColor, BorderWidth))
                graphics.DrawEllipse(pen, StartX / 2, StartY / 2, EndX, EndY);
            
        }   //End the Draw() method



    }   //End the Shape class
}   //End the PictureEditDrawing namespace
