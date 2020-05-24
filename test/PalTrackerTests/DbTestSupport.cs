﻿using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace PalTrackerTests
{
    public static class DbTestSupport
    {
        public const string TestDbConnectionString = "Server=localhost;Database=tracker_dotnet_test;Uid=tracker_dotnet;Pwd=password;";
                                                     
        public static IList<IDictionary<string, object>> ExecuteSql(string sql)
        {
            var result = new List<IDictionary<string, object>>();

            using (var connection = new MySqlConnection(TestDbConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sql;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var rowData = Enumerable.Range(0, reader.FieldCount)
                                    .ToDictionary(reader.GetName, reader.GetValue);

                                result.Add(rowData);
                            }

                            reader.NextResult();
                        }
                    }
                }

                connection.Close();
            }

            return result;
        }
    }
}