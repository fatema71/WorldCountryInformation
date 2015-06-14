using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorldsCountryInfoApp.Model;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WorldsCountryInfoApp.DAL
{
    public class GatewayCity
    {
        string connectionString = ConfigurationManager.ConnectionStrings["countryDB"].ConnectionString;
        public int Save(City objCity)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "insert into tbl_City values('" +objCity.Name+ "','" + objCity.About+ "','"+objCity.Population+"','"+objCity.Location+"','"+objCity.Weather+"','"+objCity.Country.ID+"')";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public DataTable GetElement()
        {
            //List<City> city = new List<City>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT a.ID,a.City_name,a.About_city,a.No_of_dwellers,a.Location,a.Whather,b.Country_name,b.About_country
                            FROM tbl_City a,tbl_Country b where b.ID=a.Country_id";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt=new DataTable();
            da.Fill(dt);
            /*SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                City aCity = new City();
                Country objCountry = new Country();              
                aCity.ID = (int)reader["ID"];
                aCity.Name = reader["City_name"].ToString();
                aCity.About = reader["About_city"].ToString();
                aCity.Population =Convert.ToInt16(reader["No_of_dwellers"]);
                aCity.Location = reader["Location"].ToString();
                aCity.Weather = reader["Whather"].ToString();
                objCountry.Name = reader["Country_name"].ToString();
                objCountry.About = reader["About_country"].ToString();
                aCity.Country = objCountry;
                city.Add(aCity);  
            }
            reader.Close();*/
            connection.Close(); 
            return dt;
        }
        public DataTable GetCitySearchElement(string name)
        {
            //List<City> city = new List<City>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT a.ID,a.City_name,a.About_city,a.No_of_dwellers,a.Location,a.Whather,b.Country_name,b.About_country
                            FROM tbl_City a,tbl_Country b where b.ID=a.Country_id and a.City_name like '" + name+"%'";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            /*SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                City aCity = new City();
                Country objCountry = new Country();
                aCity.ID = (int)reader["ID"];
                aCity.Name = reader["City_name"].ToString();
                aCity.About = reader["About_city"].ToString();
                aCity.Population = Convert.ToInt16(reader["No_of_dwellers"]);
                aCity.Location = reader["Location"].ToString();
                aCity.Weather = reader["Whather"].ToString();
                objCountry.Name = reader["Country_name"].ToString();
                objCountry.About = reader["About_country"].ToString();
                aCity.Country = objCountry;
                city.Add(aCity);
            }
            reader.Close();*/
            connection.Close();
            return dt;
        }
        public DataTable GetCountrySearchElement(string name)
        {
           //List<City> city = new List<City>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT a.ID,a.City_name,a.About_city,a.No_of_dwellers,a.Location,a.Whather,b.Country_name,b.About_country
                            FROM tbl_City a,tbl_Country b where b.ID=a.Country_id and b.Country_name = '" + name + "'";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            /*SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                City aCity = new City();
                Country objCountry = new Country();
                aCity.ID = (int)reader["ID"];
                aCity.Name = reader["City_name"].ToString();
                aCity.About = reader["About_city"].ToString();
                aCity.Population = Convert.ToInt16(reader["No_of_dwellers"]);
                aCity.Location = reader["Location"].ToString();
                aCity.Weather = reader["Whather"].ToString();
                objCountry.Name = reader["Country_name"].ToString();
                objCountry.About = reader["About_country"].ToString();
                aCity.Country = objCountry;
                city.Add(aCity);
            }
            reader.Close();*/
            connection.Close();
            return dt;
        }
        public bool IsCityExist(string countryid, string cityName)
        {
            bool status = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from tbl_City where City_name='" + cityName + "' and Country_id=" + countryid + "";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            status = reader.Read();
            connection.Close();
            return status;
        }
    }
}