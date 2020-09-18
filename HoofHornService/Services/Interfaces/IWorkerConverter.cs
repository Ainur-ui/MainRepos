using System.Text.Json;
using HoofHornService.Contracts;
using System.Collections.Immutable;

namespace HoofHornService.Services.Interfaces
{
    /// <summary>
    /// Интерфейс для получения данных по работникам.
    /// </summary>
    public interface IWorkerConverter
    {
        /// <summary>
        /// Получить данные по работникам.
        /// </summary>
        /// <param name="jsonData">Данные ввиде json элемента.</param>
        /// <returns> Список данных по работникам.</returns>
        public ImmutableList<Worker> GetWorkersByJson(JsonElement jsonData);
    }
}
