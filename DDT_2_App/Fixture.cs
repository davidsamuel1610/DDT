using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDT_2_App
{
    class Fixture
    {
        public string idfixture{ get; set;}
		public string TeamA{ get; set;}
		public string TeamB{ get; set;}
        public string Fixturez 
        {
            get { return string.Format("{0}. {1} VS {2}", idfixture, TeamA, TeamB); }
        }
        public override string ToString()
        {
            return string.Format("{0}. {1} VS {2}",idfixture,TeamA,TeamB);
        }
    }
}
