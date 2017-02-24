using System.Collections.Generic;
using System.Data.SqlClient;
using System;

 namespace HairSalon
 {
     public class Stylist
     {
         private int _id;
         private string _name;

         public Stylist(string name, int Id = 0)
        {
             _id = Id;
             _name = name;
         }

         public static void DeleteAll()
         {
             SqlConnection conn = DB.Connection();
             conn.Open();
             SqlCommand cmd = new SqlCommand("DELETE FROM stylists;", conn);
             cmd.ExecuteNonQuery();
             conn.Close();
         }

         public static List<Stylist> GetAll()
         {
             List<Stylist> allStylists = new List<Stylist>{};

             SqlConnection conn = DB.Connection();
             conn.Open();

             SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
             SqlDataReader rdr = cmd.ExecuteReader();

             while(rdr.Read())
             {
                 int stylistId = rdr.GetInt32(0);
                 string stylistName = rdr.GetString(1);
                 Stylist newStylist = new Stylist(stylistName, stylistId);
                 allStylists.Add(newStylist);
             }

             if (rdr != null)
             {
                 rdr.Close();
             }
             if (conn != null)
             {
                 conn.Close();
             }

             return allStylists;
         }
     }
 }
