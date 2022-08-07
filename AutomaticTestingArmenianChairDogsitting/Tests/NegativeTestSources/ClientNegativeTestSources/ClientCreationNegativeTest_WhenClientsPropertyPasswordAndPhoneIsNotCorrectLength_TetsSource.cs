using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.ClientNegativeTestSources
{
    public class ClientCreationNegativeTest_WhenClientsPropertyPasswordAndPhoneIsNotCorrectLength_TetsSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
                Password = "12345",
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Phone = "+795141255",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
                Password = "12345678",
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Phone = "+795141255471",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
                Password = "12345678",
            };
        }
    }
}
