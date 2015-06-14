using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorldsCountryInfoApp.Model;
using WorldsCountryInfoApp.DAL;
using System.Data;

namespace WorldsCountryInfoApp.BLL
{
    public class ManagerCountry
    {
        GatewayCountry objGatewayCountry = new GatewayCountry();
        public string Save(Country objCountry)
        {
            int rowAffected = objGatewayCountry.Save(objCountry);
            if (rowAffected > 0)
            {
                return "saved";
            }
            else
            {
                return "save failed";
            }
        }
        public List<Country> GetCountryInfo()
        {
            return objGatewayCountry.GetCountryInfo();
        }
        public DataTable GetCountryViewElement(string name)
        { 
          return  objGatewayCountry.GetCountryViewElement( name);
        }
        public string IsCountryExist(string countryName)
        {
            bool status = objGatewayCountry.IsCountryExist(countryName);
            if (status == true)
            {
                return "Alreday Exist";
            }
            else
            {
                return "";
            }
        }
    }
}