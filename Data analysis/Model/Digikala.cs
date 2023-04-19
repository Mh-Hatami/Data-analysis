using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_analysis.Model
{
    internal class Digikala
    {
        public int Id_Order { get; set; }
        public int Id_Customer { get; set; }
        public int Id_Item { get; set; }
        public string DateTime_CartFinalize { get; set; }
        public int Amount_Gross_Order { get; set; }
        public string City_name_fa { get; set; }
    }
}
