using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== ВЫБЕРИТЕ ЗАДАЧУ (1-15) или 0 для выхода ===");
            Console.WriteLine("1. Факториал числа");
            Console.WriteLine("2. Количество цифр в числе");
            Console.WriteLine("3. Сумма цифр числа");
            Console.WriteLine("4. Перевернуть число");
            Console.WriteLine("5. Проверка простого числа");
            Console.WriteLine("6. Все простые числа до N");
            Console.WriteLine("7. НОД двух чисел");
            Console.WriteLine("8. Среднее значение массива");
            Console.WriteLine("9. Второе максимальное число массива");
            Console.WriteLine("10. Перевернуть массив на месте");
            Console.WriteLine("11. Подсчёт гласных в строке");
            Console.WriteLine("12. Проверка палиндрома");
            Console.WriteLine("13. Камень, ножницы, бумага");
            Console.WriteLine("14. Угадай число (7 попыток)");
            Console.WriteLine("15. Мини-система студентов");
            Console.WriteLine("0. Выход");
            Console.Write("\nВведите номер задачи: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
                continue;

            if (choice == 0) break;

            Console.WriteLine("\n-------------------------------------------");

            switch (choice)
            {
                case 1:
                    Task1_Factorial();
                    break;
                case 2:
                    Task2_DigitCount();
                    break;
                case 3:
                    Task3_DigitSum();
                    break;
                case 4:
                    Task4_ReverseNumber();
                    break;
                case 5:
                    Task5_IsPrime();
                    break;
                case 6:
                    Task6_PrimesUpToN();
                    break;
                case 7:
                    Task7_GCD();
                    break;
                case 8:
                    Task8_ArrayAverage();
                    break;
                case 9:
                    Task9_SecondMax();
                    break;
                case 10:
                    Task10_ReverseArray();
                    break;
                case 11:
                    Task11_CountVowels();
                    break;
                case 12:
                    Task12_IsPalindrome();
                    break;
                case 13:
                    Task13_RockPaperScissors();
                    break;
                case 14:
                    Task14_GuessNumber();
                    break;
                case 15:
                    Task15_StudentSystem();
                    break;
                default:
                    Console.WriteLine("Неверный номер задачи.");
                    break;
            }

            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню...");
            Console.ReadKey();
        }
    }

    // 1. Факториал числа
    static void Task1_Factorial()
    {
        Console.Write("Введите N: ");
        int n = int.Parse(Console.ReadLine());

        long result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }

        Console.WriteLine($"Факториал: {result}");
    }

    // 2. Количество цифр в числе
    static void Task2_DigitCount()
    {
        Console.Write("Введите число: ");
        int number = int.Parse(Console.ReadLine());

        int count = 0;
        int temp = Math.Abs(number);

        if (temp == 0)
        {
            count = 1;
        }
        else
        {
            while (temp > 0)
            {
                count++;
                temp /= 10;
            }
        }

        Console.WriteLine($"Количество цифр: {count}");
    }

    // 3. Сумма цифр числа
    static void Task3_DigitSum()
    {
        Console.Write("Введите число: ");
        int number = int.Parse(Console.ReadLine());

        int sum = 0;
        int temp = Math.Abs(number);

        while (temp > 0)
        {
            sum += temp % 10;
            temp /= 10;
        }

        Console.WriteLine($"Сумма цифр: {sum}");
    }

    // 4. Перевернуть число
    static void Task4_ReverseNumber()
    {
        Console.Write("Введите число: ");
        int number = int.Parse(Console.ReadLine());

        int reversed = 0;
        int temp = Math.Abs(number);

        while (temp > 0)
        {
            int digit = temp % 10;
            reversed = reversed * 10 + digit;
            temp /= 10;
        }

        if (number < 0) reversed = -reversed;

        Console.WriteLine($"Перевернутое число: {reversed}");
    }

    // 5. Проверка простого числа
    static void Task5_IsPrime()
    {
        Console.Write("Введите число: ");
        int number = int.Parse(Console.ReadLine());

        bool isPrime = number > 1;

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
            {
                isPrime = false;
                break;
            }
        }

        if (isPrime)
            Console.WriteLine("Число простое");
        else
            Console.WriteLine("Число не простое");
    }

    // 6. Все простые числа до N
    static void Task6_PrimesUpToN()
    {
        Console.Write("Введите N: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 2; i <= n; i++)
        {
            bool isPrime = true;

            for (int j = 2; j * j <= i; j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                Console.Write(i + " ");
            }
        }
        Console.WriteLine();
    }

    // 7. НОД двух чисел
    static void Task7_GCD()
    {
        Console.Write("Первое число: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Второе число: ");
        int b = int.Parse(Console.ReadLine());

        a = Math.Abs(a);
        b = Math.Abs(b);

        while (b != 0)
        {
            int temp = a % b;
            a = b;
            b = temp;
        }

        Console.WriteLine($"НОД: {a}");
    }

    // 8. Среднее значение массива
    static void Task8_ArrayAverage()
    {
        int[] numbers = { 10, 20, 30, 40, 50 };

        double sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        double average = sum / numbers.Length;

        Console.WriteLine($"Массив: {string.Join(" ", numbers)}");
        Console.WriteLine($"Среднее: {average}");
    }

    // 9. Второе максимальное число массива
    static void Task9_SecondMax()
    {
        int[] numbers = { 15, 8, 27, 10, 21 };

        int max = int.MinValue;
        int secondMax = int.MinValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                secondMax = max;
                max = numbers[i];
            }
            else if (numbers[i] > secondMax && numbers[i] < max)
            {
                secondMax = numbers[i];
            }
        }

        Console.WriteLine($"Массив: {string.Join(" ", numbers)}");
        Console.WriteLine($"Второе максимальное: {secondMax}");
    }

    // 10. Перевернуть массив на месте
    static void Task10_ReverseArray()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };

        Console.WriteLine($"Было: {string.Join(" ", numbers)}");

        for (int i = 0; i < numbers.Length / 2; i++)
        {
            int temp = numbers[i];
            numbers[i] = numbers[numbers.Length - 1 - i];
            numbers[numbers.Length - 1 - i] = temp;
        }

        Console.WriteLine($"Стало: {string.Join(" ", numbers)}");
    }

    // 11. Подсчёт гласных в строке
    static void Task11_CountVowels()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine().ToLower();

        string vowels = "аеёиоуыэюя";
        int count = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (vowels.Contains(input[i]))
            {
                count++;
            }
        }

        Console.WriteLine($"Количество гласных: {count}");
    }

    // 12. Проверка палиндрома
    static void Task12_IsPalindrome()
    {
        Console.Write("Введите слово: ");
        string word = Console.ReadLine().ToLower();

        bool isPalindrome = true;

        for (int i = 0; i < word.Length / 2; i++)
        {
            if (word[i] != word[word.Length - 1 - i])
            {
                isPalindrome = false;
                break;
            }
        }

        if (isPalindrome)
            Console.WriteLine("Палиндром");
        else
            Console.WriteLine("Не палиндром");
    }

    // 13. Камень, ножницы и бумага
    static void Task13_RockPaperScissors()
    {
        string[] options = { "Камень", "Ножницы", "Бумага" };

        Console.WriteLine("Выберите option: 0 - Камень, 1 - Ножницы, 2 - Бумага");
        Console.Write("Ваш выбор: ");
        int userChoice = int.Parse(Console.ReadLine());

        Random rnd = new Random();
        int computerChoice = rnd.Next(0, 3);

        Console.WriteLine($"Ваш выбор: {options[userChoice]}");
        Console.WriteLine($"Компьютер: {options[computerChoice]}");

        if (userChoice == computerChoice)
        {
            Console.WriteLine("Ничья!");
        }
        else if ((userChoice == 0 && computerChoice == 1) ||
                 (userChoice == 1 && computerChoice == 2) ||
                 (userChoice == 2 && computerChoice == 0))
        {
            Console.WriteLine("Вы победили!");
        }
        else
        {
            Console.WriteLine("Вы проиграли!");
        }
    }

    // 14. Угадай число — 7 попыток
    static void Task14_GuessNumber()
    {
        Random rnd = new Random();
        int target = rnd.Next(1, 101);
        int maxAttempts = 7;
        bool guessed = false;

        Console.WriteLine("Загадано число от 1 до 100. У вас 7 попыток.");

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            Console.Write($"Попытка {attempt}/{maxAttempts}: ");
            int guess = int.Parse(Console.ReadLine());

            if (guess == target)
            {
                Console.WriteLine($"Вы угадали за {attempt} попыток!");
                guessed = true;
                break;
            }
            else if (guess < target)
            {
                Console.WriteLine("Загаданное число больше.");
            }
            else
            {
                Console.WriteLine("Загаданное число меньше.");
            }
        }

        if (!guessed)
        {
            Console.WriteLine($"Попытки закончились. Загаданное число было: {target}");
        }
    }

    // 15. Мини-система студентов
    static void Task15_StudentSystem()
    {
        Console.Write("Введите количество студентов: ");
        int count = int.Parse(Console.ReadLine());

        string[] names = new string[count];
        double[] scores = new double[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Имя студента {i + 1}: ");
            names[i] = Console.ReadLine();

            Console.Write($"Оценка студента {i + 1}: ");
            scores[i] = double.Parse(Console.ReadLine());
        }

        double sum = 0;
        double maxScore = scores[0];
        int bestIndex = 0;

        for (int i = 0; i < count; i++)
        {
            sum += scores[i];
            if (scores[i] > maxScore)
            {
                maxScore = scores[i];
                bestIndex = i;
            }
        }

        double average = sum / count;

        int aboveAverageCount = 0;
        for (int i = 0; i < count; i++)
        {
            if (scores[i] > average)
            {
                aboveAverageCount++;
            }
        }

        Console.WriteLine("\n--- Результаты ---");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{names[i]} — {scores[i]}");
        }

        Console.WriteLine($"\nСредняя оценка: {average:F1}");
        Console.WriteLine($"Лучший студент: {names[bestIndex]} — {scores[bestIndex]}");
        Console.WriteLine($"Выше среднего: {aboveAverageCount}");
    }
}