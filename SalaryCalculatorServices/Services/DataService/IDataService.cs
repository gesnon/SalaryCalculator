using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorServices.Services.DataService
{
    public interface IDataService<T>
    {
        public List<T> Get();
        public void Add(T data);
        public void Delete(T data);
        public void Update(T data);

    }
}
