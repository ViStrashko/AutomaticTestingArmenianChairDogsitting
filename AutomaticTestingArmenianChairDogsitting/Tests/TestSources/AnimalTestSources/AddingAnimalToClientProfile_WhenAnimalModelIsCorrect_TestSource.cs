﻿using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.AnimalTestSources
{
    public class AddingAnimalToClientProfile_WhenAnimalModelIsCorrect_TestSource
    {
        public IEnumerator GetEnumerator()
        {
            yield return new AnimalRegistrationRequestModel()
            {
                Name = "Шарик",
                Age = 1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
                ClientId = 1,
            };
        }
    }
}