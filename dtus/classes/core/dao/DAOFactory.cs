using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dtus.classes.core.dao
{
    public class DAOFactory
    {
        private static System.Object lockThis = new System.Object();
        private static DAOFactory daoFactory = null;
        private SequencesDAO seqDAO = null;
        private DAOFactory() { }

        public static DAOFactory GetInstance()
        {
            lock (lockThis)
            {
                if (daoFactory == null)
                {
                    daoFactory = new DAOFactory();
                }
                return daoFactory;
            }
        }

        //Return the sequence DAO
        public SequencesDAO CreateSequencesDAO()
        {
            lock (lockThis)
            {
                if (seqDAO == null)
                {
                    seqDAO = new SequencesDAO();
                    return seqDAO;
                }
                else
                {
                    return seqDAO;
                }
            }
        }

    }
}