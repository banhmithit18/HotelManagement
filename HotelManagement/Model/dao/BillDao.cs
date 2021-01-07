using HotelManagement.Model.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Model.dao
{
    class BillDao
    {
        public List<view.BillView> GetBill(int roomid)
        {
            HOTELMANAGEMENTEntities hm = new HOTELMANAGEMENTEntities();
            var q = hm.ORDERDETAILs.Join(hm.SRVORDERs.Where(srvorder => srvorder.PAYMENTSTATUS == false && srvorder.ROOMID == roomid), odetail => odetail.ORDERID, srvorder => srvorder.ID, (odetail, srvorder) => new { OrderDetail = odetail, SrvOrder =  srvorder }).Join(hm.SERVICEs, x => x.SrvOrder.SRVID , y => y.ID,(x,y) =>new {x.SrvOrder,x.OrderDetail,Service = y}).Select(s => new Model.view.BillView {NAME =s.Service.NAME, QUANTITY =s.SrvOrder.QUANTITY??0,PRICE = s.OrderDetail.PRICE??0, TOTAL= s.SrvOrder.QUANTITY*s.OrderDetail.PRICE??0,DATE=s.OrderDetail.date,NOTE = s.SrvOrder.NOTE }).ToList();
            return q;
        }
    }
}
