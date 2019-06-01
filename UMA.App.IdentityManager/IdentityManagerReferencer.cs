using AutoMapper;
using System.Reflection;
using UMA.App.Common.AutoMapper;

namespace UMA.App.IdentityManager
{
    public class IdentityManagerReferencer : Profile
    {
        public IdentityManagerReferencer()
        {
            MapperProfileHelper.AutoMapCustom(this, Assembly.GetExecutingAssembly());
            MapperProfileHelper.AutoMapStandard(this, Assembly.GetExecutingAssembly());
        }

    }
}
