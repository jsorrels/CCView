using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSee
{
    class UENSerchParams
    {
        private object Sender;
        private EventArgs ev;
        private eReferenceType eTypeOfSearch;
       private string sRef;

        public object Sender1
        {
            get
            {
                return Sender;
            }

            set
            {
                Sender = value;
            }
        }

        public EventArgs Ev
        {
            get
            {
                return ev;
            }

            set
            {
                ev = value;
            }
        }

        public eReferenceType ETypeOfSearch
        {
            get
            {
                return eTypeOfSearch;
            }

            set
            {
                eTypeOfSearch = value;
            }
        }

        public string SRef
        {
            get
            {
                return sRef;
            }

            set
            {
                sRef = value;
            }
        }

        public UENSerchParams(object s, EventArgs ea, eReferenceType r)
        {
            Sender1 = s;
            ev = ea;
            ETypeOfSearch = r;
        }
    }
}

