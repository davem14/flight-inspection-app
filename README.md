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


![image](https://user-images.githubusercontent.com/72437425/114621880-ed595380-9cb5-11eb-8b42-54ebbc7d7511.png)


## General structure of the folders:
1. **flight-inspection-app**:
    - model:
      - file "Flight_Model" - this is the model in the architecture MVVM
    - vm:
      - file "VM_Login" -  the view model of the view login.
      - file "VM_PlayBar" - the view model of the view play bar.
      - file "VM_Details" - the view model of the view details.
      - file "VM_Joystick" - the view model of the view joystick.
      - file "VM_Grahp" - the view model of the view graph.
      - file "VM_Screen" - this view model is for communication with the app "FlightGear".
      - file "VM_DLLUpload" - the view model of the DLLUpload window.
      - file "VM_Detector" - the view model of the view detector and uses the algorythm in the uploaded DLL. 
      - folders: reading_files_classes - classes handling with files. correlation_classes, statistics - help with drawing graphs.
    - view:
      - file "login"
      - file "playBar"
      - file "details"
      - file "joystick"
      - file "graph"
      - file "MainWindow" - 
2. **plugins**:
in this folder are anomaly detection algorythms as '.dll' files and 'IAD.dll' interface to be implemented by future plugins.

4. **documentation**:
In this folder there is more documentation about the classes.


## Necessary installations to work with the code:
1. .NET Framework 4.7.2
2. Packages: OxyPlot.Core, OxyPlot.Wpf

## App instalation and using instructions:

### Instalation instructions:
1. Download the zip file of the project with all the folders.
2. Unzip the file (it's impossible to run the setup from the zip file).
3. Go to: Setup_Flight_Inspection_App\Release\ and run the setup file.
>Note: After running the setup process it may take a while to get the OS request to allow the installetion.

### Using instructions:
**prior to the app execution**:
1. Copy your XML file into location: C:\Program Files\FlightGear[VERSION]\data\Protocol\"
2. Copy the two lines below and paste them into the FlightGear's settings in 'additional settings' section:
```
--generic=socket,in,10,127.0.0.1,5400,tcp,XXXXXXXXXX
--fdm=null
```
(replace XXXXXXXXXX with your XML file's name without its 'xml' extension)

**after starting the app run:**
1. Enter 'csv' file that contains the flight data that you want to investigate, and also 'xml' file that matches the csv file.
2. Open the app 'FlightGear' and press 'Fly' and wait until the airplane will be displayed, then press 'continue'.
>Note: It's possible running the app without the airplane's display (FlightGear app), but if you choose to do so you will not be able to start the airplane's displey during running.

### Plugin system using instructions:
The plugins SimpleAD and MinCircAD communicate locally with an Anomaly-Detection-Server (ADserver). therefore in order to use those plugins, **'ADserver' must be activated on linux environment** first. The server can handle unlimited amount of clients, one client at a time, so there's no need of further activation. Server is shut down by Ctrl + C.

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
https://youtu.be/RpE0JQ6Lt-4

## Developed by:
* Yuval Tal
* David Emanuel
* Yaniv Rotics
* Dov Moshe

## Downloads:
* FlightGear
link: https://www.flightgear.org/
