using Newtonsoft.Json;
using System;

namespace HoofHornService.Contracts
{
    /// <summary>
    /// Класс описывающий водителя.
    /// </summary>
    internal class Driver : Worker
    {
        /// <summary>
        /// Количество отработанных часов.
        /// </summary>
        [JsonProperty("timeWorked")]
        public double TimeWorked { get; protected set; }

        /// <inheritdoc/>
        public override double GetSalary()
        {
            return Salary * TimeWorked;
        }
    }
}
