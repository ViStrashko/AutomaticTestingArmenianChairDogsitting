using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.ClientNegativeTestSources
{
    public class ClientCreationNegativeTest_WhenClientsPropertyPhoneAndEmailIncorrectFormat_TetsSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася1",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrovgmail.com",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася2",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася3",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@.com",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася4",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Email = "@gmail.com",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася5",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@@gmail.com",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася6",
                LastName = "Петров",
                Phone = "asdfghjklqwe",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася7",
                LastName = "Петров",
                Phone = "+7951412554a",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася8",
                LastName = "Петров",
                Phone = "+795<>?!@#$%",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
            yield return new ClientRegistrationRequestModel()
            {
                Name = "Вася9",
                LastName = "Петров",
                Phone = "+795;:&*^-.,",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
                Password = "12345678",
                Promocode = "F85KY0UN"
            };
        }
    }
}
