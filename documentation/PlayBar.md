### More details about the 'PlayBar':

Using the controls of this part we can control the recording. The model exposes the methods: play, pause, and the properties – speed and step also. By using these controls, we operate the appropriate method in the VM_PlayBar and this operates a method of the 'model'. For example: when we click on 'skip forward', the view part operates VM_PlayBar's method named 'skip_forward' and it operates the command: 'model.Step += 300", and this is equivalent to a thirty second skip.

This part has also a slider and it synchronized with the property 'VM_Step' which is a part of the 'view model'. When we the slider is moved it's changes the property 'VM_Step' which causes a change in the property 'Step' in the model. Additionally, using the text box we can control over the recording's speed. There is a time display that shows the current time of the recording.

