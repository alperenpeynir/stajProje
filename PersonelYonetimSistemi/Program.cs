using System;
using System.Collections.Generic;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
}

class EmployeeManagementSystem
{
    private List<Employee> employees;

    public EmployeeManagementSystem()
    {
        employees = new List<Employee>();
    }

    public void AddEmployee(Employee employee)
    {
        // Yeni personel için benzersiz bir Id ataması yapalım.
        employee.Id = employees.Count + 1;
        employees.Add(employee);
    }

    public void ListEmployees()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("Şirkette hiç personel bulunmamaktadır.");
            return;
        }

        Console.WriteLine("Personel Listesi:");
        foreach (var employee in employees)
        {
            Console.WriteLine($"- Id: {employee.Id}, Adı: {employee.Name}, Departman: {employee.Department}, Maaş: {employee.Salary}");
        }
    }

    public void SearchEmployee(string keyword)
    {
        var foundEmployees = employees.FindAll(employee =>
            employee.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            employee.Department.Contains(keyword, StringComparison.OrdinalIgnoreCase));

        if (foundEmployees.Count == 0)
        {
            Console.WriteLine("Aradığınız kriterlere uygun personel bulunamadı.");
            return;
        }

        Console.WriteLine("Arama Sonuçları:");
        foreach (var employee in foundEmployees)
        {
            Console.WriteLine($"- Id: {employee.Id}, Adı: {employee.Name}, Departman: {employee.Department}, Maaş: {employee.Salary}");
        }
    }

    public void UpdateEmployee(int id, Employee updatedEmployee)
    {
        var employeeToUpdate = employees.FindIndex(employee => employee.Id == id);

        if (employeeToUpdate != -1)
        {
            updatedEmployee.Id = id;
            employees[employeeToUpdate] = updatedEmployee;
            Console.WriteLine("Personel bilgileri güncellenmiştir.");
        }
        else
        {
            Console.WriteLine("Belirtilen Id'ye sahip personel bulunamadı.");
        }
    }

    public void RemoveEmployee(int id)
    {
        var employeeToRemove = employees.Find(employee => employee.Id == id);

        if (employeeToRemove != null)
        {
            employees.Remove(employeeToRemove);
            Console.WriteLine("Personel sistemden silinmiştir.");
        }
        else
        {
            Console.WriteLine("Belirtilen Id'ye sahip personel bulunamadı.");
        }
    }
}

class Program
{
    static void Main()
    {
        EmployeeManagementSystem system = new EmployeeManagementSystem();

        Console.WriteLine("Personel Yönetim Sistemine Hoş Geldiniz!");

        while (true)
        {
            Console.WriteLine("Yapmak istediğiniz işlemi seçin:");
            Console.WriteLine("1 - Personel Ekle");
            Console.WriteLine("2 - Personelleri Listele");
            Console.WriteLine("3 - Personel Ara");
            Console.WriteLine("4 - Personel Güncelle");
            Console.WriteLine("5 - Personel Sil");
            Console.WriteLine("6 - Çıkış Yap");
            Console.Write("Seçiminiz (1/2/3/4/5/6): ");

            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine(); // Yeni satıra geçmek için

            switch (choice)
            {
                case '1':
                    Console.Write("Adı: ");
                    string name = Console.ReadLine();
                    Console.Write("Departman: ");
                    string department = Console.ReadLine();
                    Console.Write("Maaş: ");
                    decimal salary = Convert.ToDecimal(Console.ReadLine());

                    Employee newEmployee = new Employee { Name = name, Department = department, Salary = salary };
                    system.AddEmployee(newEmployee);
                    Console.WriteLine("Personel başarıyla eklenmiştir.");
                    break;
                case '2':
                    system.ListEmployees();
                    break;
                case '3':
                    Console.Write("Aranacak Personel Adı veya Departmanı: ");
                    string keyword = Console.ReadLine();
                    system.SearchEmployee(keyword);
                    break;
                case '4':
                    Console.Write("Güncellenecek Personel Id: ");
                    int idToUpdate = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Adı: ");
                    string updatedName = Console.ReadLine();
                    Console.Write("Departman: ");
                    string updatedDepartment = Console.ReadLine();
                    Console.Write("Maaş: ");
                    decimal updatedSalary = Convert.ToDecimal(Console.ReadLine());

                    Employee updatedEmployee = new Employee
                    {
                        Name = updatedName,
                        Department = updatedDepartment,
                        Salary = updatedSalary
                    };

                    system.UpdateEmployee(idToUpdate, updatedEmployee);
                    break;
                case '5':
                    Console.Write("Silinecek Personel Id: ");
                    int idToRemove = Convert.ToInt32(Console.ReadLine());
                    system.RemoveEmployee(idToRemove);
                    break;
                case '6':
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
