using System;
using System.Data;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

public class MysqlCon
{
    private void Start()
    {

    }
    public static void Function()
    {
        // var str = "SERVER=176.122.138.20;Port=27667;Database=bombman;User Id=root;Password=110022;Character Set=utf8;SslMode=None";
        var str = "server=176.122.138.20;Port=6325;Database=bombman;User Id=root;password=110022";
        // var str = "SERVER=localhost;Port=3306;Database=bombman;User=root;password=your_password;";

        // DataSet ds = new DataSet();
        MySqlConnection con = new MySqlConnection(str);

        // MySqlCommand cmd = new MySqlCommand("select * from bomb_man", con);

        // MySqlDataAdapter da = new MySqlDataAdapter();
        try
        {
            con.Open();
            // da.SelectCommand = cmd;
            // da.Fill(ds);
            // dataGridView1.DataSource = ds.Tables[0];

            // Debug.Log("Connected");
            Console.WriteLine("OOOOOOOOOK");
        }
        catch (System.Exception e)
        {
            // Debug.Log(e);
            Console.WriteLine(e);
        }
        finally
        {
            con.Close();
            // cmd.Dispose();
            Console.WriteLine("Noooooo");
        }
        // Debug.Log("Close");
    }

    private void OnDisable()
    {

    }
}