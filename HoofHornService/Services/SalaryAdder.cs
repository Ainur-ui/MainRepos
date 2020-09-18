using HoofHornService.Contracts;
using HoofHornService.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HoofHornService.Services
{
    /// <summary>
    /// Сумматор зарплат.
    /// </summary>
    public class SalaryAdder : ISalaryAdder
    {
        /// <inheritdoc/>
        public double GetSumSalary(IEnumerable<Worker> workers)
        {
            return workers.Sum(w => w.GetSalary());
        }
    }
}
