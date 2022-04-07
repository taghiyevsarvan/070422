using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _070422
{
    internal class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> _books { get; set; } = new List<Book>();


        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public Book GetBookById(int? id)
        {
            if (id == null)
                throw new NullReferenceException("id null ola bilmez");
            return _books.Find(b => b.Id == id);
        }

        public void RemoveBook(int? id)
        {
            
            if (id == null)
                throw new NullReferenceException("id null ola bilmez");
            var removeNo = _books.Find(b=> b.Id == id);
            if (removeNo == null)
                throw new Exception("bele bir id yoxdur.");
            _books.Remove(removeNo);
        }

        public List<Book> GetAllBooks()
        {
            //elave etdiyim kitablari gormek ucun bu metodu ozumden yazdim
            List<Book> copyBookList = new List<Book>();
            copyBookList.AddRange(_books);
            return copyBookList;
        }

        
    }
}
