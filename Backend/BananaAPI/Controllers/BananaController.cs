using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BananaAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BananaController : ControllerBase
  {
    private static readonly List<Group> Groups = [
        new Group { Id = 1, Members = []}
      ];

    [HttpPost("join")]
    public ActionResult<Group> JoinGroup([FromBody]string Name)
    {
      if (Name == "")
      {
        return BadRequest("Invalid Name.");
      }

      bool IsCurrentGroupFull = Groups.FirstOrDefault(g => g.Id == Groups.Count)!.IsFull();

      if (IsCurrentGroupFull)
      {
        Group NewGroup = new() { Id = Groups.Count + 1, Members = [Name] };
        Groups.Add(NewGroup);
      }

      Groups.FirstOrDefault(g => g.Id == Groups.Count)!.AddMember(Name);

      return Ok(Groups.FirstOrDefault(g => g.Id == Groups.Count));
    }

    [HttpGet("group/{GroupId}")]
    public ActionResult<int> GetCount(int GroupId)
    {
      if (GroupId <= 0 && GroupId > Groups.Count)
      {
        return BadRequest("Invalid group ID.");
      }

      int Count = Groups.FirstOrDefault(g => g.Id == GroupId)!.Count;
      return Ok(Count);
    }

    [HttpPut("group")]
    public ActionResult<int> UpdateCount([FromBody]int GroupId)
    {
      if (GroupId <= 0 && GroupId > Groups.Count)
      {
        return BadRequest("Invalid group ID.");
      }

      int Count = Groups.FirstOrDefault(g => g.Id == GroupId)!.Increment();
      return Ok(Count);
    }
  }
}
