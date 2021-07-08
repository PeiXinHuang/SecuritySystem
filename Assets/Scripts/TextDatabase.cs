using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649 //屏蔽变量未赋值（实际已在Unity Inspector处赋值）一直为空的警告

/// <summary>
/// 数据库测试类
/// </summary>
public class TextDatabase : MonoBehaviour
{
    private string sqlSer = "Server=localhost;User Id=root;Password=root;Database=textdatabase;Port=3306;CharSet=utf8"; //数据库连接语句
    private MySqlConnection conn; //数据库连接
 
   
    [Header("查询数据库UI")]
    [SerializeField]private Text _databaseText;

    [Header("删除数据库UI")]
    [SerializeField] private InputField _deleteInputField;

    [Header("插入数据库UI")]
    [SerializeField]private InputField _insertInputField1;
    [SerializeField]private InputField _insertInputField2;

    [Header("跟新数据库UI")]
    [SerializeField] private InputField _updateInputField1;
    [SerializeField] private InputField _updateInputField2;
    [SerializeField] private InputField _updateInputField3;

    [Header("错误提示UI")]
    [SerializeField] private InputField _errorText;

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
            _errorText.text = "数据库连接成功";
        }
        catch (System.Exception e)
        {
            _errorText.text = e.Message.ToString(); //连接数据库失败，打印失败原因
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
            


            //获取插入数据
            string username = _insertInputField1.text;
            string password = _insertInputField2.text;


            if (username == "")
            {
                _errorText.text = "用户名不可以为空";
                return;
            }
            if(password == "")
            {
                _errorText.text = "密码不可以为空";
                return;
            }
                
            string sql = string.Format("insert into texttable(username,password) values('{0}','{1}')", username, password); //数据库插入语句

            conn.Open();

            //执行插入语句
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();

            _errorText.text = "插入成功";
           
        }
        catch (System.Exception e)
        {

            _errorText.text = e.Message.ToString();
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
            _databaseText.text = data.ToString();


            _errorText.text = "查询成功";

        }
        catch (System.Exception e)
        {

            _errorText.text = e.Message.ToString();
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

        //获取删除id
        if(_deleteInputField.text == "")
        {
            _errorText.text = "删除用户id不可以为空";
            return;
        }
        int userid = int.Parse(_deleteInputField.text); //删除的id号




        //判断要删除的数据是否存在，存在的话继续执行删除，否则退出
        bool searchGet = true; //是否查找到数据
        try
        {
            conn.Open();
            string searchSql = string.Format("select * from texttable where userid = {0:D}", userid);

            //执行查询语句
            MySqlCommand searchcmd = conn.CreateCommand();
            searchcmd.CommandText = searchSql;

            if (searchcmd.ExecuteScalar() == null)//如果查询数据不存在，ExecuteScalar()返回null，查询数据存在，返回结果集中第一行的第一列，如果第一行第一列为空，返回DBNull
                searchGet = false; 
        }
        catch (System.Exception e)
        {
            _errorText.text = e.Message.ToString();
        }
        finally
        {
            conn.Close();
        }

        if (!searchGet)
        {
            _errorText.text = "删除数据不存在";
            return;
        }
      
        //开始删除数据
        try
        {
            string sql = string.Format("delete from texttable where userid = {0:D}",userid); //数据库删除语句
            conn.Open();

            //执行删除语句
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();

            _errorText.text = "删除成功";
        }
        catch (System.Exception e)
        {
            _errorText.text = e.Message.ToString();
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


        // 获取更新id
        if (_updateInputField1.text == "")
        {
            _errorText.text = "更新用户id不可以为空";
            return;
        }
        int userid = int.Parse(_updateInputField1.text); //删除的id号

        //获取更新用户名和密码
        string username = _updateInputField2.text;
        string password = _updateInputField3.text;
        if (username == "")
        {
            _errorText.text = "用户名不可以为空";
            return;
        }
        if (password == "")
        {
            _errorText.text = "密码不可以为空";
            return;
        }

        //判断要更新的数据是否存在，存在的话继续执行更新，否则退出
        bool searchGet = true; //是否查找到数据
        try
        {
            conn.Open();
            string searchSql = string.Format("select * from texttable where userid = {0:D}", userid);

            //执行查询语句
            MySqlCommand searchcmd = conn.CreateCommand();
            searchcmd.CommandText = searchSql;

            if (searchcmd.ExecuteScalar() == null)//如果查询数据不存在，ExecuteScalar()返回null，查询数据存在，返回结果集中第一行的第一列，如果第一行第一列为空，返回DBNull
                searchGet = false;
        }
        catch (System.Exception e)
        {
            _errorText.text = e.Message.ToString();
        }
        finally
        {
            conn.Close();
        }
        if (!searchGet)
        {
            _errorText.text = "更新数据不存在";
            return;
        }


        //开始更新
        try
        {
            conn.Open();

            string sql = string.Format("Update texttable  Set username = '{0}' , password = '{1}' where userid = {2:D}",username,password,userid); //数据库更新语句

            //执行更新语句
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();

            _errorText.text = "更新成功";
        }
        catch (System.Exception e)
        {
            _errorText.text = e.Message.ToString();
        }
        finally
        {
            conn.Close();
        }
    }
    
}
