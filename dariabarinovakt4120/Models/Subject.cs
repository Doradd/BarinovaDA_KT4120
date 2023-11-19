using System.Text.RegularExpressions;

namespace dariabarinovakt4120.Models
{
    public class Subject //предметы
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int? DirectionId { get; set; }
        public bool ? IsDeleted { get; set; }
        public Direction? Direction { get; set; }
        public bool IsValidSubject()
        { return Regex.Match(SubjectName, @"\S+\w*\s{1}\w{1}.\w{1}.$").Success; }

    }
}
