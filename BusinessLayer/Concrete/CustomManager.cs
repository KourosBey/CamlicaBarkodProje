using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.SharedModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ef6 = System.Data.Entity;

namespace BusinessLayer.Concrete
{
    public class CustomManager
    {
        IJobDal _jobDal;
        ILogCallDal _logCallDal;
        IWorkerDal _workerDal;

        public CustomManager()
        {
            _jobDal = new EFJobsRepository();
            _logCallDal = new EFLogCallRepository();
            _workerDal = new EFWorkerRepository();

        }

        public List<WorkerStatus> workerStatusa()
        {
            using (Context c=new Context()) { 
            List<WorkerStatus> result = new List<WorkerStatus>();


                var statusWorker =(from firsTable in
                         // SuccesCount
                        (from firstlogs in c.logCalls
                         join firstJobs in c.Jobs
                         on firstlogs.LogCallID equals firstJobs.LogCallID
                         join firstWorker in c.Worker
                         on firstlogs.WorkerID equals firstWorker.WorkerID
                         where firstJobs.CurrentStatus == "Çözüldü" group firstWorker by firstWorker.WorkerName into z
                         select new
                         {
                             firstSuccesWNmame = z.Key,
                             firstSuccesCount = z.Count(),
                             

                         }) 
                           // ALL COUNT
                         join secondTable in
                        ( from secondLogs in c.logCalls 
                          join secondJobs in c.Jobs 
                          on secondLogs.LogCallID equals secondJobs.LogCallID
                          join secondWorker in c.Worker 
                          on secondLogs.WorkerID equals secondWorker.WorkerID group secondWorker by secondWorker.WorkerName into g
                          select new
                          {
                              secondAllJobWorkerName= g.Key,
                              seconAllJobCount=g.Count(),


                          }  
                          )
                        on firsTable.firstSuccesWNmame equals secondTable.secondAllJobWorkerName
                     
                        select new
                        {
                            compileWorkerName= firsTable.firstSuccesWNmame,
                            compileSuccesJob= firsTable.firstSuccesCount,
                            compileAllJob= secondTable.seconAllJobCount

                        }).ToList(); 

                foreach(var status in statusWorker)
                {
                    result.Add(new WorkerStatus { workerName = status.compileWorkerName, succesLog = status.compileSuccesJob, logCount = status.compileAllJob });
                }

            return result;

            }
            //using (var c = new Context())
            //using (var command = c.Database.GetDbConnection().CreateCommand())
            //{
            //    int index = 0;
            //    command.CommandText = "select allJobList.WorkerName,allJobList.allJob,succesJobs.succesJobCount from(select logWorkers.WorkerName, count(logWorkers.WorkerName) as allJob from logCalls,(select LogCallID, logcalls.WorkerID, WorkerName from logCalls, Worker where logCalls.WorkerID = Worker.WorkerID) as logWorkers,(select logCalls.LogCallID,Jobs.JobID,Jobs.CurrentStatus from logCalls,Jobs  where Jobs.LogCallID = logCalls.LogCallID) as logJobswhere logCalls.LogCallID = logWorkers.LogCallID and logCalls.LogCallID = logJobs.LogCallID group by logWorkers.WorkerName)as allJobList,(select Worker.WorkerName,count(logCalls.LogCallID) as succesJobCount from logCalls, Jobs, Worker where logCalls.LogCallID = Jobs.LogCallID and Jobs.CurrentStatus = 'Çözüldü' and logCalls.WorkerID = Worker.WorkerID group by Worker.WorkerName) as succesJobs where succesJobs.WorkerName = allJobList.WorkerName";
            //    c.Database.OpenConnection();
            //    using(  var result = command.ExecuteReader())
            //    {while (result.Read())
            //        {

            //            WorkerStatus _freshWorkerStatus = new WorkerStatus();
            //            _freshWorkerStatus.workerName= result


            //            index++;
            //        }





            //    }

        }

        public  List<WorkerStatus> workerStatusWithDate(string choose)
        {
            using (Context c = new Context())
            {
                List<WorkerStatus> result = new List<WorkerStatus>();



                var dateRow = DateTime.Now.Day;
                var dateRowMonth = DateTime.Now.Month;
                var dateRowYear = DateTime.Now.Year;
                if (choose == "1")
                {
                   
                    var statusWorker = (from firsTable in
                        // SuccesCount
                        (from firstlogs in c.logCalls
                         join firstJobs in c.Jobs
                         on firstlogs.LogCallID equals firstJobs.LogCallID
                         join firstWorker in c.Worker
                         on firstlogs.WorkerID equals firstWorker.WorkerID
                         where firstJobs.CurrentStatus == "Çözüldü" && firstJobs.CreatedDay.Day >= dateRow-1 && firstJobs.CreatedDay.Month == dateRowMonth && firstJobs.CreatedDay.Year == dateRowYear
                         group firstWorker by firstWorker.WorkerName into z
                         select new
                         {
                             firstSuccesWNmame = z.Key,
                             firstSuccesCount = z.Count(),

                         })
                                            // ALL COUNT
                                        join secondTable in
                                       (from secondLogs in c.logCalls
                                        join secondJobs in c.Jobs
                             on secondLogs.LogCallID equals secondJobs.LogCallID
                                        join secondWorker in c.Worker
                             on secondLogs.WorkerID equals secondWorker.WorkerID
                             where secondJobs.CreatedDay.Day >= dateRow-1 && secondJobs.CreatedDay.Month >= dateRowMonth && secondJobs.CreatedDay.Year >= dateRowYear
                                        group secondWorker by secondWorker.WorkerName into g
                                        select new
                                        {
                                            secondAllJobWorkerName = g.Key,
                                            seconAllJobCount = g.Count(),


                                        })

                                       on firsTable.firstSuccesWNmame equals secondTable.secondAllJobWorkerName
                                        select new
                                        {
                                            compileWorkerName = firsTable.firstSuccesWNmame,
                                            compileSuccesJob = firsTable.firstSuccesCount,
                                            compileAllJob = secondTable.seconAllJobCount

                                        }).ToList();
                    foreach (var status in statusWorker)
                    {
                        result.Add(new WorkerStatus { workerName = status.compileWorkerName, succesLog = status.compileSuccesJob, logCount = status.compileAllJob });
                    }
                }
                else if (choose == "2")
                {
                 

                    var statusWorker = (from firsTable in
                            // SuccesCount
                            (from firstlogs in c.logCalls
                             join firstJobs in c.Jobs
                             on firstlogs.LogCallID equals firstJobs.LogCallID
                             join firstWorker in c.Worker
                             on firstlogs.WorkerID equals firstWorker.WorkerID
                             where firstJobs.CurrentStatus == "Çözüldü" && firstJobs.CreatedDay.Month >= dateRowMonth-1  && firstJobs.CreatedDay.Year >= dateRowYear-1
                             group firstWorker by firstWorker.WorkerName into z
                             select new
                             {
                                 firstSuccesWNmame = z.Key,
                                 firstSuccesCount = z.Count(),

                             })
                                            // ALL COUNT
                                        join secondTable in
                                       (from secondLogs in c.logCalls
                                        join secondJobs in c.Jobs
                             on secondLogs.LogCallID equals secondJobs.LogCallID
                                        join secondWorker in c.Worker
                             on secondLogs.WorkerID equals secondWorker.WorkerID
                                        where secondJobs.CreatedDay.Month >= dateRowMonth-1 && secondJobs.CreatedDay.Year >= dateRowYear - 1
                                        group secondWorker by secondWorker.WorkerName into g
                                        select new
                                        {
                                            secondAllJobWorkerName = g.Key,
                                            seconAllJobCount = g.Count(),


                                        })

                                       on firsTable.firstSuccesWNmame equals secondTable.secondAllJobWorkerName
                                        select new
                                        {
                                            compileWorkerName = firsTable.firstSuccesWNmame,
                                            compileSuccesJob = firsTable.firstSuccesCount,
                                            compileAllJob = secondTable.seconAllJobCount

                                        }).ToList();
                    foreach (var status in statusWorker)
                    {
                        result.Add(new WorkerStatus { workerName = status.compileWorkerName, succesLog = status.compileSuccesJob, logCount = status.compileAllJob });
                    }

                }
                else if (choose == "3")
                {
                   
                    var statusWorker = (from firsTable in
                                // SuccesCount
                                (from firstlogs in c.logCalls
                                 join firstJobs in c.Jobs
                                 on firstlogs.LogCallID equals firstJobs.LogCallID
                                 join firstWorker in c.Worker
                                 on firstlogs.WorkerID equals firstWorker.WorkerID
                                 where firstJobs.CurrentStatus == "Çözüldü" && firstJobs.CreatedDay.Year >= dateRowYear-1
                                 group firstWorker by firstWorker.WorkerName into z
                                 select new
                                 {
                                     firstSuccesWNmame = z.Key,
                                     firstSuccesCount = z.Count(),

                                 })
                                            // ALL COUNT
                                        join secondTable in
                                       (from secondLogs in c.logCalls
                                        join secondJobs in c.Jobs
                             on secondLogs.LogCallID equals secondJobs.LogCallID
                                        join secondWorker in c.Worker
                             on secondLogs.WorkerID equals secondWorker.WorkerID
                             where secondJobs.CreatedDay.Year >= dateRowYear-1
                                        group secondWorker by secondWorker.WorkerName into g
                                        select new
                                        {
                                            secondAllJobWorkerName = g.Key,
                                            seconAllJobCount = g.Count(),


                                        })

                                       on firsTable.firstSuccesWNmame equals secondTable.secondAllJobWorkerName
                                        select new
                                        {
                                            compileWorkerName = firsTable.firstSuccesWNmame,
                                            compileSuccesJob = firsTable.firstSuccesCount,
                                            compileAllJob = secondTable.seconAllJobCount

                                        }).ToList();
                    foreach (var status in statusWorker)
                    {
                        result.Add(new WorkerStatus { workerName = status.compileWorkerName, succesLog = status.compileSuccesJob, logCount = status.compileAllJob });
                    }
                }
                else
                {
                    var statusWorker = (from firsTable in
                        // SuccesCount
                        (from firstlogs in c.logCalls
                         join firstJobs in c.Jobs
                         on firstlogs.LogCallID equals firstJobs.LogCallID
                         join firstWorker in c.Worker
                         on firstlogs.WorkerID equals firstWorker.WorkerID
                         where firstJobs.CurrentStatus == "Çözüldü"
                         group firstWorker by firstWorker.WorkerName into z
                         select new
                         {
                             firstSuccesWNmame = z.Key,
                             firstSuccesCount = z.Count(),

                         })
                                            // ALL COUNT
                                        join secondTable in
                                       (from secondLogs in c.logCalls
                                        join secondJobs in c.Jobs
                         on secondLogs.LogCallID equals secondJobs.LogCallID
                                        join secondWorker in c.Worker
                         on secondLogs.WorkerID equals secondWorker.WorkerID
                                        group secondWorker by secondWorker.WorkerName into g
                                        select new
                                        {
                                            secondAllJobWorkerName = g.Key,
                                            seconAllJobCount = g.Count(),


                                        })

                                       on firsTable.firstSuccesWNmame equals secondTable.secondAllJobWorkerName
                                        select new
                                        {
                                            compileWorkerName = firsTable.firstSuccesWNmame,
                                            compileSuccesJob = firsTable.firstSuccesCount,
                                            compileAllJob = secondTable.seconAllJobCount

                                        }).ToList();
                    foreach (var status in statusWorker)
                    {
                        result.Add(new WorkerStatus { workerName = status.compileWorkerName, succesLog = status.compileSuccesJob, logCount = status.compileAllJob });
                    }
                }



                return result;

            }
        }
        
        public List<WorkerStatus> workerStatusaE()
        {
            using (Context c = new Context())
            {
                WorkerStatus rescik = new WorkerStatus();
                List<WorkerStatus> result = new List<WorkerStatus>();

                var succesJob = (from logs in c.logCalls
                                 join worker in c.Worker on logs.WorkerID
                                  equals worker.WorkerID
                                 join jobs in c.Jobs on logs.LogCallID equals jobs.LogCallID
                                 where jobs.CurrentStatus == "Çözüldü"

                                 group worker by worker.WorkerName into g
                                 select new
                                 {
                                     workerName = g.Key,
                                     succesCount = g.Count(),
                                     allJobs = 0,

                                 }).ToList();





                foreach (var suc in succesJob)
                {
                    result.Add(new WorkerStatus { workerName = suc.workerName, succesLog = suc.succesCount });
                }


                return result;

                // select sorgusu worker status için 


                //                select allJobList.WorkerName,allJobList.allJob,succesJobs.succesJobCount from
                //(
                //select logWorkers.WorkerName, count(logWorkers.WorkerName) as allJob from logCalls,
                //(select LogCallID, logcalls.WorkerID, WorkerName from logCalls, Worker
                //where logCalls.WorkerID = Worker.WorkerID) as logWorkers,
                //(select logCalls.LogCallID,Jobs.JobID,Jobs.CurrentStatus from logCalls,Jobs
                //where Jobs.LogCallID = logCalls.LogCallID) as logJobs
                //where logCalls.LogCallID = logWorkers.LogCallID and
                //logCalls.LogCallID = logJobs.LogCallID group by logWorkers.WorkerName)as allJobList,
                //(select Worker.WorkerName,count(logCalls.LogCallID) as succesJobCount
                //from logCalls, Jobs, Worker where logCalls.LogCallID = Jobs.LogCallID and Jobs.CurrentStatus = 'Çözüldü' and
                //logCalls.WorkerID = Worker.WorkerID group by Worker.WorkerName) as succesJobs
                //where succesJobs.WorkerName = allJobList.WorkerName






                //var workers = c.Worker.FromSqlRaw($"select Worker.WorkerName,logCalls.LogCallID from Worker,logCalls where Worker.WorkerID=logCalls.WorkerID ").GroupBy(x => x.WorkerName).ToList();

                //var logWorkes = c.logCalls.GroupBy(x => x.Worker!.WorkerName).Select(x => new { WorkerName = x.Key, Count = x.Count() });
                //List<WorkerStatus> status = new List<WorkerStatus>();
                //public string? workerName;
                //public int logCount;
                //public int succesLog;
                //status = ((List<WorkerStatus>)(from list in( from worker in c.Worker join logcalls in c.logCalls on worker.WorkerID equals logcalls.CustomerID  group worker.WorkerName by worker.WorkerName ) select new { workerName = list.Key, logCount = list.Count() }));

                // Bugüne kadar alınmış tüm işleri saydırır. 
                // Count all logcall


                // Başarılı olduğu iş sayısı

                //var _logs = _logCallDal.IncludeAll();
                //var _jobs = _jobDal.IncludeAll();
                //var _workers = _workerDal.GetListAll();

                // İnanılmaz çirkin kod satırının dönüşümü herkesi şaşırttı...
                //foreach (var _job in _jobs)
                //{
                //    foreach (var _log in _logs)
                //    {
                //        if (_job.LogCallID == _log.LogCallID)
                //        {
                //            foreach (var _worker in _workers)
                //            {
                //                if (_log.WorkerID == _worker.WorkerID)
                //                {
                //                    if (result.Count() == 0)
                //                    {
                //                        if (_job.CurrentStatus == "Çözüldü")
                //                        {
                //                            rescik.workerName = _worker.WorkerName;
                //                            rescik.logCount = 1;
                //                            rescik.succesLog = 1;
                //                            result.Add(rescik);
                //                            break;
                //                        }
                //                        else
                //                        {
                //                            rescik.workerName = _worker.WorkerName;
                //                            rescik.logCount = 1;
                //                            rescik.succesLog = 0;
                //                            result.Add(rescik);
                //                            break;
                //                        }
                //                    }
                //                    else
                //                    {
                //                        bool degistimi = true;
                //                        foreach (var res in result)
                //                        {
                //                            if (res.workerName == _worker.WorkerName)
                //                            {
                //                                res.logCount++;
                //                                degistimi = false;
                //                                if (_job.CurrentStatus == "Çözüldü")
                //                                {

                //                                    res.succesLog++;

                //                                }
                //                                break;
                //                            }

                //                        }
                //                        if (degistimi)
                //                        {
                //                            if (_job.CurrentStatus == "Çözüldü")
                //                            {
                //                                rescik.workerName = _worker.WorkerName;
                //                                rescik.logCount = 1;
                //                                rescik.succesLog = 1;
                //                                result.Add(rescik);
                //                                break;
                //                            }
                //                            else
                //                            {
                //                                rescik.workerName = _worker.WorkerName;
                //                                rescik.logCount = 1;
                //                                rescik.succesLog = 0;
                //                                result.Add(rescik);
                //                                break;
                //                            }
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //    }
                //}
            }
        }


    }
}
