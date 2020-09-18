using System;

namespace HoofHornService.Contracts
{
    /// <summary>
    /// Класс описывающий техника.
    /// </summary>
    internal class Technician : WorkerWithCategory
    {
        /// <inheritdoc/>
        public override double GetSalary()
        {
            return base.GetSalary() + Bonus;
        }
    }
}
