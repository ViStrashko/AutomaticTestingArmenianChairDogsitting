using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.ClientTestSources
{
    public class ClientCreation_WhenClientModelIsCorrectAndPromocodeIsEmpty_TetsSource : IEnumerable
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
                Password = "12345678",
                Promocode = ""
            };
        }
    }
}