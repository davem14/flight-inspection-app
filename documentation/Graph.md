### More details about the 'Graph':

This part displays statistic data of the flight. Each category has a graph that displays its data and displays the data of the most correlated category to it. This display is dynamic and is updated simultaneously during the flight. In addition, there is a graph that displays the regression line between both categories (blue line), displays all the points of the regression line (grey points) and marks the points that belong to the last thirty seconds in red color. It's possible to switch between categories. Each time when an event of new Step occurs in the model, the marked points will change. The synchronization of the graphs is executed by 'binding'. In addition, the graph will contain the 'plugin' display has detailed in the appropriate file.

The statistical calculations are executed when the constructor of the class 'VM_Graph' is called and not in real time, using classes 'Statistics, Correlation'.

The graph's display uses the package 'OxyPlot'.

