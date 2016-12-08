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
        private string sDate;
        private string eDate;


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

        public string SDate
        {
            get
            {
                return sDate;
            }

            set
            {
                sDate = value;
            }
        }

        public string EDate
        {
            get
            {
                return eDate;
            }

            set
            {
                eDate = value;
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

