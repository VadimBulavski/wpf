using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MyERP.Model
{
    public static class ProfessionRepository
    {
        private static ObservableCollection<Profession> _professions;

        public static ObservableCollection<Profession> AllProfessions
        {
            get
            {
                if (_professions == null)
                    _professions = GenerateProfessionRepository();
                return _professions;
            }
        }

        public static ObservableCollection<Profession> GenerateProfessionRepository()
        {
            ObservableCollection<Profession> professions = new ObservableCollection<Profession>()
            {
                new Profession
                {
                    EmployeeNumber = 101456,
                    FirstName = "Алексей",
                    LastName = "Петров",
                    Adress = new Adress(){City = "Минск", Street = "Кунцевщина", HomeNumber = 45},
                    Date = new DateTime(1979,3,7),
                    Foto = new BitmapImage(new Uri(@"/Images/Леха.jpg",UriKind.Relative)),
                    Department = Departament.Shipping,
                    Position = Position.HeadOfDepartment,
                    Salory = 323.58,
                    ListOrder = new List<Order>(){new Order(){NameOrder = "101", 
                                                NameOfCustomer = "Метеорит", Start = new DateTime(2015,11,10), 
                                                Finish = new DateTime(2015,11,27), Completion = 90.2}},
                    Rating = Rating.GetRating(0.9,0.8,0.7,0.95,0.78)
                },
                new Profession
                {
                    EmployeeNumber = 101460,
                    FirstName = "Александр",
                    LastName = "Сидоров",
                    Adress = new Adress(){City = "Минск", Street = "Минская", HomeNumber = 10},
                    Date = new DateTime(1965,11,21),
                    Foto = new BitmapImage(new Uri(@"/Images/Директор.jpg",UriKind.Relative)),
                    Department = Departament.Production,
                    Position = Position.Director,
                    Rating = Rating.GetRating(1,1,1,1,1),
                    Salory = 1023.58,
                },
                new Profession
                {
                    EmployeeNumber = 102050,
                    FirstName = "Алена",
                    LastName = "Иванова",
                    Adress = new Adress(){City = "Минск", Street = "Кирова", HomeNumber = 16},
                    Date = new DateTime(1985,4,12),
                    Foto = new BitmapImage(new Uri(@"/Images/Дизайнер.jpg",UriKind.Relative)),
                    Department = Departament.Disigners,
                    Position = Position.Disigner,
                    Salory = 352.12,
                    ListOrder = new List<Order>(){new Order(){NameOrder = "102", 
                                                NameOfCustomer = "ПартнерОптима", Start = new DateTime(2015,12,10), 
                                                Finish = new DateTime(2015,12,28), Completion = 87}},
                    Rating = Rating.GetRating(0.8,0.3,0.6,0.89,0.95)
                },
                 new Profession
                {
                    EmployeeNumber = 126578,
                    FirstName = "Наталья",
                    LastName = "Соколова",
                    Adress = new Adress(){City = "Минск", Street = "Неманская", HomeNumber = 18},
                    Date = new DateTime(1984,2,12),
                    Foto = new BitmapImage(new Uri(@"/Images/Менеджер.jpg",UriKind.Relative)),
                    Department = Departament.Managers,
                    Position = Position.Manager,
                    Salory = 355.35,
                    ListOrder = new List<Order>(){new Order(){NameOrder = "103", 
                                                NameOfCustomer = "ДрейдДизайн", Start = new DateTime(2015,11,25), 
                                                Finish = new DateTime(2015,12,21), Completion = 79}},
                    Rating = Rating.GetRating(0.78,0.69,0.89,0.55,0.99)
                },
                 new Profession
                {
                    EmployeeNumber = 125848,
                    FirstName = "Алекснадр",
                    LastName = "Козловский",
                    Adress = new Adress(){City = "Минск", Street = "Тюленина", HomeNumber = 18},
                    Date = new DateTime(1968,11,15),
                    Foto = new BitmapImage(new Uri(@"/Images/Зам.jpg",UriKind.Relative)),
                    Department = Departament.Production,
                    Position = Position.DeputyDirector,
                    Salory = 687.12,
                    Rating = Rating.GetRating(0.96,0.85,0.92,0.91,0.99)
                },
                  new Profession
                {
                    EmployeeNumber = 135548,
                    FirstName = "Олег",
                    LastName = "Алексейчик",
                    Adress = new Adress(){City = "Минск", Street = "Сурганова", HomeNumber = 36},
                    Date = new DateTime(1983,5,13),
                    Foto = new BitmapImage(new Uri(@"/Images/Олег.jpg",UriKind.Relative)),
                    Department = Departament.Shipping,
                    Position = Position.Working,
                    Salory = 255.65,
                    ListOrder = new List<Order>(){new Order(){NameOrder = "103", 
                                                NameOfCustomer = "ДрейдДизайн", Start = new DateTime(2015,11,25), 
                                                Finish = new DateTime(2015,12,21), Completion = 79},
                                                  new Order(){NameOrder = "102", 
                                                NameOfCustomer = "ПартнерОптима", Start = new DateTime(2015,12,10), 
                                                Finish = new DateTime(2015,12,28), Completion = 87},
                                                  new Order(){NameOrder = "101", 
                                                NameOfCustomer = "Метеорит", Start = new DateTime(2015,11,10), 
                                                Finish = new DateTime(2015,11,27), Completion = 90.2}},
                    Rating = Rating.GetRating(0.85,0.77,0.84,0.66,0.92)
                },
                  new Profession
                {
                    EmployeeNumber = 135548,
                    FirstName = "Антон",
                    LastName = "Лавров",
                    Adress = new Adress(){City = "Минск", Street = "Кедышко", HomeNumber = 45},
                    Date = new DateTime(1981,10,26),
                    Foto = new BitmapImage(new Uri(@"/Images/Рабочий.jpg",UriKind.Relative)),
                    Department = Departament.Production,
                    Position = Position.Working,
                    Salory = 278.32,
                    ListOrder = new List<Order>(){new Order(){NameOrder = "103", 
                                                NameOfCustomer = "ДрейдДизайн", Start = new DateTime(2015,11,25), 
                                                Finish = new DateTime(2015,12,21), Completion = 79},
                                                  new Order(){NameOrder = "102", 
                                                NameOfCustomer = "ПартнерОптима", Start = new DateTime(2015,12,10), 
                                                Finish = new DateTime(2015,12,28), Completion = 87},
                                                  new Order(){NameOrder = "101", 
                                                NameOfCustomer = "Метеорит", Start = new DateTime(2015,11,10), 
                                                Finish = new DateTime(2015,11,27), Completion = 90.2}},
                    Rating = Rating.GetRating(0.92,0.85,0.93,0.97,0.96)
                },
                    
            };
            return professions;
        }
    }
}
