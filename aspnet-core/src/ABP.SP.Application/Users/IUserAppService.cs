using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ABP.SP.Roles.Dto;
using ABP.SP.Users.Dto;
using System.Threading.Tasks;

namespace ABP.SP.Users;

public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
{
    Task DeActivate(EntityDto<long> user);
    Task Activate(EntityDto<long> user);
    Task<ListResultDto<RoleDto>> GetRoles();
    Task ChangeLanguage(ChangeUserLanguageDto input);

    Task<bool> ChangePassword(ChangePasswordDto input);
}
