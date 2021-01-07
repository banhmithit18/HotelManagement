using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Model.view
{
    class BillView
    {
        public String NAME { get; set; }
        public int QUANTITY { get; set; }
        public double PRICE { get; set; }
        public double TOTAL { get; set; }
        public String DATE { get; set; }
        public String NOTE { get; set; }
    }
}
