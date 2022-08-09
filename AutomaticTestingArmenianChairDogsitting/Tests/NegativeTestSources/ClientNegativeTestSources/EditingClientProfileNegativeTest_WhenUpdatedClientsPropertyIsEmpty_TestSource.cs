﻿using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.ClientNegativeTestSources
{
    public class EditingClientProfileNegativeTest_WhenUpdatedClientsPropertyIsEmpty_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new ClientUpdateRequestModel()
            {
                Name = "",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася",
                LastName = "",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Phone = "",
                Address = "ул. Итальянская, дом. 10",
                Email = "petrov@gmail.com",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "",
                Email = "petrov@gmail.com",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Email = "",
            };
            yield return new ClientUpdateRequestModel()
            {
                Name = "",
                LastName = "",
                Phone = "",
                Address = "",
                Email = "",
            };
        }
    }
}