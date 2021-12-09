using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Common;
using Hangfire.Storage;
using Infrastructure.BackgroundJobs.ApiFootballUpdater;
using Infrastructure.BackgroundJobs.CouponCheckers;
using Microsoft.CodeAnalysis;

namespace Infrastructure.BackgroundJobs;

public class Supervisor
{
    private static string FixtureUpdaterId = "E4905F4D-9A88-448B-AB5B-0D7501F1D996";
    private static string BetsUpdaterId = "4459A947-F635-43C8-B473-D1965F72B8C6";
    private static string CouponCheckerId = "08037CC3-61D8-4E39-962A-6DB7DA835C5F";

    private readonly FixtureUpdater _fixtureUpdater;
    private readonly BetsUpdater _betsUpdater;
    private readonly CouponChecker _couponChecker;

    public Supervisor(FixtureUpdater fixtureUpdater, BetsUpdater betsUpdater,
        CouponChecker couponChecker)
    {
        _fixtureUpdater = fixtureUpdater;
        _betsUpdater = betsUpdater;
        _couponChecker = couponChecker;
    }

    public void Start()
    {
        var jobs = new List<Job>
        {
            new Job(FixtureUpdaterId, "0 * * * *", () => _fixtureUpdater.Update()),
            new Job(BetsUpdaterId, "5 * * * *", () => _betsUpdater.Update()),
            new Job(CouponCheckerId, "10 * * * *", () => _couponChecker.Check()),
        };

        var recurringJobsIds = JobStorage.Current
            .GetConnection().GetRecurringJobs().Select(x => x.Id);

        var jobsToAdd = jobs
            .Where(x => !recurringJobsIds
                .Contains(x.Id))
            .ToList();

        if (!jobsToAdd.Any()) 
            return;

        foreach (var job in jobsToAdd)
        {
            RecurringJob.AddOrUpdate(job.Id, job.Task, job.Cron);
        }
    }
}

internal record Job(string Id, string Cron, Expression<Func<Task>> Task);


