# flight-inspection-app

## About the desktop application:
The purpose of this application is help investigate data of flight. The app using with app "FlightGear" as a screen to display the airplane.
In the application there is several features: play bar, corrrlation between category, joystick, plugin system to upload anomaly detector and more.

The app was written in architecture of MVVM.


## General structure of the folders:
1. **flight-inspection-app**:
  - model:
    - file "Flight_Model" - this is the model in the architecture MVVM
  - vm:
    - file "VM_Login" - 
    - file "VM_PlayBar" - the view model of the view play bar.
    - file "VM_Details" - the view model of hte view details.
    - file "VM_Joystick" - the view model of hte view joystick.
    - file "VM_Grahp" - the view model of hte view graph.
    - file "VM_Screen" - this view model is for communication with the app "FlightGear".
    - folders: reading_files_classes - classes handling with files. correlation_classes, statistics - help with drawing graphs.
    - ///
  - view:
    - file "login"
    - file "playBar"
    - file "details"
    - file "joystick"
    - file "graph"
    - 
  - file "MainWindow" - 
2. **plugin**:
4. **documentation**:
In this folder there is more documentation about the classes.


## Necessary installations to work with the code:
1. .NET Framework 4.7.2
2. Packages: OxyPlot.Core, OxyPlot.Wpf

## Installing the app:

## More documentation about the classes:

## Link to video


## Owners
* Yuval Tal
* David Emanuel
* Yaniv Rotics
* Dov Moshe

## Downloads:
* FlightGear
link: https://www.flightgear.org/

* 
