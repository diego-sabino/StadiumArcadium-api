using Microsoft.AspNetCore.Components;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
public class MemberController : BaseController<Member, MemberServices>
{
    public MemberController(MemberServices memberServices) : base(memberServices)
    {
    }
}