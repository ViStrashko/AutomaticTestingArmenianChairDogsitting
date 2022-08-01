using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSourses.ClientTestSourses
{
    public class DeleteClientProfile_WhenClientModelIsCorrect_TestSours : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new ClientAllInfoResponseModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Email = "petrov@gmail.com",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                RegistrationDate = DateTime.Now.Date,
                Dogs = null,
                IsDeleted = true,
            };
        }
    }
}
