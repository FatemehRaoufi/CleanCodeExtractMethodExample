# Clean Code - Extract Method Example

This example demonstrates the **Extract Method** refactoring technique in C#. It refactors a method into smaller, more manageable methods, improving code readability, maintainability, and testability. 

## Overview

The original method `PerformSearch()` in the `SearchSmartphones` class was long and difficult to read. Using the **Extract Method** technique, the method was broken down into several smaller methods, each responsible for one task. This makes the code cleaner, easier to maintain, and more modular.

### Before Refactoring

The `PerformSearch` method in the original code was long and contained multiple concerns, including:
- Gathering user input
- Performing a search operation
- Displaying search results
- Asking the user if they wanted to perform another search

### After Refactoring

The refactored version uses **Extract Method** to break down the large method into smaller, more manageable methods:
- `GetSearchKeyword()` – Retrieves the search term from the user.
- `SearchForSmartphones()` – Performs the actual search logic.
- `DisplaySearchResults()` – Displays the results or informs the user if no matches were found.
- `ShouldContinueWithSearch()` – Asks the user if they want to continue searching.

## Refactored Code Example

```csharp
namespace CleanCodeExtractMethodExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the SearchSmartphones class
            SearchSmartphones searchSmartphones = new SearchSmartphones();
            // Call the PerformSearch method to start the search process
            searchSmartphones.PerformSearch();
        }
    }

    public class SearchSmartphones
    {
        // List of available smartphone results
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

        // Refactored method using Extract Method
        public void PerformSearch()
        {
            bool continueSearch = true;

            while (continueSearch)
            {
                string keyword = GetSearchKeyword();
                var results = SearchForSmartphones(keyword);

                DisplaySearchResults(results);
                continueSearch = ShouldContinueWithSearch();
            }

            Console.WriteLine("Thanks for searching!");
        }

        // Extracted method to get search keyword from the user
        private string GetSearchKeyword()
        {
            Console.Write("Search for smartphone: ");
            return Console.ReadLine();
        }

        // Extracted method to perform the search and get results
        private IEnumerable<string> SearchForSmartphones(string keyword)
        {
            return smartphones
                .Where(phone => phone
                                    .ToLower()
                                    .Contains(keyword.ToLower()));
        }

        // Extracted method to display results to the user
        private void DisplaySearchResults(IEnumerable<string> results)
        {
            if (results.Any())
            {
                Console.WriteLine("Here are the matched results:\n");
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

        // Extracted method for asking if the user wants to continue
        private bool ShouldContinueWithSearch()
        {
            string continueSearchResponse;
            do
            {
                Console.Write("\nMake another search (y/n)?: ");
                continueSearchResponse = Console.ReadLine();

                if (continueSearchResponse.ToLower() == "n")
                {
                    return false;
                }
                if (continueSearchResponse.ToLower() != "y")
                {
                    Console.WriteLine("Invalid response.");
                }

            } while (continueSearchResponse.ToLower() != "n"
                     && continueSearchResponse.ToLower() != "y");

            return true;
        }
    }
}
