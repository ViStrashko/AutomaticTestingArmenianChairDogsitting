using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.ClientNegativeTestSources
{
    public class ClientAuthorizationNegativeTest_WhenClientIsRegisteredAndPasswordAndEmailIsStrangers_TetsSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new ClientRegistrationRequestModel()
                {
                    Name = "Вася1",
                    LastName = "Петров",
                    Phone = "+79514125547",
                    Address = "ул. Итальянская, дом. 10",
                    Email = "petrov@gmail.com",
                    Password = "12345678",
                    Promocode = "F85KY0UN"

                },
                new AuthRequestModel()
                {
                    Email = "petrov@gmail.com",
                    Password = "12345677",
                }
            };
            yield return new object[]
            {
                new ClientRegistrationRequestModel()
                {
                    Name = "Вася2",
                    LastName = "Петров",
                    Phone = "+79514125547",
                    Address = "ул. Итальянская, дом. 10",
                    Email = "petrov@gmail.com",
                    Password = "12345678",
                    Promocode = "F85KY0UN"

                },
                new AuthRequestModel()
                {
                    Email = "smirnov@gmail.com",
                    Password = "12345678",
                }
            };
        }
    }
}
