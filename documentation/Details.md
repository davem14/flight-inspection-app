### More details about the 'Details':

To present the details of the flight, we created 2 classes.

**view.details class:**
The view.details class is in the view part of the project and is used to present the gui data on the screen.
This class is defined as a user control and uses the grid structure to show the data.
In 6 positions on the grid, 6 data fields from the flight are presented.
This fields are changed all the time in accordance with the flight progress.
The way this changes are reflected in the screen is in a label by using binding to the content parameter of a label.
For example:
<Label Content="{Binding VM_Height}"
Will get the data from the VM_hehight property
The other classes are build in such a way that whenever there will be a change to the VM property, this change will be reflected in the content of the corresponding label.

**VM_details class:**
The VM_details class is in the view_model part of the project and is used to retrieve the data from the model and pass it to the gui part of the project which is presented by the class view.details described above.
The method is to wait for a change in a property of the model. 
If such a change occurs, the code will be invoked and in this class it will be checked if the property line is changed.
Since line contains a full line of data which consists of many fields, the task of this class is to extract from line the fields which are relevant to the six details that are presented by the corresponding gui class.
For example words[25] contains the data of the height field and this is a signed to the height variable.
Then the NotifyPropertyChanged("VM_Height") command will indicate that a change was done in the VM_Height property and as a result of it, this change will be presented in the screen with the corresponding gui class.

