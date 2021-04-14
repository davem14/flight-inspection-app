### More details about the 'Joystick':

To present the joystick of the flight, we created 2 classes. 

**view.joystick class:**
The view. joystick class is in the view part of the project and is used to present the gui of the joystick on the screen. This class is defined as a user control and uses 2 sliders to present the Throttle and the Rudder, and several canvas to present the wheel of the joystick. The internal canvas contains an elipse and a path that will move together depending on the changes in the values of the elevator and aileron. The movment of the 2 elements together is achived since thay both belong to the same canvas, that will move since its left and its top properties depend on the values of the VM_Left and the VM_Top properties of the corresponding view model class,

**VM_ joystick class:**
The VM_ joystick class is in the view_model part of the project and is used to retrieve the data from the model and pass it to the gui part of the project which is presented by the class view.joystick described above. The method is to wait for a change in a property of the model. If such a change occurs, the code will be invoked and in this class it will be checked if the property line is changed. Since line contains a full line of data which consists of many fields, the task of this class is to extract from line the fields which are relevant to the 4 flight elements that are presented by the corresponding gui class. For example words[0] contains the data of the aileron field and this is a signed to the aileron variable. Then the NotifyPropertyChanged("VM_Aileron") command will indicate that a change was done in the VM_ Aileron property and as a result of it, this change will be presented in the screen with the corresponding gui class.

