using HotelManagement.Model.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Model.dao
{
    class OrderDetailDao
    {
        public bool Add(Model.entity.ORDERDETAIL od)
        {
            HOTELMANAGEMENTEntities hm = new HOTELMANAGEMENTEntities();
            try
            {
                hm.ORDERDETAILs.Add(od);
                hm.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return false;

            }
        }
    }
}
