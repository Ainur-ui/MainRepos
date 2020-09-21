using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HoofHornService.Contracts
{
    /// <summary>
    /// класс описывающий работника с категорией.
    /// </summary>
    public class WorkerWithCategory : Decorator
    {
        /// <summary>
        /// Категория (A - 125%, B - 115%, С - 100%).
        /// </summary>
        public string Category { get; protected set; }

        /// <summary>
        /// Категории и их значения.
        /// </summary>
        private readonly Dictionary<string, double> CategoryValues = new Dictionary<string, double>() { { "A", 1.25 }, { "B", 1.15 }, { "C", 1 } };

        public WorkerWithCategory(Worker worker, string category)
            : base(worker)
        {
            Category = category;
        }

        /// <inheritdoc/>
        public override double GetSalary()
        {
            if (CategoryValues.ContainsKey(Category))
            {
                return base.GetSalary() * CategoryValues[Category] + worker.Bonus;
            }
            else
            {
                throw new Exception("Возникла ошибка при определении категории!");
            }
        }
    }
}
