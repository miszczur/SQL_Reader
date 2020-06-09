using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using FirebirdSql.Data.FirebirdClient;
using SQL_Reader.Interfaces;

namespace SQL_Reader.Senders

{
    class DataBaseSender : ISender, IDisposable
    {
        public event EventHandler<string> Log;
        public event EventHandler<string> Message;
        public event EventHandler<string> Error;

        private readonly FbConnection _connection;
        private FbTransaction _transaction;
        private short _counter;
        private readonly StringBuilder _sb;
        public DataBaseSender(string path, string username, string password)
        {
                this._connection = new FbConnection($"database=localhost:{path};user={username};password={password}");
                _connection.Open();
                OnMessageConsole("Connected to the DB!");
                _sb = new StringBuilder();         
        }
        public void Send(string query)
        {
            
                _sb.Append(query).Append("\n");

                if (query.Contains("PROCEDURE"))
                {
                    using var command = new FbCommand(query, _connection, _transaction);
                    OnMessageConsole("Executing procedure...");

                    command.ExecuteScalar();
                    OnMessageConsole("Procedure has been correctly executed");
                    OnMessageConsole("Sending queries...");
                }
                else
                {
                    using var command = new FbCommand(query, _connection, _transaction);
                    command.ExecuteNonQuery();
                    _counter++;
                }
                if (_counter == 100 || query.Contains("PROCEDURE"))
                {
                    OnLogging(_sb.ToString());
                    _transaction = _connection.BeginTransaction();
                }
            
        }

        public void Send(IEnumerable<string> queries)
        {
            try
            {
                _transaction = _connection.BeginTransaction();
            OnMessageConsole("Sending queries...");
            foreach (string query in queries)
            {
                string buffor = Regex.Replace(query, "COMMIT;.*", string.Empty).Trim();
                if (string.IsNullOrEmpty(buffor))
                {
                    continue;
                }

                Send(query);
            }

            OnLogging(_sb.ToString());
            OnMessageConsole("End.");
            }
            catch (FbException e)
            {
                Error?.Invoke(e, e.Message);
                _transaction.Rollback();
                _transaction.Dispose();
                _connection.Close();
            }

        }


        protected virtual void OnLogging(string e)
        {
            _transaction.Commit();
            Log?.Invoke(this, e);
            _counter = 0;
            _sb.Clear();
        }
        protected virtual void OnMessageConsole(string e)
        {
            Message?.Invoke(this, e);

        }
        public void Dispose()
        {
            _transaction.Dispose();
            _connection.Close();
            _connection.Dispose();
        }
    }
}
