using System;
using System.Collections;
using System.Collections.Generic;

namespace NotebookApp
{
    class Notebook
    {

        static void Main(string[] args)
        {
            Console.WriteLine("ТЕЛЕФОННАЯ КНИЖКА");
            List<Note> noteList = new List<Note>();
            helpInformation();

            while (true)
            {
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "new":
                        CreateNewNote(ref noteList);
                        break;
                    case "edit":
                        EditNote(ref noteList);
                        break;
                    case "delete":
                        DeleteNote(ref noteList);
                        break;
                    case "showAll":
                        ShowAllNotes(ref noteList);
                        break;
                    case "show":
                        ReadNote(ref noteList);
                        break;
                    case "exit":
                        System.Environment.Exit(0);
                        break;
                    case "help":
                        helpInformation();
                        break;
                    default:
                        Console.WriteLine("Нет такой команды.");
                        Console.WriteLine("Введите 'help' для списка всех команд.");
                        break;
                }
            }
        }

        public static void CreateNewNote(ref List<Note> nList)
        {
            Console.WriteLine("* - обязательное поле");
            bool check = true;
            string lastName = "";
            while (check) {
                Console.Write("Фамилия*: ");
                lastName = Console.ReadLine();
                if (lastName == "")
                    Console.WriteLine("Это обязательное поле!!!");
                else
                    check = false;
            }
            check = true;
            string name = "";
            while(check) { 
                Console.Write("Имя*: ");
                name = Console.ReadLine();
                if(name == "")
                    Console.WriteLine("Это обязательное поле!!!");
                else
                    check = false;
            }
            Console.Write("Отчество: ");
            string patronymic = Console.ReadLine();
            int num;
            bool isNum = false;
            int number = 0;
            while (!isNum)
            {
            Console.Write("Номер телефона(только цифры)*: ");
            string str = Console.ReadLine();
            isNum = int.TryParse(str, out num);
                if(!isNum)
                Console.WriteLine("Необходимо ввести только цифры");
                else { 
                    number = Convert.ToInt32(str);
                    isNum = true;
                }
            }
            check = true;
            string country = "";
            while (check) { 
                Console.Write("Страна*: ");
                country = Console.ReadLine();
                if(country == "")
                    Console.WriteLine("Это обязательное поле!!!");
                else
                    check = false;
            }
            Console.Write("Дата рождения: ");
            string birthDate = Console.ReadLine();
            Console.Write("Организация: ");
            string organization = Console.ReadLine();
            Console.Write("Должность: ");
            string jobPosition = Console.ReadLine();
            Console.Write("Прочие заметки: ");
            string otherNotes = Console.ReadLine();

            nList.Add(new Note(name, lastName, number, country, birthDate, patronymic, organization, jobPosition, otherNotes));
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Новая запись создана");
            Console.WriteLine("------------------------------------");
        }
        public static void EditNote(ref List<Note> nList)
        {
            Console.Write("Введите ID строки для чтения: ");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (Note item in nList)
            {
                if (id == item.idNote)
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine(item);
                    Console.WriteLine("Нажимайте пробел, если поле менять не нужно");            
                    
                    Console.Write("Фамилия*: ");
                    string lastName = Console.ReadLine();
                    if (lastName != "")
                        item.lastName = lastName;
                    Console.Write("Имя*: ");
                    string name = Console.ReadLine();
                    if (name != "")
                        item.name = name;
                    Console.Write("Отчество: ");
                    string patronymic = Console.ReadLine();
                    if (patronymic != "")
                        item.patronymic = patronymic;
                    Console.Write("Номер телефона(только цифры)*: ");
                     string str = Console.ReadLine();
                     int number = Convert.ToInt32(str);
                     item.number = number;
                    Console.Write("Страна*: ");
                    string country = Console.ReadLine();
                    if (country != "")
                        item.country = country;
                    Console.Write("Дата рождения: ");
                    string birthDate = Console.ReadLine();
                    if (birthDate != "")
                        item.birthDate = birthDate;
                    Console.Write("Организация: ");
                    string organization = Console.ReadLine();
                    if (organization != "")
                        item.organization = organization;
                    Console.Write("Должность: ");
                    string jobPosition = Console.ReadLine();
                    if (jobPosition != "")
                        item.jobPosition = jobPosition;
                    Console.Write("Прочие заметки: ");
                    string otherNotes = Console.ReadLine();
                    if (otherNotes != "")
                        item.otherNotes = otherNotes;
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Запись обновлена");
                    Console.WriteLine("------------------------------------");
                }
            }
        }
        public static void DeleteNote(ref List<Note> nList)
        {
            Console.Write("Введите ID записи для удаления: ");
            int id = Convert.ToInt32(Console.ReadLine());
            nList.RemoveAt(id);
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Запись была удалена");
            Console.WriteLine("------------------------------------");

        }
        public static void ReadNote(ref List<Note> nList)
        {
            Console.Write("Введите ID строки для чтения: ");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (Note item in nList)
            {
                if(id==item.idNote)
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine(item);
                    Console.WriteLine("------------------------------------");
                }
            }
        }
        public static void ShowAllNotes(ref List<Note> nList)
        {
            Console.WriteLine("------------------------------------");
            foreach (Note item in nList)
            {
                Console.WriteLine($"ID: {item.idNote}  Фамилия: {item.lastName}  Имя: {item.name}  Номер телефона: {item.number}");
            }
            Console.WriteLine("------------------------------------");
        }

        public static void helpInformation()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Для открытия списка команд введите: help");
            Console.WriteLine("Для создания новой записи введите: new");
            Console.WriteLine("Для редактирования созданных записей введите: edit");
            Console.WriteLine("Для удаления созданных записей введите: delete");
            Console.WriteLine("Для просмотра созданной учетной записи введите: show");
            Console.WriteLine("Для просмотра ВСЕХ учетных записей введите: showAll");
            Console.WriteLine("Для выхода из записной книжки введите: exit");
            Console.WriteLine("------------------------------------");
        }
    }


    public class Note
    {
        public static int count = 0;
        public int idNote;
        public string name;
        public string lastName;
        public string patronymic;
        public int number;
        public string country;
        public string birthDate;
        public string organization;
        public string jobPosition;
        public string otherNotes;

        public Note(string name, string lastName, int number, string country, string patronymic = "-", string birthDate = "-", string organization = "-", string jobPosition = "-", string otherNotes = "-")
        {
            this.name = name;
            this.lastName = lastName;
            this.patronymic = patronymic;
            this.number = number;
            this.country = country;
            this.birthDate = birthDate;
            this.organization = organization;
            this.jobPosition = jobPosition;
            this.otherNotes = otherNotes;
            idNote = count++;
        }

        public override string ToString()
        {
            return $"Фамилия: {this.lastName}  Имя: {this.name}  Отчество: {this.patronymic}  Номер телефона: {this.number}  Старана: {this.country}  Дата рождения: {this.birthDate}  Организация: {this.organization}  Должность: {this.jobPosition}  Прочие заметки: {this.otherNotes}";
        }

    }
}
