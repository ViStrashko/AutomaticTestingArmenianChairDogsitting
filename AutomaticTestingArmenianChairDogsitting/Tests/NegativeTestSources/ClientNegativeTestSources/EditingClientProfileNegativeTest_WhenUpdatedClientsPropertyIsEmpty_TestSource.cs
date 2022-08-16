using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.ClientNegativeTestSources
{
    public class EditingClientProfileNegativeTest_WhenUpdatedClientsPropertyIsEmpty_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new ClientUpdateRequestModel()
            {
                Name = "",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася1",
                LastName = "",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася2",
                LastName = "Петров",
                Phone = "",
                Address = "ул. Итальянская, дом. 10",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася3",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "",
                LastName = "",
                Phone = "",
                Address = "",
            };
        }
    }
}
