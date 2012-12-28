using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dtus.classes.core.model
{
    public class DTUUser : DTUFile
    {
        public String ID { get; set; }
        public String Forename { get; set; }
        public String Surname { get; set; }
        public String Password { get; set; }
        public Section Section { get; set; }
    }
}
