using Microsoft.Extensions.Options;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class MemberServices : BaseServices<Member>, IService<Member>
{
    public MemberServices(IOptions<DBSettings> dbSettings)
        : base(dbSettings, dbSettings.Value.MemberCollectionName)
    {
    }
}