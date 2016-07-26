using System;
using System.Collections.Generic;
using InforApplication.BLL.Entity;
using InforApplication.BLL.Repository;
using InforApplication.BLL.Repository.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InforApplication.Tests
{
    [TestClass]
    public class BookRepositoryTest
    {
        [TestMethod]
        public void TestImportFiles()
        {
            try
            {
                IBookRepository repository = new BookRepository();
                var books = repository.ImportFiles(GetBookFiles());
                Assert.IsNotNull(books);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
             
             

        }

        public List<BookFile> GetBookFiles()
        {
            var bookFile = new List<BookFile>()
            {
                new BookFile()
                {
                    FileName = "A.txt",
                    FileLocation = @"c:\Infor"
                },
                new BookFile()
                {
                    FileName = "B.txt",
                    FileLocation = @"c:\Infor"

                }
            };
            return bookFile;
        }
    }
}
