using HoofHornService.Contracts;
using System.Collections.Generic;

namespace HoofHornService.Services.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с сумматором зарплат.
    /// </summary>
    public interface ISalaryAdder
    {
        /// <summary>
        /// Получить общую сумму запрлат по всем работникам.
        /// </summary>
        /// <param name="workers">Список работников.</param>
        /// <returns>Общая сумма.</returns>
        public double GetSumSalary(IEnumerable<Worker> workers);
    }
}
