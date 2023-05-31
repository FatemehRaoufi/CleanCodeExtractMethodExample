namespace CleanCodeExtractMethodExample
{
    public class SearchSmartphones
    {
        //list of available smartphone results
        List<string> smartphones = new List<string>()
    {
    "Samsung Galaxy S20",
    "Pixel 2",
    "Pixel 3",
    "Pixel 4",
    "iPhone XR",
    "iPhone 12",
    "iPhone 12 Pro",
    "iPhone 12 Pro Max"
    };

        //long method that we will refactor
        public void PerformSearch()
        {
            bool continueSearch = true;

            while (continueSearch)
            {
                SearchForSmartphones();

               
                
                continueSearch = ShouldContinueWithSearch(continueSearch);
            }

            Console.Write("Thanks for searching!");
        }

        private static bool ShouldContinueWithSearch(bool continueSearch)
        {
            //this asks user if he wants to search again
            //valid responses are Y and N
            //the program stops if the answer is N
            string continueSearchResponse;
            do
            {
                Console.Write("\nMake another search (y/n)?: ");
                continueSearchResponse = Console.ReadLine();

                if (continueSearchResponse.ToLower() == "n")
                {
                    continueSearch = false;
                    break;
                }
                if (continueSearchResponse.ToLower() != "y")
                {
                    Console.WriteLine("Invalid response.");
                }

            } while (continueSearchResponse.ToLower() != "n"
                                     && continueSearchResponse.ToLower() != "y");
            return continueSearch;
        }

        private void SearchForSmartphones()
        {
            //user enters the term
            Console.Write("Search for smartphone: ");
            string keyword = Console.ReadLine();

            var results = smartphones
                .Where(phone => phone
                                    .ToLower()
                                    .Contains(keyword.ToLower()));
            //if there are resuls, they are displayed in the output
            if (results != null)
            {
                Console.WriteLine("Here are the matched results.\n");

                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
            }
            else
            {
                Console.WriteLine("No results found.");
            }
        }
    }
}

//Source: https://methodpoet.com/extract-method/
//PerformSearch without using Extract methods:
/*
public void PerformSearch()
{
    bool continueSearch = true;

    while (continueSearch)
    {
        //user enters the term
        Console.Write("Search for smartphone: ");
        string keyword = Console.ReadLine();

        var results = smartphones
            .Where(phone => phone
                                .ToLower()
                                .Contains(keyword.ToLower()));
        //if there are resuls, they are displayed in the output
        if (results != null)
        {
            Console.WriteLine("Here are the matched results.\n");

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
        else
        {
            Console.WriteLine("No results found.");
        }

        //this asks user if he wants to search again
        //valid responses are Y and N
        //the program stops if the answer is N
        string continueSearchResponse;
        do
        {
            Console.Write("\nMake another search (y/n)?: ");
            continueSearchResponse = Console.ReadLine();

            if (continueSearchResponse.ToLower() == "n")
            {
                continueSearch = false;
                break;
            }
            if (continueSearchResponse.ToLower() != "y")
            {
                Console.WriteLine("Invalid response.");
            }

        } while (continueSearchResponse.ToLower() != "n"
                 && continueSearchResponse.ToLower() != "y");
    }

    Console.Write("Thanks for searching!");
} 
 */