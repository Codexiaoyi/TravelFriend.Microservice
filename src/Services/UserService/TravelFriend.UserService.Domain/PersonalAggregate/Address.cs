using System.Collections.Generic;
using TravelFriend.Domain.Abstractions;

namespace TravelFriend.UserService.Domain.PersonalAggregate
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }

        public Address()
        {
            Street = string.Empty;
            City = string.Empty;
            Province = string.Empty;
        }

        public Address(string street, string city, string province)
        {
            Street = street;
            City = city;
            Province = province;
        }

        /// <summary>
        /// 获取原子数据
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
            yield return Province;
        }

        public override string ToString()
        {
            return $"{Province}-{City}-{Street}";
        }
    }
}
