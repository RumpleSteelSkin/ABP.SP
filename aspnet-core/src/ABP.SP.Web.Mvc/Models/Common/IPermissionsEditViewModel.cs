using ABP.SP.Roles.Dto;
using System.Collections.Generic;

namespace ABP.SP.Web.Models.Common;

public interface IPermissionsEditViewModel
{
    List<FlatPermissionDto> Permissions { get; set; }
}