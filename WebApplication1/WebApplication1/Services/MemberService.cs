using Microsoft.Extensions.Options;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class MemberService : BaseService<Member>, IService<Member>
{
    public MemberService(IOptions<DBSettings> dbSettings)
        : base(dbSettings, dbSettings.Value.MemberCollectionName)
    {
    }
}