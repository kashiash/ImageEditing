using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagesXaf.Module.BusinessObjects
{
    public class OpisZdjecia : XPObject
    {
        public OpisZdjecia(Session session) : base(session)
        { }


        Osoba osoba;
        int height;
        int width;
        int yPos;
        int xPos;
        string opis;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Opis
        {
            get => opis;
            set => SetPropertyValue(nameof(Opis), ref opis, value);
        }

        public int XPos
        {
            get => xPos;
            set => SetPropertyValue(nameof(XPos), ref xPos, value);
        }

        public int YPos
        {
            get => yPos;
            set => SetPropertyValue(nameof(YPos), ref yPos, value);
        }

        public int Width
        {
            get => width;
            set => SetPropertyValue(nameof(Width), ref width, value);
        }

        public int Height
        {
            get => height;
            set => SetPropertyValue(nameof(Height), ref height, value);
        }
        
        [Association("Osoba-OpisZdjeciaCollection")]
        public Osoba Osoba
        {
            get => osoba;
            set => SetPropertyValue(nameof(Osoba), ref osoba, value);
        }
    }
}
