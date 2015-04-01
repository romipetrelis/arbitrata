using System.Collections.Generic;

namespace KnockoutWebForms.Models
{
    public static class AddressModelFaker
    {
        public static AddressModel Fake()
        {
            return new AddressModel
            {
                City = Faker.Address.City(),
                Country = "US",
                Line1 = Faker.Address.StreetAddress(),
                Line2 = Faker.Address.SecondaryAddress(),
                PostalCode = Faker.Address.ZipCode(),
                State = Faker.Address.UsStateAbbr()
            };
        }

        public static IEnumerable<AddressModel> FakeEnumerable()
        {
            var toReturn = new List<AddressModel>();
            var max = Faker.RandomNumber.Next(1, 100);

            for (var i = 0; i < max; i++)
            {
                toReturn.Add(AddressModelFaker.Fake());
            }
            return toReturn;
        }
    }
}