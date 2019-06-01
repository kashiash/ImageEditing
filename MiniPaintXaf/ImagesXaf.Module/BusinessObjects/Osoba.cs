using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagesXaf.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Osoba : Person
    {
        public Osoba(Session session) : base(session)
        { }

        [Association("Osoba-OpisZdjeciaCollection")]
        public XPCollection<OpisZdjecia> OpisZdjeciaCollection
        {
            get
            {
                return GetCollection<OpisZdjecia>(nameof(OpisZdjeciaCollection));
            }
        }
    }

}
