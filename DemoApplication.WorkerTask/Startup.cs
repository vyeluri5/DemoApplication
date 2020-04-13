using Couchbase.Extensions.DependencyInjection;
using DemoApplication.Interfaces;
using DemoApplication.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DemoApplication.WorkerTask
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            #region Couchbase

            services
                .AddCouchbase(Configuration.GetSection("Couchbase"))
                .AddCouchbaseBucket<IStatsmoreFeedBucketProvider>("feeds", "feeds123");
            //.AddCouchbaseBucket<IStatsmoreFeedBucketProvider>("statsmore-feeds", "statsmore-feeds");

            #endregion

            services.RegisterServices(Configuration);
        }
    }
}
