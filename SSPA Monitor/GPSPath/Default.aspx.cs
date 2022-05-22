using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Latitude"));
            dt.Columns.Add(new DataColumn("Longitude"));

            DataRow row = dt.NewRow();
            row["Latitude"] = 33.779005;
            row["Longitude"] = -118.178985;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Latitude"] = 33.879005;
            row["Longitude"] = -118.098985;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Latitude"] = 33.979005;
            row["Longitude"] = -118.218985;
            dt.Rows.Add(row);

            js.Text = GPSLib.PlotGPSPoints(dt); ;
        }
    }
}