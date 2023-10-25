using System;
using System.Collections.Generic;

class Note
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }

    public Note(string title, string description, DateTime date)
    {
        Title = title;
        Description = description;
        Date = date;
    }
}

class DailyPlanner
{
    private List<Note> notes = new List<Note>();
    private DateTime currentDate = new DateTime(2023, 10, 24);

    public void Run()
    {
        InitializeNotes();
        ConsoleKeyInfo keyInfo;

        do
        {
            Console.Clear();
            DisplayMenu();

            keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    DecrementSelectedDate();
                    break;
                case ConsoleKey.RightArrow:
                    IncrementSelectedDate();
                    break;
                case ConsoleKey.Enter:
                    DisplayNoteDetails();
                    break;
                case ConsoleKey.N:
                    AddNewNote();
                    break;
            }
        } while (keyInfo.Key != ConsoleKey.Escape);
    }

    private void InitializeNotes()
    {
        notes.Add(new Note("Пойти на пары", "Ну тут чиста mathematic, englishetic, philosophic и остальное ик", new DateTime(2023, 10, 27)));
        notes.Add(new Note("Регнуть в доту", "-30 птс enjoyer", new DateTime(2023, 10, 30)));
        notes.Add(new Note("Поспать", "люто поспать", new DateTime(2023, 10, 29)));
        notes.Add(new Note("Люто покодить", "ЧТО ТАКОЕ ВАША МАТРИЦА А?!?!?!", new DateTime(2023, 10, 25)));
        notes.Add(new Note("Навернуть пельменей", "Ооаоаоаоао пельмешкь", new DateTime(2023, 10, 23)));
    }

    private void DisplayMenu()
    {
        Console.WriteLine("Ежедневник");
        Console.WriteLine("Используйте стрелки влево/вправо для выбора даты");
        Console.WriteLine("Нажмите Enter для просмотра заметки");
        Console.WriteLine("Нажмите N для добавления новой записи");
        Console.WriteLine("Нажмите Escape для выхода");

        Console.WriteLine();
        Console.WriteLine("Выбранная дата: " + currentDate.ToString("dd.MM.yyyy"));

        Console.WriteLine("Заметки на выбранную дату:");

        foreach (var note in notes)
        {
            if (note.Date == currentDate)
            {
                Console.WriteLine("-> " + note.Title);
            }
        }
    }

    private void DecrementSelectedDate()
    {
        currentDate = currentDate.AddDays(-1);
    }

    private void IncrementSelectedDate()
    {
        currentDate = currentDate.AddDays(1);
    }

    private void DisplayNoteDetails()
    {
        Console.Clear();
        Console.WriteLine($"Заметки на {currentDate.ToString("dd.MM.yyyy")}:");

        foreach (var note in notes)
        {
            if (note.Date == currentDate)
            {
                Console.WriteLine($"Название: {note.Title}");
                Console.WriteLine($"Дата: {note.Date.ToString("dd.MM.yyyy")}");
                Console.WriteLine($"Описание: {note.Description}");
                Console.WriteLine();
            }
        }

        Console.WriteLine("Нажмите Enter для возврата в меню");
        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
    }

    private void AddNewNote()
    {
        Console.Clear();
        Console.Write("Введите название: ");
        string title = Console.ReadLine();

        Console.Write("Введите описание: ");
        string description = Console.ReadLine();

        Console.Write("Введите дату (в формате dd.MM.yyyy): ");
        string dateString = Console.ReadLine();
        DateTime date;

        if (DateTime.TryParseExact(dateString, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out date))
        {
            notes.Add(new Note(title, description, date));
        }
        else
        {
            Console.WriteLine("Ошибка: Неверный формат даты.");
        }

        Console.WriteLine("Заметка добавлена. Нажмите Enter для продолжения.");
        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
    }
}

class Program
{
    static void Main(string[] args)
    {
        DailyPlanner planner = new DailyPlanner();
        planner.Run();
    }
}