using MySql.Data.MySqlClient;
using System;

namespace to_do_list_home_work
{
    public static class DBController
    {
        private static string connectionString = "Server=localhost;Database=list_home_work;Uid=root;Pwd=;";

        // Method untuk eksekusi query yang tidak mengembalikan hasil (INSERT, UPDATE, DELETE)
        public static void ExecuteNonQuery(string query, Action<MySqlCommand> addParameters = null)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        addParameters?.Invoke(cmd); // Jika ada parameter, tambahkan
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Database error: " + ex.Message);
                    }
                }
            }
        }

        // Method untuk eksekusi query yang mengembalikan hasil (SELECT)
        public static void ExecuteReader(string query, Action<MySqlDataReader> processResult, Action<MySqlCommand> addParameters = null)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        addParameters?.Invoke(cmd); // Jika ada parameter, tambahkan
                        using (var reader = cmd.ExecuteReader())
                        {
                            processResult(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Database error: " + ex.Message);
                    }
                }
            }
        }

        // save create in database
        public static void InsertTask(string title, string description, string date, string priority, string progress)
        {
            string query = "INSERT INTO list (Title, Description, Deadline, Priority, Progress) " +
                           "VALUES (@Title, @Description, @Deadline, @Priority, @Progress)";

            ExecuteNonQuery(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Deadline", date);
                cmd.Parameters.AddWithValue("@Priority", priority);
                cmd.Parameters.AddWithValue("@Progress", progress);
            });
        }
    }
}