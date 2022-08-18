using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.ClientNegativeTestSources
{
    public class EditingClientProfileNegativeTest_WhenUpdatedClientsPropertyPhoneIncorrectFormat_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася1",
                LastName = "Петров",
                Phone = "asdfghjklqwe",
                Address = "ул. Итальянская, дом. 10",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася2",
                LastName = "Петров",
                Phone = "+7951412554a",
                Address = "ул. Итальянская, дом. 10",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася3",
                LastName = "Петров",
                Phone = "+795<>?!@#$%",
                Address = "ул. Итальянская, дом. 10",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася4",
                LastName = "Петров",
                Phone = "+795;:&*^-.,",
                Address = "ул. Итальянская, дом. 10",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася5",
                LastName = "Петров",
                Phone = "asdfghjklqw",
                Address = "ул. Итальянская, дом. 10",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася6",
                LastName = "Петров",
                Phone = "8951412554a",
                Address = "ул. Итальянская, дом. 10",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася7",
                LastName = "Петров",
                Phone = "895<>?!@#$%",
                Address = "ул. Итальянская, дом. 10",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася8",
                LastName = "Петров",
                Phone = "895;:&*^-.,",
                Address = "ул. Итальянская, дом. 10",
            };
        }
    }
}
