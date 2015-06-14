using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WorldsCountryInfoApp.Model;
using System.Data.SqlClient;
using System.Data;

namespace WorldsCountryInfoApp.DAL
{
    public class GatewayCountry
    {
        string connectionString = ConfigurationManager.ConnectionStrings["countryDB"].ConnectionString;
        public int Save(Country objCountry)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "insert into tbl_Country values('"+objCountry.Name+"','"+objCountry.About+"')";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public List<Country> GetCountryInfo()
        {
            List<Country> country = new List<Country>();
            
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from tbl_Country";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Country aCountry = new Country();
                aCountry.ID = (int)reader["ID"];
                aCountry.Name = reader["Country_name"].ToString();
                aCountry.About = reader["About_country"].ToString();
                country.Add(aCountry);
            }
            reader.Close();
            connection.Close();
            return country;
        }
        public DataTable GetCountryViewElement(string name)
      {
          
          SqlConnection connection = new SqlConnection(connectionString);
          string query = @"select distinct (c.ID)Sl,c.Country_name,c.About_country,
                            (select SUM(No_of_dwellers)from [WorldsCountryDB].[dbo].[tbl_City] d where d.Country_id=c.ID group by d.Country_id)No_of_dwellers,
                            (select  COUNT(City_name)from [WorldsCountryDB].[dbo].[tbl_City] e  where e.Country_id=c.ID group by e.Country_id) TotalCity 
                             from
                            (select  distinct a.ID,a.Country_name,a.About_country,b.No_of_dwellers,b.City_name 
                             from [WorldsCountryDB].[dbo].[tbl_Country] a
                             ,[WorldsCountryDB].[dbo].[tbl_City] b 
                             where a.ID=b.Country_id and a.Country_name like '" + name + "%') c;";
          connection.Open();
          SqlCommand command = new SqlCommand(query, connection);
          SqlDataAdapter adapter = new SqlDataAdapter(command);
          DataTable data=new DataTable();
          adapter.Fill(data);
          connection.Close();
          return data;

      }
        public bool IsCountryExist( string countryName)
        {
            bool status = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from tbl_Country where Country_name='" + countryName + "'";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            status = reader.Read();
            connection.Close();
            return status;
        }
    }
}