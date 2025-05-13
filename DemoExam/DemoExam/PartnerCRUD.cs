using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam
{
    public static class PartnerCRUD
    {
        static string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database2.mdf;Integrated Security=True";

        public static List<PartnerData> PartnersListData()
        {
            List<PartnerData> partnerData = new List<PartnerData>();

            using (SqlConnection con = new SqlConnection(conn))
            {
                string selectData = "SELECT * FROM Partners AS a LEFT JOIN (SELECT PartnerTitle, SUM(Quantity) AS Quantity FROM ProductPartner GROUP BY PartnerTitle) AS b ON a.Title = b.PartnerTitle";
                using (SqlCommand cmd = new SqlCommand(selectData, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PartnerData pd = new PartnerData();
                            pd.Title = reader["Title"].ToString();
                            pd.Type = reader["Type"].ToString();
                            pd.Surname = reader["Surname"].ToString();
                            pd.Name = reader["Name"].ToString();
                            pd.Patronymic = reader["Patronymic"].ToString();
                            pd.Email = reader["Email"].ToString();
                            pd.Phone = reader["Phone"].ToString();
                            pd.Postcode = reader["Postcode"].ToString();
                            pd.Region = reader["Region"].ToString();
                            pd.City = reader["City"].ToString();
                            pd.Street = reader["Street"].ToString();
                            pd.Number = reader["Number"].ToString();
                            pd.TIN = reader["TIN"].ToString();
                            pd.Rating = reader["Rating"].ToString();

                            int quantity;
                            string discount;

                            try
                            {
                                quantity = (int)reader["Quantity"];
                            }
                            catch (Exception ex)
                            {
                                quantity = 0;
                            }
                            
                            if (quantity < 10000) discount = "0%";
                            else if (quantity >= 10000 && quantity < 50000) discount = "5%";
                            else if (quantity >= 50000 && quantity < 300000) discount = "10%";
                            else discount = "15%";

                            pd.Discount = discount;

                            partnerData.Add(pd);
                        }
                    }
                }
            }
            return partnerData;
        }

        public static void AddPartner(PartnerData partner)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                string query = "INSERT INTO Partners VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@1", partner.Title);
                    cmd.Parameters.AddWithValue("@2", partner.Type);
                    cmd.Parameters.AddWithValue("@3", partner.Surname);
                    cmd.Parameters.AddWithValue("@4", partner.Name);
                    cmd.Parameters.AddWithValue("@5", partner.Patronymic);
                    cmd.Parameters.AddWithValue("@6", partner.Email);
                    cmd.Parameters.AddWithValue("@7", partner.Phone);
                    cmd.Parameters.AddWithValue("@8", partner.Postcode);
                    cmd.Parameters.AddWithValue("@9", partner.Region);
                    cmd.Parameters.AddWithValue("@10", partner.City);
                    cmd.Parameters.AddWithValue("@11", partner.Street);
                    cmd.Parameters.AddWithValue("@12", partner.Number);
                    cmd.Parameters.AddWithValue("@13", partner.TIN);
                    cmd.Parameters.AddWithValue("@14", partner.Rating);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdatePartner(PartnerData partner, string title)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                string query = "UPDATE Partners SET Title = @1, Type = @2, Surname = @3, Name = @4, Patronymic = @5, Email = @6, Phone = @7, Postcode = @8, Region = @9, City = @10, Street = @11, Number = @12, TIN = @13, Rating = @14 WHERE Title = @15";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@1", partner.Title);
                    cmd.Parameters.AddWithValue("@2", partner.Type);
                    cmd.Parameters.AddWithValue("@3", partner.Surname);
                    cmd.Parameters.AddWithValue("@4", partner.Name);
                    cmd.Parameters.AddWithValue("@5", partner.Patronymic);
                    cmd.Parameters.AddWithValue("@6", partner.Email);
                    cmd.Parameters.AddWithValue("@7", partner.Phone);
                    cmd.Parameters.AddWithValue("@8", partner.Postcode);
                    cmd.Parameters.AddWithValue("@9", partner.Region);
                    cmd.Parameters.AddWithValue("@10", partner.City);
                    cmd.Parameters.AddWithValue("@11", partner.Street);
                    cmd.Parameters.AddWithValue("@12", partner.Number);
                    cmd.Parameters.AddWithValue("@13", partner.TIN);
                    cmd.Parameters.AddWithValue("@14", partner.Rating);
                    cmd.Parameters.AddWithValue("@15", title);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

