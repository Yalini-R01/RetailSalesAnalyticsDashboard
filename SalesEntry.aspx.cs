using System;
using System.Linq;
using System.Xml.Linq;

namespace RetailSalesAnalyticsDashboard
{
    public partial class SalesEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSales();
            }
        }

        protected void btnAddSale_Click(object sender, EventArgs e)
        {
            decimal qty = Convert.ToDecimal(txtQty.Text);
            decimal price = Convert.ToDecimal(txtPrice.Text);
            decimal discount = Convert.ToDecimal(txtDiscount.Text);

            decimal total = qty * price;
            decimal discountAmount = total * discount / 100;
            decimal finalTotal = total - discountAmount;

            string filePath = Server.MapPath("~/SalesData.xml");

            XDocument doc;

            if (System.IO.File.Exists(filePath))
            {
                doc = XDocument.Load(filePath);
            }
            else
            {
                doc = new XDocument(new XElement("Sales"));
            }

            doc.Root.Add(
                new XElement("Sale",
                    new XElement("Product", txtProduct.Text),
                    new XElement("Category", ddlCategory.SelectedValue),
                    new XElement("Unit", ddlUnit.SelectedValue),
                    new XElement("Quantity", qty),
                    new XElement("Price", price),
                    new XElement("Discount", discount),
                    new XElement("Payment", rblPayment.SelectedValue),
                    new XElement("Date",
                        calDate.SelectedDate == DateTime.MinValue
                        ? DateTime.Today.ToShortDateString()
                        : calDate.SelectedDate.ToShortDateString()
                    ),
                    new XElement("Total", finalTotal)
                )
            );

            doc.Save(filePath);

            LoadSales();
            ClearForm();

            // ✅ Redirect to Dashboard
            Response.Redirect("Dashboard.aspx");
        }

        private void LoadSales()
        {
            string filePath = Server.MapPath("~/SalesData.xml");

            if (!System.IO.File.Exists(filePath)) return;

            XDocument doc = XDocument.Load(filePath);

            var sales = doc.Root.Elements("Sale")
                .Select(x => new
                {
                    Product = (string)x.Element("Product"),
                    Category = (string)x.Element("Category"),
                    Unit = (string)x.Element("Unit"),
                    Quantity = (string)x.Element("Quantity"),
                    Price = (string)x.Element("Price"),
                    Discount = (string)x.Element("Discount"),
                    Total = (string)x.Element("Total")
                }).ToList();

            gvSales.DataSource = sales;
            gvSales.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtProduct.Text = "";
            txtQty.Text = "";
            txtPrice.Text = "";
            txtDiscount.Text = "0";
            ddlCategory.SelectedIndex = 0;
            ddlUnit.SelectedIndex = 0;
            rblPayment.ClearSelection();
            calDate.SelectedDate = DateTime.Today;
        }
    }
}