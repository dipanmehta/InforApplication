using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InforApplication.BLL.Entity;

namespace InforApplication.BLL.Repository
{
    public interface IBookRepository
    {
        List<Book> ImportFiles(List<BookFile> fileList);
    }
}
