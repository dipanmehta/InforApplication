using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InforApplication.BLL.Entity;

namespace InforApplication.BLL.Repository.Concrete
{
    public class BookRepository : IBookRepository
    {
        private IFormatRepository _formatRepository;

        public BookRepository()
        {
            _formatRepository = new FormatRepository();
        }

        public List<Book> ImportFiles(List<BookFile> fileList)
        {
            var bookList = new List<Book>();

            var bookTasks = new List<Task<List<Book>>>();
            foreach (var file in fileList)
            {
                bookTasks.Add(ProcessFile(file));
            }

            Task.WaitAll(bookTasks.ToArray());

            for (var i = 0; i < bookTasks.Count; i++)
            {
                var books = bookTasks[i].Result;
                if (books != null)
                    bookList = bookList.Union(books).ToList();
            }
            return bookList;

        }

        private Task<List<Book>> ProcessFile(BookFile file)
        {
            return Task.Run(() =>
            {
                if (file == null)
                    return null;
                var filePath = Path.Combine(file.FileLocation, file.FileName);
                FileFormat fileFormat = null;
                var bookList = new List<Book>();
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    var isFirstLine = true;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(line))
                            continue;
                        if (isFirstLine)
                        {
                            isFirstLine = false;
                            var formatType = line.Trim();
                            fileFormat = _formatRepository.GetFileFormatByFileType(formatType.ToUpper());
                        }
                        else
                        {
                            var book = new Book();
                            //var charArray = line.ToCharArray();
                            var tabString = new string('~', 5);
                            line = line.Replace("\t", tabString);
                            for (var i = 1; i <= fileFormat.Columns.Count; i++)
                            {
                                var column = fileFormat.Columns[i - 1];
                                var length = column.EndPosition - column.StartPosition;
                                var value = (i != fileFormat.Columns.Count)
                                    ? line.Substring(column.StartPosition - 1,
                                        length)
                                    : line.Substring(column.StartPosition - 1);
                                value = value.Replace("~", "").Trim();
                                if (column.ColumnName.Equals("Name")) book.Name = value;
                                else if (column.ColumnName.Equals("Isbn")) book.Isbn = value;
                                else book.Author = value;
                            }
                            bookList.Add(book);
                        }

                    }
                }
                return bookList;
            });

        }
    }
}
