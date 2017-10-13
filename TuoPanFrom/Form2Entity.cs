using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuoPanFrom
{
    public class Form2Entity
    {
        private string pId;
        private string name;
        private string describe;
      

        public string PId
        {
            get
            {
                return pId;
            }

            set
            {
                pId = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Describe
        {
            get
            {
                return describe;
            }

            set
            {
                describe = value;
            }
        }
    }
}
