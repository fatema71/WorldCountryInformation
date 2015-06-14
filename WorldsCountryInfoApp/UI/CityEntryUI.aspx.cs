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
    public partial class CityEntryUI : System.Web.UI.Page
    {
        ManagerCountry objManagerCountry = new ManagerCountry();
        City objCity = new City();
        Country aCountry = new Country();
        ManagerCity objManagerCity = new ManagerCity();

        List<string> countryName = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList.DataSource = objManagerCountry.GetCountryInfo();
                DropDownList.DataValueField = "ID";
                DropDownList.DataTextField = "Name";

                DropDownList.DataBind();
                
            }
            LoadGridData();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (IsInputOK())
            {
                string Result = objManagerCity.IsCityExist(DropDownList.SelectedItem.Value, nameTextBox.Text);
                if (Result == "")
                {
                    aCountry.ID = Convert.ToInt16(DropDownList.SelectedItem.Value);
                    objCity.Name = nameTextBox.Text;
                    objCity.About = aboutTextBox.Text;
                    objCity.Population = Convert.ToDouble(populationTextBox.Text);
                    objCity.Location = locationTextBox.Text;
                    objCity.Weather = weatherTextBox.Text;
                    objCity.Country = aCountry;
                    string ststus = objManagerCity.Save(objCity);
                    statusLabel.Text = ststus;

                    LoadGridData();
                }
                else {
                    statusLabel.Text = "<span style='color:red'>" + Result + "</span>";
                }
            }
            else
            {
                statusLabel.Text = "<span style='color:red'>Please fill all the input</span>"; 
            }
        }
        private bool IsInputOK()
        {
            if (nameTextBox.Text == "" || aboutTextBox.Text == "" || populationTextBox.Text == "" || locationTextBox.Text == "" || weatherTextBox.Text == "")
            {
                return false;
            }
            else
                return true;
        }
        protected void cancelButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "";
            aboutTextBox.Text = "";
            populationTextBox.Text = "";
            locationTextBox.Text = "";
            weatherTextBox.Text = "";
            DropDownList.ClearSelection();
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int i = 0; 
            foreach (GridViewRow row in GridView.Rows)
            { 
                row.Cells[0].Text = (i+1).ToString();
                i++;
            }
        }
        private void LoadGridData()
        {
            DataTable dt = objManagerCity.GetElement();

            GridView.DataSource = dt;
            GridView.DataBind();
            countryName.Clear();
        }
    }
}