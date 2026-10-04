using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== ВЫБЕРИТЕ ЗАДАЧУ (1-30) или 0 для выхода ===");
            Console.WriteLine("1. Животное");
            Console.WriteLine("2. Транспорт");
            Console.WriteLine("3. Человек и студент");
            Console.WriteLine("4. Сотрудники");
            Console.WriteLine("5. Фигуры");
            Console.WriteLine("6. Транспорт с методом движения");
            Console.WriteLine("7. Работник магазина");
            Console.WriteLine("8. Компьютеры");
            Console.WriteLine("9. Книги");
            Console.WriteLine("10. Домашние животные");
            Console.WriteLine("11. Банковские счета");
            Console.WriteLine("12. Транспортная компания");
            Console.WriteLine("13. Работники компании");
            Console.WriteLine("14. Система образования");
            Console.WriteLine("15. Военная техника");
            Console.WriteLine("16. Игровые персонажи");
            Console.WriteLine("17. Электронные устройства");
            Console.WriteLine("18. Платежи");
            Console.WriteLine("19. Сотрудники с бонусами");
            Console.WriteLine("20. Животные зоопарка");
            Console.WriteLine("--- Повышенный уровень ---");
            Console.WriteLine("21. Абстрактные фигуры");
            Console.WriteLine("22. Интернет-магазин");
            Console.WriteLine("23. Система транспорта");
            Console.WriteLine("24. Больница");
            Console.WriteLine("25. Система сотрудников с уровнями наследования");
            Console.WriteLine("26. Игра: персонажи");
            Console.WriteLine("27. Файлы");
            Console.WriteLine("28. Система оплаты зарплаты");
            Console.WriteLine("29. Полиморфизм + наследование");
            Console.WriteLine("30. Итоговое задание — система автопарка");
            Console.WriteLine("0. Выход");
            Console.Write("\nВведите номер задачи: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
                continue;

            if (choice == 0) break;

            Console.WriteLine("\n-------------------------------------------\n");

            switch (choice)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 4: Task4(); break;
                case 5: Task5(); break;
                case 6: Task6(); break;
                case 7: Task7(); break;
                case 8: Task8(); break;
                case 9: Task9(); break;
                case 10: Task10(); break;
                case 11: Task11(); break;
                case 12: Task12(); break;
                case 13: Task13(); break;
                case 14: Task14(); break;
                case 15: Task15(); break;
                case 16: Task16(); break;
                case 17: Task17(); break;
                case 18: Task18(); break;
                case 19: Task19(); break;
                case 20: Task20(); break;
                case 21: Task21(); break;
                case 22: Task22(); break;
                case 23: Task23(); break;
                case 24: Task24(); break;
                case 25: Task25(); break;
                case 26: Task26(); break;
                case 27: Task27(); break;
                case 28: Task28(); break;
                case 29: Task29(); break;
                case 30: Task30(); break;
                default: Console.WriteLine("Неверный номер задачи."); break;
            }

            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню...");
            Console.ReadKey();
        }
    }

    #region 1. Животное
    class Animal1
    {
        public virtual void Speak() => Console.WriteLine("Животное издает звук");
    }
    class Dog1 : Animal1
    {
        public override void Speak() => Console.WriteLine("Собака: Гав!");
    }
    class Cat1 : Animal1
    {
        public override void Speak() => Console.WriteLine("Кошка: Мяу!");
    }
    static void Task1()
    {
        Animal1 dog = new Dog1();
        Animal1 cat = new Cat1();
        dog.Speak();
        cat.Speak();
    }
    #endregion

    #region 2. Транспорт
    class Vehicle2
    {
        public string Brand { get; set; }
        public double Speed { get; set; }
    }
    class Car2 : Vehicle2
    {
        public int DoorsCount { get; set; }
    }
    class Motorcycle2 : Vehicle2
    {
        public bool HasSidecar { get; set; }
    }
    static void Task2()
    {
        Car2 car = new Car2 { Brand = "Toyota", Speed = 180, DoorsCount = 4 };
        Motorcycle2 moto = new Motorcycle2 { Brand = "Yamaha", Speed = 220, HasSidecar = false };
        Console.WriteLine($"Авто: {car.Brand}, {car.Speed} км/ч, дверей: {car.DoorsCount}");
        Console.WriteLine($"Мото: {moto.Brand}, {moto.Speed} км/ч, коляска: {moto.HasSidecar}");
    }
    #endregion

    #region 3. Человек и студент
    class Person3
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Student3 : Person3
    {
        public string Specialty { get; set; }
        public int Course { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"Имя: {Name}, Возраст: {Age}, Специальность: {Specialty}, Курс: {Course}");
        }
    }
    static void Task3()
    {
        Student3 student = new Student3 { Name = "Иван", Age = 20, Specialty = "Информатика", Course = 3 };
        student.DisplayInfo();
    }
    #endregion

    #region 4. Сотрудники
    class Employee4
    {
        public string Name { get; set; }
        public double Salary { get; set; }
    }
    class Manager4 : Employee4
    {
        public int DepartmentSize { get; set; }
    }
    class Developer4 : Employee4
    {
        public string PrimaryLanguage { get; set; }
    }
    static void Task4()
    {
        Manager4 mgr = new Manager4 { Name = "Анна", Salary = 120000, DepartmentSize = 10 };
        Developer4 dev = new Developer4 { Name = "Олег", Salary = 150000, PrimaryLanguage = "C#" };
        Console.WriteLine($"Менеджер: {mgr.Name}, ЗП: {mgr.Salary}, Отдел: {mgr.DepartmentSize} чел.");
        Console.WriteLine($"Разработчик: {dev.Name}, ЗП: {dev.Salary}, Язык: {dev.PrimaryLanguage}");
    }
    #endregion

    #region 5. Фигуры
    class Shape5
    {
        public virtual double GetArea() => 0;
    }
    class Rectangle5 : Shape5
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public override double GetArea() => Width * Height;
    }
    class Circle5 : Shape5
    {
        public double Radius { get; set; }
        public override double GetArea() => Math.PI * Radius * Radius;
    }
    static void Task5()
    {
        Shape5 rect = new Rectangle5 { Width = 5, Height = 10 };
        Shape5 circle = new Circle5 { Radius = 4 };
        Console.WriteLine($"Площадь прямоугольника: {rect.GetArea()}");
        Console.WriteLine($"Площадь круга: {circle.GetArea():F2}");
    }
    #endregion

    #region 6. Транспорт с методом движения
    class Vehicle6
    {
        public virtual void Move() => Console.WriteLine("Транспорт движется");
    }
    class Car6 : Vehicle6
    {
        public override void Move() => Console.WriteLine("Машина едет по дороге");
    }
    class Bus6 : Vehicle6
    {
        public override void Move() => Console.WriteLine("Автобус везет пассажиров по маршруту");
    }
    class Train6 : Vehicle6
    {
        public override void Move() => Console.WriteLine("Поезд мчит по рельсам");
    }
    static void Task6()
    {
        Vehicle6[] list = { new Car6(), new Bus6(), new Train6() };
        foreach (var v in list) v.Move();
    }
    #endregion

    #region 7. Работник магазина
    class Worker7
    {
        public string Name { get; set; }
        public string Position { get; set; }
    }
    class Cashier7 : Worker7
    {
        public int RegisterNumber { get; set; }
    }
    class Seller7 : Worker7
    {
        public string SalesDepartment { get; set; }
    }
    static void Task7()
    {
        Cashier7 c = new Cashier7 { Name = "Елена", Position = "Кассир", RegisterNumber = 3 };
        Seller7 s = new Seller7 { Name = "Павел", Position = "Продавец", SalesDepartment = "Электроника" };
        Console.WriteLine($"{c.Position} {c.Name}, Касса №{c.RegisterNumber}");
        Console.WriteLine($"{s.Position} {s.Name}, Отдел: {s.SalesDepartment}");
    }
    #endregion

    #region 8. Компьютеры
    class Computer8
    {
        public string Processor { get; set; }
        public int RAM { get; set; }
    }
    class Laptop8 : Computer8
    {
        public double BatteryLifeHours { get; set; }
    }
    class Desktop8 : Computer8
    {
        public string FormFactor { get; set; }
    }
    static void Task8()
    {
        Laptop8 laptop = new Laptop8 { Processor = "Intel i7", RAM = 16, BatteryLifeHours = 8.5 };
        Desktop8 pc = new Desktop8 { Processor = "AMD Ryzen 9", RAM = 32, FormFactor = "Full-Tower" };
        Console.WriteLine($"Ноутбук: {laptop.Processor}, {laptop.RAM}GB, Батарея: {laptop.BatteryLifeHours}ч");
        Console.WriteLine($"ПК: {pc.Processor}, {pc.RAM}GB, Корпус: {pc.FormFactor}");
    }
    #endregion

    #region 9. Книги
    class Book9
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }
    class PaperBook9 : Book9
    {
        public int PageCount { get; set; }
    }
    class EBook9 : Book9
    {
        public double FileSizeMB { get; set; }
    }
    static void Task9()
    {
        PaperBook9 pb = new PaperBook9 { Title = "Война и мир", Author = "Л. Толстой", PageCount = 1225 };
        EBook9 eb = new EBook9 { Title = "Чистый код", Author = "Р. Мартин", FileSizeMB = 4.2 };
        Console.WriteLine($"Бумажная книга: '{pb.Title}', {pb.PageCount} стр.");
        Console.WriteLine($"Электронная книга: '{eb.Title}', {eb.FileSizeMB} MB");
    }
    #endregion

    #region 10. Домашние животные
    class Pet10
    {
        public virtual void Eat() => Console.WriteLine("Питомец ест");
    }
    class Dog10 : Pet10
    {
        public override void Eat() => Console.WriteLine("Собака ест сухой корм из миски");
    }
    class Cat10 : Pet10
    {
        public override void Eat() => Console.WriteLine("Кошка ест рыбу");
    }
    class Parrot10 : Pet10
    {
        public override void Eat() => Console.WriteLine("Попугай клюет семечки");
    }
    static void Task10()
    {
        Pet10[] pets = { new Dog10(), new Cat10(), new Parrot10() };
        foreach (var p in pets) p.Eat();
    }
    #endregion

    #region 11. Банковские счета
    class BankAccount11
    {
        public double Balance { get; protected set; }
        public BankAccount11(double balance) => Balance = balance;
        public virtual void Deposit(double amount) => Balance += amount;
        public virtual void Withdraw(double amount)
        {
            if (Balance >= amount) Balance -= amount;
            else Console.WriteLine("Недостаточно средств!");
        }
    }
    class SavingsAccount11 : BankAccount11
    {
        public double InterestRate { get; set; } = 0.05;
        public SavingsAccount11(double balance) : base(balance) { }
        public void ApplyInterest() => Balance += Balance * InterestRate;
    }
    class CreditAccount11 : BankAccount11
    {
        public double CreditLimit { get; set; } = 50000;
        public CreditAccount11(double balance) : base(balance) { }
        public override void Withdraw(double amount)
        {
            if (Balance + CreditLimit >= amount) Balance -= amount;
            else Console.WriteLine("Превышен кредитный лимит!");
        }
    }
    static void Task11()
    {
        SavingsAccount11 sa = new SavingsAccount11(10000);
        sa.ApplyInterest();
        Console.WriteLine($"Сберегательный счет с процентами: {sa.Balance}");

        CreditAccount11 ca = new CreditAccount11(1000);
        ca.Withdraw(5000);
        Console.WriteLine($"Кредитный счет после снятия: {ca.Balance}");
    }
    #endregion

    #region 12. Транспортная компания
    class Transport12
    {
        public virtual double CalculateCost(double distance) => distance * 10;
    }
    class Car12 : Transport12
    {
        public override double CalculateCost(double distance) => distance * 15;
    }
    class Truck12 : Transport12
    {
        public override double CalculateCost(double distance) => distance * 50;
    }
    class Bus12 : Transport12
    {
        public override double CalculateCost(double distance) => distance * 25;
    }
    static void Task12()
    {
        double dist = 100;
        Console.WriteLine($"Стоимость перевозки на 100 км:");
        Console.WriteLine($"Легковая: {new Car12().CalculateCost(dist)}");
        Console.WriteLine($"Грузовик: {new Truck12().CalculateCost(dist)}");
        Console.WriteLine($"Автобус: {new Bus12().CalculateCost(dist)}");
    }
    #endregion

    #region 13. Работники компании
    class Employee13
    {
        public double BaseRate { get; set; } = 50000;
        public virtual double GetSalary() => BaseRate;
    }
    class Programmer13 : Employee13
    {
        public int CompletedProjects { get; set; } = 3;
        public override double GetSalary() => BaseRate + (CompletedProjects * 15000);
    }
    class Designer13 : Employee13
    {
        public int LayoutsCount { get; set; } = 10;
        public override double GetSalary() => BaseRate + (LayoutsCount * 2000);
    }
    class Manager13 : Employee13
    {
        public double TeamBonus { get; set; } = 30000;
        public override double GetSalary() => BaseRate + TeamBonus;
    }
    static void Task13()
    {
        Console.WriteLine($"ЗП Программиста: {new Programmer13().GetSalary()}");
        Console.WriteLine($"ЗП Дизайнера: {new Designer13().GetSalary()}");
        Console.WriteLine($"ЗП Менеджера: {new Manager13().GetSalary()}");
    }
    #endregion

    #region 14. Система образования
    class Person14
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Student14 : Person14
    {
        public string Major { get; set; }
    }
    class GraduateStudent14 : Student14
    {
        public string DissertationTopic { get; set; }
        public void PrintFullInfo()
        {
            Console.WriteLine($"Аспирант: {Name}, {Age} лет | Специальность: {Major} | Тема диссертации: {DissertationTopic}");
        }
    }
    static void Task14()
    {
        GraduateStudent14 grad = new GraduateStudent14
        {
            Name = "Сергей",
            Age = 25,
            Major = "Прикладная математика",
            DissertationTopic = "Алгоритмы машинного обучения"
        };
        grad.PrintFullInfo();
    }
    #endregion

    #region 15. Военная техника
    class MilitaryVehicle15
    {
        public virtual void Attack() => Console.WriteLine("Техника атакует!");
    }
    class Tank15 : MilitaryVehicle15
    {
        public override void Attack() => Console.WriteLine("Танк стреляет из основного орудия!");
    }
    class Helicopter15 : MilitaryVehicle15
    {
        public override void Attack() => Console.WriteLine("Вертолет запускает ракеты!");
    }
    class ArmoredCar15 : MilitaryVehicle15
    {
        public override void Attack() => Console.WriteLine("Бронеавтомобиль ведет огонь из пулемета!");
    }
    static void Task15()
    {
        MilitaryVehicle15[] squad = { new Tank15(), new Helicopter15(), new ArmoredCar15() };
        foreach (var v in squad) v.Attack();
    }
    #endregion

    #region 16. Игровые персонажи
    class Character16
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public virtual void Attack() => Console.WriteLine($"{Name} атакует со силой {Damage}");
    }
    class Warrior16 : Character16
    {
        public override void Attack() => Console.WriteLine($"Воин {Name} рубит мечом на {Damage} урона!");
    }
    class Mage16 : Character16
    {
        public override void Attack() => Console.WriteLine($"Маг {Name} кастует фаербол на {Damage * 1.5} урона!");
    }
    class Archer16 : Character16
    {
        public override void Attack() => Console.WriteLine($"Лучник {Name} стреляет из лука на {Damage} урона!");
    }
    static void Task16()
    {
        Character16[] party = {
            new Warrior16 { Name = "Конан", Health = 150, Damage = 25 },
            new Mage16 { Name = "Гэндальф", Health = 80, Damage = 40 },
            new Archer16 { Name = "Леголас", Health = 100, Damage = 30 }
        };
        foreach (var c in party) c.Attack();
    }
    #endregion

    #region 17. Электронные устройства
    class Device17
    {
        public virtual void TurnOn() => Console.WriteLine("Устройство включено");
        public virtual void TurnOff() => Console.WriteLine("Устройство выключено");
    }
    class Phone17 : Device17
    {
        public override void TurnOn() => Console.WriteLine("Экран телефона загорелся...");
    }
    class Computer17 : Device17
    {
        public override void TurnOn() => Console.WriteLine("Компьютер загружается...");
    }
    class Television17 : Device17
    {
        public override void TurnOn() => Console.WriteLine("Телевизор включен...");
    }
    static void Task17()
    {
        Device17[] devices = { new Phone17(), new Computer17(), new Television17() };
        foreach (var d in devices) d.TurnOn();
    }
    #endregion

    #region 18. Платежи
    class Payment18
    {
        public virtual void Pay(double amount) => Console.WriteLine($"Оплачено: {amount}");
    }
    class CashPayment18 : Payment18
    {
        public override void Pay(double amount) => Console.WriteLine($"Оплата наличными: {amount} руб.");
    }
    class CardPayment18 : Payment18
    {
        public override void Pay(double amount) => Console.WriteLine($"Оплата картой: {amount} руб.");
    }
    class OnlinePayment18 : Payment18
    {
        public override void Pay(double amount) => Console.WriteLine($"Онлайн-оплата: {amount} руб.");
    }
    static void Task18()
    {
        Payment18 p1 = new CashPayment18();
        Payment18 p2 = new CardPayment18();
        Payment18 p3 = new OnlinePayment18();
        p1.Pay(500); p2.Pay(1200); p3.Pay(3500);
    }
    #endregion

    #region 19. Сотрудники с бонусами
    class Employee19
    {
        public double BaseSalary { get; set; } = 60000;
        public virtual double CalculateBonus() => 0;
    }
    class Manager19 : Employee19
    {
        public override double CalculateBonus() => BaseSalary * 0.20;
    }
    class Developer19 : Employee19
    {
        public override double CalculateBonus() => BaseSalary * 0.15;
    }
    class SalesManager19 : Employee19
    {
        public override double CalculateBonus() => BaseSalary * 0.30;
    }
    static void Task19()
    {
        Console.WriteLine($"Бонус Менеджера: {new Manager19().CalculateBonus()}");
        Console.WriteLine($"Бонус Разработчика: {new Developer19().CalculateBonus()}");
        Console.WriteLine($"Бонус Продавца: {new SalesManager19().CalculateBonus()}");
    }
    #endregion

    #region 20. Животные зоопарка
    class Animal20
    {
        public string Name { get; set; }
        public Animal20(string name) => Name = name;
        public virtual void Eat() => Console.WriteLine($"{Name} ест");
        public virtual void MakeSound() => Console.WriteLine($"{Name} издает звук");
    }
    class Lion20 : Animal20
    {
        public Lion20() : base("Лев") { }
        public override void Eat() => Console.WriteLine($"{Name} ест мясо");
        public override void MakeSound() => Console.WriteLine($"{Name}: Ррррр!");
    }
    class Elephant20 : Animal20
    {
        public Elephant20() : base("Слон") { }
        public override void Eat() => Console.WriteLine($"{Name} ест сено");
        public override void MakeSound() => Console.WriteLine($"{Name}: Ууууу!");
    }
    class Monkey20 : Animal20
    {
        public Monkey20() : base("Обезьяна") { }
        public override void Eat() => Console.WriteLine($"{Name} ест бананы");
        public override void MakeSound() => Console.WriteLine($"{Name}: У-а-а!");
    }
    class Wolf20 : Animal20
    {
        public Wolf20() : base("Волк") { }
        public override void Eat() => Console.WriteLine($"{Name} ест добычу");
        public override void MakeSound() => Console.WriteLine($"{Name}: Ауууу!");
    }
    class Bear20 : Animal20
    {
        public Bear20() : base("Медведь") { }
        public override void Eat() => Console.WriteLine($"{Name} ест рыбу");
        public override void MakeSound() => Console.WriteLine($"{Name}: Ээууу!");
    }
    static void Task20()
    {
        Animal20[] zoo = { new Lion20(), new Elephant20(), new Monkey20(), new Wolf20(), new Bear20() };
        foreach (var a in zoo)
        {
            a.Eat();
            a.MakeSound();
            Console.WriteLine();
        }
    }
    #endregion

    #region 21. Абстрактные фигуры
    abstract class Shape21
    {
        public abstract double GetArea();
    }
    class Circle21 : Shape21
    {
        public double Radius { get; set; }
        public Circle21(double r) => Radius = r;
        public override double GetArea() => Math.PI * Radius * Radius;
    }
    class Rectangle21 : Shape21
    {
        public double W { get; set; }, H { get; set; };
        public Rectangle21(double w, double h) { W = w; H = h; }
        public override double GetArea() => W * H;
    }
    class Triangle21 : Shape21
    {
        public double A { get; set; }, H { get; set; };
        public Triangle21(double a, double h) { A = a; H = h; }
        public override double GetArea() => 0.5 * A * H;
    }
    class Square21 : Shape21
    {
        public double Side { get; set; }
        public Square21(double s) => Side = s;
        public override double GetArea() => Side * Side;
    }
    static void Task21()
    {
        Shape21[] shapes = { new Circle21(5), new Rectangle21(4, 6), new Triangle21(3, 8), new Square21(4) };
        foreach (var s in shapes)
        {
            Console.WriteLine($"Фигура {s.GetType().Name}, Площадь: {s.GetArea():F2}");
        }
    }
    #endregion

    #region 22. Интернет-магазин
    class Product22
    {
        public string Name { get; set; }
        public double BasePrice { get; set; }
        public virtual double GetTotalPrice() => BasePrice;
    }
    class Electronics22 : Product22
    {
        public override double GetTotalPrice() => BasePrice * 1.20;
    }
    class Clothing22 : Product22
    {
        public override double GetTotalPrice() => BasePrice * 0.90;
    }
    class Food22 : Product22
    {
        public override double GetTotalPrice() => BasePrice * 1.05;
    }
    static void Task22()
    {
        Product22 p1 = new Electronics22 { Name = "Телефон", BasePrice = 50000 };
        Product22 p2 = new Clothing22 { Name = "Куртка", BasePrice = 8000 };
        Product22 p3 = new Food22 { Name = "Торт", BasePrice = 1000 };

        Console.WriteLine($"{p1.Name}: итоговая цена = {p1.GetTotalPrice()}");
        Console.WriteLine($"{p2.Name}: итоговая цена = {p2.GetTotalPrice()}");
        Console.WriteLine($"{p3.Name}: итоговая цена = {p3.GetTotalPrice()}");
    }
    #endregion

    #region 23. Система транспорта
    abstract class Transport23
    {
        public abstract void Move();
        public abstract double GetFuelConsumption();
    }
    class Car23 : Transport23
    {
        public override void Move() => Console.WriteLine("Легковой автомобиль едет");
        public override double GetFuelConsumption() => 8.5;
    }
    class Truck23 : Transport23
    {
        public override void Move() => Console.WriteLine("Грузовик везет контейнер");
        public override double GetFuelConsumption() => 32.0;
    }
    class Bus23 : Transport23
    {
        public override void Move() => Console.WriteLine("Автобус едет по маршруту");
        public override double GetFuelConsumption() => 20.0;
    }
    class Motorcycle23 : Transport23
    {
        public override void Move() => Console.WriteLine("Мотоцикл едет по дороге");
        public override double GetFuelConsumption() => 4.0;
    }
    static void Task23()
    {
        Transport23[] list = { new Car23(), new Truck23(), new Bus23(), new Motorcycle23() };
        foreach (var t in list)
        {
            t.Move();
            Console.WriteLine($"Расход: {t.GetFuelConsumption()} л/100км\n");
        }
    }
    #endregion

    #region 24. Больница
    class MedicalWorker24
    {
        public string Name { get; set; }
        public virtual void Work() => Console.WriteLine("Работает...");
    }
    class Doctor24 : MedicalWorker24
    {
        public override void Work() => Console.WriteLine("Врач проводит осмотр пациента");
    }
    class Nurse24 : MedicalWorker24
    {
        public override void Work() => Console.WriteLine("Медсестра делает уколы");
    }
    class Surgeon24 : MedicalWorker24
    {
        public override void Work() => Console.WriteLine("Хирург проводит операцию");
    }
    static void Task24()
    {
        MedicalWorker24[] staff = { new Doctor24(), new Nurse24(), new Surgeon24() };
        foreach (var w in staff) w.Work();
    }
    #endregion

    #region 25. Система сотрудников с уровнями наследования
    class Person25
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void Talk() => Console.WriteLine($"{Name} говорит...");
    }
    class Employee25 : Person25
    {
        public string Position { get; set; }
        public double Salary { get; set; }
        public void Work() => Console.WriteLine($"{Name} работает на должности {Position}");
    }
    class Manager25 : Employee25
    {
        public string Department { get; set; }
        public int TeamSize { get; set; }
        public void HoldMeeting() => Console.WriteLine($"{Name} проводит собрание отдела {Department}");
    }
    class Director25 : Manager25
    {
        public double CompanyBudget { get; set; }
        public int StockOptions { get; set; }
        public void MakeStrategyDecision() => Console.WriteLine($"Директор {Name} подписывает стратегический указ");
    }
    static void Task25()
    {
        Director25 boss = new Director25
        {
            Name = "Виктор Степанович",
            Age = 52,
            Position = "Генеральный директор",
            Salary = 500000,
            Department = "Головной офис",
            TeamSize = 200,
            CompanyBudget = 50000000,
            StockOptions = 1500
        };

        boss.Talk();
        boss.Work();
        boss.HoldMeeting();
        boss.MakeStrategyDecision();
    }
    #endregion

    #region 26. Игра: персонажи
    abstract class Character26
    {
        public string Name { get; set; }
        public abstract void Attack();
        public abstract void Defend();
        public abstract void SpecialAttack();
    }
    class Warrior26 : Character26
    {
        public override void Attack() => Console.WriteLine("Воин бьет мечом!");
        public override void Defend() => Console.WriteLine("Воин закрывается щитом!");
        public override void SpecialAttack() => Console.WriteLine("Воин использует Яростный Вихрь!");
    }
    class Mage26 : Character26
    {
        public override void Attack() => Console.WriteLine("Маг стреляет заклинанием!");
        public override void Defend() => Console.WriteLine("Маг кастует щит!");
        public override void SpecialAttack() => Console.WriteLine("Маг вызывает Метеоритный дождь!");
    }
    class Archer26 : Character26
    {
        public override void Attack() => Console.WriteLine("Лучник стреляет!");
        public override void Defend() => Console.WriteLine("Лучник уворачивается!");
        public override void SpecialAttack() => Console.WriteLine("Лучник делает Град стрел!");
    }
    static void Task26()
    {
        Character26 hero = new Mage26();
        hero.Attack();
        hero.Defend();
        hero.SpecialAttack();
    }
    #endregion

    #region 27. Файлы
    class File27
    {
        public string Name { get; set; }
        public double SizeMB { get; set; }
        public File27(string name, double size) { Name = name; SizeMB = size; }
        public virtual void Open() => Console.WriteLine($"Открываем файл {Name}");
    }
    class TextFile27 : File27
    {
        public TextFile27(string n, double s) : base(n, s) { }
        public override void Open() => Console.WriteLine($"Открываем текстовый файл {Name} в Блокноте...");
    }
    class ImageFile27 : File27
    {
        public ImageFile27(string n, double s) : base(n, s) { }
        public override void Open() => Console.WriteLine($"Рендерим изображение {Name}...");
    }
    class VideoFile27 : File27
    {
        public VideoFile27(string n, double s) : base(n, s) { }
        public override void Open() => Console.WriteLine($"Запускаем видеоплеер для {Name}...");
    }
    static void Task27()
    {
        File27[] files = {
            new TextFile27("doc.txt", 0.1),
            new ImageFile27("photo.png", 3.5),
            new VideoFile27("movie.mp4", 1500)
        };
        foreach (var f in files) f.Open();
    }
    #endregion

    #region 28. Система оплаты зарплаты
    abstract class Employee28
    {
        public string Name { get; set; }
        public abstract double CalculateSalary();
    }
    class HourlyEmployee28 : Employee28
    {
        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }
        public override double CalculateSalary() => HourlyRate * HoursWorked;
    }
    class SalariedEmployee28 : Employee28
    {
        public double MonthlySalary { get; set; }
        public override double CalculateSalary() => MonthlySalary;
    }
    class CommissionEmployee28 : Employee28
    {
        public double BaseSalary { get; set; }
        public double SalesVolume { get; set; }
        public double CommissionRate { get; set; }
        public override double CalculateSalary() => BaseSalary + (SalesVolume * CommissionRate);
    }
    static void Task28()
    {
        List<Employee28> employees = new List<Employee28>
        {
            new HourlyEmployee28 { Name = "Игорь", HourlyRate = 500, HoursWorked = 160 },
            new SalariedEmployee28 { Name = "Ольга", MonthlySalary = 90000 },
            new CommissionEmployee28 { Name = "Дмитрий", BaseSalary = 30000, SalesVolume = 500000, CommissionRate = 0.08 }
        };

        double totalPayroll = 0;
        foreach (var emp in employees)
        {
            double salary = emp.CalculateSalary();
            totalPayroll += salary;
            Console.WriteLine($"{emp.Name}: {salary} руб.");
        }
        Console.WriteLine($"\nОбщий фонд зарплаты: {totalPayroll} руб.");
    }
    #endregion

    #region 29. Полиморфизм + наследование
    class Animal29
    {
        public virtual void MakeSound() => Console.WriteLine("Звук животного");
    }
    class Dog29 : Animal29 { public override void MakeSound() => Console.WriteLine("Гав!"); }
    class Cat29 : Animal29 { public override void MakeSound() => Console.WriteLine("Мяу!"); }
    class Cow29 : Animal29 { public override void MakeSound() => Console.WriteLine("Мууу!"); }
    class Sheep29 : Animal29 { public override void MakeSound() => Console.WriteLine("Беее!"); }
    class Duck29 : Animal29 { public override void MakeSound() => Console.WriteLine("Кря!"); }

    static void Task29()
    {
        List<Animal29> animals = new List<Animal29>
        {
            new Dog29(), new Cat29(), new Cow29(), new Sheep29(), new Duck29()
        };

        Console.WriteLine("Полиморфный вызов MakeSound():");
        foreach (var a in animals)
        {
            a.MakeSound();
        }
    }
    #endregion

    #region 30. Итоговое задание — система автопарка
    abstract class Vehicle30
    {
        public string Model { get; set; }
        public double Price { get; set; }
        public double MaxSpeed { get; set; }

        public Vehicle30(string model, double price, double maxSpeed)
        {
            Model = model;
            Price = price;
            MaxSpeed = maxSpeed;
        }

        public abstract double GetFuelConsumption();
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"[{GetType().Name}] Модель: {Model} | Цена: ${Price} | Макс.скорость: {MaxSpeed} км/ч | Расход: {GetFuelConsumption()} л/100км");
        }
    }

    class Car30 : Vehicle30
    {
        public Car30(string model, double price, double maxSpeed) : base(model, price, maxSpeed) { }
        public override double GetFuelConsumption() => 7.5;
    }

    class Truck30 : Vehicle30
    {
        public Truck30(string model, double price, double maxSpeed) : base(model, price, maxSpeed) { }
        public override double GetFuelConsumption() => 28.0;
    }

    class Bus30 : Vehicle30
    {
        public Bus30(string model, double price, double maxSpeed) : base(model, price, maxSpeed) { }
        public override double GetFuelConsumption() => 18.0;
    }

    class ElectricCar30 : Vehicle30
    {
        public ElectricCar30(string model, double price, double maxSpeed) : base(model, price, maxSpeed) { }
        public override double GetFuelConsumption() => 0.0;
    }

    class Motorcycle30 : Vehicle30
    {
        public Motorcycle30(string model, double price, double maxSpeed) : base(model, price, maxSpeed) { }
        public override double GetFuelConsumption() => 3.5;
    }

    class FleetManager
    {
        private List<Vehicle30> vehicles = new List<Vehicle30>();

        public void AddVehicle(Vehicle30 v) => vehicles.Add(v);
        public void RemoveVehicle(Vehicle30 v) => vehicles.Remove(v);

        public void ShowAll()
        {
            Console.WriteLine("=== ВСЕ ТРАНСПОРТНЫЕ СРЕДСТВА АВТОПАРКА ===");
            foreach (var v in vehicles)
            {
                v.DisplayInfo();
            }
        }

        public void ShowFastestAndMostExpensive()
        {
            if (vehicles.Count == 0) return;

            Vehicle30 fastest = vehicles[0];
            Vehicle30 mostExpensive = vehicles[0];

            foreach (var v in vehicles)
            {
                if (v.MaxSpeed > fastest.MaxSpeed) fastest = v;
                if (v.Price > mostExpensive.Price) mostExpensive = v;
            }

            Console.WriteLine("\n--- АНАЛИТИКА АВТОПАРКА ---");
            Console.WriteLine($"Самый быстрый транспорт: {fastest.Model} ({fastest.MaxSpeed} км/ч)");
            Console.WriteLine($"Самый дорогой транспорт: {mostExpensive.Model} (${mostExpensive.Price})");
        }
    }

    static void Task30()
    {
        FleetManager fleet = new FleetManager();

        fleet.AddVehicle(new Car30("Toyota Camry", 30000, 210));
        fleet.AddVehicle(new Truck30("MAN TGX", 110000, 130));
        fleet.AddVehicle(new Bus30("Mercedes-Benz Conecto", 85000, 100));
        fleet.AddVehicle(new ElectricCar30("Tesla Model S", 95000, 250));
        fleet.AddVehicle(new Motorcycle30("Ducati Panigale", 25000, 299));

        fleet.ShowAll();
        fleet.ShowFastestAndMostExpensive();
    }
    #endregion
}