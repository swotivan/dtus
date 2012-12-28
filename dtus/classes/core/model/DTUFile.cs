using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dtus.classes.core.model
{
    public class DTUFile
    {
        public int FileID { get; set; }
        public Nullable<DateTime> CreateDate { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }
        public Boolean IsDeleted { get; set; }
        public String ProfileName { get; set; }
    }
}