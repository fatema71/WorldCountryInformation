using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorldsCountryInfoApp.Model;
using WorldsCountryInfoApp.DAL;
using System.Data;

namespace WorldsCountryInfoApp.BLL
{
    public class ManagerCity
    {
        GatewayCity objGatewayCity = new GatewayCity();
        public string Save(City objCity)
        {
            int rowAffected = objGatewayCity.Save(objCity);
            if (rowAffected > 0)
            {
                return "Saved";
            }
            else
            {
                return "failed";
            }
        }
        public DataTable GetElement()
        {
            return objGatewayCity.GetElement();
        }
        public DataTable GetCitySearchElement(string name)
        {
            return objGatewayCity.GetCitySearchElement(name);
        }
        public DataTable GetCountrySearchElement(string name)
        {
            return objGatewayCity.GetCountrySearchElement(name);
        }
        public string IsCityExist(string countryid, string cityName)
        {
            bool status = objGatewayCity.IsCityExist(countryid, cityName);
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