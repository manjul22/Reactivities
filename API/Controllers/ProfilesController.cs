using System.Threading.Tasks;
using Application.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProfilesController : BaseApiController
    {
        [HttpGet("{username}")]
        public async Task<IActionResult> GetProfile(string userName)
        {
            return HandleResult(await Mediator.Send(new Details.Query { UserName = userName }));
        }

        [HttpGet("{username}/activities")]
        public async Task<IActionResult> GetUserActivities(string userName,string predicate)
        {
            return HandleResult(await Mediator.Send(new ListActivities.Query
            { UserName = userName, Predicate = predicate }));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Edit.Command command)
        {
            return HandleResult(await Mediator.Send(command));
        }
    }
}