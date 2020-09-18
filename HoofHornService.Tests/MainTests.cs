using HoofHornService.Services;
using HoofHornService.Services.Interfaces;
using NUnit.Framework;
using System.Text.Json;

namespace HoofHornService.Tests
{
    public class MainTests
    {
        /// <summary>
        /// Класс для работы с Json.
        /// </summary>
        private IWorkerConverter _jsonParser;

        /// <summary>
        /// Сумматор зарплат.
        /// </summary>
        private ISalaryAdder _salaryAdder;

        [SetUp]
        public void Setup()
        {
            _jsonParser = new WorkerConverter();
            _salaryAdder = new SalaryAdder();
        }

        [Test]
        public void Test1()
        {
            string recuest = @"
[
  {
    ""positon"":""manager"",
    ""salary"": ""150000"",
    ""bonus"": ""0""
  },
  {
    ""positon"":""technician"",
    ""salary"": ""35000"",
    ""bonus"": ""5000"",
    ""category"": ""B""
  },
  {
    ""positon"":""driver"",
    ""salary"": ""250"",
    ""bonus"": ""10000"",
    ""timeWorked"": ""80"",
    ""category"": ""A""
  }
]
";
            JsonDocument doc = JsonDocument.Parse(recuest);
            var workers = _jsonParser.GetWorkersByJson(doc.RootElement);
            Assert.AreEqual(workers.Count, 3);
            var sum = _salaryAdder.GetSumSalary(workers);
            Assert.AreEqual(sum, 230250);
        }
    }
}