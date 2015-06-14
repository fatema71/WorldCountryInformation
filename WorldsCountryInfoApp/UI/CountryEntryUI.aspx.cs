using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorldsCountryInfoApp.Model;
using WorldsCountryInfoApp.BLL;

namespace WorldsCountryInfoApp
{
    public partial class CountryEntryUI : System.Web.UI.Page
    {
        Country objCountry = new Country();
        ManagerCountry objManagerCountry = new ManagerCountry();
        protected void Page_Load(object sender, EventArgs e)
        {
            CountryShowGridView.DataSource = objManagerCountry.GetCountryInfo();

            CountryShowGridView.DataBind();

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (IsInputOK())
            {
                string Result = objManagerCountry.IsCountryExist(countryNameTextBox.Text);
                if (Result == "")
                {
                    objCountry.Name = countryNameTextBox.Text;
                    objCountry.About = aboutTextBox.Text;
                    string result = objManagerCountry.Save(objCountry);
                    statusLabel.Text = result;
                    CountryShowGridView.DataSource = objManagerCountry.GetCountryInfo();

                    CountryShowGridView.DataBind();
                }
                else
                {
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
            if (countryNameTextBox.Text == "" || aboutTextBox.Text == "")
            {
                return false;
            }
            else
                return true;
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            countryNameTextBox.Text = "";
            aboutTextBox.Text = "";
        }

        protected void CountryShowGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int i = 0;
            foreach (GridViewRow row in CountryShowGridView.Rows)
            {
                row.Cells[0].Text = (i + 1).ToString();
                i++;
            }

        }
    }
}