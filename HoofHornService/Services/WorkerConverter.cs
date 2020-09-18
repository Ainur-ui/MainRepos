using HoofHornService.Contracts;
using HoofHornService.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.Json;

namespace HoofHornService.Services
{
    /// <summary>
    /// Сервис по получене данных по работникам.
    /// </summary>
    public class WorkerConverter : IWorkerConverter
    {
        /// <inheritdoc/>
        public ImmutableList<Worker> GetWorkersByJson(JsonElement jsonData)
        {
            var workers = new List<Worker>();
            foreach (var objectItem in jsonData.EnumerateArray())
            {
                var field = objectItem.EnumerateObject().ToImmutableList().Find(x => x.Name == "positon");
                switch (field.Value.ToString())
                {
                    case "manager":
                        workers.Add(JsonConvert.DeserializeObject<Manager>(objectItem.ToString()));
                        break;
                    case "technician":
                        workers.Add(JsonConvert.DeserializeObject<Technician>(objectItem.ToString()));
                        break;
                    case "driver":
                        workers.Add(JsonConvert.DeserializeObject<Driver>(objectItem.ToString()));
                        break;
                }
            }

            return workers.ToImmutableList();
        }
    }
}
