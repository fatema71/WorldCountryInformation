using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorldsCountryInfoApp.DAL;
using WorldsCountryInfoApp.BLL;
using System.Data;

namespace WorldsCountryInfoApp.UI
{
    public partial class ViewCountryUI : System.Web.UI.Page
    {
        ManagerCountry objGatewayCountry = new ManagerCountry(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable data = objGatewayCountry.GetCountryViewElement("");

            detailShowGridView.DataSource = data;
            detailShowGridView.DataBind();
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string name = countryNameTextBox.Text;
            DataTable data = objGatewayCountry.GetCountryViewElement(name);  

            detailShowGridView.DataSource = data;
            detailShowGridView.DataBind();
        }

        protected void detailShowGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int i = 0;
            foreach (GridViewRow row in detailShowGridView.Rows)
            {
                row.Cells[0].Text = (i + 1).ToString();
                i++;
            }
        }

        protected void detailShowGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string name = countryNameTextBox.Text;
            DataTable data = objGatewayCountry.GetCountryViewElement(name); 
            detailShowGridView.DataSource = data;
            detailShowGridView.DataBind();

            detailShowGridView.PageIndex = e.NewPageIndex;
            detailShowGridView.DataBind();
        }
    }
}