using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorServices.Services.DataService
{
    public interface IDataService<T>
    {
        public List<T> ReadFromFile(string path);

        public void AddToFile(string path, List<T> records);
        public void WriteToFile(string path, List<T> list);

    }
}
