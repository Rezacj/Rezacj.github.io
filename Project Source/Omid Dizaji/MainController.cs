using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace WebApplication6.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View("View2");
        }

        #region Add Methods
        public byte admin_add(Models.tbl_admins _input)
        {

            Models.db db1 = new Models.db();
            var q = from i in db1.tb_admins where i.username == _input.username select i;
            if (q.Count() == 0)
            {
                db1.tb_admins.Add(_input);
                db1.SaveChanges();
                return 0;
            }
            else
                return 1;
            
        }
        public byte user_add(Models.tbl_users _input)
        {

            Models.db db1 = new Models.db();
            var q = from i in db1.tb_users where i.phonenumber == _input.phonenumber || i.nationalcode == _input.nationalcode select i;
            if (q.Count() == 0)
            {
                // if (پنل پیامکی) {

                db1.tb_users.Add(_input);
                db1.SaveChanges();
                return 0;

                // }
            }
            else
                return 1;

        }
        public byte basket_active_add(Models.tbl_basket_active _input)
        {
            try
            {
                Models.db db1 = new Models.db();

                _input.registiration_date = DateTime.Now.Date;
                _input.visited = 0; // Default

                db1.tb_basket_active.Add(_input);

                return 0;
            }
            catch (Exception)
            {
                return 1;
            }
            
        }
        public byte basket_deactive_add(Models.tbl_basket_deactive _input)
        {
            try
            {
                Models.db db1 = new Models.db();

                _input.registiration_date = DateTime.Now.Date;

                db1.tb_basket_deactive.Add(_input);

                return 0;
            }
            catch (Exception)
            {
                return 1;
            }

        }
        public byte brand_add(Models.tbl_brands _input)
        {

            Models.db db1 = new Models.db();
            var q = from i in db1.tb_brands where i.model == _input.model && i.name == _input.name && i.series == _input.series select i;
            if (q.Count() == 0) // در صورتی که ورودی (نام - مدل - سری) در جدول وجود نداشت ثبت بشود
            {
                

                db1.tb_brands.Add(_input);
                db1.SaveChanges();
                return 0; // با موفقیت ثبت شد

               
            }
            else
                return 1; // ورودی در پایگاه داده تکراری است

        }
        public byte pricerange_add(Models.tbl_pricerange _input)
        {
            Models.db db1 = new Models.db();
            var q = from i in db1.tb_pricerange where i.brand_ID == _input.brand_ID select i;
            if (q.Count() == 0) // در صورتی که ورودی (آیدی برند) در جدول وجود نداشت ثبت بشود -این شرط برای تکرار نشدن 2 رنج قیمتی برای 1 آیدی برند میباشد
            {
                db1.tb_pricerange.Add(_input);
                db1.SaveChanges();
                return 0; // با موفقیت ثبت شد
                
            }
            else
                return 1; // ورودی در پایگاه داده تکراری است
        }
        public byte product_add(Models.tbl_product _input)
        {
            try
            {
                Models.db db1 = new Models.db();
                _input.approval_status = 0;
                _input.registration_date = DateTime.Now.Date;
                db1.tb_product.Add(_input);
                return 0; // با موفقیت ثبت شد 
            }
            catch (Exception)
            {
                return 1; // مشکلی در ثبت اتفاق افتاده است
            }
            
        }
        public byte product_deleted_add(Models.tbl_product_deleted _input)
        {
            try
            {
                Models.db db1 = new Models.db();
                _input.deleted_date = DateTime.Now.Date;
                db1.tb_product_deleted.Add(_input);
                // Delete Function
                ///////////////////////////////////////////////////////
                return 0; // با موفقیت حذف شد 
            }
            catch (Exception)
            {
                return 1; // مشکلی در حذف اتفاق افتاده است
            }

        }
        public byte product_sold_add(Models.tbl_product_sold _input)
        {
            try
            {
                Models.db db1 = new Models.db();
                _input.sold_date = DateTime.Now.Date;
                db1.tb_product_sold.Add(_input);
                // Delete Function
                ///////////////////////////////////////////////////////
                return 0; // با موفقیت حذف شد 
            }
            catch (Exception)
            {
                return 1; // مشکلی در حذف اتفاق افتاده است
            }

        }
        public byte scheduling_add(Models.tbl_scheduling _input)
        {
            try
            {
                Models.db db1 = new Models.db();
                db1.tb_scheduling.Add(_input);
                return 0; // با موفقیت ثبت شد 
            }
            catch (Exception)
            {
                return 1; // مشکلی در ثبت اتفاق افتاده است
            }

        }
        public byte ticket_add(Models.tbl_ticket _input)
        {
            try
            {
                Models.db db1 = new Models.db();
                _input.date = DateTime.Now.Date;
                _input.visited = 0;
                db1.tb_ticket.Add(_input);

                return 0; // با موفقیت ثبت شد 
            }
            catch (Exception)
            {
                return 1; // مشکلی در ثبت اتفاق افتاده است
            }

        }

        #endregion

        #region Select Methods
        
        public byte login_admin(string username,string password)
        {

            Models.db db1 = new Models.db();
            byte _access_level;
            var q = from i in db1.tb_admins where i.username == username && i.password == password select i.access_level;
            
            if (q.Count() == 1)
            {
                _access_level = q.Single();
                return _access_level;
            }
            else
                return 100; // not found

        }

        // user login code with sms verfication

        public ActionResult selectAll_basket_active()
        {
            Models.db db1 = new Models.db();

            var query = from b in db1.tb_basket_active
                        join a in db1.tb_admins on b.source_ID equals a.U_ID into joined
                        from a in joined.DefaultIfEmpty()
                        select new
                        {
                            ID = b.ID,
                            sourceName = a.name,
                            DesName = (from a2 in db1.tb_admins where b.destinition_ID == a2.U_ID select a2.name).FirstOrDefault(),
                            product_ID = b.product_ID,
                            registiration_date = b.registiration_date
                        };


            //execute the LINQ query
            var results = query.ToList();
            
            return Json(results, JsonRequestBehavior.AllowGet);

        }
        public ActionResult select_basket_active_id(byte _id)
        {
            Models.db db = new Models.db();
            
            var query = from basket in db.tb_basket_active
                        join admin in db.tb_admins on basket.source_ID equals admin.U_ID
                        where basket.destinition_ID == _id
                        select new
                        {
                            ID = basket.ID,
                            sourceName = admin.name,
                            DesName = db.tb_admins.Where(a => a.U_ID == basket.destinition_ID).Select(a => a.name).FirstOrDefault(),
                            product_ID = basket.product_ID,
                            registiration_date = basket.registiration_date
                        };


            //execute the LINQ query
            if (query.Count() == 0)
                return null;
            else
            {
                var results = query.ToList();
                return Json(results, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

    }
}