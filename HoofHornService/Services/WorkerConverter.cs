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
                Worker worker = null;
                var field = objectItem.EnumerateObject().ToImmutableList().Find(x => x.Name == "positon").Value.ToString();
                switch (field)
                {
                    case "manager":
                        worker = JsonConvert.DeserializeObject<Manager>(objectItem.ToString());
                        worker = new WorkerWithoutCategory(worker);
                        workers.Add(worker);
                        break;
                    case "technician":
                    case "driver":
                        var category = objectItem.EnumerateObject().ToImmutableList().Find(x => x.Name == "category").Value.ToString();
                        if (field == "technician")
                        {
                            worker = JsonConvert.DeserializeObject<Technician>(objectItem.ToString());
                        }
                        else
                        {
                            worker = JsonConvert.DeserializeObject<Driver>(objectItem.ToString());
                        }

                        worker = new WorkerWithCategory(worker, category);
                        workers.Add(worker);
                        break;
                }
            }

            return workers.ToImmutableList();
        }
    }
}
