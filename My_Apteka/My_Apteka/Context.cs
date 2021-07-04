using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using My_Apteka.Model;

namespace My_Apteka
{

    internal class Context
    {
        private Logger logger;
        MySqlDataAdapter adapter;
        DataTable DataTable;
        MySqlConnection connection = null;
        List<Apt> apts_all = new List<Apt>();
        internal void WriteLog(string log, string fullFileLog)
        {
            using (StreamWriter stream = new StreamWriter(fullFileLog , true))
            {
                stream.WriteLine(log);
            }
        }

        internal MySqlConnection GetServer()
        {
            MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();
            stringBuilder.UserID = "shabanov";
            stringBuilder.Database = "my_apteka";
            stringBuilder.Password = "ZybrbnfZdfvgbh54";
            stringBuilder.Port = 3306;
            stringBuilder.Server = "10.32.10.171";
            connection = new MySqlConnection(stringBuilder.ToString());
            return connection;
        }

        internal string GetFileLog(string folderLog, string filelog)
        {

            if (!Directory.Exists(folderLog))
            {
                Directory.CreateDirectory(folderLog);
            }
            var fullFileName = Path.Combine(folderLog, filelog);
            if (!File.Exists(fullFileName))
            {
                File.Create(fullFileName).Dispose();
            }
            return fullFileName;
        }


        internal void Add_to_db( string inn, int node, string ur, string adres, string tel, string email, string paas, string work_time, string kass1, string kass1fn, string kass1rn, string kass1zn, string kass2, string kass2fn, string kass2rn, string kass2zn, string kass3, string kass3fn, string kass3rn, string kass3zn, string kass4, string kass4fn, string kass4rn, string kass4zn, string vpn, string vpn_code, string oper, string tel_op, string login_log)
        {
            try
            {
                var connection = GetServer();
                connection.Open();
                string sql_id = "SELECT ID FROM my_apteka_db";
                int id =0;
                    DataTable = new DataTable();
                MySqlCommand cmd_id = new MySqlCommand(sql_id, connection);
                adapter = new MySqlDataAdapter(cmd_id);
                adapter.Fill(DataTable);
                foreach (var item in DataTable.AsEnumerable())
                {
                    Apt apt = new Apt();
                    apt.ID = (int)item["ID"];
                    id++;
                }
                id++;
                string sql_change = "INSERT my_apteka_db SET flag ='1' , ID='" + id + "' , UR='" + ur + "' , NODE='" + node + "' , INN='" + inn + "' , Address='" + adres + "' , Telephone='" + tel + "' , Email='" + email + "' , Pass_Email='" + paas + "' , Work_time='" + work_time + "' ," +
                    " Kass_1='" + kass1 + "' , Kass1_RN='" + kass1rn + "' , Kass1_ZN='" + kass1zn + "' , Kass1_FN='" + kass1fn + "' , " +
                      "Kass_2='" + kass2 + "' , Kass2_RN='" + kass2rn + "' , Kass2_ZN='" + kass2zn + "' , Kass2_FN='" + kass2fn + "' ," +
                        "Kass_3='" + kass3 + "' , Kass3_RN='" + kass3rn + "' , Kass3_ZN='" + kass3zn + "' , Kass3_FN='" + kass3fn + "' , " +
                        "Kass_4='" + kass4 + "' , Kass4_RN='" + kass4rn + "' , Kass4_ZN='" + kass4zn + "' , Kass4_FN='" + kass4fn + "' , " +
                    "VPN='" + vpn + "' , VPN_CODE='" + vpn_code + "' , Operator='" + oper + "' , Tel_Operator='" + tel_op + "';";

                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql_change;
                    cmd.Parameters.Add(new MySqlParameter(id.ToString(), MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(node.ToString(), MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(inn, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(ur, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(adres, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(tel, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(email, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(paas, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(work_time, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(kass1, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(kass1rn, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(kass1fn, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(kass1zn, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(kass2, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(kass2fn, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(kass2rn, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(kass2zn, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(kass3, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(kass3fn, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(kass3rn, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(kass3zn, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(kass4, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(kass4fn, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(kass4rn, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(kass4zn, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(kass4zn, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(vpn, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(vpn_code, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(oper, MySqlDbType.Text));
                    cmd.Parameters.Add(new MySqlParameter(tel_op, MySqlDbType.Text));
                    cmd.ExecuteNonQuery();
                    logger = new Logger();
                    logger.Log($"Добавлена аптека Пользователем :{login_log} ID: {id} \nУзел: {node} \nЮЛ: {ur} \nИНН: {inn} \nАдрес: {adres}");

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

        }

        internal void Dell_Row(Apt select_row, string loginName)
        {
            var connection = GetServer();
            string sql = "UPDATE my_apteka_db SET flag ='0' Where ID=" + select_row.ID + ";";
            connection.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                logger = new Logger();
                logger.Log($"Была помечена на удаление аптека Пользователем: {loginName} \nID: {select_row.ID}  \nУзел: {select_row.Node} \nЮЛ: {select_row.UR} \nАптека: {select_row.Address}");
            }

        }

        internal void OutPut(Apt i, TextBox textBox_view)
        {
            string y = i.Address;
            string out_put = $"{y}";
            textBox_view.Text = out_put;
        }

        internal void OutPut_textBox(Apt select_row, TextBox textBox_View_APT)
        {
            string output = $"Узел: {select_row.Node}\nЮр. Лицо: {select_row.UR}\nИНН: {select_row.INN}\nТелефон аптеки: {select_row.Telephone}\nEmail: {select_row.Email}\tПароль от Email: {select_row.Pass_Email}\nВремя Работы: {select_row.Work_time}"
                + $"\nКасса 1: {select_row.Kass_1} \t РН: {select_row.Kass1_RN} \t ЗН: {select_row.Kass1_ZN} \t ФН:{select_row.Kass1_FN}\nКасса 2: {select_row.Kass_2} \t РН: {select_row.Kass2_RN} \t ЗН: {select_row.Kass2_ZN} \t ФН:{select_row.Kass3_FN}"
                + $"\nКасса 3: {select_row.Kass_3} \t РН: {select_row.Kass3_RN} \t ЗН: {select_row.Kass3_ZN} \t ФН:{select_row.Kass3_FN}\nКасса 4: {select_row.Kass_4} \t РН: {select_row.Kass3_RN} \t ЗН: {select_row.Kass4_ZN} \t ФН:{select_row.Kass4_FN}"
                + $"\nVPN: {select_row.VPN} \t Код Подсети: {select_row.VPN_CODE}\nПровайдер: {select_row.Operator}\nТелефон Провайдера:\t{select_row.Tel_Operator}";
            textBox_View_APT.Text = output;

        }
        internal void GetChange(string node, string adres, string email, string telephone, string inn, string ur, string passemail, string worktime,
            string kass1, string kass1fn, string kass1rn, string kass1zn, string kass2, string kass2fn, string kass2rn, string kass2zn,
            string kass3, string kass3fn, string kass3rn, string kass3zn, string kass4, string kass4fn, string kass4rn, string kass4zn,
            string vpn, string vpncode, string operat, string teloper, int iD, string login)
        {
            var connection = GetServer();
            string sql = "UPDATE my_apteka_db SET UR='" + ur + "' , NODE=" + node + " , INN='" + inn + "', Address='" + adres + "' , Telephone='" + telephone + "' , Email='" + email + "' , Pass_Email='" +
                passemail + "' , Work_time='" + worktime + "' , Kass_1='" + kass1 + "' , Kass1_RN='" + kass1rn + "' , Kass1_ZN='" + kass1zn + "' , Kass1_FN='" + kass1fn + "' , Kass_2='" + kass2 + "', Kass2_RN='" 
                + kass2rn + "' , Kass2_ZN='" + kass2zn+ " ', Kass2_FN='" + kass2fn + "' , Kass_3='" + kass3 + "' , Kass3_RN='" + kass3rn + " ', Kass3_ZN='" + kass3zn + "' , Kass3_FN='" + kass3fn + "'  " +
                ", Kass_4='" + kass4 + "' , Kass4_RN='" + kass4rn + "' , Kass4_ZN='" + kass4zn + "' , Kass4_FN='" + kass4fn + "' , VPN='" + vpn + "' , VPN_CODE='" + vpncode + "' , Operator='" + operat + "' , Tel_Operator='" + teloper + "' Where ID=" + iD + " ;";
            connection.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
                logger = new Logger();

                logger.Log($"Были произведены изменения аптеки Пользователем : {login} \n Аптеки ID: {iD}  \tУзел: {node} \tЮЛ: {ur} \t: {adres}");
            }
        }
    }
}
