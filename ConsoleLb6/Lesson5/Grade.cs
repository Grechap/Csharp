using SubjectList;

namespace GradeList
{
    public struct Grade
    {
        public Subject Subject { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }

        public Grade(Subject subject, int score, DateTime date)
        {
            Subject = subject;
            Score = score;
            Date = date;
        }
    }
}
