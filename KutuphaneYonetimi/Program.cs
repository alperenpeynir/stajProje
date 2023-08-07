using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
}

class Library
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void ListBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Kütüphanede hiç kitap bulunmamaktadır.");
            return;
        }

        Console.WriteLine("Kütüphanedeki Kitaplar:");
        foreach (var book in books)
        {
            Console.WriteLine($"- {book.Title} by {book.Author} ({book.Year})");
        }
    }

    public void SearchBook(string keyword)
    {
        var foundBooks = books.FindAll(book =>
            book.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            book.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase));

        if (foundBooks.Count == 0)
        {
            Console.WriteLine("Aradığınız kriterlere uygun kitap bulunamadı.");
            return;
        }

        Console.WriteLine("Arama Sonuçları:");
        foreach (var book in foundBooks)
        {
            Console.WriteLine($"- {book.Title} by {book.Author} ({book.Year})");
        }
    }

    public void RemoveBook(string title)
    {
        var bookToRemove = books.Find(book =>
            book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine($"{title} isimli kitap kütüphaneden silinmiştir.");
        }
        else
        {
            Console.WriteLine("Belirtilen isimde bir kitap bulunamadı.");
        }
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();

        Console.WriteLine("Kütüphane Yönetimine Hoş Geldiniz!");

        while (true)
        {
            Console.WriteLine("Yapmak istediğiniz işlemi seçin:");
            Console.WriteLine("1 - Kitap Ekle");
            Console.WriteLine("2 - Kitapları Listele");
            Console.WriteLine("3 - Kitap Ara");
            Console.WriteLine("4 - Kitap Sil");
            Console.WriteLine("5 - Çıkış Yap");
            Console.Write("Seçiminiz (1/2/3/4/5): ");

            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine(); // Yeni satıra geçmek için

            switch (choice)
            {
                case '1':
                    Console.Write("Kitap Adı: ");
                    string title = Console.ReadLine();
                    Console.Write("Yazar: ");
                    string author = Console.ReadLine();
                    Console.Write("Yayın Yılı: ");
                    int year = Convert.ToInt32(Console.ReadLine());

                    Book newBook = new Book { Title = title, Author = author, Year = year };
                    library.AddBook(newBook);
                    Console.WriteLine("Kitap başarıyla eklendi.");
                    break;
                case '2':
                    library.ListBooks();
                    break;
                case '3':
                    Console.Write("Aranacak Kitap veya Yazar: ");
                    string keyword = Console.ReadLine();
                    library.SearchBook(keyword);
                    break;
                case '4':
                    Console.Write("Silinecek Kitap Adı: ");
                    string bookToRemove = Console.ReadLine();
                    library.RemoveBook(bookToRemove);
                    break;
                case '5':
                    Console.WriteLine("Programdan çıkılıyor...");
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim!");
                    break;
            }

            Console.WriteLine(); // Yeni satıra geçmek için
        }
    }
}

