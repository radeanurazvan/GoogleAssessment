using System.Collections.Generic;
using System.Linq;

namespace GoogleAssessment.Entry
{
    public static class GuestsMapper
    {
        public static IEnumerable<Guest> FromTimes(int[] arrivals, int[] leaves)
        {
            return arrivals.ToList()
                .Select((arrivingAt, i) =>
                {
                    var leavingAt = leaves.ElementAt(i);

                    return new Guest(arrivingAt, leavingAt);
                });
        } 
    }

    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> toAdd)
        {
            foreach (var x in toAdd)
            {
                collection.Add(x);
            }
        }
    }

    public class GuestChairCalculator
    {
        private ICollection<Chair> chairs;

        public GuestChairCalculator()
        {
            this.chairs = new List<Chair>();
        }

        public int CalculateFor(IEnumerable<Guest> guests)
        {
            if (!guests.Any())
            {
                return 0;
            }

            var minArrival = guests.Min(g => g.Arrival);
            var maxLeaving= guests.Max(g => g.Leaving);

            for (var time = minArrival; time <= maxLeaving; time++)
            {
                var arrivingGuests = guests.Where(g => g.Arrival == time);
                if (!arrivingGuests.Any())
                {
                    continue;
                }

                if (!IsChairAvailable(time))
                {
                    var additionalChairs = arrivingGuests.Select(Chair.ForGuest);
                    chairs.AddRange(additionalChairs);
                }    
            }

            return chairs.Count;
        }

        private bool IsChairAvailable(int time)
        {
            return chairs.Any(c => c.IsAvailable(time));
        }
    }

    public sealed class Chair
    {
        private Chair()
        {
            
        }

        public int BusyFrom { get; private set; }

        public int BusyUntil { get; private set; }

        public bool IsAvailable(int time)
        {
            var timeInBusyRange = BusyFrom <= time && BusyUntil > time;

            return !timeInBusyRange;
        }

        public void OccupyBy(Guest guest)
        {
            this.BusyFrom = guest.Arrival;
            this.BusyUntil = guest.Leaving;
        }

        public static Chair ForGuest(Guest guest)
        {
            var chair = new Chair();
            chair.OccupyBy(guest);

            return chair;
        }
    }

    public sealed class Guest
    {
        public Guest(int arrival, int leaving)
        {
            Arrival = arrival;
            Leaving = leaving;
        }

        public int Arrival { get; }

        public int Leaving { get; }
    }
}