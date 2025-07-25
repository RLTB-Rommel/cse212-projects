// I ran the project before modifying this method to ensure that the test setup and project structure were working correctly
// The test for this method failed, as expected. The test returned: 
// "Failed!  - Failed:    13, Passed:     2, Skipped:     0, Total:    15, Duration: 11 s"

// I will now implement the logic to find symmetry word pairs in O(n) time using the HashSet to this:
// public static string[] FindPairs(string[] words)

/// after implementing the logic in the public static string[] FindPairs(string[] words) I ran again the dotnet test, it returned this:
/// Failed!  - Failed:     8, Passed:     7, Skipped:     0, Total:    15, Duration: 18 s
/// After running the test I realized that the output should be shown alphabetically so I will include this line: 
/// pair.Sort();
/// result.Add($"{pair[0]} & {pair[1]}");
/// I ran the dotnet test again and all FindPairs()-related tests now passed

/// I will now do Problem 2 involving census.txt...

/// The census.txt CSV file will be read and then be summarized the times each degree appears.
/// The degree is expected iin the fourth column (index 3 )of each line.
/// It returns a dictionary where:
/// --> Key = degree name (e.g., "PhD")
/// --> Value = the number of people who earned the degree.
/// I will now implement the logic to check for anagrams in the IsAnagram method in O(n) time using a dictionary.
/// after completing the code for "public static Dictionary<string, int> SummarizeDegrees(string filename)" 
/// the test for SummarizeCensusDegrees has passed it is no longer in the lists of failed tests.

/// I will now do Problem 3 involving IsAnagram...

/// My steps will be to first clean both strings (ensure there is no space and that strings are lowercase)
/// Second, count the letters in word1; third, decrease the counts using word2, fourth, conclude that if all counts become 0, meaning no extra or missing letters exist - indicative of an anagram
/// I will now implement this logic to  "public static bool IsAnagram(string word1, string word2)"]
/// I now ran dotnet test and all IsAnagram_*test passed
/// 
/// I just finished making the Maze.cs (another file). I will now be working for a possible additional credit by working on the Earthquake JSON data problem
/// I ran the dotnet test and obtained this output: Passed!  - Failed:     0, Passed:    15, Skipped:     0, Total:    15, Duration: 20 s - code.dll (net8.0)
/// this means that all 15 tests passed successfully


using System.Text.Json; //originally included in the provided cs file which provide the JSON serialization and deserialization tools
using System.Net.Http; //this is added to enable sending HTTP requests to external servers such as the USGS where we will retrive the data
using System.Text.Json.Serialization; //this is added to allow mapping JSON property names to C# properties using attributes


public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE:

        var seen = new HashSet<string>(); // this is to store available words
        var result = new List<string>(); // this is to store symmetric pairs

        foreach (var word in words)

        {
            if (word[0] == word[1]) //compare the first character word[0] and second character word[1]
                continue; // skip it if they are the same

            string reversed = new string(new char[] { word[1], word[0] }); //obviously I interchange word[0], word[1] as they represent the 1st and 2nd charaters

            //setup to reverse the word

            if (seen.Contains(reversed))
            {
                var pair = new List<string> { word, reversed };
                pair.Sort(); // now pair[0] is the smaller word    
                result.Add($"{pair[0]} & {pair[1]}"); //if reversed is satisfied it's added
            }
            else
            {
                seen.Add(word);// if the reverse is not seen yet store for a later match 
            }

        }
        ///return [];
        return result.ToArray(); //now return the result as an array  
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename)) // reads each line from the file, one at a time
        {
            var fields = line.Split(","); // this line splits the line by commas into fields
            // TODO Problem 2 - ADD YOUR CODE HERE

            if (fields.Length > 3) //this is to check if the line has at least 4 columns
            {

                //get the value from the column (index 3)
                string degree = fields[3].Trim(); // use Trim() to remove extra whitespace
                if (degrees.ContainsKey(degree)) //this is to check if the degree already exists in the dictionary
                {
                    degrees[degree]++; // increment the count by 1 if it is a yes
                }
                else
                {
                    degrees[degree] = 1; //if not, add it with an initial count of 1
                }

                // if the line doesn't have enough columns, it is skipped.
            }
        }

        return degrees; // returns dict containing degree counts
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE

        word1 = word1.Replace(" ", "").ToLower(); // normalize the 1st string and convert to lower case
        word2 = word2.Replace(" ", "").ToLower(); // normalize the 2nd string and convert to lower case

        //I will now check the lengths are different after cleaning. If they are not the same they can't be anagrams
        if (word1.Length != word2.Length)
            return false;

        //employ dictionary to count characters in word1
        var letterCount = new Dictionary<char, int>();

        //count each character in word1
        foreach (char c in word1)
        {
            if (letterCount.ContainsKey(c))
                letterCount[c]++;
            else
                letterCount[c] = 1;
        }

        // subtract counts using characters in word2
        foreach (char c in word2)
        {
            if (!letterCount.ContainsKey(c))
            return false; //extra letter in word2

            letterCount[c]--;

            if (letterCount[c] < 0)
                return false; // too many of the same letter in word2    
        }
        //If all counts are zero, it's an anagram
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties [checked]*
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.

        // Safety check
        if (featureCollection?.Features == null)//check that there is a non null Features list
            return Array.Empty<string>(); //return an empty string if it is null

        // Build formatted strings: "Location - Mag X.YZ"
        var summary = new List<string>(); //initialize a list to store the formatted earthquake descriptions

        //loop through earthquake 'Feature' in the collection
        foreach (var feature in featureCollection.Features)
        {
            string place = feature.Properties.Place ?? "Unknown location"; //get place or location of the earthquake. if null use "Unknown location"
            double mag = feature.Properties.Mag; //get magnitude of the earthquake

            summary.Add($"{place} - Mag {mag}");// this is to add the formatted string to summary list
        }

        return summary.ToArray(); //this is to convert the List<string> to a string array and then to return it
    }
}