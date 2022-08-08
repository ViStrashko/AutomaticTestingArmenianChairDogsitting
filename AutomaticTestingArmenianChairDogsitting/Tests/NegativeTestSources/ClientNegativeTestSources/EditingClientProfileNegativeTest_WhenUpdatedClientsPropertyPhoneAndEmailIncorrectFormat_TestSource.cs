using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.ClientNegativeTestSources
{
    public class EditingClientProfileNegativeTest_WhenUpdatedClientsPropertyPhoneAndEmailIncorrectFormat_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrovgmail.com",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Phone = "asdfghjklqwe",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Phone = "+7951412554a",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Phone = "+795<>?!@#$%",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Phone = "+795;:&*^-.,",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
            };
        }
    }
}
