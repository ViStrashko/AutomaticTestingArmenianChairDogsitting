using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.ClientNegativeTestSources
{
    public class ClientAuthorizationNegativeTest_WhenClientIsRegisteredAndPasswordAndEmailIsNotCorrect_TetsSource : IEnumerable
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
                    Email = "",
                    Password = "12345678",
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
                    Email = "petrov@gmail.com",
                    Password = "",
                }
            };
            yield return new object[]
            {
                new ClientRegistrationRequestModel()
                {
                    Name = "Вася3",
                    LastName = "Петров",
                    Phone = "+79514125547",
                    Address = "ул. Итальянская, дом. 10",
                    Email = "petrov@gmail.com",
                    Password = "12345678",
                    Promocode = "F85KY0UN"

                },
                new AuthRequestModel()
                {
                    Email = "petrovgmail.com",
                    Password = "12345678",
                }
            };
            yield return new object[]
            {
                new ClientRegistrationRequestModel()
                {
                    Name = "Вася4",
                    LastName = "Петров",
                    Phone = "+79514125547",
                    Address = "ул. Итальянская, дом. 10",
                    Email = "petrov@gmail.com",
                    Password = "12345678",
                    Promocode = "F85KY0UN"

                },
                new AuthRequestModel()
                {
                    Email = "petrov@gmail",
                    Password = "12345678",
                }
            };
            yield return new object[]
            {
                new ClientRegistrationRequestModel()
                {
                    Name = "Вася5",
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
                    Password = "1234567",
                }
            };
            yield return new object[]
            {
                new ClientRegistrationRequestModel()
                {
                    Name = "Вася6",
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
                    Password = "1",
                }
            };
            yield return new object[]
            {
                new ClientRegistrationRequestModel()
                {
                    Name = "Вася7",
                    LastName = "Петров",
                    Phone = "+79514125547",
                    Address = "ул. Итальянская, дом. 10",
                    Email = "petrov@gmail.com",
                    Password = "12345678",
                    Promocode = "F85KY0UN"

                },
                new AuthRequestModel()
                {
                    Email = "",
                    Password = "",
                }
            };
        }
    }
}
