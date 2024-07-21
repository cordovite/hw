using System;

// Class to represent an Address
public class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;

    public Address(string streetAddress, string city, string state, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public override string ToString()
    {
        return $"{streetAddress}, {city}, {state}, {country}";
    }
}

// Base class for an Event
public abstract class Event
{
    private string title;
    private string description;
    private DateTime date;
    private string time;
    private Address address;

    protected Event(string title, string description, DateTime date, string time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address}";
    }

    public abstract string GetFullDetails();

    public string GetShortDescription()
    {
        return $"Event Type: {this.GetType().Name}\nTitle: {title}\nDate: {date.ToShortDateString()}";
    }

    protected string GetCommonDetails()
    {
        return $"{GetStandardDetails()}\nEvent Type: {this.GetType().Name}";
    }
}

// Derived class for a Lecture
public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetCommonDetails()}\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

// Derived class for a Reception
public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{GetCommonDetails()}\nRSVP Email: {rsvpEmail}";
    }
}

// Derived class for an Outdoor Gathering
public class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{GetCommonDetails()}\nWeather Forecast: {weatherForecast}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Address address2 = new Address("456 Maple Ave", "Othertown", "ON", "Canada");
        Address address3 = new Address("789 Oak Blvd", "Sometown", "TX", "USA");

        // Create events
        Event lecture = new Lecture("Tech Talk", "A lecture on the latest in tech", new DateTime(2024, 8, 15), "10:00 AM", address1, "Dr. Smith", 100);
        Event reception = new Reception("Business Networking", "An evening of networking", new DateTime(2024, 8, 20), "6:00 PM", address2, "rsvp@business.com");
        Event outdoorGathering = new OutdoorGathering("Summer Picnic", "An outdoor picnic for families", new DateTime(2024, 8, 25), "12:00 PM", address3, "Sunny, 75°F");

        // List of events
        Event[] events = { lecture, reception, outdoorGathering };

        // Display marketing messages for each event
        foreach (var ev in events)
        {
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine();
        }
    }
}
