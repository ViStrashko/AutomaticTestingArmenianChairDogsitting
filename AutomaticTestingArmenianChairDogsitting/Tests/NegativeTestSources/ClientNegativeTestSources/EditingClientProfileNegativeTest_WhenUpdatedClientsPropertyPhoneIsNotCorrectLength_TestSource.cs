using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.ClientNegativeTestSources
{
    public class EditingClientProfileNegativeTest_WhenUpdatedClientsPropertyPhoneIsNotCorrectLength_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася1",
                LastName = "Петров",
                Phone = "+7951412554",
                Address = "ул. Итальянская, дом. 10",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася2",
                LastName = "Петров",
                Phone = "+795141255471",
                Address = "ул. Итальянская, дом. 10",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася3",
                LastName = "Петров",
                Phone = "8951471259",
                Address = "ул. Итальянская, дом. 10",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася4",
                LastName = "Петров",
                Phone = "895147125941",
                Address = "ул. Итальянская, дом. 10",
            };

        }
    }
}