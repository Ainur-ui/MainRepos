using Newtonsoft.Json;

namespace HoofHornService.Contracts
{
    /// <summary>
    /// Абстрактный класс описывающий работника.
    /// </summary>
    public abstract class Worker
    {
        /// <summary>
        /// Профессия.
        /// </summary>
        [JsonProperty("positon")]
        public string Positon { get; protected set; }

        /// <summary>
        /// Базовая заработная плата.
        /// </summary>
        [JsonProperty("salary")]
        public double Salary { get; protected set; }

        /// <summary>
        /// Gets or sets размер премии сотрудника.
        /// </summary>
        [JsonProperty("bonus")]
        public double Bonus { get; protected set; }

        /// <summary>
        /// Получить зарплату за месяц.
        /// </summary>
        /// <returns>Полная зарплата.</returns>
        public virtual double GetSalary()
        {
            return this.Salary;
        }
    }
}
