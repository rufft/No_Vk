using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Data;
using Npgsql;

namespace No_Vk.Test
{
    [MemoryDiagnoser]
    [RankColumn]
    public class BenchmarkDbTests
    {
        string connectionString = "Host=localhost;Port=5432;Database=no_vk;Username=postgres;Password=t7w-eeG-3Jw-DRt";

        [Benchmark]
        public void AddUsersToDbTest()
        {
            using NpgsqlConnection con = new(connectionString);
            string script = File.ReadAllText(@"C:\Users\saaky\OneDrive\Рабочий стол\User_Test.sql");


            using NpgsqlCommand cmd = new(script, con);
            
            DataTable usersTable = new DataTable("user_test");

            NpgsqlDataAdapter dap = new(cmd);

            con.Open();
            dap.Fill(usersTable);
            con.Close();
        }
        [Benchmark]
        public void GetUsersToDbTest()
        {
            using NpgsqlConnection con = new(connectionString);
            string script = "Select * from user_test";


            using NpgsqlCommand cmd = new(script, con);
            
            DataTable usersTable = new DataTable("user_test");

            NpgsqlDataAdapter dap = new(cmd);

            con.Open();
            dap.Fill(usersTable);
            con.Close();
        }
    }
}