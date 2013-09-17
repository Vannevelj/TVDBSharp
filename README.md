TVDBSharp
=========

**A C# wrapper for the TVDB API.**

This API provides an easy-to-use interface to the TVDB API by translating the XML responses into objects. 
You won't need any knowledge about the API itself to use this library.

To get started there are a few steps you have to undertake.

**1) Get an API key.**  
This is as easy as filling out a form on TheTVDB's webpage. 
Read the rules and enter your information, you can find your API key under 'Account'.

http://thetvdb.com/?tab=apiregister

**2) Optionally: familiarize yourself with the API itself.**  
You don't have to do this, but some people might want to read up on the, although slightly outdated, API.

http://www.thetvdb.com/wiki/index.php?title=Programmers_API

**3) Import the library.**  
This can be done by either forking this repository and compiling it yourself 
or by downloading the latest version from the link below.

https://mega.co.nz/#!VQdlDIYD!V_W2OCeHeCvnPrtAIfduD2LwPp5B3d_rmrcnNE1cpHg

Add it as a reference to your project and you're all set.

**4) Use it!**  
You can now use TVDBSharp in your own project.
Look trough the examples project if you aren't entirely sure how to get started.

A simple example:

    var tvdb = new TVDB("mykey"); // Create a new TVDB object with your API key.
    var results = tvdb.Search("Suits", 3); // Search for series called "Suits" and take the top-3.
    
    foreach(var show in results){
     Console.WriteLine({0}:\t{1}, show.Name, show.ID); // Print every show's name and ID
    }
