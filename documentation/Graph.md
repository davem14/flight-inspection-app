### More details about the 'Graph':

**The view part:**

This part displays statistic data of the flight. Each category has a graph that displays its data and displays the data of the most correlated category to it. This display is dynamic and is updated simultaneously during the flight. In addition, there is a graph that displays the regression line between both categories (blue line), displays all the points of the regression line (grey points) and marks the points that belong to the last thirty seconds in red color. It's possible to switch between categories. Each time when an event of new Step occurs in the model, the marked points will change. The synchronization of the graphs is executed by 'binding' with properties which are located in the 'view model'. In addition, the graph will contain the 'plugin' view, as detailed in the appropriate file.

**The view model part:**

The statistical calculations are executed when the constructor of the class 'VM_Graph' is called and not on real time, using classes 'Statistics, Correlation'. The data is synchronized with the view by using properties. The dynamic data changes each time it receives notification form the model about the property Step.

The graph's display uses the package 'OxyPlot'.

