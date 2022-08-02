using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTestingArmenianChairDogsitting.TestsCaseSources
{
    public class GetAllSittes_ByAllRolesTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<SitterRegistrationRequestModel> sitters = new List<SitterRegistrationRequestModel>() 
            {
                new SitterRegistrationRequestModel()
                {
                    Name = "Валера",
                    LastName = "Пет1",
                    Phone = "+79514125547",
                    Email = "pet0@gmail.com",
                    Password = "12345678",
                    Age = 20,
                    Experience = 10,
                    Sex = 1,
                    Description = "Description"
                },
                new SitterRegistrationRequestModel()
                {
                    Name = "Валера",
                    LastName = "Пет",
                    Phone = "+79514125547",
                    Email = "pet1@gmail.com",
                    Password = "12345678",
                    Age = 20,
                    Experience = 10,
                    Sex = 1,
                    Description = "Description"
                },
                new SitterRegistrationRequestModel()
                {
                    Name = "Валера",
                    LastName = "Пет",
                    Phone = "+79514125547",
                    Email = "pet2@gmail.com",
                    Password = "12345678",
                    Age = 20,
                    Experience = 10,
                    Sex = 1,
                    Description = "Description"
                },
                new SitterRegistrationRequestModel()
                {
                    Name = "Валера",
                    LastName = "Пет",
                    Phone = "+79514125547",
                    Email = "pet3@gmail.com",
                    Password = "12345678",
                    Age = 20,
                    Experience = 10,
                    Sex = 1,
                    Description = "Description"
                }
            };
            ClientRegistrationRequestModel clientModel = new ClientRegistrationRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Email = "petrov@gmail.com",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Password = "12345678",
            };

            yield return new object[] { sitters, clientModel };
        }
    }
}
