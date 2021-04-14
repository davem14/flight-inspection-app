### More details about the 'Plugin' system and 'DLL' files:

**A Dll for anomalies detection algorythm must have the following structure:**

```
namespace AD_plugin
{
  public class AD
  {
    public List<List<int>> Detect(string regflightPath, string anomalflightPath, int numberOfProperties);
    public Dictionary<int, List<Func<double, double>>> GetNormalModel();
  }
}
```
(functions implement interface 'IAD', available as '.dll' file in directory 'plugins')

Dll must reffer to a feature by its index, therefore 'Detect' recieves the number of properties. 

**'Detect' return type format:**

List of anomalies, each anomaly happens between features i and j, represented by List of 3 ints: int feature1, int start, int end.
feature1 is anomaly's left feature (i in example), start is anomaly's start time, end is anomaly's ending time.
if we have these anomalies:
feature3-feature8 from timestamp 100 to timestamp 180
feature4-feature5 from timestamp 30 to timestamp 200
Detect will return:
{ { 3,100,180 } , {4,30,200} }
  
**'GetNormalModel' return type format:**

Dictionary of every feature that correlates with another feature mapped to a List of equations(=Func<double,double>).
app will generate graphic view of each feature's 'normal domain', drawn by feature's List of equation.  
