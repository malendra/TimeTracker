using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeSheetDAL;

namespace TimesheetApi.Data
{
    public class ClientJobDb
    {
        private TimeSheetEntities db = new TimeSheetEntities();

        public ClientJob Add(Guid clientId,Guid jobId )
        {
            var id = Guid.NewGuid();
            var clientJob = new ClientJob{ClientJobId = id, JobId = jobId, ClientId = clientId};

            clientJob = db.ClientJobs.Add(clientJob);

            db.SaveChanges();

            return clientJob;
        }

    }
}