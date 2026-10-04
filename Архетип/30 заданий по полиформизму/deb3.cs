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
            Console.WriteLine("1. Животные (MakeSound)");
            Console.WriteLine("2. Транспорт (Move)");
            Console.WriteLine("3. Работники (Work)");
            Console.WriteLine("4. Фигуры (GetArea)");
            Console.WriteLine("5. Банковские счета (CalculateInterest)");
            Console.WriteLine("6. Игроки (Attack)");
            Console.WriteLine("7. Устройства (TurnOn)");
            Console.WriteLine("8. Музыкальные инструменты (Play)");
            Console.WriteLine("9. Птицы (Fly)");
            Console.WriteLine("10. Сотрудники и зарплата (CalculateSalary)");
            Console.WriteLine("--- Средний уровень ---");
            Console.WriteLine("11. Система оплаты (Pay)");
            Console.WriteLine("12. Уведомления (Send)");
            Console.WriteLine("13. Доставка (CalculatePrice)");
            Console.WriteLine("14. Система скидок (CalculateDiscount)");
            Console.WriteLine("15. Роботы (PerformTask)");
            Console.WriteLine("16. Геометрические фигуры (GetArea, GetPerimeter)");
            Console.WriteLine("17. Система транспорта (GetSpeed, List<Transport>)");
            Console.WriteLine("18. Зарплата сотрудников (List<Employee>)");
            Console.WriteLine("19. Интернет-магазин (GetFinalPrice)");
            Console.WriteLine("20. Система сообщений (IMessageSender)");
            Console.WriteLine("21. Платёжная система (IPaymentMethod)");
            Console.WriteLine("22. Система сотрудников компании (Developer, Manager, Designer, Tester)");
            Console.WriteLine("23. Игра — персонажи (Warrior, Mage, Archer, Assassin)");
            Console.WriteLine("24. Больница (MedicalWorker, TreatPatient)");
            Console.WriteLine("25. Файловая система (TextFile, ImageFile, VideoFile, AudioFile)");
            Console.WriteLine("26. Система отчетов (IReport)");
            Console.WriteLine("27. Умный дом (SmartDevice)");
            Console.WriteLine("28. Система заказов (Order, CalculateTotal)");
            Console.WriteLine("29. Такси-сервис (IRide)");
            Console.WriteLine("30. Мини-система интернет-магазина (Product + IDiscount)");
            Console.WriteLine("0. Выход");
            Console.Write("\nВведите номер задачи: ");

            if (!int.TryParse(Console.ReadLine(), out int choice)) continue;
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

    #region 1. Животные
    class Animal1
    {
        public virtual void MakeSound() => Console.WriteLine("Издает звук");
    }
    class Dog1 : Animal1 { public override void MakeSound() => Console.WriteLine("Собака: Гав!"); }
    class Cat1 : Animal1 { public override void MakeSound() => Console.WriteLine("Кошка: Мяу!"); }
    class Cow1 : Animal1 { public override void MakeSound() => Console.WriteLine("Корова: Му-у!"); }

    static void Task1()
    {
        Animal1[] animals = { new Dog1(), new Cat1(), new Cow1() };
        foreach (var a in animals) a.MakeSound();
    }
    #endregion

    #region 2. Транспорт
    class Vehicle2
    {
        public virtual void Move() => Console.WriteLine("Транспорт движется");
    }
    class Car2 : Vehicle2 { public override void Move() => Console.WriteLine("Машина едет по шоссе"); }
    class Bike2 : Vehicle2 { public override void Move() => Console.WriteLine("Велосипед крутит педали"); }
    class Bus2 : Vehicle2 { public override void Move() => Console.WriteLine("Автобус везет пассажиров"); }

    static void Task2()
    {
        Vehicle2[] vehicles = { new Car2(), new Bike2(), new Bus2() };
        foreach (var v in vehicles) v.Move();
    }
    #endregion

    #region 3. Работники
    class Employee3
    {
        public virtual void Work() => Console.WriteLine("Сотрудник работает");
    }
    class Programmer3 : Employee3 { public override void Work() => Console.WriteLine("Программист пишет код"); }
    class Teacher3 : Employee3 { public override void Work() => Console.WriteLine("Учитель ведет урок"); }
    class Doctor3 : Employee3 { public override void Work() => Console.WriteLine("Врач лечит пациента"); }

    static void Task3()
    {
        Employee3[] workers = { new Programmer3(), new Teacher3(), new Doctor3() };
        foreach (var w in workers) w.Work();
    }
    #endregion

    #region 4. Фигуры
    class Shape4
    {
        public virtual double GetArea() => 0;
    }
    class Rectangle4 : Shape4
    {
        public double W { get; set; } = 4;
        public double H { get; set; } = 5;
        public override double GetArea() => W * H;
    }
    class Circle4 : Shape4
    {
        public double R { get; set; } = 3;
        public override double GetArea() => Math.PI * R * R;
    }
    class Triangle4 : Shape4
    {
        public double B { get; set; } = 6;
        public double H { get; set; } = 4;
        public override double GetArea() => 0.5 * B * H;
    }

    static void Task4()
    {
        Shape4[] shapes = { new Rectangle4(), new Circle4(), new Triangle4() };
        foreach (var s in shapes) Console.WriteLine($"Площадь {s.GetType().Name}: {s.GetArea():F2}");
    }
    #endregion

    #region 5. Банковские счета
    class BankAccount5
    {
        public double Balance { get; set; } = 100000;
        public virtual double CalculateInterest() => Balance * 0.01;
    }
    class SavingsAccount5 : BankAccount5
    {
        public override double CalculateInterest() => Balance * 0.08;
    }
    class BusinessAccount5 : BankAccount5
    {
        public override double CalculateInterest() => Balance * 0.03;
    }

    static void Task5()
    {
        BankAccount5 sa = new SavingsAccount5();
        BankAccount5 ba = new BusinessAccount5();
        Console.WriteLine($"Проценты по сберегательному счету: {sa.CalculateInterest()}");
        Console.WriteLine($"Проценты по бизнес-счету: {ba.CalculateInterest()}");
    }
    #endregion

    #region 6. Игроки
    class Player6
    {
        public virtual void Attack() => Console.WriteLine("Игрок атакует");
    }
    class Warrior6 : Player6 { public override void Attack() => Console.WriteLine("Воин бьет мечом!"); }
    class Archer6 : Player6 { public override void Attack() => Console.WriteLine("Лучник стреляет из лука!"); }
    class Mage6 : Player6 { public override void Attack() => Console.WriteLine("Маг кастует заклинание!"); }

    static void Task6()
    {
        Player6[] team = { new Warrior6(), new Archer6(), new Mage6() };
        foreach (var p in team) p.Attack();
    }
    #endregion

    #region 7. Устройства
    class Device7
    {
        public virtual void TurnOn() => Console.WriteLine("Устройство включается");
    }
    class Phone7 : Device7 { public override void TurnOn() => Console.WriteLine("Телефон включается, зажигается экран"); }
    class Computer7 : Device7 { public override void TurnOn() => Console.WriteLine("Компьютер загружает ОС"); }
    class Television7 : Device7 { public override void TurnOn() => Console.WriteLine("Телевизор отображает каналы"); }

    static void Task7()
    {
        Device7[] dev = { new Phone7(), new Computer7(), new Television7() };
        foreach (var d in dev) d.TurnOn();
    }
    #endregion

    #region 8. Музыкальные инструменты
    class Instrument8
    {
        public virtual void Play() => Console.WriteLine("Инструмент звучит");
    }
    class Guitar8 : Instrument8 { public override void Play() => Console.WriteLine("Гитара: Бренчат струны"); }
    class Piano8 : Instrument8 { public override void Play() => Console.WriteLine("Пианино: Играют клавиши"); }
    class Drums8 : Instrument8 { public override void Play() => Console.WriteLine("Барабаны: Звучит ритмичный стук"); }

    static void Task8()
    {
        Instrument8[] band = { new Guitar8(), new Piano8(), new Drums8() };
        foreach (var i in band) i.Play();
    }
    #endregion

    #region 9. Птицы
    class Bird9
    {
        public virtual void Fly() => Console.WriteLine("Птица летит в небе");
    }
    class Eagle9 : Bird9 { public override void Fly() => Console.WriteLine("Орел высоко парит"); }
    class Penguin9 : Bird9 { public override void Fly() => Console.WriteLine("Пингвин не умеет летать, но отлично плавает!"); }
    class Sparrow9 : Bird9 { public override void Fly() => Console.WriteLine("Воробей быстро машет крыльями"); }

    static void Task9()
    {
        Bird9[] birds = { new Eagle9(), new Penguin9(), new Sparrow9() };
        foreach (var b in birds) b.Fly();
    }
    #endregion

    #region 10. Сотрудники и зарплата
    class Employee10
    {
        public virtual double CalculateSalary() => 30000;
    }
    class Manager10 : Employee10 { public override double CalculateSalary() => 80000; }
    class Developer10 : Employee10 { public override double CalculateSalary() => 120000; }
    class Intern10 : Employee10 { public override double CalculateSalary() => 20000; }

    static void Task10()
    {
        Employee10[] emp = { new Manager10(), new Developer10(), new Intern10() };
        foreach (var e in emp) Console.WriteLine($"Зарплата ({e.GetType().Name}): {e.CalculateSalary()}");
    }
    #endregion

    #region 11. Система оплаты
    class Payment11
    {
        public virtual void Pay(decimal amount) => Console.WriteLine($"Оплата {amount}");
    }
    class CashPayment11 : Payment11 { public override void Pay(decimal amount) => Console.WriteLine($"Оплачено {amount} руб. наличными"); }
    class CardPayment11 : Payment11 { public override void Pay(decimal amount) => Console.WriteLine($"Оплачено {amount} руб. банковской картой"); }
    class CryptoPayment11 : Payment11 { public override void Pay(decimal amount) => Console.WriteLine($"Оплачено {amount} в криптовалюте"); }

    static void Task11()
    {
        Payment11 p1 = new CashPayment11();
        Payment11 p2 = new CardPayment11();
        Payment11 p3 = new CryptoPayment11();
        p1.Pay(500); p2.Pay(1500); p3.Pay(3000);
    }
    #endregion

    #region 12. Уведомления
    class Notification12
    {
        public virtual void Send(string msg) => Console.WriteLine($"Уведомление: {msg}");
    }
    class EmailNotification12 : Notification12 { public override void Send(string msg) => Console.WriteLine($"[Email] {msg}"); }
    class SmsNotification12 : Notification12 { public override void Send(string msg) => Console.WriteLine($"[SMS] {msg}"); }
    class PushNotification12 : Notification12 { public override void Send(string msg) => Console.WriteLine($"[Push] {msg}"); }

    static void Task12()
    {
        Notification12[] notifs = { new EmailNotification12(), new SmsNotification12(), new PushNotification12() };
        foreach (var n in notifs) n.Send("Ваш заказ готов!");
    }
    #endregion

    #region 13. Доставка
    class Delivery13
    {
        public virtual decimal CalculatePrice(double distance) => (decimal)distance * 10;
    }
    class CourierDelivery13 : Delivery13 { public override decimal CalculatePrice(double distance) => (decimal)distance * 20; }
    class PostDelivery13 : Delivery13 { public override decimal CalculatePrice(double distance) => (decimal)distance * 5 + 100; }
    class ExpressDelivery13 : Delivery13 { public override decimal CalculatePrice(double distance) => (decimal)distance * 35 + 300; }

    static void Task13()
    {
        double dist = 15;
        Console.WriteLine($"Курьер (15км): {new CourierDelivery13().CalculatePrice(dist)} руб.");
        Console.WriteLine($"Почта (15км): {new PostDelivery13().CalculatePrice(dist)} руб.");
        Console.WriteLine($"Экспресс (15км): {new ExpressDelivery13().CalculatePrice(dist)} руб.");
    }
    #endregion

    #region 14. Система скидок
    class Discount14
    {
        public virtual decimal CalculateDiscount(decimal price) => 0;
    }
    class StudentDiscount14 : Discount14 { public override decimal CalculateDiscount(decimal price) => price * 0.15m; }
    class VipDiscount14 : Discount14 { public override decimal CalculateDiscount(decimal price) => price * 0.30m; }
    class SeasonalDiscount14 : Discount14 { public override decimal CalculateDiscount(decimal price) => price * 0.10m; }

    static void Task14()
    {
        decimal price = 1000m;
        Console.WriteLine($"Студенческая скидка: {new StudentDiscount14().CalculateDiscount(price)} руб.");
        Console.WriteLine($"VIP скидка: {new VipDiscount14().CalculateDiscount(price)} руб.");
        Console.WriteLine($"Сезонная скидка: {new SeasonalDiscount14().CalculateDiscount(price)} руб.");
    }
    #endregion

    #region 15. Роботы
    class Robot15
    {
        public virtual void PerformTask() => Console.WriteLine("Робот работает");
    }
    class CleaningRobot15 : Robot15 { public override void PerformTask() => Console.WriteLine("Робот-пылесос убирает комната за комнатой"); }
    class SecurityRobot15 : Robot15 { public override void PerformTask() => Console.WriteLine("Робот-охранник патрулирует периметр"); }
    class DeliveryRobot15 : Robot15 { public override void PerformTask() => Console.WriteLine("Робот-доставщик везет посылку адресату"); }

    static void Task15()
    {
        Robot15[] robots = { new CleaningRobot15(), new SecurityRobot15(), new DeliveryRobot15() };
        foreach (var r in robots) r.PerformTask();
    }
    #endregion

    #region 16. Геометрические фигуры
    abstract class Shape16
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }
    class Circle16 : Shape16
    {
        public double R { get; set; } = 5;
        public override double GetArea() => Math.PI * R * R;
        public override double GetPerimeter() => 2 * Math.PI * R;
    }
    class Rectangle16 : Shape16
    {
        public double W { get; set; } = 4;
        public double H { get; set; } = 6;
        public override double GetArea() => W * H;
        public override double GetPerimeter() => 2 * (W + H);
    }
    class Square16 : Shape16
    {
        public double S { get; set; } = 4;
        public override double GetArea() => S * S;
        public override double GetPerimeter() => 4 * S;
    }
    class Triangle16 : Shape16
    {
        public double A { get; set; } = 3, B { get; set; } = 4, C { get; set; } = 5;
        public override double GetArea() => 0.5 * A * B;
        public override double GetPerimeter() => A + B + C;
    }

    static void Task16()
    {
        Shape16[] shapes = { new Circle16(), new Rectangle16(), new Square16(), new Triangle16() };
        foreach (var s in shapes)
        {
            Console.WriteLine($"{s.GetType().Name}: Площадь = {s.GetArea():F2}, Периметр = {s.GetPerimeter():F2}");
        }
    }
    #endregion

    #region 17. Система транспорта
    abstract class Transport17
    {
        public abstract double GetSpeed();
    }
    class Car17 : Transport17 { public override double GetSpeed() => 120; }
    class Train17 : Transport17 { public override double GetSpeed() => 200; }
    class Airplane17 : Transport17 { public override double GetSpeed() => 850; }
    class Ship17 : Transport17 { public override double GetSpeed() => 45; }

    static void Task17()
    {
        List<Transport17> transports = new List<Transport17>
        {
            new Car17(), new Train17(), new Airplane17(), new Ship17()
        };
        foreach (var t in transports)
        {
            Console.WriteLine($"Скорость {t.GetType().Name}: {t.GetSpeed()} км/ч");
        }
    }
    #endregion

    #region 18. Зарплата сотрудников
    abstract class Employee18
    {
        public string Name { get; set; }
        public abstract decimal CalculateSalary();
    }
    class Manager18 : Employee18
    {
        public override decimal CalculateSalary() => 90000m;
    }
    class Developer18 : Employee18
    {
        public override decimal CalculateSalary() => 140000m;
    }
    class SalesManager18 : Employee18
    {
        public override decimal CalculateSalary() => 70000m;
    }

    static void Task18()
    {
        List<Employee18> list = new List<Employee18>
        {
            new Manager18 { Name = "Анастасия" },
            new Developer18 { Name = "Дмитрий" },
            new SalesManager18 { Name = "Кирилл" }
        };
        foreach (var e in list)
        {
            Console.WriteLine($"Сотрудник {e.Name} ({e.GetType().Name}): {e.CalculateSalary()} руб.");
        }
    }
    #endregion

    #region 19. Интернет-магазин
    class Product19
    {
        public decimal BasePrice { get; set; } = 1000m;
        public virtual decimal GetFinalPrice() => BasePrice;
    }
    class Electronics19 : Product19
    {
        public override decimal GetFinalPrice() => BasePrice * 1.20m; // НДС и наценка
    }
    class Food19 : Product19
    {
        public override decimal GetFinalPrice() => BasePrice * 0.95m; // Быстропортящееся - скидка
    }
    class Clothing19 : Product19
    {
        public override decimal GetFinalPrice() => BasePrice * 0.90m; // Распродажа
    }

    static void Task19()
    {
        Product19 p1 = new Electronics19();
        Product19 p2 = new Food19();
        Product19 p3 = new Clothing19();

        Console.WriteLine($"Электроника (Баз. 1000): {p1.GetFinalPrice()} руб.");
        Console.WriteLine($"Еда (Баз. 1000): {p2.GetFinalPrice()} руб.");
        Console.WriteLine($"Одежда (Баз. 1000): {p3.GetFinalPrice()} руб.");
    }
    #endregion

    #region 20. Система сообщений
    interface IMessageSender
    {
        void SendMessage(string message);
    }
    class EmailSender20 : IMessageSender
    {
        public void SendMessage(string message) => Console.WriteLine($"[Email]: {message}");
    }
    class SmsSender20 : IMessageSender
    {
        public void SendMessage(string message) => Console.WriteLine($"[SMS]: {message}");
    }
    class TelegramSender20 : IMessageSender
    {
        public void SendMessage(string message) => Console.WriteLine($"[Telegram]: {message}");
    }

    static void Task20()
    {
        List<IMessageSender> senders = new List<IMessageSender>
        {
            new EmailSender20(), new SmsSender20(), new TelegramSender20()
        };
        foreach (var s in senders) s.SendMessage("Ваш проверочный код: 4912");
    }
    #endregion

    #region 21. Платёжная система
    interface IPaymentMethod
    {
        void Pay(decimal amount);
        void Refund(decimal amount);
    }
    class BankCard21 : IPaymentMethod
    {
        public void Pay(decimal amount) => Console.WriteLine($"Оплата {amount} руб. с банковской карты.");
        public void Refund(decimal amount) => Console.WriteLine($"Возврат {amount} руб. на банковскую карту.");
    }
    class PayPal21 : IPaymentMethod
    {
        public void Pay(decimal amount) => Console.WriteLine($"Оплата {amount} руб. через PayPal.");
        public void Refund(decimal amount) => Console.WriteLine($"Возврат {amount} руб. в аккаунт PayPal.");
    }
    class CryptoWallet21 : IPaymentMethod
    {
        public void Pay(decimal amount) => Console.WriteLine($"Списание {amount} USD из криптокошелька.");
        public void Refund(decimal amount) => Console.WriteLine($"Возвращено {amount} USD в криптокошелек.");
    }

    static void Task21()
    {
        IPaymentMethod pm = new BankCard21();
        pm.Pay(2500);
        pm.Refund(2500);
    }
    #endregion

    #region 22. Система сотрудников компании
    abstract class Employee22
    {
        public string Name { get; set; }
        public abstract void Work();
        public abstract decimal CalculateSalary();
    }
    class Developer22 : Employee22
    {
        public override void Work() => Console.WriteLine($"{Name} пишет чистый C# код");
        public override decimal CalculateSalary() => 150000m;
    }
    class Manager22 : Employee22
    {
        public override void Work() => Console.WriteLine($"{Name} управляет спринтом и проектами");
        public override decimal CalculateSalary() => 110000m;
    }
    class Designer22 : Employee22
    {
        public override void Work() => Console.WriteLine($"{Name} рисует макеты в Figma");
        public override decimal CalculateSalary() => 95000m;
    }
    class Tester22 : Employee22
    {
        public override void Work() => Console.WriteLine($"{Name} ищет баги и проводит тесты");
        public override decimal CalculateSalary() => 85000m;
    }

    static void Task22()
    {
        List<Employee22> team = new List<Employee22>
        {
            new Developer22 { Name = "Алексей" },
            new Manager22 { Name = "Екатерина" },
            new Designer22 { Name = "Мария" },
            new Tester22 { Name = "Иван" }
        };

        foreach (var emp in team)
        {
            emp.Work();
            Console.WriteLine($"Зарплата: {emp.CalculateSalary()} руб.\n");
        }
    }
    #endregion

    #region 23. Игра — персонажи
    abstract class Character23
    {
        public string Name { get; set; }
        public abstract void Attack();
    }
    class Warrior23 : Character23 { public override void Attack() => Console.WriteLine($"Воин {Name} крушит сокрушительным ударом!"); }
    class Mage23 : Character23 { public override void Attack() => Console.WriteLine($"Маг {Name} запускает огненный шар!"); }
    class Archer23 : Character23 { public override void Attack() => Console.WriteLine($"Лучник {Name} делает прицельный выстрел!"); }
    class Assassin23 : Character23 { public override void Attack() => Console.WriteLine($"Убийца {Name} наносит удар из тени!"); }

    static void Task23()
    {
        List<Character23> party = new List<Character23>
        {
            new Warrior23 { Name = "Артур" },
            new Mage23 { Name = "Мерлин" },
            new Archer23 { Name = "Робин" },
            new Assassin23 { Name = "Эцио" }
        };

        Console.WriteLine("--- Команда идет в атаку ---");
        foreach (var hero in party) hero.Attack();
    }
    #endregion

    #region 24. Больница
    class MedicalWorker24
    {
        public string Name { get; set; }
        public virtual void TreatPatient() => Console.WriteLine($"{Name} оказывает медицинскую помощь");
    }
    class Doctor24 : MedicalWorker24 { public override void TreatPatient() => Console.WriteLine($"Врач {Name} ставит диагноз"); }
    class Surgeon24 : MedicalWorker24 { public override void TreatPatient() => Console.WriteLine($"Хирург {Name} оперирует"); }
    class Nurse24 : MedicalWorker24 { public override void TreatPatient() => Console.WriteLine($"Медсестра {Name} ставит капельницу"); }
    class Dentist24 : MedicalWorker24 { public override void TreatPatient() => Console.WriteLine($"Стоматолог {Name} лечит зуб"); }

    static void Task24()
    {
        List<MedicalWorker24> hospitalStaff = new List<MedicalWorker24>
        {
            new Doctor24 { Name = "Др. Хаус" },
            new Surgeon24 { Name = "Др. Брагин" },
            new Nurse24 { Name = "Анна" },
            new Dentist24 { Name = "Др. Иванов" }
        };

        foreach (var worker in hospitalStaff) worker.TreatPatient();
    }
    #endregion

    #region 25. Файловая система
    abstract class File25
    {
        public string Name { get; set; }
        public abstract void Open();
    }
    class TextFile25 : File25 { public override void Open() => Console.WriteLine($"Открытие текстового файла {Name}..."); }
    class ImageFile25 : File25 { public override void Open() => Console.WriteLine($"Просмотр изображения {Name}..."); }
    class VideoFile25 : File25 { public override void Open() => Console.WriteLine($"Воспроизведение видео {Name}..."); }
    class AudioFile25 : File25 { public override void Open() => Console.WriteLine($"Прослушивание трека {Name}..."); }

    static void Task25()
    {
        File25[] files = {
            new TextFile25 { Name = "notes.txt" },
            new ImageFile25 { Name = "avatar.png" },
            new VideoFile25 { Name = "clip.mkv" },
            new AudioFile25 { Name = "song.mp3" }
        };

        foreach (var f in files) f.Open();
    }
    #endregion

    #region 26. Система отчетов
    interface IReport
    {
        void Generate();
    }
    class SalesReport26 : IReport
    {
        public void Generate() => Console.WriteLine("Генерация отчета по продажам за месяц...");
    }
    class FinancialReport26 : IReport
    {
        public void Generate() => Console.WriteLine("Генерация финансового балансового отчета...");
    }
    class EmployeeReport26 : IReport
    {
        public void Generate() => Console.WriteLine("Генерация отчета по эффективности сотрудников...");
    }

    static void Task26()
    {
        List<IReport> reports = new List<IReport>
        {
            new SalesReport26(), new FinancialReport26(), new EmployeeReport26()
        };

        foreach (var rep in reports) rep.Generate();
    }
    #endregion

    #region 27. Умный дом
    class SmartDevice27
    {
        public string Name { get; set; }
        public virtual void TurnOn() => Console.WriteLine($"{Name} включен");
        public virtual void TurnOff() => Console.WriteLine($"{Name} выключен");
    }
    class SmartLight27 : SmartDevice27
    {
        public override void TurnOn() => Console.WriteLine("Умная лампочка загорелась теплым светом");
    }
    class SmartTV27 : SmartDevice27
    {
        public override void TurnOn() => Console.WriteLine("SmartTV включил онлайн-кинотеатр");
    }
    class SmartThermostat27 : SmartDevice27
    {
        public override void TurnOn() => Console.WriteLine("Термостат поддерживают температуру 22°C");
    }
    class SecurityCamera27 : SmartDevice27
    {
        public override void TurnOn() => Console.WriteLine("Камера наблюдения вещает в эфир");
    }

    class SmartHomeController
    {
        private List<SmartDevice27> devices = new List<SmartDevice27>();

        public void AddDevice(SmartDevice27 device) => devices.Add(device);

        public void TurnAllOn()
        {
            Console.WriteLine("=== ВКЛЮЧЕНИЕ УМНОГО ДОМА ===");
            foreach (var d in devices) d.TurnOn();
        }
    }

    static void Task27()
    {
        SmartHomeController home = new SmartHomeController();
        home.AddDevice(new SmartLight27 { Name = "Гостиная Свет" });
        home.AddDevice(new SmartTV27 { Name = "ТВ" });
        home.AddDevice(new SmartThermostat27 { Name = "Климат" });
        home.AddDevice(new SecurityCamera27 { Name = "Камера" });

        home.TurnAllOn();
    }
    #endregion

    #region 28. Система заказов
    abstract class Order28
    {
        public abstract decimal CalculateTotal();
    }
    class FoodOrder28 : Order28
    {
        public override decimal CalculateTotal() => 1200m; // Еда + доставка
    }
    class ClothingOrder28 : Order28
    {
        public override decimal CalculateTotal() => 4500m; // Одежда
    }
    class ElectronicsOrder28 : Order28
    {
        public override decimal CalculateTotal() => 35000m; // Техника + страховка
    }

    static void Task28()
    {
        Order28[] orders = { new FoodOrder28(), new ClothingOrder28(), new ElectronicsOrder28() };
        foreach (var o in orders)
        {
            Console.WriteLine($"Заказ {o.GetType().Name}: Итого = {o.CalculateTotal()} руб.");
        }
    }
    #endregion

    #region 29. Такси-сервис
    interface IRide
    {
        void StartRide();
        decimal CalculateCost(double distanceKm);
    }
    class EconomyRide29 : IRide
    {
        public void StartRide() => Console.WriteLine("Подача Эконом такси...");
        public decimal CalculateCost(double distanceKm) => (decimal)distanceKm * 20m + 100m;
    }
    class ComfortRide29 : IRide
    {
        public void StartRide() => Console.WriteLine("Подача Комфорт такси...");
        public decimal CalculateCost(double distanceKm) => (decimal)distanceKm * 35m + 200m;
    }
    class BusinessRide29 : IRide
    {
        public void StartRide() => Console.WriteLine("Подача Бизнес такси...");
        public decimal CalculateCost(double distanceKm) => (decimal)distanceKm * 70m + 500m;
    }

    static void Task29()
    {
        double km = 12.5;
        IRide ride = new ComfortRide29();
        ride.StartRide();
        Console.WriteLine($"Стоимость поездки ({km} км): {ride.CalculateCost(km)} руб.");
    }
    #endregion

    #region 30. Мини-система интернет-магазина
    interface IDiscount
    {
        decimal ApplyDiscount(decimal price);
    }

    class NoDiscount30 : IDiscount
    {
        public decimal ApplyDiscount(decimal price) => price;
    }

    class PercentDiscount30 : IDiscount
    {
        private readonly decimal _percent;
        public PercentDiscount30(decimal percent) => _percent = percent;
        public decimal ApplyDiscount(decimal price) => price * (1m - _percent / 100m);
    }

    abstract class Product30
    {
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public IDiscount DiscountStrategy { get; set; }

        public Product30(string name, decimal basePrice, IDiscount discountStrategy)
        {
            Name = name;
            BasePrice = basePrice;
            DiscountStrategy = discountStrategy;
        }

        public decimal GetFinalPrice()
        {
            return DiscountStrategy.ApplyDiscount(BasePrice);
        }

        public virtual void Display()
        {
            Console.WriteLine($"Товар: {Name} | Базовая цена: {BasePrice} руб. | Итоговая цена: {GetFinalPrice()} руб.");
        }
    }

    class Electronics30 : Product30
    {
        public Electronics30(string name, decimal basePrice, IDiscount discount) : base(name, basePrice, discount) { }
    }

    class Food30 : Product30
    {
        public Food30(string name, decimal basePrice, IDiscount discount) : base(name, basePrice, discount) { }
    }

    class Clothing30 : Product30
    {
        public Clothing30(string name, decimal basePrice, IDiscount discount) : base(name, basePrice, discount) { }
    }

    static void Task30()
    {
        IDiscount noDiscount = new NoDiscount30();
        IDiscount tenPercent = new PercentDiscount30(10);
        IDiscount twentyPercent = new PercentDiscount30(20);

        List<Product30> cart = new List<Product30>
        {
            new Electronics30("Смартфон", 50000m, tenPercent),
            new Food30("Яблоки", 200m, noDiscount),
            new Clothing30("Джинсы", 4000m, twentyPercent)
        };

        decimal totalPrice = 0;

        Console.WriteLine("=== КОРЗИНА ИНТЕРНЕТ-МАГАЗИНА ===");
        // Полностью полиморфный вывод без использования if/switch типов!
        foreach (var product in cart)
        {
            product.Display();
            totalPrice += product.GetFinalPrice();
        }

        Console.WriteLine($"\nИтоговая стоимость всей корзины: {totalPrice} руб.");
    }
    #endregion
}