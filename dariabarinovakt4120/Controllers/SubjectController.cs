using dariabarinovakt4120.Filters;
using dariabarinovakt4120.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dariabarinovakt4120.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectController : Controller
    {
        private readonly ILogger<SubjectController> _logger;
        private readonly ISubjectService _subjectService;

        public SubjectController(ILogger<SubjectController> logger, ISubjectService subjectService)
        {
            _logger = logger;
            _subjectService = subjectService;
        }

        [HttpPost(Name = "GetSubjectBySpec")]

        public async Task<IActionResult> GetSubjectBySpecAsync(SubjectSpecFilter filter, CancellationToken cancellationToken = default)
        {
            var subject = await _subjectService.GetSubjectBySpecAsync(filter, cancellationToken);
            return Ok(subject);
        }
    }

}
