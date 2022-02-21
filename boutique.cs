using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataComponent
{
    public class Boutique
    {
        public int CId { get; set; }
        public string CType { get; set; }
        public string CBrand { get; set; }
        public string CSize { get; set; }
        public int CPrice { get; set; }

        public void Dispose()
        {
           
        }
    }
}
