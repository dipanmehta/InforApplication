using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InforApplication.BLL.Entity;

namespace InforApplication.BLL.Repository
{
    public interface IFormatRepository
    {
        List<FileFormat> GetAllFileFormats();
        FileFormat GetFileFormatByFileType(string fileType);
    }
}
