using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoofHornService.Contracts
{
    /// <summary>
    /// Абстрактный класс для шаблона декоратор.
    /// </summary>
    public abstract class Decorator : Worker
    {
        /// <summary>
        /// Конкретный работник.
        /// </summary>
        protected Worker worker;

        public Decorator(Worker worker)
        {
            this.worker = worker;
        }

        /// <inheritdoc/>
        public override double GetSalary()
        {
            if (worker != null)
                return worker.GetSalary();
            else
                return 0;
        }
    }
}
