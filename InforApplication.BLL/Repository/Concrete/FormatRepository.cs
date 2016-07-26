using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InforApplication.BLL.Entity;

namespace InforApplication.BLL.Repository.Concrete
{
    public class FormatRepository: IFormatRepository
    {
        private static List<FileFormat> FileFormats;
        public List<FileFormat> GetAllFileFormats()
        {
            return FormatRepository.DummyFileFormats();
        }

        public FileFormat GetFileFormatByFileType(string formatType)
        {
            var fileFormats = FormatRepository.DummyFileFormats();
            return  fileFormats.FirstOrDefault(x => x.FormatType.Equals(formatType));
            
        }

        public static List<FileFormat> DummyFileFormats()
        {
            FileFormats = new List<FileFormat>()
            {
                new FileFormat()
                {
                   FormatType = "A",
                   Columns = new List<Column>()
                   {
                       new Column()
                       {
                           ColumnName = "Name",
                           StartPosition = 1,
                           EndPosition = 20
                       },
                       new Column()
                       {
                           ColumnName = "Isbn",
                           StartPosition = 21,
                           EndPosition = 41
                       },
                       new Column()
                       {
                           ColumnName = "Author",
                           StartPosition = 42,
                           EndPosition = 62
                       }
                   }
                },
                new FileFormat()
                {
                   FormatType = "B",
                   Columns = new List<Column>()
                   {
                       new Column()
                       {
                           ColumnName = "Name",
                           StartPosition = 1,
                           EndPosition = 30
                       },
                       new Column()
                       {
                           ColumnName = "Isbn",
                           StartPosition = 31,
                           EndPosition = 51
                       },
                       new Column()
                       {
                           ColumnName = "Author",
                           StartPosition = 52,
                           EndPosition = 72
                       }
                   }
                }
            };

            return FileFormats;
        }
    }
}
