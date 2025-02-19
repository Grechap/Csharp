using GradeList;
using SubjectList;

namespace StudentList
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Grade> Grades { get; set; }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
            Grades = new List<Grade>();
        }
        public void AddGrade(Subject subject, int score, DateTime date)
        {
            Grades.Add(new Grade(subject, score, date));
        }
        public List<Grade> FindGradesBySubject(Subject subject)
        {
            return Grades.Where(g => g.Subject == subject).ToList(); //поискоценок по Subject
        }
    }
}
