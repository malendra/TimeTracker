using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TimesheetApi.Data;
using TimesheetApi.dto;
using TimeSheetDAL;

namespace TimesheetApi.Controllers
{
    public class JobController : ApiController
    {
        
        //// GET api/Job
        //public IQueryable<TimeSheetDetail> GetTimeSheetDetails()
        //{
        //    return db.TimeSheetDetails;
        //}

        //// GET api/Job/5
        //[ResponseType(typeof(TimeSheetDetail))]
        //public IHttpActionResult GetTimeSheetDetail(Guid id)
        //{
           

        //    return Ok(timesheetdetail);
        //}

        // PUT api/Job/5
        //public IHttpActionResult PutTimeSheetDetail(Guid id, TimeSheetDetail timesheetdetail)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != timesheetdetail.TimeSheetId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(timesheetdetail).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TimeSheetDetailExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST api/Job
        
        
        [HttpPost]
        [EnableCors(origins: "http://localhost:50191", headers: "*", methods: "*")]
        public void PostTimeSheetDetail(PostJobDto dto )
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var  db = new TimeSheetDb();
            var timeSheet = db.SaveTimeSheet(dto);

            //return CreatedAtRoute("DefaultApi", new { id = timeSheet.TimeSheetId }, timeSheet);
        }

        [HttpGet]
        public List<GetTimeSheetDto> PostTimeSheetDetail(Guid userId)
        {
           

            var db = new TimeSheetDb();
            var timeSheets = db.GetTimeSheetByUserId(userId);

            var list = new List<GetTimeSheetDto>();


            foreach (var timeSheet in timeSheets)
            {
                list.Add(new GetTimeSheetDto{ Remarks = timeSheet.Comments, 
                    Starttime = timeSheet.StartTime, 
                    Stoptime = timeSheet.StopTime, Workcode = timeSheet.WorkCode.Code });
            }

            return list;
        }


        //// DELETE api/Job/5
        //[ResponseType(typeof(TimeSheetDetail))]
        //public IHttpActionResult DeleteTimeSheetDetail(Guid id)
        //{
        //    TimeSheetDetail timesheetdetail = db.TimeSheetDetails.Find(id);
        //    if (timesheetdetail == null)
        //    {
        //        return NotFound();
        //    }

        //    db.TimeSheetDetails.Remove(timesheetdetail);
        //    db.SaveChanges();

        //    return Ok(timesheetdetail);
        //}

       

    
    }
}