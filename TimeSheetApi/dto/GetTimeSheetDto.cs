using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimesheetApi.dto
{
    public class GetTimeSheetDto
    {
        public DateTime Starttime { get; set; }	
        public DateTime Stoptime { get; set; }	
        public string Workcode {get;set;}
        public string Remarks { get; set; }

    }
}