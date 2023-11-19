namespace dariabarinovakt4120.Tests
{
    public class SubjectTests
    {
        [Fact]
        public void IsValidSubject_KT4120_True()
        {
            var testSub = new Models.Subject
            {
                SubjectId = 1,
                SubjectName= "Physics",
                DirectionId =2,
                IsDeleted=true
            };

            var result = testSub.IsValidSubject();

            Assert.True(result);

        }
    }
}