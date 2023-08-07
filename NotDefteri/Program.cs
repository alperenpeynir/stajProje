using System;
using System.Collections.Generic;

class Note
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
}

class NoteBook
{
    private List<Note> notes;

    public NoteBook()
    {
        notes = new List<Note>();
    }

    public void AddNote(Note note)
    {
        note.CreatedAt = DateTime.Now;
        notes.Add(note);
    }

    public void ListNotes()
    {
        if (notes.Count == 0)
        {
            Console.WriteLine("Not defterinde hiç not bulunmamaktadır.");
            return;
        }

        Console.WriteLine("Not Defteri:");
        foreach (var note in notes)
        {
            Console.WriteLine($"- [{note.CreatedAt}] {note.Title}: {note.Content}");
        }
    }

    public void RemoveNote(int index)
    {
        if (index >= 0 && index < notes.Count)
        {
            notes.RemoveAt(index);
            Console.WriteLine("Belirtilen not silinmiştir.");
        }
        else
        {
            Console.WriteLine("Geçersiz not numarası!");
        }
    }
}

class Program
{
    static void Main()
    {
        NoteBook notebook = new NoteBook();

        Console.WriteLine("Not Defterine Hoş Geldiniz!");

        while (true)
        {
            Console.WriteLine("Yapmak istediğiniz işlemi seçin:");
            Console.WriteLine("1 - Not Ekle");
            Console.WriteLine("2 - Notları Listele");
            Console.WriteLine("3 - Not Sil");
            Console.WriteLine("4 - Çıkış Yap");
            Console.Write("Seçiminiz (1/2/3/4): ");

            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine(); // Yeni satıra geçmek için

            switch (choice)
            {
                case '1':
                    Console.Write("Not Başlığı: ");
                    string title = Console.ReadLine();
                    Console.Write("Not İçeriği: ");
                    string content = Console.ReadLine();

                    Note newNote = new Note { Title = title, Content = content };
                    notebook.AddNote(newNote);
                    Console.WriteLine("Not başarıyla eklendi.");
                    break;
                case '2':
                    notebook.ListNotes();
                    break;
                case '3':
                    Console.Write("Silinecek Not Numarası: ");
                    int index = Convert.ToInt32(Console.ReadLine());
                    notebook.RemoveNote(index - 1); // Not numaralarını 1'den başlatmak için -1 çıkarıyoruz.
                    break;
                case '4':
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
