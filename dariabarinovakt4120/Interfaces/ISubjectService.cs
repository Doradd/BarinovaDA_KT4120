using dariabarinovakt4120.Database;
using dariabarinovakt4120.Filters;
using dariabarinovakt4120.Models;
using Microsoft.EntityFrameworkCore;


namespace dariabarinovakt4120.Interfaces
{
    public interface ISubjectService
    {
        public Task<Subject[]> GetSubjectBySpecAsync(SubjectSpecFilter filter, CancellationToken cancellationToken);
    }
    public class SubjectService : ISubjectService
    {

        private readonly SubjectDbContext _dbContext;

        public SubjectService(SubjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Subject[]> GetSubjectBySpecAsync(SubjectSpecFilter filter, CancellationToken cancellationToken = default)
        {
            var subject = _dbContext.Set<Subject>().Where( d => d.Direction.DirectionName == filter.Directionname && d.IsDeleted == filter.IsDeleted).ToArrayAsync(cancellationToken);
            return subject;
        }


    }
}