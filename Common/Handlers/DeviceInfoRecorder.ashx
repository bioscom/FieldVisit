<%@ WebHandler Language="C#" Class="DeviceInfoRecorder" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class DeviceInfoRecorder : IHttpHandler
{
    private const int INITIAL_COUNT = 1;
    private const string CONNECTION_STRING_KEY = "AspnetAjaxDeviceInformation35";
    
    public void ProcessRequest(HttpContext context)
    {
        AddRecord(context);
    }

    private void AddRecord(HttpContext context)
    {
        var widthParam= context.Request.QueryString["width"].ToString();
        var heightParam = context.Request.QueryString["height"].ToString();

        if (widthParam != null && heightParam != null)
        {
            var width = context.Request.QueryString["width"].ToString();
            var height = context.Request.QueryString["height"].ToString();
            var userAgent = context.Request.UserAgent;

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[CONNECTION_STRING_KEY].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM DeviceInformationRecords WHERE UserAgent='" + userAgent + "'";
                cmd.Connection = connection;

                try
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var count = (int)reader["Count"];
                        var id = reader["Id"];

                        cmd.CommandText = "UPDATE DeviceInformationRecords SET Count = @count WHERE Id = @id";
                        cmd.Parameters.AddWithValue("@count", count + 1);
                        cmd.Parameters.AddWithValue("@id", id);
                    }


                    if (!reader.HasRows)
                    {
                        reader.Close();
                        cmd.CommandText = "INSERT DeviceInformationRecords(Width, Height, UserAgent, Count) VALUES (@width, @height, @userAgent, @count)";
                        cmd.Parameters.AddWithValue("@width", width);
                        cmd.Parameters.AddWithValue("@height", height);
                        cmd.Parameters.AddWithValue("@userAgent", userAgent);
                        cmd.Parameters.AddWithValue("@count", INITIAL_COUNT);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        reader.Close();
                        cmd.ExecuteNonQuery();
                    }
                    context.Response.Write("success");

                }
                catch (Exception ex)
                {
                    context.Response.Write(ex.Message);
                }
            }
        }
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}

