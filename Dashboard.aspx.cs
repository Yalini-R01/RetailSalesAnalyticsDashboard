using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Xml.Linq;

public partial class Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDashboard("All");
        }
    }

    private void LoadDashboard(string filter)
    {
        string filePath = Server.MapPath("~/SalesData.xml");

        if (!File.Exists(filePath))
        {
            lblRevenue.Text = "No sales data available";
            return;
        }

        XDocument doc = XDocument.Load(filePath);

        var sales = doc.Root.Elements("Sale")
            .Select(x => new
            {
                Product = (string)x.Element("Product"),
                Category = (string)x.Element("Category"),
                Date = Convert.ToDateTime(x.Element("Date").Value),
                Total = Convert.ToDecimal(x.Element("Total").Value)
            })
            .ToList();

        // FILTER
        if (filter == "Today")
        {
            sales = sales.Where(x => x.Date.Date == DateTime.Today).ToList();
        }
        else if (filter == "Month")
        {
            sales = sales.Where(x =>
                x.Date.Month == DateTime.Now.Month &&
                x.Date.Year == DateTime.Now.Year
            ).ToList();
        }

        gvDashboard.DataSource = sales;
        gvDashboard.DataBind();

        lblRevenue.Text = "Total Revenue: ₹" + sales.Sum(x => x.Total);

        var best = sales.OrderByDescending(x => x.Total).FirstOrDefault();
        if (best != null)
        {
            lblBest.Text = "Best Product: " + best.Product + " (₹" + best.Total + ")";
        }

        Chart1.Series["Sales"].Points.Clear();
        foreach (var item in sales)
        {
            Chart1.Series["Sales"].Points.AddXY(item.Product, item.Total);
        }

        Chart2.Series["CategorySales"].Points.Clear();

        var categoryData = sales
            .GroupBy(x => x.Category)
            .Select(g => new
            {
                Category = g.Key,
                Total = g.Sum(x => x.Total)
            });

        foreach (var item in categoryData)
        {
            Chart2.Series["CategorySales"].Points.AddXY(item.Category, item.Total);
        }
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        LoadDashboard(ddlFilter.SelectedValue);
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=SalesReport.xls");
        Response.ContentType = "application/vnd.ms-excel";

        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);

        gvDashboard.RenderControl(hw);

        Response.Output.Write(sw.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {
    }
}