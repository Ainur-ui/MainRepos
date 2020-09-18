using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HoofHornService.Contracts
{
    /// <summary>
    /// Абстрактный класс описывающий работника с категорией.
    /// </summary>
    public abstract class WorkerWithCategory : Worker
    {
        /// <summary>
        /// Категория (A - 125%, B - 115%, С - 100%).
        /// </summary>
        [JsonProperty("category")]
        public string Category { get; protected set; }

        /// <summary>
        /// Категории и их значения.
        /// </summary>
        private readonly Dictionary<string, double> CategoryValues = new Dictionary<string, double>() { { "A", 1.25 }, { "B", 1.15 }, { "C", 1 } };

        /// <inheritdoc/>
        public override double GetSalary()
        {
            if (CategoryValues.ContainsKey(Category))
            {
                return base.GetSalary() * CategoryValues[Category];
            }
            else
            {
                throw new Exception("Возникла ошибка при определении категории!");
            }
        }
    }
}
