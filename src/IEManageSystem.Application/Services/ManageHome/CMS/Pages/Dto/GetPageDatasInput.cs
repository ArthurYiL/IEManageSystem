﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IEManageSystem.Services.ManageHome.CMS.Pages.Dto
{
    public class GetPageDatasInput
    {
        [Range(1, 99999999)]
        public int PageIndex { get; set; }

        [Range(1, 99999999)]
        public int PageSize { get; set; }

        public int Top { get; set; }

        public string SearchKey { get; set; }

        public bool EnablePageFilter { get; set; }

        /// <summary>
        /// EnablePageFilter 为 true，则给字段生效
        /// </summary>
        public List<string> FilterPageNames { get; set; }

        public List<string> Tags { get; set; }

        public string Orderby { get; set; }

        public bool IsScore() => Orderby == "Score";

        public bool IsClick() => Orderby == "Click";

        public bool IsDate() => Orderby == "Date";

        public string PageName { get; set; }
    }
}
