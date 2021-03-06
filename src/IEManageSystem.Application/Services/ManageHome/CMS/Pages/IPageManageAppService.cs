﻿using Abp.Application.Services;
using IEManageSystem.Services.ManageHome.CMS.Pages.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IEManageSystem.Services.ManageHome.CMS.Pages
{
    public interface IPageManageAppService: IApplicationService
    {
        AddPageOutput AddPage(AddPageInput input);

        DeletePageOutput DeletePage(DeletePageInput input);

        UpdatePageOutput UpdatePage(UpdatePageInput input);

        UpdateContentPagePermissionOutput UpdateContentPagePermission(UpdateContentPagePermissionInput input);
    }
}
