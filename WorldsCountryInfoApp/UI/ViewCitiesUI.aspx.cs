using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorldsCountryInfoApp.BLL;
using WorldsCountryInfoApp.Model;
using System.Data;

namespace WorldsCountryInfoApp.UI
{
    public partial class ViewCitiesUI : System.Web.UI.Page
    {
        City objCity = new City();
        ManagerCity objManagerCity = new ManagerCity();
        ManagerCountry objManagerCountry = new ManagerCountry();
        List<string> CountryProperty = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                countryDropDownList.DataSource = objManagerCountry.GetCountryInfo();
                countryDropDownList.DataValueField = "ID";
                countryDropDownList.DataTextField = "Name";

                countryDropDownList.DataBind();

                DataTable dt = objManagerCity.GetElement();
                LoadGridData(dt);
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (citySelectRadioButton.Checked == true)
            {
                DataTable dt = objManagerCity.GetCitySearchElement(cityNameTextBox.Text);
                LoadGridData(dt);

            }
            else
            {
                string name = countryDropDownList.SelectedItem.Text;
                DataTable dt = objManagerCity.GetCountrySearchElement(name);
                LoadGridData(dt);
            }
        }
        private void LoadGridData(DataTable dt)
        { 
            //foreach (City objCity in objCityList)
            //{
            //    CountryProperty.Add(objCity.Country.Name);
            //    CountryProperty.Add(objCity.Country.About);
            //}

            detailShowGridView.DataSource = dt;
            detailShowGridView.DataBind();
            CountryProperty.Clear();
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

        protected void citySelectRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (citySelectRadioButton.Checked == true)
            {
                countrySelectRadioButton.Checked = false;
            }
           
        }

        protected void countrySelectRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (countrySelectRadioButton.Checked == true)
            {
                citySelectRadioButton.Checked =false;
            }
           
        }

        protected void detailShowGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = objManagerCity.GetElement();
            LoadGridData(dt);

            detailShowGridView.PageIndex = e.NewPageIndex;
            detailShowGridView.DataBind();
        }

    }
}