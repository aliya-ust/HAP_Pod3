using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Databases
{
    public class HealthRecordDB
    {
        private List<HealthRecord> _records = new List<HealthRecord>();
        
        public List<HealthRecord> Records
        {
            get { return _records; }
            set { _records = value; }
        }

    }
}