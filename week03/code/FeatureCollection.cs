using System.ComponentModel;

public class FeatureCollection //this is the JSON Features array which holds details about each earthquake
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    public List<Feature> Features { get; set; } //list of feature objects (each object representing an earthquake)
    public class Feature
    {
        public Properties Properties { get; set; } // sets and contains the information like magnitude, location, etc.
    }

    public class Properties //this class represents the inner properties object in the JSON structure, building specific data points about the earthquake
    {
        public double Mag { get; set; } // mag in the JSON maps to this property, basically representing the magnitude of the earthquake
        public string Place { get; set; } // place in the JSON maps to this property, basically describing the location where the earthquake occured
    }
}