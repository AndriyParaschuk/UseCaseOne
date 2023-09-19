# UseCaseOne

# .NET Web API Application

This is a .NET Web API application that can be used to retrieve data from an public API.
User can filter countries by name, population. There is posibility to otder countries by name and apply pagination.
In case when user has need to gather all data without filters all parameters should be null.

## Getting Started

1. Clone the repository.
2. Open the project in Visual Studio or your favorite IDE.
3. Run the following command to build the project:
   dotnet build
4. Run the following command to start the application:
   dotnet run
5. The application will be started on port 7278 by default. You can access the application by opening a web browser and navigating to the following URL:
   https://localhost:7278/swagger/index.html

## Usage

The application exposes the following endpoint:

* `api/Country`: Get a list of countries. Ignore parameters for filtering countries to get unmodified list or set filters to get filtered list.
  
  Samples of request body to use the endpoint :
    - Without any filters
       ```
       {
          "search": "string",
          "populationFilter": 0,
          "sort": "string",
          "countriesCount": 0
        }
       ```
    - To filter countries by name
       ```
       {
         "search": "Ukr",
       }
       ```
    - To filter countries by population (in millions)
       ```
       {
         "populationFilter": 3,
       }
       ```
    - To order countries by name (Asc)
       ```
       {
         "sort": "ascend",
       }
       ```
    - To order countries by name (Desc)
       ```
       {
         "sort": "descend",
       }
       ```
    - To take first 10 countries
       ```
       {
         "countriesCount": 10
       }
       ```
    - To take first 10 filtered by name countries
       ```
       {
         "search": "am",
         "sort": "descend",
         "countriesCount": 10
       }
       ```
    - To take countries filtered by population countries
       ```
       {
         "populationFilter": 3,
         "sort": "descend"
       }
       ```
    - To take countries filtered by name and population countries
       ```
       {
         "search": "am",
         "populationFilter": 3,
         "sort": "descend"
       }
       ```
    - With all filters
       ```
       {
         "search": "a",
         "populationFilter": 1,
         "sort": "ascend",
         "countriesCount": 5
       }
       ```

## Contributing

Contributions are welcome! Please open a pull request if you have any changes or improvements.

## License

This project is licensed under the MIT License.