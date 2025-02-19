using StudentList;

namespace SubjectList
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Student_count { get; set; }
        public List<Student> Students { get; set; }

        public Course(int id, string name, int student_count)
        {
            Id = id;
            Name = name;
            Student_count = student_count;
            Students = new List<Student>();
        }
    }
}