using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using DataAccesLayer.Repositories;
using EntityLayer.Concrete;
using EntityLayer.SharedModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class JobManager : IJobService
    {
        IJobDal _jobDal;
        ILogCallDal _logCallDal;
        IWorkerDal _workerDal;
        public JobManager(IJobDal jobDal)
        {
            _workerDal = new EFWorkerRepository();
            _logCallDal = new EFLogCallRepository();
            _jobDal = jobDal;
        }

        public List<Job> JobInclude()
        {

            return _jobDal.IncludeAll();
        }

        public List<JobPoint> SqlSorgusuJobPoint()
        {
            using (Context c = new Context())
            {

                List<JobPoint> jpAndIDs = new List<JobPoint>();
                JobPoint jp = new JobPoint();
                //var i= c.Jobs.FromSqlRaw($"select tbl2.WorkerName, COUNT(tbl2.WorkerName) as CzlSay from(select tbl1.WorkerName, WorkerID from Jobs, (select Worker.WorkerName, Worker.WorkerID, logCalls.LogCallID FROM logCalls, Worker WHERE(logCalls.WorkerID = Worker.WorkerID)and(logCalls.IsJob = 1)) as tbl1 where(Jobs.LogCallID = tbl1.LogCallID and Jobs.CurrentStatus = 'Çözüldü')) as tbl2 Group by WorkerName").ToList();
                List<Job> firstTemp = (List<Job>)c.Jobs.Where(x => x.CurrentStatus == "Çözüldü").ToList();
                List<LogCall> secTemp = _logCallDal.IncludeAll();
                List<Worker> thirdTemp = _workerDal.GetListAll();
                var resultQuerry = (from logs in c.logCalls
                                    join worker in c.Worker on logs.WorkerID equals worker.WorkerID
                                    group worker by worker.WorkerName into g
                                    select new { workerName = g.Key, count = g.Count() }).ToList();

                foreach( var res in resultQuerry)
                {
                    if(jpAndIDs.Count()==0)
                    
                        {
                            var v = res.count;
                            var workerID = res.workerName;
                        jpAndIDs.Add(new JobPoint{ Worker=workerID, point=v });
                        }
                    else
                    {
                        bool degistimi = true;
                        foreach (var jpe in jpAndIDs)
                        {
                           
                            if (jpe.Worker == res.workerName)
                            {
                                jpe.point = res.count;
                                degistimi = false;
                            }

                            

                        }
                        if (degistimi) {
                            var v = res.count;
                            var workerID = res.workerName;
                            jpAndIDs.Add(new JobPoint { Worker = workerID, point = v });
                        }
                    }

                }


                //foreach (var items in firstTemp)
                //{
                //    foreach (var item2 in secTemp)
                //    {
                //        if (items.LogCallID == item2.LogCallID)
                //        {
                //            foreach (var item3 in thirdTemp)
                //            {
                //                if (item2.Worker!.WorkerID == item3.WorkerID)
                //                {
                //                    if (jpAndIDs.Count() == 0)
                //                    {
                //                        var v = 1;
                //                        var workerID = item3.WorkerName;
                //                        jpAndIDs!.Add(new JobPoint { Worker = workerID, point = v });
                //                    }
                //                    else
                //                    {
                //                        bool isNotChange = true;
                //                        foreach (var item4 in jpAndIDs)
                //                        {

                //                            if (item4.Worker == item3.WorkerName)
                //                            {
                //                                item4.point = item4.point + 1;
                //                                isNotChange = false;
                //                                break;
                //                            }


                //                        }
                //                        if (isNotChange)
                //                        {
                //                            var v = 1;
                //                            var workerID = item3.WorkerName;
                //                            jpAndIDs!.Add(new JobPoint { Worker = workerID, point = v });
                //                            break;
                //                        }

                //                    }
                //                }

                //            }


                //        }



                //    }

                //}

                return jpAndIDs;
            }
        }
        public List<LogCall> TarihSqlSorgusu(string tarih)
        {
           
            using (Context c = new Context())
            {
                List<LogCall> logs = new List<LogCall>();
                var tarihliLogs = _logCallDal.IncludeAll();
                DateTime now = DateTime.Now;
              
                // degişecek sorgu yazılacak bunun yerine 
                
                foreach (var dates in tarihliLogs)
                {
                    DateTime create = dates.CreateCallTime;
                    System.TimeSpan fark = now.Subtract(create);

                    if (tarih == "gün" && fark.TotalDays < 1)
                    {
                        logs.Add(dates);
                        
                        
                    }

                    else if (tarih == "ay" && fark.TotalDays < 31)
                    {
                        logs.Add(dates);
                    }

                    else if (tarih == "yıl" && fark.TotalDays < 366)
                    {
                        logs.Add(dates);
                    }
                    else if(tarih=="tumu")
                    {

                        return _logCallDal.GetListAll();
                    }
                }
                return logs;
            }
        }
        public void AddJob(Job job)
        {
            _jobDal.Insert(job);

        }

        public Job GetById(int id)
        {
            return _jobDal.GetByID(id);
        }

        public List<Job> GetList()
        {
            return _jobDal.GetListAll();
        }

        public void RemoveJob(Job job)
        {
            _jobDal?.Delete(job);
        }

        public void UpdateJob(Job job)
        {
            _jobDal?.Update(job);
        }
    }
}
