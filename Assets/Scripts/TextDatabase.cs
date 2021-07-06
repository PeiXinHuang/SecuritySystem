using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDatabase : MonoBehaviour
{
    private string sqlSer = "server=localhost;User Id=root;password=root;Database=textdatabase;charset=utf8";
    private MySqlConnection conn;
    public InputField errorText;
    private void Start()
    {
        conn = new MySqlConnection(sqlSer);
        ConnectDatabase();
        InserData("babab","45566465");
    }

    /// <summary>
    /// 连接数据库
    /// </summary>
    public void ConnectDatabase() {
        try
        {
            conn.Open();
            Debug.Log("------链接成功------");
            errorText.text = "------链接成功------";
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
            errorText.text = e.Message.ToString();
        }
        finally
        {
            conn.Close();
        }
    }

    public void InserData(string username,string password)
    {
        try
        {
            conn.Open();
            string sql = "insert into " + "texttable(username,password)" + " " + "values('暴风雪','px04545')";
            MySqlCommand command  = conn.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();
            Debug.Log("插入数据 " + username + " " + password);
            errorText.text = "------插入成功------";
        }
        catch (System.Exception e)
        {

            Debug.Log(e.Message);
            errorText.text = e.Message.ToString();
        }
        finally
        {
            conn.Close();
        }
    }
  
}
