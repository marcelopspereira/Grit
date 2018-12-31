# General Notes for GRIT
GRIT is the side project of Grant Watson to build a better CRM tool

This will be an open sourced CRM tool built with ASP.NET Core 2.2


# GRIT Stands for?
GRIT stands for Growth, Relations, and Interactions Terminal. This tool is set to redefine what CRM tools are meant to be. Yes, this is a CRM tool, but it is built in the mindset of a user, and how that user is able to see/manipulate data.


# GRIT website?

http://grit.azurewebsites.net

# Technologies used:

Of course the big one is ASP.NET Core with MVC, I like using the most "up-to-date" frameworks out there. ASP.NET is a clean data driven framework, that makes it clear and clean to how to derive what data I want in each view. 

I am going with Entity Framework for my data. More specifically I am going the route of code-first writing for my data bases. For example, I create a model of which I want my data to look like for a view, I implement that DbSet into a DbContext, and scaffold out my database from the terminal using dotnet ef migrations add 'SomethingMigration' and dotnet ef database update. 

More information found through this site: https://docs.microsoft.com/en-us/ef/#pivot=entityfmwk
