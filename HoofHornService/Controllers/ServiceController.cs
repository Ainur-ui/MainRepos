using HoofHornService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace HoofHornService.Controllers
{
    /// <summary>
    /// Контроллер.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ServiceController : ControllerBase
    {
        /// <summary>
        /// Класс для работы с Json.
        /// </summary>
        private readonly IWorkerConverter _jsonParser;

        /// <summary>
        /// Сумматор зарплат.
        /// </summary>
        private readonly ISalaryAdder _salaryAdder;

        public ServiceController(IWorkerConverter jsonParser, ISalaryAdder salaryAdder)
        {
            _jsonParser = jsonParser;
            _salaryAdder = salaryAdder;
        }

        /// <summary>
        /// Получение результатов.
        /// </summary>
        /// <param name="jsonData">объекты.</param>
        /// <returns>Результат.</returns>
        [HttpPost]
        [ActionName("getamountpayments")]
        public async Task<ActionResult<double>> GetAmountPayments([FromBody] JsonElement jsonData)
        {
            var workers = _jsonParser.GetWorkersByJson(jsonData);
            return _salaryAdder.GetSumSalary(workers);
        }
    }
}
