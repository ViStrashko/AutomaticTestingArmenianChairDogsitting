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
                Name = "Вася1",
                LastName = "",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася2",
                LastName = "Петров",
                Phone = "",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася3",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "",
                Email = "petrov@gmail.com",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася4",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Email = "",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася5",
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
            yield return new ClientRegistrationRequestModel()
            {
                Name = "",
                LastName = "",
                Phone = "",
                Address = "",
                Email = "",
                Password = "",
                Promocode = ""
            };
        }
    }
}
