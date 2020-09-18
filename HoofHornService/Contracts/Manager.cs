namespace HoofHornService.Contracts
{
    /// <summary>
    /// Класс описывающий менеджера.
    /// </summary>
    internal class Manager : Worker
    {
        /// <inheritdoc/>
        public override double GetSalary()
        {
            return base.GetSalary() + Bonus;
        }
    }
}
