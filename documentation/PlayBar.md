### More details about the 'PlayBar':

**The view part:**

Using the controls of this part we can control the recording. There are buttons of play, pause skip and more, by using this we send commands to the VM_PlayBar. There is a silder that uses 'binding' and 'DataContext' to communicate with the property 'VM_Step' which is located in the 'view model'. Also, there is an option to change the reording's speed, and it also uses 'binding' and 'DataContext' to communicate with the property 'VM_Speed'. There is a time display that shows the current time of the recording.

**The view model part:**

The model exposes the methods: play, pause, and the properties – speed and step also. By using these controls, we operate the appropriate method in the VM_PlayBar and this operates a method of the 'model'. For example: when we click on 'skip forward', the view part operates VM_PlayBar's method named 'skip_forward' and it operates the command: 'model.Step += 300", and this is equivalent to a thirty second skip. More about the slider, when the slider is moved it's changes the property 'VM_Step' which causes a change in the property 'Step' in the model.
