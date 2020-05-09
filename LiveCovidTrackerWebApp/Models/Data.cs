using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveCovidTrackerWebApp.Models
{
    public class CovidData
    {
        public bool Success { get; set; }

        public Data Data { get; set; }

        public DateTimeOffset LastRefreshed { get; set; }

        public DateTimeOffset LastOriginUpdate { get; set; }
    }

    public class Data
    {
        public string Source { get; set; }
        public DateTimeOffset LastRefreshed { get; set; }
        public Total Total { get; set; }
        public List<State> Statewise { get; set; }
    }

    public class Total
    {
        public long Confirmed { get; set; }
        public long Recovered { get; set; }
        public long Deaths { get; set; }
        public long Active { get; set; }
    }

    public class State
    {
        public string state { get; set; }
        public long Confirmed { get; set; }
        public long Recovered { get; set; }
        public long Deaths { get; set; }
        public long Active { get; set; }
    }
}
