using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InforApplication.BLL.Entity
{
    public class FileFormat
    {
        public string FormatType { get; set; }
        public List<Column> Columns { get; set; }
    }
}
