using Newtonsoft.Json;
using System;
using System.IO;

namespace _070422
{
    internal class Program
    {
        static void Main(string[] args)
        {
        #region CreatedJson
            string path = @"D:\task\070422\070422\";
            if (!Directory.Exists(path + "Files"))
            {
                Directory.CreateDirectory(path + "Files");
            }
            if (!File.Exists(path + @"Files\Database.json"))
            {
                var result = File.Create(path + @"Files\Database.json");
                result.Close();
            }
            #endregion

        #region Library
            Library library = new Library()
            {
                Id = 1,
                Name = "Axundov kitabxanasi"
            };
        #endregion

        #region Menu
        menu:
            Console.WriteLine("=======MENU=======");
            Console.WriteLine("1-Add Book\n2-Get book by Id\n3-Remove Book\n4-Get all books\n0-Quit");
            Console.Write("\nYour choice: ");
            string choice = Console.ReadLine();
            bool quit = false;
            do
            {
                switch (choice)
                {
                    case "1":
                        Book newBook = new Book();
                        Console.Write("Book Id: ");
                        newBook.Id = int.Parse(Console.ReadLine());
                        Console.Write("Book name: ");
                        newBook.Name = Console.ReadLine();
                        Console.Write("Author name: ");
                        newBook.AuthorName = Console.ReadLine();
                        Console.Write("Price: ");
                        newBook.Price = double.Parse(Console.ReadLine());
                        library.AddBook(newBook);

                        var bookJson = JsonConvert.SerializeObject(library);
                        using (StreamWriter sw = new StreamWriter(path + @"Files\Database.json"))
                        {
                            sw.WriteLine(bookJson);
                        }
                        goto menu;
                    case "2":
                        Console.Write("Enter Id: ");
                        int getId = int.Parse(Console.ReadLine());
                        using (StreamReader sw = new StreamReader(path + @"Files\Database.json"))
                        {
                            var swRead = sw.ReadToEnd();
                            var deBookJson = JsonConvert.DeserializeObject<Library>(swRead);
                            Console.WriteLine(deBookJson.GetBookById(getId).ShowInfo());
                        }
                        goto menu;
                    case "3":
                        Console.Write("Ener remove book Id: ");
                        int removeId = int.Parse(Console.ReadLine());
                        string newLibrary = null;
                        using (StreamReader sw = new StreamReader(path + @"Files\Database.json"))
                        {
                            var swRead = sw.ReadToEnd();

                            var jsonDecode = JsonConvert.DeserializeObject<Library>(swRead);
                            jsonDecode.RemoveBook(removeId);

                            var jsonEncode = JsonConvert.SerializeObject(jsonDecode);
                            newLibrary = jsonEncode;
                        }
                        goto menu;
                    case "4":
                        Console.WriteLine("====BOOKS====");
                        using (StreamReader sw = new StreamReader(path + @"Files\Database.json"))
                        {
                            var swRead = sw.ReadToEnd();
                            var deBookJson = JsonConvert.DeserializeObject<Library>(swRead);
                            foreach (var item in deBookJson.GetAllBooks())
                            {
                                Console.WriteLine(item.ShowInfo());
                            }
                        }
                        goto menu;
                    case "0":
                        quit = true;
                        Console.WriteLine("\nProsses ended....");
                        break;
                    default:
                        Console.WriteLine("\nWrong Choice. Choose between 0 and 4");
                        goto menu;
                }
            } while (!quit);

            #endregion


        }
    }

}
