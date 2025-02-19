using GradeList;
using SubjectList;

namespace StudentList
{
    class Program
    {
        static List<Course> courses = new List<Course>();
        static List<Student> students = new List<Student>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("_______________________________________");
                Console.WriteLine("1. Добавить курс");
                Console.WriteLine("2. Посмотреть курс");
                Console.WriteLine("3. Записать студента на курс"); // ура больше не дубилруется
                Console.WriteLine("4. Показать список студентов на курсе"); 
                Console.WriteLine("5. Удалить студента из курса");
                Console.WriteLine("6. Удалить курс");
                Console.WriteLine("7. Поставить оценку");
                Console.WriteLine("8. Показать оценки студента по предмету");
                Console.WriteLine("9. Выход");
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
                        AddGrade();
                        break;
                    case "8":
                        GradesBySubject();
                        break;
                    case "9":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор, попробуйте снова");
                        break;
                }
            }
        }

        static void AddCourse()
        {
            Console.Write("Введите идентификатор курса: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Введите название курса: ");
            string name = Console.ReadLine();
            Console.Write("Введите вместимость курса: ");
            int capacity = int.Parse(Console.ReadLine());
            courses.Add(new Course(id, name, capacity));
            Console.WriteLine("Курс успешно добавлен.\n");
        }

        static void ViewCourse()
        {
            Console.Write("Введите идентифиикатор курса: ");
            int id = int.Parse(Console.ReadLine());
            Course course = courses.Find(c => c.Id == id);
            if (course != null)
            {
                Console.WriteLine($"\nНаименование курса: '{course.Name}', \nВместимость: {course.Student_count}");
            }
            else
            {
                Console.WriteLine("Курс не найден");
            }
        }

        static void AddStudent()
        {
            Console.Write("Введите идентификатор курса: ");
            int courseId = int.Parse(Console.ReadLine());
            Course course = courses.Find(c => c.Id == courseId);
            if (course != null)
            {
                if (course.Students.Count < course.Student_count)
                {
                    Console.Write("Введите идентификатор студента: ");
                    int studentId = int.Parse(Console.ReadLine());
                    Console.Write("Введите имя студента: ");
                    string name = Console.ReadLine();
                    Student student = students.FirstOrDefault(s => s.Id == studentId);
                    if (student == null)
                    {
                        student = new Student(studentId, name);
                        students.Add(student);
                    }
                    if (!course.Students.Contains(student))
                    {
                        course.Students.Add(student);
                        Console.WriteLine("Студент успешно зачислен на курс\n");
                    }
                    else
                    {
                        Console.WriteLine("Студент уже зачислен на этот курс\n");
                    }
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
            Course course = courses.Find(c => c.Id == courseId);
            if (course != null)
            {
                Console.WriteLine("Список студентов:");
                foreach (var student in course.Students)
                {
                    Console.WriteLine($"ID: {student.Id}, Имя: {student.Name}\n");
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
            Course course = courses.Find(c => c.Id == courseId);
            if (course != null)
            {
                Console.Write("Введите идентификатор студента: ");
                int studentId = int.Parse(Console.ReadLine());
                Student student = course.Students.FirstOrDefault(s => s.Id == studentId);
                if (student != null)
                {
                    course.Students.Remove(student);
                    Console.WriteLine("Студент удален\n");
                }
                else
                {
                    Console.WriteLine("Студент не найден\n");
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
            Course course = courses.Find(c => c.Id == courseId);
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

        static void AddGrade()
        {
            Console.Write("Введите идентификатор студента: ");
            int studentId = int.Parse(Console.ReadLine());
            Student student = students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                Console.Write("Введите предмет (Math, Physics, Chemistry): ");
                string subjectInput = Console.ReadLine();
                if (Enum.TryParse(subjectInput, ignoreCase: true, out Subject subject)) //игнорирование регистра
                {
                    Console.Write("Введите оценку: ");
                    int score = int.Parse(Console.ReadLine());
                    Console.Write("Введите дату (YYYY-MM-DD): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    student.AddGrade(subject, score, date);
                    Console.WriteLine("Оценка успешно добавлена.\n");
                }
                else
                {
                    Console.WriteLine("Неверный предмет.\n");
                }
            }
            else
            {
                Console.WriteLine("Студент не найден.\n");
            }
        }

        static void GradesBySubject()
        {
            Console.Write("Введите идентификатор студента: ");
            int studentId = int.Parse(Console.ReadLine());
            Student student = students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                Console.Write("Введите предмет (Math, Physics, Chemistry: ");
                string subjectInput = Console.ReadLine();
                if (Enum.TryParse(subjectInput, out Subject subject))
                {
                    List<Grade> grades = student.FindGradesBySubject(subject);
                    if (grades.Any())
                    {
                        Console.WriteLine("Оценки студента по предмету:");
                        foreach (var grade in grades)
                        {
                            Console.WriteLine($"Предмет: {grade.Subject}, Оценка: {grade.Score}, Дата: {grade.Date.ToShortDateString()}\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Оценки не найдены.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Неверный предмет.\n");
                }
            }
            else
            {
                Console.WriteLine("Студент не найден.\n");
            }
        }
    }
}
