using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebApplication6.Models
{
    //کلاس های دارای جدول ها و فیلد های پایگاه داده

    #region Classes

    public class tbl_admins // جدول اطلاعات کاربران ادمین و زیر مجموعه
    {

        [Key]
        public int U_ID { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public byte access_level { get; set; }
    }

    public class tbl_users // جدول اطلاعات کاربران معمولی
    {

        [Key]
        public int U_ID { get; set; }
        public string name { get; set; }
        public string phonenumber { get; set; }
        public DateTime membership_date { get; set; }
        public string nationalcode { get; set; }
    }

    public class tbl_basket_active // جدول سبد آگهی فعال
    {
        [Key]
        public int ID { get; set; }
        public int source_ID { get; set; }
        public int destinition_ID { get; set; }
        public int product_ID { get; set; }
        public byte visited { get; set; }
        public DateTime registiration_date { get; set; }
        public string description { get; set; }


    }

    public class tbl_basket_deactive // جدول سبد آگهی غیر فعال
    {
        [Key]
        public int ID { get; set; }
        public int destinition_ID { get; set; }
        public int product_ID { get; set; }
        public DateTime registiration_date { get; set; }
        public string description { get; set; }
        public string deleted_reason { get; set; }


    }

    public class tbl_brands // جدول اطلاعات برند
    {
        [Key]
        public int brand_ID { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public string series { get; set; }
        public string logo_url { get; set; }


    }

    public class tbl_pricerange // جدول رنج قیمتی
    {
        [Key]
        public int pricerange_ID { get; set; }
        public int brand_ID { get; set; }
        public string minimum_price { get; set; }
        public string maximum_price { get; set; }


    }

    public class tbl_product // جدول محصولات
    {
        [Key]
        public int P_ID { get; set; } // آیدی آگهی
        public int registrant_UID { get; set; } // آیدی ثبت کننده آگهی
        public int brand_ID { get; set; } // آیدی اطلاعات برند
        public int pricerange_ID { get; set; } // آیدی رنج قیمتی
        public string title { get; set; } // تیتر
        public string description { get; set; } // توضیحات
        public string costumer_price { get; set; } // قیمت داده شده توسط مشتری
        public DateTime year { get; set; } // سال ساخت
        public string odometer { get; set; } //کارکرد 
        public byte approval_status { get; set; } // وضعیت تائید
        public string technician_price { get; set; } // قیمت کارشناسی
        public DateTime registration_date { get; set; } // تاریخ ثبت آگهی
        public string pictures_list { get; set; } // لیست عکس های محصول
        
    }

    public class tbl_product_deleted // جدول محصولات حذف شده
    {
        [Key]
        public int U_ID { get; set; }
        public string product_info { get; set; }
        public string desciption { get; set; }
        public DateTime deleted_date { get; set; }


    }

    public class tbl_product_sold // جدول محصولات فروخته شده
    {
        [Key]
        public int ID { get; set; }
        public int registrant_UID { get; set; }
        public int buyer_UID { get; set; }
        public int seller_UID { get; set; }
        public string product_info { get; set; }
        public string sold_price { get; set; }
        public DateTime sold_date { get; set; }



    }

    public class tbl_scheduling // جدول تقویم و زمانبندی
    {
        [Key]
        public int scheduling_ID { get; set; }
        public int product_ID { get; set; }
        public DateTime date { get; set; }
        public DateTime time { get; set; }
        public int ticket_ID  { get; set; }



    }

    public class tbl_ticket // جدول تیکت
    {
        [Key]
        public int ticket_ID { get; set; }
        public int sender_ID { get; set; }
        public string text { get; set; }
        public DateTime date { get; set; }
        public byte visited { get; set; }
        public int product_ID { get; set; }
        public DateTime visited_date { get; set; }
        
    }

    #endregion

}