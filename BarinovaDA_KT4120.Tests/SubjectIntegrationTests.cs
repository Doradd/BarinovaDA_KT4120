using dariabarinovakt4120.Database;
using dariabarinovakt4120.Interfaces;
using dariabarinovakt4120.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace dariabarinovakt4120.Tests
{
    public class SubjectIntegrationTests
{
        public readonly DbContextOptions<SubjectDbContext> _dbContextOptions;

        public SubjectIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<SubjectDbContext>()
             .UseInMemoryDatabase(databaseName: "subject_db")
             .Options;
        }

        [Fact]

        public async Task GetSubjectBySpecAsync_KT4120_TwoObjects()
        {
            //Arrange
            var ctx = new SubjectDbContext(_dbContextOptions);
            var subjectService = new SubjectService(ctx);
            var direction = new List<Direction>
            {
                new Direction
                {
                    DirectionId = 1,
                    DirectionName = "Humanitarian"
                },
                new Direction
                {
                    DirectionId = 2,
                    DirectionName = "Technical"
                }
            };
            await ctx.Set<Direction>().AddRangeAsync(direction);

            var subjects = new List<Subject>
            {
                new Subject
                {
                    SubjectName = "Russian language",
                    DirectionId = 1,
                    IsDeleted = true,
                    
                },
                new Subject
                {
                    SubjectName = "Philosophy",
                    DirectionId = 1,
                    IsDeleted = false,
                    
                },
                new Subject
                {
                    SubjectName = "Mathematics",
                    DirectionId = 2,
                    IsDeleted = true,
                  
                }
            };
            await ctx.Set<Subject>().AddRangeAsync(subjects);
            await ctx.SaveChangesAsync();

            //Act
            var filter = new Filters.SubjectSpecFilter
            {
                Directionname = "Humanitarian",
                IsDeleted = false
            };
            var subjectResult = await subjectService.GetSubjectBySpecAsync(filter, CancellationToken.None);

            //Assert
            Assert.Single( subjectResult);
        }

    }
}
