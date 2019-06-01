using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureEditDrawing
{
    abstract public class Shape
    {
        /// <summary>
        /// Gets or sets the starting X co-ordinate for the Shape
        /// </summary>
        public int StartX
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the starting Y co-ordinate for the Shape
        /// </summary>
        public int StartY
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ending X co-ordinate for the Shape
        /// </summary>
        public int EndX
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ending Y co-ordinate for the Shape
        /// </summary>
        public int EndY
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the ForeColor of this Shape
        /// </summary>
        public Color ForeColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Border Width of this Shape
        /// </summary>
        public float BorderWidth
        {
            get;
            set;
        }


        /// <summary>
        /// Initializes a new instance of the Shape class
        /// </summary>
        public Shape()
        {
            BorderWidth = 1.0f;
            ForeColor = Color.Black;
        }


        /// <summary>
        /// Draws this Shape
        /// </summary>
        /// <param name="graphics">Current Graphics context</param>
        public abstract void Draw(Graphics graphics);



    }   //End the Shape class
}   //End the PictureEditDrawing namespace
