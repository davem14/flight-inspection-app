# flight-inspection-app

## About this Windows desktop application:

### The purpose:
This app purpose is to investigate flight's data. The app has several features: control over the flight's video using controls, displaying the main flight's data (such as speed and height), statistical data – correlation between categories with graphs, joystick that moves according to flight's data and plugin system that allows uploading 'anomaly detector' to detect animalities during the flight.

### General operation:
To be able running the app the user has to enter the app 'csv' file that contains the flight data that the user wants to investigate, and also 'xml' file that belongs to the csv file. In addition, the user can use FlightGear application in order to get the airplane's display.
This app is simple to use with full control over the flight's recording.

### The design pattern implemented in the app:
The app was designed with MVVM architecture. The model's name is 'Flight Model' and is used by all View Model parts. The 'model' notifies each time a new data line is red, and each 'view model' registered to get a notification can retrieve the current line. The model can receive commands using methods it exposes. It can change the inner state by Properties.
In addition to the 'model', each part of the app has 'view model' and 'model'. The 'view model' receives notifications from the 'model' and passes on the needed data to the 'view' by using 'Data Context' and 'binding'.

### Developing tools:
The app was written using the developing tool 'WPF' with .NET Framework platform. This development tool was chosen because this is Windows desktop application, and it is suitable for Windows desktop app development. In addition, this platform fully supports MVVM architecture.

More details about each part of the application can be viewed at appropriate file.


![screen3](https://user-images.githubusercontent.com/72437425/114620193-0234e780-9cb4-11eb-9e0f-d5555dffef94.jpg)







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
      - file dll ???????
    - view:
      - file "login"
      - file "playBar"
      - file "details"
      - file "joystick"
      - file "graph"
      - file dll ???????
    - file "MainWindow" - 
2. **plugin**:
4. **documentation**:
In this folder there is more documentation about the classes.


## Necessary installations to work with the code:
1. .NET Framework 4.7.2
2. Packages: OxyPlot.Core, OxyPlot.Wpf

## App instalation and using instructions:

### Instalation instructions:

### Using instructions:

### Plugin system using instructions:
The plugins SimpleAD and MinCircAD communicate locally with an Anomaly-Detection-Server (ADserver). therefore in order to use a Dll, **ADserver must be activated on linux environment** first. The server can handle unlimited amount of clients, one client at a time, so there's no need of further activation. Server is shut down by Ctrl + C.

## More documentation about the classes:
- [Flight Model](documentation/Model.md)
- [Login](documentation/Login.md)
- [PlayBar](documentation/PlayBar.md)
- [Details](documentation/Details.md)
- [Joystick](documentation/Joystick.md)
- [Graph](documentation/Graph.md)
- [DLL plugin](documentation/Dll.md)
- [UML diagram](documentation/uml.pdf)

## Link to video for demo of using:


## Developed by:
* Yuval Tal
* David Emanuel
* Yaniv Rotics
* Dov Moshe

## Downloads:
* FlightGear
link: https://www.flightgear.org/

* 
