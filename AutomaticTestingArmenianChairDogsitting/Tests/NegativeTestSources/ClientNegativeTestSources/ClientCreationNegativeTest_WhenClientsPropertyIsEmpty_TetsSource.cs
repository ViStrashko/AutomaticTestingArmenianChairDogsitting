using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.ClientNegativeTestSources
{
    public class ClientCreationNegativeTest_WhenClientsPropertyIsEmpty_TetsSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new ClientRegistrationRequestModel()
            {
                Name = "",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася",
                LastName = "",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Phone = "",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "",
                Email = "petrov@gmail.com",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Email = "",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
                Password = "",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "",
                LastName = "",
                Phone = "",
                Address = "",
                Email = "",
                Password = "",
                Promocode = "F85KY0UN"
            };
        }
    }
}
