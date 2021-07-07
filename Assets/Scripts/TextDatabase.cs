using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 数据库测试类
/// </summary>
public class TextDatabase : MonoBehaviour
{
    private string sqlSer = "Server=localhost;User Id=root;Password=root;Database=textdatabase;Port=3306;CharSet=utf8"; //数据库连接语句
    private MySqlConnection conn; //数据库连接
 


    public InputField errorText; //错误Text UI
    public Text databaseText; //数据库内容Text UI

    private void Start()
    {
        conn = new MySqlConnection(sqlSer); //实例化数据库连接
    }

    /// <summary>
    /// 连接数据库
    /// </summary>
    public void ConnectDatabase()
    {

        try
        {
            conn.Open(); //打开数据库select * from texttable;
            errorText.text = "数据库连接成功";
        }
        catch (System.Exception e)
        {
            errorText.text = e.Message.ToString(); //连接数据库失败，打印失败原因
        }
        finally
        {
            conn.Close(); //关闭数据库连接
        }
    }

    /// <summary>
    /// 插入数据到数据库中
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="password">密码</param>
    public void InserData()
    {
        try
        {
            
            conn.Open();

            string sql = "insert into " + "texttable(username,password)" + " " + "values('暴风雪','px04545')"; //数据库插入语句

            //执行插入语句
            MySqlCommand command  = conn.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();

            errorText.text = "插入成功";
           
        }
        catch (System.Exception e)
        {

            errorText.text = e.Message.ToString();
        }
        finally
        {
            conn.Close();
        }
    }

    /// <summary>
    /// 查询数据库测试表里面的所有数据
    /// </summary>
    public void GetData()
    {
        try
        {
            conn.Open();

            string sql = "select * from texttable"; //查询语句

            //执行查询语句，并将查询到的数据返回到reader中
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();

            //将查询到的数据显示到UI上
            StringBuilder data = new StringBuilder();
            while (reader.Read())
            {
                data.Append(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + "\n");
            }
            databaseText.text = data.ToString();


            errorText.text = "查询成功";

        }
        catch (System.Exception e)
        {

            errorText.text = e.Message.ToString();
        }
        finally
        {
            conn.Close();
        }
    }

    /// <summary>
    /// 删除数据库中的某一项
    /// </summary>
    public void DeleteData()
    {
        try
        {
            conn.Open();

            string sql = "delete from texttable where userid = 2"; //数据库删除语句

            //执行删除语句
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();

            errorText.text = "删除成功";
        }
        catch (System.Exception e)
        {
            errorText.text = e.Message.ToString();
        }
        finally
        {
            conn.Close();
        }
    }

    /// <summary>
    /// 更新数据库
    /// </summary>
    public void UpdateData()
    {
        try
        {
            conn.Open();

            string sql = "Update texttable  Set username = 'peixin' , password = 'pass' where userid = 4"; //数据库更新语句

            //执行更新语句
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();

            errorText.text = "更新成功";
        }
        catch (System.Exception e)
        {
            errorText.text = e.Message.ToString();
        }
        finally
        {
            conn.Close();
        }
    }
    
}
