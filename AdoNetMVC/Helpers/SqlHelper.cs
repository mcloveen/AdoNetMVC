﻿using System.Data;
using System.Data.SqlClient;

namespace AdoNetMVC.Helpers
{
    public static class SqlHelper
    {
        private const string _connectionStr = "Server=localhost;Database=AmazonSuperMarket;User Id=Sa;Password=Said670;";

        public static async Task<DataTable> SelectAsync(string query)
        {
            using SqlConnection conn = new SqlConnection(_connectionStr);
            await conn.OpenAsync();
            using (SqlDataAdapter sda = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }
        public static async Task<int> ExecuteAsync(string command)
        {

            using (SqlConnection conn = new SqlConnection(_connectionStr))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(command, conn))
                {
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

