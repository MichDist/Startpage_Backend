using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startpage_Backend.Models
{
    public class StartpageDatabaseSettings : IStartpageDatabaseSettings
    {
        public string StartpageCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IStartpageDatabaseSettings
    {
        string StartpageCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
