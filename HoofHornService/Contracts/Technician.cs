using System;

namespace HoofHornService.Contracts
{
    /// <summary>
    /// Класс описывающий техника.
    /// </summary>
    internal class Technician : Worker
    {
        /// <inheritdoc/>
        public override double GetSalary()
        {
            return Salary;
        }
    }
}
