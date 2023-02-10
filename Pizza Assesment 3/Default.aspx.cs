using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pizza_Assesment_3
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            double total;
            total = 0;

            if (SPRB.Checked)
            {
                total = 8;
                PLable.Text = string.Format("Small Pepperoni pizza");
            }

            else if (MPRB.Checked)
            {
                total = 10;
                PLable.Text = string.Format("Medium Pepperoni pizza");
            }
            else if (LPRB.Checked)
            {
                total = 12;
                PLable.Text = string.Format("Large Pepperoni pizza");
            }

            if (SMRB.Checked)
            {
                MLable.Text = string.Format("Small Margarita pizza");
            }
            else if (MMRB.Checked)
            {
                MLable.Text = string.Format("Medium Margarita pizza");
            }

            else if (LMRB.Checked)
            {
                MLable.Text = string.Format("Large Margarita pizza");
            }

            total = (SMRB.Checked) ? total + 8 : total;
            total = (MMRB.Checked) ? total + 10 : total;
            total = (LMRB.Checked) ? total + 12 : total;

            priceBox.Text = total.ToString();
        }


        protected void OrderButton_Click(object sender, EventArgs e)
        {
            /* PizzaDatabaseEntities1
                public virtual DbSet<Customer> Customers { get; set; }
                public virtual DbSet<Login> Logins { get; set; }
                public virtual DbSet<Order> Orders { get; set; }

                [Pepperoni] VARCHAR (50) NULL,
                [Margarita] VARCHAR (50) NULL,

                public virtual DbSet<Price> Prices { get; set; }
                public virtual DbSet<Table> Tables { get; set; }
             */


        }



        protected void priceBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void SMRB_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void LMRB_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void grdPrice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click1(object sender, EventArgs e)
        {
            PizzaDatabase1Entities db = new PizzaDatabase1Entities();
            var Price = db.Prices;
            var newPrice = new Price();
            String x = priceBox.Text.ToString();
            newPrice.Price1 = x;
            db.Prices.Add(newPrice);
            db.SaveChanges();
            grdPrice.DataBind();






        }

        protected void OrderButton_Click1(object sender, EventArgs e)
        {

            PizzaDatabase1Entities db = new PizzaDatabase1Entities();
            var order = new Order();
            order.Pepperoni = PLable.Text.ToString();
            order.Margarita = MLable.Text.ToString();

            db.Orders.Add(order);
            db.SaveChanges();
            grdOrder.DataBind();

            Response.Redirect("Order.aspx");



            foreach (var Price in db.Prices) ;


        }
    }
}