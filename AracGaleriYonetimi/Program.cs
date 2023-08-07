using System;
using System.Collections.Generic;

class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
}

class CarGallery
{
    private List<Car> cars;

    public CarGallery()
    {
        cars = new List<Car>();
    }

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public void ListCars()
    {
        if (cars.Count == 0)
        {
            Console.WriteLine("Araç galerisinde hiç araç bulunmamaktadır.");
            return;
        }

        Console.WriteLine("Araç Galerisi:");
        foreach (var car in cars)
        {
            Console.WriteLine($"- {car.Brand} {car.Model} ({car.Year})");
        }
    }

    public void SearchCar(string keyword)
    {
        var foundCars = cars.FindAll(car =>
            car.Brand.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            car.Model.Contains(keyword, StringComparison.OrdinalIgnoreCase));

        if (foundCars.Count == 0)
        {
            Console.WriteLine("Aradığınız kriterlere uygun araç bulunamadı.");
            return;
        }

        Console.WriteLine("Arama Sonuçları:");
        foreach (var car in foundCars)
        {
            Console.WriteLine($"- {car.Brand} {car.Model} ({car.Year})");
        }
    }

    public void RemoveCar(string brand, string model)
    {
        var carToRemove = cars.Find(car =>
            car.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
            car.Model.Equals(model, StringComparison.OrdinalIgnoreCase));

        if (carToRemove != null)
        {
            cars.Remove(carToRemove);
            Console.WriteLine($"{brand} {model} araç galeriden silinmiştir.");
        }
        else
        {
            Console.WriteLine("Belirtilen kriterlere uygun bir araç bulunamadı.");
        }
    }
}

class Program
{
    static void Main()
    {
        CarGallery gallery = new CarGallery();

        Console.WriteLine("Araç Galerisi Yönetimine Hoş Geldiniz!");

        while (true)
        {
            Console.WriteLine("Yapmak istediğiniz işlemi seçin:");
            Console.WriteLine("1 - Araç Ekle");
            Console.WriteLine("2 - Araçları Listele");
            Console.WriteLine("3 - Araç Ara");
            Console.WriteLine("4 - Araç Sil");
            Console.WriteLine("5 - Çıkış Yap");
            Console.Write("Seçiminiz (1/2/3/4/5): ");

            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine(); // Yeni satıra geçmek için

            switch (choice)
            {
                case '1':
                    Console.Write("Marka: ");
                    string brand = Console.ReadLine();
                    Console.Write("Model: ");
                    string model = Console.ReadLine();
                    Console.Write("Yıl: ");
                    int year = Convert.ToInt32(Console.ReadLine());

                    Car newCar = new Car { Brand = brand, Model = model, Year = year };
                    gallery.AddCar(newCar);
                    Console.WriteLine("Araç başarıyla eklenmiştir.");
                    break;
                case '2':
                    gallery.ListCars();
                    break;
                case '3':
                    Console.Write("Aranacak Marka veya Model: ");
                    string keyword = Console.ReadLine();
                    gallery.SearchCar(keyword);
                    break;
                case '4':
                    Console.Write("Silinecek Araç Marka: ");
                    string carBrand = Console.ReadLine();
                    Console.Write("Silinecek Araç Model: ");
                    string carModel = Console.ReadLine();
                    gallery.RemoveCar(carBrand, carModel);
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
