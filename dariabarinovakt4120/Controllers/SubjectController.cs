using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using dariabarinovakt4120.Interfaces;
using dariabarinovakt4120.Filters;

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
