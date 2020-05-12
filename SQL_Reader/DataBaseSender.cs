using System.Collections.Generic;
using System;
using FirebirdSql.Data.FirebirdClient;
using System.Text.RegularExpressions;

namespace SQL_Reader

{
    class DataBaseSender : ISender
    {
        public event EventHandler<string> Logging;

        public void Send(string query)
        {

            using (var connection = new FbConnection("database=localhost:I:\\SqlReaderTest.fdb;user=sysdba;password=masterkey"))
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

            foreach (string query in queries)
            {
                var buffor = Regex.Replace(query, "COMMIT;.*", string.Empty).Trim();
                if (string.IsNullOrEmpty(buffor))
                {
                    continue;
                }

                Send(query);
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
