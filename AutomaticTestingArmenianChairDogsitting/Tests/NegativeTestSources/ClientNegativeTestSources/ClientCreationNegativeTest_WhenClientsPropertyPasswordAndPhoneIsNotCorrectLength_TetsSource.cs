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
                Name = "Вася1",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
                Password = "1234567",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася2",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
                Password = "1",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася3",
                LastName = "Петров",
                Phone = "+7951412554",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася4",
                LastName = "Петров",
                Phone = "+795141255471",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася5",
                LastName = "Петров",
                Phone = "8951487154",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася6",
                LastName = "Петров",
                Phone = "895148715491",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
        }
    }
}
