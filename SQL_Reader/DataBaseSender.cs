using System.Collections.Generic;
using System;
using FirebirdSql.Data.FirebirdClient;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using FirebirdSql.Data.Logging;
using System.Linq;

namespace SQL_Reader

{
    class DataBaseSender : ISender, IDisposable
    {
        public event EventHandler<string> Logging;

        private FbConnection _connection;
        private FbTransaction _transaction;
        public DataBaseSender(string path, string username, string password)
        {
            this._connection = new FbConnection($"database=localhost:{path};user={username};password={password}");
            _connection.Open();
            Console.WriteLine("Connected to DB");


        }
        public void Send(string query)
        {

            if (query.Contains("PROCEDURE"))
            {
                _transaction = _connection.BeginTransaction();
                using var command = new FbCommand(query, _connection, _transaction);
                Console.Write("\nExecuting procedure...");

                command.ExecuteScalar();
                _transaction.Commit();
                Console.WriteLine("\tProcedure has been correctly sent.");
            }
            else
            {
                using var command = new FbCommand(query, _connection, _transaction);
                command.ExecuteNonQuery();
            }

        }

        public void Send(IEnumerable<string> queries)
        {
            Console.Write("Sending Queries, be patient...");
            _transaction = _connection.BeginTransaction();
            foreach (string query in queries)
            {
                string buffor = Regex.Replace(query, "COMMIT;.*", string.Empty).Trim();
                if (string.IsNullOrEmpty(buffor))
                {
                    continue;
                }
                else if (query.Contains("PROCEDURE"))
                {
                    _transaction.Commit();
                }

                Send(query);

                if(query == queries.Last())
                {
                    _transaction.Commit();
                }

                OnQueriesLogged(query);               
            }


            Console.WriteLine("\nEnd.");
        }

        
        protected virtual void OnQueriesLogged(string e)
        {
            Logging?.Invoke(this, e);
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}
