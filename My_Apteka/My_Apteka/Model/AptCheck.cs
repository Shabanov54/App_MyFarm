using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace My_Apteka.Model
{
    internal class AptCheck
    {

        MySqlDataAdapter adapter;
        DataTable DataTable;
        MySqlConnection connection = null;
        string sql = "SELECT * FROM my_apteka_db";
        List<Apt> apts_all = new List<Apt>();

        internal List<Apt> GetAptsCheck()
        {
            MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();
            stringBuilder.UserID = "shabanov";
            stringBuilder.Database = "my_apteka";
            stringBuilder.Password = "ZybrbnfZdfvgbh54";
            stringBuilder.Port = 3306;
            stringBuilder.Server = "10.32.10.171";
            connection = new MySqlConnection(stringBuilder.ToString());

            DataTable = new DataTable();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            adapter = new MySqlDataAdapter(cmd);
            connection.Open();
            adapter.Fill(DataTable);
            try
            {
                foreach (var item in DataTable.AsEnumerable())
                {
                    Apt apt = new Apt();
                    apt.ID = (int)item["ID"];
                    apt.Flag = (int)item["flag"];
                    if (!string.IsNullOrEmpty(item["UR"].ToString()))
                    {
                        apt.UR = (string)item["UR"];

                    }
                    if (!string.IsNullOrEmpty(item["Node"].ToString()))
                    {
                        apt.Node = (int)item["Node"];

                    }
                    if (!string.IsNullOrEmpty(item["INN"].ToString()))
                    {
                        apt.INN = (string)item["INN"];

                    }
                    if (!string.IsNullOrEmpty(item["Address"].ToString()))
                    {
                        apt.Address = (string)item["Address"];
                    }
                    if (!string.IsNullOrEmpty(item["Telephone"].ToString()))
                    {

                        apt.Telephone = (string)item["Telephone"];
                    }
                    if (!string.IsNullOrEmpty(item["Email"].ToString()))
                    {

                        apt.Email = (string)item["Email"];
                    }
                    if (!string.IsNullOrEmpty(item["Pass_Email"].ToString()))
                    {
                        apt.Pass_Email = (string)item["Pass_Email"];

                    }
                    if (!string.IsNullOrEmpty(item["Work_time"].ToString()))
                    {
                        apt.Work_time = (string)item["Work_time"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass_1"].ToString()))
                    {
                        apt.Kass_1 = (string)item["Kass_1"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass1_RN"].ToString()))
                    {
                        apt.Kass1_RN = (string)item["Kass1_RN"];

                    }
                    if (!string.IsNullOrEmpty(item["Kass1_ZN"].ToString()))
                    {
                        apt.Kass1_ZN = (string)item["Kass1_ZN"];

                    }
                    if (!string.IsNullOrEmpty(item["Kass1_FN"].ToString()))
                    {
                        apt.Kass1_FN = (string)item["Kass1_FN"];

                    }
                    if (!string.IsNullOrEmpty(item["Kass_2"].ToString()))
                    {
                        apt.Kass_2 = (string)item["Kass_2"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass2_RN"].ToString()))
                    {
                        apt.Kass2_RN = (string)item["Kass2_RN"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass2_ZN"].ToString()))
                    {
                        apt.Kass2_ZN = (string)item["Kass2_ZN"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass2_FN"].ToString()))
                    {
                        apt.Kass2_FN = (string)item["Kass2_FN"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass_3"].ToString()))
                    {
                        apt.Kass_3 = (string)item["Kass_3"];

                    }
                    if (!string.IsNullOrEmpty(item["Kass3_RN"].ToString()))
                    {
                        apt.Kass3_RN = (string)item["Kass3_RN"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass3_ZN"].ToString()))
                    {
                        apt.Kass3_ZN = (string)item["Kass3_ZN"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass3_FN"].ToString()))
                    {
                        apt.Kass3_FN = (string)item["Kass3_FN"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass_4"].ToString()))
                    {
                        apt.Kass_4 = (string)item["Kass_4"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass4_RN"].ToString()))
                    {
                        apt.Kass4_RN = (string)item["Kass4_RN"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass4_ZN"].ToString()))
                    {
                        apt.Kass4_ZN = (string)item["Kass4_ZN"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass4_FN"].ToString()))
                    {
                        apt.Kass4_FN = (string)item["Kass4_FN"];
                    }
                    if (!string.IsNullOrEmpty(item["VPN"].ToString()))
                    {
                        apt.VPN = (string)item["VPN"];
                    }
                    if (!string.IsNullOrEmpty(item["VPN_CODE"].ToString()))
                    {
                        apt.VPN_CODE = (string)item["VPN_CODE"];
                    }

                    if (!string.IsNullOrEmpty(item["Operator"].ToString()))
                    {
                        apt.Operator = (string)item["Operator"];
                    }
                    if (!string.IsNullOrEmpty(item["Tel_Operator"].ToString()))
                    {
                        apt.Tel_Operator = (string)item["Tel_Operator"];
                    }

                    apts_all.Add(apt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return apts_all;
        }


        internal List<Apt> GetAptsUNCheck()
        {
            MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();
            stringBuilder.UserID = "shabanov";
            stringBuilder.Database = "my_apteka";
            stringBuilder.Password = "ZybrbnfZdfvgbh54";
            stringBuilder.Port = 3306;
            stringBuilder.Server = "10.32.10.171";
            connection = new MySqlConnection(stringBuilder.ToString());


            DataTable = new DataTable();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            adapter = new MySqlDataAdapter(cmd);
            connection.Open();
            adapter.Fill(DataTable);

            try
            {
                foreach (var item in DataTable.AsEnumerable())
                {
                    Apt apt = new Apt();
                    apt.ID = (int)item["ID"];

                    apt.Flag = (int)item["flag"];
                    if (!string.IsNullOrEmpty(item["UR"].ToString()))
                    {
                        apt.UR = (string)item["UR"];

                    }
                    if (!string.IsNullOrEmpty(item["Node"].ToString()))
                    {
                        apt.Node = (int)item["Node"];

                    }
                    if (!string.IsNullOrEmpty(item["INN"].ToString()))
                    {
                        apt.INN = (string)item["INN"];

                    }
                    if (!string.IsNullOrEmpty(item["Address"].ToString()))
                    {
                        apt.Address = (string)item["Address"];
                    }
                    if (!string.IsNullOrEmpty(item["Telephone"].ToString()))
                    {

                        apt.Telephone = (string)item["Telephone"];
                    }
                    if (!string.IsNullOrEmpty(item["Email"].ToString()))
                    {

                        apt.Email = (string)item["Email"];
                    }
                    if (!string.IsNullOrEmpty(item["Pass_Email"].ToString()))
                    {
                        apt.Pass_Email = (string)item["Pass_Email"];

                    }
                    if (!string.IsNullOrEmpty(item["Work_time"].ToString()))
                    {
                        apt.Work_time = (string)item["Work_time"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass_1"].ToString()))
                    {
                        apt.Kass_1 = (string)item["Kass_1"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass1_RN"].ToString()))
                    {
                        apt.Kass1_RN = (string)item["Kass1_RN"];

                    }
                    if (!string.IsNullOrEmpty(item["Kass1_ZN"].ToString()))
                    {
                        apt.Kass1_ZN = (string)item["Kass1_ZN"];

                    }
                    if (!string.IsNullOrEmpty(item["Kass1_FN"].ToString()))
                    {
                        apt.Kass1_FN = (string)item["Kass1_FN"];

                    }
                    if (!string.IsNullOrEmpty(item["Kass_2"].ToString()))
                    {
                        apt.Kass_2 = (string)item["Kass_2"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass2_RN"].ToString()))
                    {
                        apt.Kass2_RN = (string)item["Kass2_RN"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass2_ZN"].ToString()))
                    {
                        apt.Kass2_ZN = (string)item["Kass2_ZN"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass2_FN"].ToString()))
                    {
                        apt.Kass2_FN = (string)item["Kass2_FN"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass_3"].ToString()))
                    {
                        apt.Kass_3 = (string)item["Kass_3"];

                    }
                    if (!string.IsNullOrEmpty(item["Kass3_RN"].ToString()))
                    {
                        apt.Kass3_RN = (string)item["Kass3_RN"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass3_ZN"].ToString()))
                    {
                        apt.Kass3_ZN = (string)item["Kass3_ZN"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass3_FN"].ToString()))
                    {
                        apt.Kass3_FN = (string)item["Kass3_FN"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass_4"].ToString()))
                    {
                        apt.Kass_4 = (string)item["Kass_4"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass4_RN"].ToString()))
                    {
                        apt.Kass4_RN = (string)item["Kass4_RN"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass4_ZN"].ToString()))
                    {
                        apt.Kass4_ZN = (string)item["Kass4_ZN"];
                    }
                    if (!string.IsNullOrEmpty(item["Kass4_FN"].ToString()))
                    {
                        apt.Kass4_FN = (string)item["Kass4_FN"];
                    }
                    if (!string.IsNullOrEmpty(item["VPN"].ToString()))
                    {
                        apt.VPN = (string)item["VPN"];
                    }
                    if (!string.IsNullOrEmpty(item["VPN_CODE"].ToString()))
                    {
                        apt.VPN_CODE = (string)item["VPN_CODE"];
                    }

                    if (!string.IsNullOrEmpty(item["Operator"].ToString()))
                    {
                        apt.Operator = (string)item["Operator"];
                    }
                    if (!string.IsNullOrEmpty(item["Tel_Operator"].ToString()))
                    {
                        apt.Tel_Operator = (string)item["Tel_Operator"];
                    }
                    if (apt.Flag == 0)
                    {
                        continue;
                    }

                    apts_all.Add(apt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return apts_all;
        }

    }
}
