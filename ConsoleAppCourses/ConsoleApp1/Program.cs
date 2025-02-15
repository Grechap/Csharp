using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int id_student { get; set; } 
    public string name { get; set; }

    public Student(int id_student, string name)
    {
        this.id_student = id_student;
        this.name = name;
    }


}
class Course
    {
    public int id_course { get; set; }
    public string name { get; set; }
    public int students_count { get; set; }
    public List<Student> students { get; set; }

    public Course(int id_course, string name, int students_count, List<Student> students)
    {
        this.id_course = id_course;
        this.name = name;
        this.students_count = students_count;
        this.students = students;
    }
}

class Program
{
    static List<Course> courses = new List<Course>();
    static List<Student> students = new List<Student>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Добавить курс");
            Console.WriteLine("2. Посмотреть курс");
            Console.WriteLine("3. Записать студента на курс");
            Console.WriteLine("4. Показать список студентов на курсе");
            Console.WriteLine("5. Удалить студента из курса");
            Console.WriteLine("6. Удалить курс");
            Console.WriteLine("7. Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddCourse();
                    break;
                 case "2":
                    ViewCourse();
                    break;
                case "3":
                    AddStudent();
                    break;
                case "4":
                    ViewStudents();
                    break;
                case "5":
                    DeleteStudent();
                    break;
                case "6":
                    DeleteCourse();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Неверный выбор, попробуйте снова");
                    break;
                /* case "8":
                    AddCourse();
                    break;*/ 

            }
        }
    }
    static void AddCourse()
    {   
        Console.Write("Введите индентификатор курса: ");
        int id_course = int.Parse(Console.ReadLine());
        Console.Write("Введите название курса: ");
        string name = Console.ReadLine();
        Console.Write("Введите вместимость курса: ");
        int students_count = int.Parse(Console.ReadLine());
        courses.Add(new Course(id_course, name, students_count, students));
        Console.WriteLine("КУрс успешно добавлен. \n");

    }

    static void ViewCourse()
    {
        Console.Write("Введите идентификатор курса: ");
        int id_course = int.Parse(Console.ReadLine());
        Course course = courses.Find(c => c.id_course == id_course);
        if (course != null)
        {
            Console.WriteLine($"\nНаименование курса: '{course.name}', \nВместимость: {course.students_count}");
        }
        else
        {
            Console.WriteLine("Курс не найден");
        }
    }
    static void AddStudent()
    {
        Console.Write("Введите идентификатор курса: ");
        int id_course = int.Parse(Console.ReadLine());
        Course course = courses.Find(c => c.id_course == id_course);
        if (course != null)
        {
            if (course.students.Count < course.students_count)
            { 
                Console.Write("Введите идентификатор студента: ");
                int id_student = int.Parse(Console.ReadLine());
                Console.Write("Введите имя студента: ");
                string name = Console.ReadLine();
                Student student = students.FirstOrDefault(s => s.id_student == id_student); //LINQ, который возвращает первый элемент последовательности поуказанному условию, или значение по умолчанию.
                if (student == null)
                {
                student = new Student(id_student, name);
                students.Add(student);
                }
                course.students.Add(student);
                Console.WriteLine("Студент успешно зачислен на курс\n"); // студенты дублируются в список =(
            }
            else
            {
                Console.WriteLine("Курс уже набран\n");
            }
        }
        else
        {
            Console.WriteLine("Курс не найден\n");
        }
    }

    static void ViewStudents()
    {
        Console.Write("Введите идентификатор курса: ");
        int courseId = int.Parse(Console.ReadLine());
        Course course = courses.Find(c => c.id_course == courseId);
        if (course != null)
        {
            Console.WriteLine("Список студентов:");
            foreach (var student in course.students)
            {
                Console.WriteLine($"ID: {student.id_student}, Имя: {student.name}\n");
            }
        }
        else
        {
            Console.WriteLine("Курс не найден\n");
        }
    }

    static void DeleteStudent()
    {
        Console.Write("Введите идентификатор курса: ");
        int courseId = int.Parse(Console.ReadLine());
        Course course = courses.Find(c => c.id_course == courseId);
        if (course != null)
        {
            Console.Write("Введите идентификатор студента: ");
            int studentId = int.Parse(Console.ReadLine());
            Student student = course.students.FirstOrDefault(s => s.id_student == studentId);
            if (student != null)
            {
                course.students.Remove(student);
                Console.WriteLine("Студент удален из курса.\n");
            }
            else
            {
                Console.WriteLine("Студент не найден на курсе.\n");
            }
        }
        else
        {
            Console.WriteLine("Курс не найден\n");
        }
    }

    static void DeleteCourse()
    {
        Console.Write("Введите идентификатор курса: ");
        int courseId = int.Parse(Console.ReadLine());
        Course course = courses.Find(c => c.id_course == courseId);
        if (course != null)
        {
            courses.Remove(course);
            Console.WriteLine("Курс удален.\n");
        }
        else
        {
            Console.WriteLine("Курс не найден\n");
        }
    }
}