using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BananaAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BananaController : ControllerBase
  {
    private static List<Group> Groups = [
        new Group { Id = 1, Members = []}
      ];

    [HttpPost("join")]
    public ActionResult<Group> JoinGroup([FromBody]string Name)
    {
      bool res = Groups.FirstOrDefault(g => g.Id == Groups.Count).AddMember(Name);

      if (!res)
      {
        Group NewGroup = new() { Id = Groups.Count + 1, Members = [Name] };
        Groups.Add(NewGroup);
      }

      return Ok(Groups.FirstOrDefault(g => g.Id == Groups.Count));
    }

    [HttpGet("group/{GroupId}")]
    public ActionResult<int> GetCount(int GroupId)
    {
      int Count = Groups.FirstOrDefault(g => g.Id == GroupId).Count;
      return Ok(Count);
    }

    [HttpPut("group")]
    public ActionResult<int> UpdateCount([FromBody]int GroupId)
    {
      int Count = Groups.FirstOrDefault(g => g.Id == GroupId).Increment();
      return Ok(Count);
    }
  }
}
