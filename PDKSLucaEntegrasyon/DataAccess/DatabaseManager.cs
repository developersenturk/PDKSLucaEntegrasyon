using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDKSLucaEntegrasyon.DataAccess
{
    public class DatabaseManager
    {
        MySqlConnection _connection;
        public bool Connectstatus;
        public DatabaseManager()
        {
            try
            {
                _connection = new MySqlConnection(Program.GetConnectionString);
                _connection.Open();
                Connectstatus = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                Connectstatus = false;
            }
         
        }
        public string ConnectionTest(string constr)
        {
            try
            {
                _connection = new MySqlConnection(constr);
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                    _connection.Close();
                }
                return "True";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public DbResult Execute(string query)
        {
            DbResult result = new();
            try
            {
                DataTable dataTable = new();
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                MySqlCommand command = new(query, _connection);
                MySqlDataAdapter adapter = new(command);
                adapter.Fill(dataTable);
                result.Status = 1;
                result.Data = dataTable;
            }
            catch (Exception ex)
            {

                result.Status = 0;
                result.ErrMessage = ex.ToString();
            }


            return result;
        }
        public static string GenerateInsertQuery(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            string tableName = type.Name.ToLower();
            string columns = "";
            string values = "";

            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo property = properties[i];
                string columnName = property.Name.ToLower();
                object value = property.GetValue(obj);
                string valueStr;

                if (value == null)
                    valueStr = "NULL";
                else if (value is string)
                    valueStr = $"'{value.ToString().Replace("'", "''")}'";
                else if (value is DateTime time)
                    valueStr = $"'{time:yyyy-MM-dd HH:mm:ss}'";
                else if (value is bool boolean)
                    valueStr = boolean ? "1" : "0";
                else if (value is TimeSpan timeSpan)
                    valueStr = $"'{timeSpan:c}'";
                else
                    valueStr = value.ToString();

                if (i > 0)
                {
                    columns += ", ";
                    values += ", ";
                }

                columns += columnName;
                values += valueStr;
            }

            return $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
        }
        public static string GenerateUpdateQuery(object obj, string primarykeyname, string condition = "")
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            string tableName = type.Name.ToLower();
            string setClause = "";

            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo property = properties[i];
                string columnName = property.Name.ToLower();
                object value = property.GetValue(obj);
                string valueStr;

                if (value == null)
                    valueStr = "NULL";
                else if (value is string)
                    valueStr = $"'{value.ToString().Replace("'", "''")}'";
                else if (value is DateTime time)
                    valueStr = $"'{time:yyyy-MM-dd HH:mm:ss}'";
                else if (value is bool boolean)
                    valueStr = boolean ? "1" : "0";
                else if (value is TimeSpan timeSpan)
                    valueStr = $"'{timeSpan:hh\\:mm\\:ss}'";
                else
                    valueStr = value.ToString();

                if (columnName != primarykeyname.ToLower())
                {
                    if (i > 1)
                        setClause += ", ";
                    setClause += $"{columnName} = {valueStr}";
                }
            }

            string whereClause = string.IsNullOrEmpty(condition) ? "" : $"WHERE {condition}";
            return $"UPDATE {tableName} SET {setClause} {whereClause}";
        }
    }
    public class DbResult
    {
        public int Status { get; set; }
        public string ErrMessage { get; set; }
        public DataTable Data { get; set; }
    }
}
