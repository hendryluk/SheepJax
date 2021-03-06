﻿using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using SheepJax.Comet.AsyncHelpers;

namespace SheepJax.Comet.DataHelpers
{
    public static class DbAsyncHelper
    {
        public static Task<SqlDataReader> ExecuteReaderAsync(this SqlCommand cmd)
        {
            return Task.Factory.FromAsync(cmd.BeginExecuteReader, x => cmd.EndExecuteReader(x), null);
        }

        public static Task<int> ExecuteNonQueryAsync(this SqlCommand cmd)
        {
            return Task.Factory.FromAsync(cmd.BeginExecuteNonQuery, x => cmd.EndExecuteNonQuery(x), null);
        }

        public static Task<T> WithinTransaction<T>(this SqlConnection conn, Func<SqlTransaction, Task<T>> task)
        {
            SqlTransaction tx = null;
            try
            {
                conn.Open();
                tx = conn.BeginTransaction();
                return task(tx).Finally(t => { tx.Dispose(); conn.Dispose(); });
            }
            catch (Exception e)
            {
                if (tx != null)
                    tx.Dispose();
                conn.Dispose();
                return TplHelper.FromException<T>(e);
            }
        }

        public static Task WithinTransaction(this SqlConnection conn, Func<SqlTransaction, Task> task)
        {
            SqlTransaction tx = null;
            try
            {
                conn.Open();
                tx = conn.BeginTransaction();
                return task(tx).Finally(t => { tx.Dispose(); conn.Dispose(); });
            }
            catch (Exception e)
            {
                if (tx != null)
                    tx.Dispose();
                conn.Dispose();
                return TplHelper.FromException(e);
            }
        }
    }
}