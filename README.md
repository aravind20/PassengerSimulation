# PassengerSimulation
Simulation to find probability of last passenger to get own seat

# Architecture

Layered decoupled application divided in to following projects

  * PassengerSeatingSimulation 
  * PassengerSeatingSimulation.Domain ( for storing domain models)
  * Architecture ( service layer)
  * PassengerSeatingSimulation.Tests ( Test classes for service and application methods)

# Description

  PassengerSeatingSimulation (console) project provides the application layer which takes input from user that how many times simulation should be run.Based on user input application makes calls to PassengerSeatingService and calculates probability for last passenger to occupy his/her own seat. Number of seats can be adjusted from app.config entry.
Application generates passenger seating based on random values for allocated seat number and occupied seat number. Application ensures once an allocated seat can not be allocated to another passenger. same applies for occupied seat also .

# Technologies

  * C sharp / Dot net 5.0 
  * AutoFac for Implementing IoC
  * Visual studio 2019
  * MS Test for writing unit tests

# Running this solution

  * Get latest from repo
  * click manage nuget for the solution and update ( to fetch auto fac)
  * run this application in Visual studio 
  * Once screen is loaded input how many times you like to run this simulation , once user inputs this application will run generating passengers and finds probability for last     passenger to get own seat.

If you like to know more about this or any issues , feel free to mail me . (raj.pandian@gmail.com)


   

