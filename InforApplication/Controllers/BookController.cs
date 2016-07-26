using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InforApplication.BLL;
using InforApplication.BLL.Repository;
using InforApplication.BLL.Repository.Concrete;
using InforApplication.BLL.Entity;

namespace InforApplication.Controllers
{
    public class BookController : ApiController
    {
        IBookRepository _bookRepository;
        IFormatRepository _formatRepository;

        public BookController()
        {
            _bookRepository = new BookRepository();
            _formatRepository = new  FormatRepository();
        }

        [HttpPost]
        [HttpGet]
        public HttpResponseMessage AllFiles()
        {
            try
            {
                var bookFiles = GetBookFiles();
                return Request.CreateResponse(HttpStatusCode.OK, bookFiles);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Error = ex.Message });
            }
        }

        [HttpPost]
        [HttpGet]
        public HttpResponseMessage AllFileFormats()
        {
            try
            {
                var allFormats = _formatRepository.GetAllFileFormats();
                return Request.CreateResponse(HttpStatusCode.OK, allFormats);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Error = ex.Message });
            }
        }

        [HttpPost]
        [HttpGet]
        public HttpResponseMessage ImportAllFiles()
        {
            try
            {
                var books = _bookRepository.ImportFiles(GetBookFiles());
                return Request.CreateResponse(HttpStatusCode.OK, books);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Error = ex.Message });
            }
        }

        private List<BookFile> GetBookFiles()
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
