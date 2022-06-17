using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;



public class MySQLData : MonoBehaviour
{
    public string host = "34.125.69.41";
    public string database = "animondb";
    public string user = "master";
    public string password = "password";
    public bool pooling = true;

    private string connectionString;
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        connectionString = "Server=" + host + ";Database=" + database + ";User=" + user + ";Password=" + password + ";";
       

        MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        Debug.Log("Mysql state: " + conn.State);

        string sql = "SELECT * FROM UserInfo";
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
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    if (i != rdr.FieldCount - 1)
                        temp += rdr[i] + ";";    // parser 넣어주기
                    else if (i == rdr.FieldCount - 1)
                        temp += rdr[i] + "\n";
                }
            }
        }

        Debug.Log(temp);

        conn.Close();


    }
    
}
