using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureEditDrawing
{
    sealed public class Line : Shape
    {
        
        /// <summary>
        /// Initializes a new instance of the Line class
        /// </summary>
        public Line()
            : base()
        {

        }



        /// <summary>
        /// Draws this Line
        /// </summary>
        /// <param name="graphics">Current Graphics context</param>
        public override void Draw(Graphics graphics)
        {
            using (Pen pen = new Pen(ForeColor, BorderWidth))
                graphics.DrawLine(pen, StartX, StartY, EndX, EndY);
            
        }   //End the Draw() method




    }   //End the Line class
}   //End the PictureEditDrawing namespace
