using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using dtus.classes.core.model;

namespace dtus.classes.core.dao
{
    public abstract class BaseDAO
    {
        public static readonly String AUDIT_TYPE_INSERT = "INSERT";
        public static readonly String AUDIT_TYPE_UPDATE = "UPDATE";
        public static readonly String AUDIT_TYPE_DELETE = "DELETE";

        protected SqlParameter GenParameter(String paramName, SqlDbType type, int size, Object value)
        {
            if (value == null)
                value = DBNull.Value;

            SqlParameter param = null;

            if (type == SqlDbType.DateTime)
            {
                if (value == DBNull.Value)
                {
                    param = new SqlParameter(paramName, value);
                }
                else
                {
                    param = new SqlParameter(paramName, ((Nullable<DateTime>)value).Value);
                }
            }
            else
            {
                param = new SqlParameter(paramName, type, size);
                param.Value = value;
            }

            return param;
        }

        public int GetInt(Object val)
        {
            if (val == DBNull.Value)
                return -1;
            else
                return (int)val;
        }

        public Nullable<DateTime> GetDateTime(Object val)
        {
            if (val == DBNull.Value)
                return null;
            else
                return (DateTime)val;
        }

        public String GetString(Object val)
        {
            if (val == DBNull.Value)
                return null;
            else
                return (String)val;
        }

        public abstract bool Audit(Object oldValue, Object newValue, DTUUser user, String action, SqlTransaction transaction);
        protected bool WriteLog(String oldVal, String newVal, DTUUser user, String action, String table, SqlTransaction transaction)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Transaction = transaction;
            cmd.Connection = transaction.Connection;
            SequencesDAO seqDAO = DAOFactory.GetInstance().CreateSequencesDAO();
            int logID = seqDAO.GetNextSequenceByName(Sequence.SEQUENCE_LOGID, transaction);
            if (user == null)
                cmd.CommandText = "insert into EFilingLog(LogID, LogTime, OldValue, newValue, [Action], [Table]) values( @LogID , getDate(), @OldValue, @NewValue,@Action, @Table)";
            else
            {
                cmd.CommandText = "insert into EFilingLog(LogID, LogTime, OldValue, newValue, [Action], [Table], [User]) values( @LogID , getDate(), @OldValue, @NewValue,@Action, @Table, @User)";
                cmd.Parameters.Add(GenParameter("@User", SqlDbType.Int, 10, user.FileID));
            }
            cmd.Parameters.Add(GenParameter("@LogID", SqlDbType.Int, 10, logID));
            cmd.Parameters.Add(GenParameter("@OldValue", SqlDbType.NVarChar, 4000, oldVal));
            cmd.Parameters.Add(GenParameter("@NewValue", SqlDbType.NVarChar, 4000, newVal));
            cmd.Parameters.Add(GenParameter("@Action", SqlDbType.NVarChar, 50, action));
            cmd.Parameters.Add(GenParameter("@Table", SqlDbType.NVarChar, 255, table));


            try
            {
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                return false;
            }
            return true;
        }
    }
}
