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


        public int GetId()
        {
            return _id;
        }
        public string GetName()
        {
            return _name;
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

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherStylist;
                bool idEquality = this.GetId() == newStylist.GetId();
                bool nameEquality = this.GetName() == newStylist.GetName();
                return (idEquality && nameEquality);
            }
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO stylists (name) OUTPUT INSERTED.id VALUES (@StylistName);", conn);

            SqlParameter nameParameter = new SqlParameter("@StylistName", this.GetName());
            // nameParameter.ParameterName = "@StylistName";
            // nameParameter.Value = this.GetName();
            cmd.Parameters.Add(nameParameter);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if(conn != null)
            {
                conn.Close();
            }
        }

        public static Stylist Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM stylists WHERE id = @StylistId;", conn);
            SqlParameter stylistIdParameter = new SqlParameter();
            stylistIdParameter.ParameterName = "@StylistId";
            stylistIdParameter.Value = id.ToString();
            cmd.Parameters.Add(stylistIdParameter);
            SqlDataReader rdr = cmd.ExecuteReader();

            int foundStylistId = 0;
            string foundStylistName = null;

            while(rdr.Read())
            {
                foundStylistId = rdr.GetInt32(0);
                foundStylistName = rdr.GetString(1);
            }
            Stylist foundStylist = new Stylist(foundStylistName, foundStylistId);

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return foundStylist;
        }
    }
}
