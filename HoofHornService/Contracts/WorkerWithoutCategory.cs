using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HoofHornService.Contracts
{
    /// <summary>
    /// класс описывающий работника без категории.
    /// </summary>
    public class WorkerWithoutCategory : Decorator
    {
        public WorkerWithoutCategory(Worker worker)
            : base(worker)
        {
        }

        /// <inheritdoc/>
        public override double GetSalary()
        {
            return base.GetSalary() + worker.Bonus;
        }
    }
}
