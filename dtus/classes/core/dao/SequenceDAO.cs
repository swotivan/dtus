using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using dtus.classes.core.model;

namespace dtus.classes.core.dao
{
    public class SequencesDAO : BaseDAO
    {

        public static readonly String getNextSequenceByNameSql = "select [Value] from Sequences where SequenceName = @SequenceName";
        public static readonly String addSequenceByNameSql = "update Sequences set [Value] = [Value] + 1 where SequenceName = @SequenceName";

        public int GetNextSequenceByName(string sequenceName, SqlTransaction transaction)
        {
            int sequenceValue = 0;

            SqlConnection conn = transaction.Connection;
            SqlCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.Transaction = transaction;
            cmd.CommandText = addSequenceByNameSql;

            cmd.Parameters.Add(GenParameter("SequenceName", SqlDbType.NVarChar, 100, sequenceName));
            cmd.ExecuteNonQuery();

            cmd.CommandText = getNextSequenceByNameSql;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                sequenceValue = GetInt(reader["Value"]);
            }
            else
            {
                reader.Close();
                cmd.Dispose();
                throw new Exception("SequenceName : " + sequenceName + " not found!");
            }
            reader.Close();
            cmd.Dispose();
            return sequenceValue;
        }

        public int GetExistingSequenceByName(string sequenceName, SqlTransaction transaction)
        {
            int sequenceValue = 0;

            SqlConnection conn = transaction.Connection;
            SqlCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.Transaction = transaction;
            cmd.CommandText = getNextSequenceByNameSql;
            cmd.Parameters.Add(GenParameter("SequenceName", SqlDbType.NVarChar, 100, sequenceName));

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                sequenceValue = GetInt(reader["Value"]);
            }
            else
            {
                reader.Close();
                cmd.Dispose();
                throw new Exception("SequenceName : " + sequenceName + " not found!");
            }
            reader.Close();
            cmd.Dispose();
            return sequenceValue;
        }

        public override bool Audit(Object oldVal, Object newVal, DTUUser user, String action, SqlTransaction transaction)
        {
            return false;
        }
    }
}
