using System.Collections.Generic;
using System;
using FirebirdSql.Data.FirebirdClient;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;

namespace SQL_Reader

{
    class DataBaseSender : ISender
    {
        public event EventHandler<string> Logging;

        public void Send(string query)
        {
            JsonConfig cfg = JsonConvert.DeserializeObject<JsonConfig>(File.ReadAllText("config.json"));

            using (var connection = new FbConnection($"database=localhost:{cfg.Path};user={cfg.Username};password={cfg.Password}"))
            {
                connection.Open();
                
                using (var transaction = connection.BeginTransaction())
                {
                    if (query.Contains("PROCEDURE"))
                    {
                        using (var command = new FbCommand(query, connection, transaction))
                        {
                            command.ExecuteScalar();
                            transaction.Commit();
                        }
                    }
                    else
                    {
                        using (var command = new FbCommand(query, connection, transaction))
                        {
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }


                    }
                }
            }
        }

        public void Send(IEnumerable<string> queries)
        {
            Console.WriteLine("Connected to DB");
            Console.WriteLine("Sending Queries, be patient");
            foreach (string query in queries)
            {
                var buffor = Regex.Replace(query, "COMMIT;.*", string.Empty).Trim();
                if (string.IsNullOrEmpty(buffor))
                {
                    continue;
                }
                
                Send(query);
                Console.Write(".");
                OnQueriesLogged(query);
            }
            Console.WriteLine("End.");
        }

        protected virtual void OnQueriesLogged(string e)
        {
            Logging?.Invoke(this, e);
        }

    }
}
