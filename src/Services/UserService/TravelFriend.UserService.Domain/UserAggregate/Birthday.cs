using System;
using System.Collections.Generic;
using System.Text;
using TravelFriend.Domain.Abstractions;

namespace TravelFriend.UserService.Domain.UserAggregate
{
    public class Birthday : ValueObject
    {
        public int Year { get; private set; }
        public int Month { get; private set; }
        public int Day { get; private set; }

        public Birthday() { }
        public Birthday(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        /// <summary>
        /// 获取原子数据
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Year;
            yield return Month;
            yield return Day;
        }

        public override string ToString()
        {
            return $"{Year}/{Month}/{Day}";
        }
    }
}
