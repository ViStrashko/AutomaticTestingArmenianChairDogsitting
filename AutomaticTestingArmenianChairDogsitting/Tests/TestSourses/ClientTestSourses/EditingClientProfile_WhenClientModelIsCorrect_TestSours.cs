using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSourses.ClientTestSourses
{
    public class EditingClientProfile_WhenClientModelIsCorrect_TestSours : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Email = "petrov@gmail.com",
                Phone = "+79518741247",
                Address = "ул. Итальянская, дом. 10",
            };
        }
    }
}
