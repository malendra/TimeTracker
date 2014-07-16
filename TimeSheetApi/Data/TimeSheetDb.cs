using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeSheetDAL;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TimesheetApi.dto;
using System.Web.Http.Results;

namespace TimesheetApi.Data
{
    public class TimeSheetDb : IDisposable
    {
        private TimeSheetEntities db = new TimeSheetEntities();

        public TimeSheetDetail SaveTimeSheet(PostJobDto dto)
        {
            ClientJobDb clientJobDb = new ClientJobDb();
            var clientJob = clientJobDb.Add(dto.ClientId, dto.JobId);

            var timesheetdetail = new TimeSheetDetail
            {
                TimeSheetId = Guid.NewGuid(),
                StartTime =  DateTime.Today.Add(new TimeSpan(dto.StartTime.Hour,dto.StartTime.Minute,dto.StartTime.Second)),
                StopTime = DateTime.Today.Add(new TimeSpan(dto.StopTime.Hour,dto.StopTime.Minute,dto.StopTime.Second)),
                ClientJobId =  clientJob.ClientJobId,
                Comments = dto.Comments,
                UserId = dto.UserId,
                UnitId = dto.UnitId,
                WorkCodeId = dto.WorkCodeId
            };

            db.TimeSheetDetails.Add(timesheetdetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                if (TimeSheetDetailExists(timesheetdetail.TimeSheetId))
                {
                    throw new DbUpdateException("timeSheetExist");
                }
                else
                {
                    throw ex;
                }
            }

            return timesheetdetail; 
            
        }

        public List<TimeSheetDetail>  GetTimeSheetByUserId(Guid userId )
        {
            var timesheetdetail = db.TimeSheetDetails.Where(t => t.UserId == userId).ToList();
            if (timesheetdetail == null)
            {
                return null;
            }
            return timesheetdetail;
        }

        private bool TimeSheetDetailExists(Guid id)
        {
            return db.TimeSheetDetails.Count(e => e.TimeSheetId == id) > 0;
        }

         


         public void Dispose()
         {
             if (db != null)
             {
                 db.Dispose();
             }
             
         }
    }
}