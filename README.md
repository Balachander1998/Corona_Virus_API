# Corona_Virus_API
*The following Project which triggers the current status of corona virus  by using an API Call and stores the data in an SQL Server by using an C# Application.  The .exe file is then triggered from Apache NiFi.*


**Program Description** 


    1. A C# Console Application has been Created for Calling the following REST API: https://corona.lmao.ninja/countries
    
    2. Using HTTPWebRequest and HTTPWebResponse Class on c# the response from the above API is obtained and the JSON Array is Parsed using the Newtonsoft JSON Library on Nuget Packages.
    
    3. The Parsed Content is Moved to the MS SQL Sever.
   
    
    4. Build the solution in Release Mode and get the .exe file.
    
    5. Install  Apache NiFi  (ETL Tool)  in your machine and dragg the Execute Process Processor for triggering the NiFi to execute the .exe file daily and in order to update values.
    
###  To install NiFi Refer the following URL:-https://nifi.apache.org/docs/nifi-docs/html/getting-started.html ###   


    6. Use any Data Visualization Tool to view the dashboard.
