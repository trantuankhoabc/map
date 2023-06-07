// will act as inmemory db
// static classes contain static members, so when we create a ctor, it is not possible to refresh a static object, so we defined a ctor static

using _3_locationDemo.Models;

namespace _3_locationDemo.Data
{
    public static class ApplicationContext ////Static classes do not need instances as they can be accessed directly without instantiation. However, non-static classes can be used when an instance is created. Each instance can be thought of as a different object of the same class, and the properties and behavior of each object are unique to that instance.
    {
        public static List<Location> Locations { get; set; }
        static ApplicationContext()
        {
            Locations = new List<Location>()
            {
                new Location() {Id=1, LocationName="L1", X= 35.1, Y=42.1},
                new Location() {Id=2, LocationName="L2", X= 35.2, Y=42.2},
                new Location() {Id=3, LocationName="L3", X= 35.3, Y=42.3}
            };
        }
    }
}
