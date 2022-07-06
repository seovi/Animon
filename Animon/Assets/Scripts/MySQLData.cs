using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Threading.Tasks;



public class MySQLData
{
    public string host = "34.125.69.41";
    public string database = "animondb";
    public string user = "master";
    public string password = "password";
    public bool pooling = true;

    private string connectionString;
    MySqlConnection conn;
    
    public MySQLData()
    {
        connectionString = "Server=" + host + ";Database=" + database + ";User=" + user + ";Password=" + password + ";";
       
        conn = new MySqlConnection(connectionString);
        
        Debug.Log("Mysql state: " + conn.State);

        //string sql = "SELECT * FROM UserInfo";
        //MySqlCommand cmd = new MySqlCommand(sql, conn);
        //MySqlDataReader rdr = cmd.ExecuteReader();

        //string temp = string.Empty;
        //if (rdr == null)
        //{
        //    temp = "No return";
        //}
        //else
        //{
        //    while (rdr.Read())
        //    {
        //        for (int i = 0; i < rdr.FieldCount; i++)
        //        {
        //            if (i != rdr.FieldCount - 1)
        //                temp += rdr[i] + ";";    // parser 넣어주기
        //            else if (i == rdr.FieldCount - 1)
        //                temp += rdr[i] + "\n";
        //        }
        //    }
        //}

        
    }

    ~MySQLData()
    {
        conn.Close();
    }
    

    public int GetCoinCount(string idName)
    {
        int coinCount = 0;
        conn.Open();
        Debug.Log("GetCoinCount state: " + conn.State);

        string quote = "\"";
        string sql = "SELECT coin_count FROM UserInfo WHERE id_name=" + quote + idName + quote;
        Debug.Log("GetCoinCount sql: " + sql);
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        MySqlDataReader rdr = cmd.ExecuteReader();

        string temp = string.Empty;
        if (rdr == null)
        {
            temp = "No return";
        }
        else
        {
            while (rdr.Read())
            {
                coinCount= (int)rdr[0];
            }
        }

        Debug.Log("GetCoinCount state: " + coinCount);

        conn.Close();

        return coinCount;
    }

    public async void SetCoinCount(string idName, int coinCount)
    {        
        var task = Task.Run(() => UpdateCoinCount(idName, coinCount));
        await task;
    }

    public void UpdateCoinCount(string idName, int coinCount)
    {
        conn.Open();
        string quote = "\"";
        string sql = "UPDATE UserInfo SET coin_count=" + coinCount + " WHERE id_name=" + quote + idName + quote;
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        MySqlDataReader rdr = cmd.ExecuteReader();

        conn.Close();
    }
}
