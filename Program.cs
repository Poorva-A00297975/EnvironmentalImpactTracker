using System;

class EnvironmentalImpactTracker
{
    private readonly System.Collections.Generic.Dictionary<string, double> impactScores;
    private double cumulativeImpact;

    public EnvironmentalImpactTracker()
    {
        // Initialize environmental impact scores for different activities
        impactScores = new System.Collections.Generic.Dictionary<string, double>
        {
            { "electricity_consumption", 2.5 },
            { "car_travel", 5.0 },
            { "bike_travel", 1.0 },
            { "public_transport", 2.0 }
            // Add more activities and impact scores as needed
        };
        cumulativeImpact = 0.0;
    }

    public void TrackActivity()
    {
        Console.Write("Enter the activity (e.g., electricity_consumption): ");
        string activity = Console.ReadLine().ToLower(); // Convert to lowercase for case-insensitivity

        if (impactScores.TryGetValue(activity, out double activityScore))
        {
            Console.Write("Enter the duration in hours: ");

            if (double.TryParse(Console.ReadLine(), out double duration))
            {
                // Calculate and display the environmental impact
                double impact = activityScore * duration;
                cumulativeImpact += impact;

                Console.WriteLine($"Environmental Impact for {activity}: {impact} units");
            }
            else
            {
                Console.WriteLine("Invalid input for duration. Please enter a valid number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid activity. Please enter a valid activity.");
        }
    }

    public void CheckEnvironmentalSecurity()
    {
        // Set a threshold for environmental security
        const double securityThreshold = 50.0;

        // Check if the cumulative impact exceeds the threshold
        if (cumulativeImpact > securityThreshold)
        {
            Console.WriteLine("\nThe environment is not secure! Take action to reduce your environmental impact.");
        }
        else
        {
            Console.WriteLine("\nThe environment is secure. Keep up the good work!");
        }
    }
}

class Program
{
    static void Main()
    {
        EnvironmentalImpactTracker tracker = new EnvironmentalImpactTracker();

        char choice;
        do
        {
            // Allow the user to track multiple activities
            tracker.TrackActivity();
            // Check and display environmental security status
            tracker.CheckEnvironmentalSecurity();

            // Ask if the user wants to track another activity
            Console.Write("Do you want to track another activity? (y/n): ");
            choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

        } while (choice == 'y' || choice == 'Y');

        
    }
}


