using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP.FunOA.DailyWorks.Dto
{
    public class PagedDailyWorkResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }

        public bool? isPublished { get; set; }

        public string UserName { get; set; }
        public long UserId { get; set; }
    }
}
