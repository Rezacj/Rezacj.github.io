using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; // i am use [entity framework] to trade informations betwen program and DataBase

namespace WebApplication6.Models
{
    public class db : DbContext
    {
        // در این بخش تمامی کلاس ها از طریق زیر به پایگاه داده اصلی متصل میشوند

        #region Section1 => SQL Connection Location confirmer
        public db() : base("name=jjEntities") { } // connection located in web.config and name is jjEntities

        #endregion

        #region Section2 => Classes
        public DbSet<tbl_admins> tb_admins { get; set; }
        public DbSet<tbl_users> tb_users { get; set; }
        public DbSet<tbl_basket_active> tb_basket_active { get; set; }

        public DbSet<tbl_basket_deactive> tb_basket_deactive { get; set; }
        public DbSet<tbl_brands> tb_brands { get; set; }
        public DbSet<tbl_pricerange> tb_pricerange { get; set; }
        public DbSet<tbl_product> tb_product { get; set; }
        public DbSet<tbl_product_deleted> tb_product_deleted { get; set; }
        public DbSet<tbl_product_sold> tb_product_sold { get; set; }
        public DbSet<tbl_scheduling> tb_scheduling { get; set; }
        public DbSet<tbl_ticket> tb_ticket { get; set; }

        #endregion
        
    }
}