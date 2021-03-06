### More details about the 'Flight Model':
The model is the logic part of the app. It contains the data and runs it line by line. The model doesn’t recognize the other part in the app. It notifies each time a new data line is red, and each 'view model' registered to get a notification can retrieve the current line. The model can receive commands using methods it exposes. It can change the inner state by Properties. 

**The methods:**
1. start – Method has a loop that runs it a different thread and skips line by line over the data. Each time when it skips a line the property 'Step' and 'Line' are updating. The loop's speed is determined by the property 'Speed' and when the property 'Speed's value is 1 the loop runs ten times in one second.
2. pause – Method switches the thread to 'Wait' state.
3. play – Method switches the thread to 'run' state.
4. stopRun – Method ends the loop.

**The properties:**
1. Step – Contains the current step.
2. Line – Contains the current data line.
3. Speed – Contains the speed value.
4. File – Contains the whole flight's data.
