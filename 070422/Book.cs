using System;
using System.Collections.Generic;
using System.Text;

namespace _070422
{
    internal class Book
    {
        //public Book()
        //{
        //    id++;
        //    Id = id;
        //}
        //private static int id;
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public double Price { get; set; }

        public string ShowInfo()
        {
            return $"Id: {this.Id} - Name: {this.Name} - Author name: {this.AuthorName} - Price: {Price}";
        }

    }
}
