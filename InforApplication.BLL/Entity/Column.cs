using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InforApplication.BLL.Entity
{
    public class Column
    {
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
        public int StartPosition { get; set; }
        public int EndPosition { get; set; }
    }
}
