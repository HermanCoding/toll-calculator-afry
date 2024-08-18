using System;
using System.Collections.Generic;

namespace TollFeeCalculator
{
    public class TollCalculator
    {
        /// <summary>
        /// Calculate the total toll fees for a timeperiod
        /// </summary>
        /// <param name="vehicle">the vehicle</param>
        /// <param name="passes">date and time of all passes</param>
        /// <returns>total toll fees</returns>
        /// 
        public int GetTollFee(IVehicle vehicle, DateTime[] passes)
        {
            DateTime firstPassThisHour = passes[0];
            DateTime currentDay = passes[0].Date;
            int totalFee = 0;
            int dayFee = 0;
            int activeFee = 0;

            foreach (DateTime pass in passes)
            {
                int nextFee = GetTollFee(pass, vehicle);

                if (pass.Date != currentDay)
                {
                    totalFee += Math.Min(dayFee + activeFee, 60);
                    dayFee = 0;
                    activeFee = 0;
                    currentDay = pass.Date;
                    firstPassThisHour = pass;
                }

                if ((pass - firstPassThisHour).TotalMinutes > 60)
                {
                    dayFee += activeFee;
                    activeFee = nextFee;
                    firstPassThisHour = pass;
                }
                else
                {
                    activeFee = Math.Max(activeFee, nextFee);
                }
            }
            totalFee += Math.Min(dayFee + activeFee, 60);
            return totalFee;
        }

        private bool TollFreeVehicle(IVehicle vehicle)
        {
            return vehicle.IsTollFreeVehicle;
        }

        public int GetTollFee(DateTime date, IVehicle vehicle)
        {
            if (IsTollFreeDate(date) || TollFreeVehicle(vehicle)) return 0;

            TimeSpan time = date.TimeOfDay;

            foreach (TimeInterval timeInterval in timeIntervals)
            {
                if (timeInterval.IsWithinInterval(time))
                    return timeInterval.Fee;
            }
            return 0;
        }

        private readonly List<TimeInterval> timeIntervals = new List<TimeInterval>
        {
            new TimeInterval(new TimeSpan(6, 0, 0), new TimeSpan(6, 29, 59), 8),
            new TimeInterval(new TimeSpan(6, 30, 0), new TimeSpan(6, 59, 59), 13),
            new TimeInterval(new TimeSpan(7, 0, 0), new TimeSpan(7, 59, 59), 18),
            new TimeInterval(new TimeSpan(8, 0, 0), new TimeSpan(8, 29, 59), 13),
            new TimeInterval(new TimeSpan(8, 30, 0), new TimeSpan(14, 59, 59), 8),
            new TimeInterval(new TimeSpan(15, 0, 0), new TimeSpan(15, 29, 59), 13),
            new TimeInterval(new TimeSpan(15, 30, 0), new TimeSpan(16, 59, 59), 18),
            new TimeInterval(new TimeSpan(17, 0, 0), new TimeSpan(17, 59, 59), 13),
            new TimeInterval(new TimeSpan(18, 0, 0), new TimeSpan(18, 29, 59), 8),
        };

        private bool IsTollFreeDate(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

            if (year == 2024) // Denna funktion borde vara kopplad till en API.
            {
                if (month == 1 && day == 1 ||
                    month == 1 && day == 6 ||
                    month == 3 && (day == 29 || day == 31) ||
                    month == 4 && day == 1 ||
                    month == 5 && (day == 1 || day == 9 || day == 19) ||
                    month == 6 && (day == 6 || day == 21 || day == 22) ||
                    month == 11 && day == 2 ||
                    month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
                {
                    return true;
                }
            }
            return false;
        }
    }
}