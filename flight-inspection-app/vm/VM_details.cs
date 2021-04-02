using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;
using flight_inspection_app.model;

namespace flight_inspection_app.vm
{
    class VM_details : INotifyPropertyChanged
    {
        private Flight_Model model;
        string height, airSpeed, flightDirection, pitch, roll, yaw;

        public event PropertyChangedEventHandler PropertyChanged;

        public VM_details(Flight_Model model)
        {
            this.model = model;
            
            model.PropertyChanged +=
                delegate (object sender, PropertyChangedEventArgs e)
                {
                    string s = GetPropertyValue(model, e.PropertyName).ToString();
                    if (Equals(e.PropertyName,"Line")&&model.Line != null)
                    {
                        string[] words = s.Split(',');
                        height = words[25].Substring(0, Math.Min(words[25].Length,7));
                        NotifyPropertyChanged("VM_Height");
                        airSpeed = words[21].Substring(0, Math.Min(words[21].Length, 7));
                        NotifyPropertyChanged("VM_AirSpeed");
                        // still looking for the correct column in the CSV file for flightDirection, guess heading-deg
                        flightDirection = words[19].Substring(0, Math.Min(words[19].Length, 7));
                        NotifyPropertyChanged("VM_FlightDirection");
                        pitch = words[18].Substring(0, Math.Min(words[18].Length, 7));
                        NotifyPropertyChanged("VM_Pitch");
                        roll = words[17].Substring(0, Math.Min(words[17].Length, 7));
                        NotifyPropertyChanged("VM_Roll");
                        // side-slip int the XML file for yaw
                        yaw = words[20].Substring(0, Math.Min(words[20].Length, 7));
                        NotifyPropertyChanged("VM_Yaw");
                    }
                };
        }

        public static object GetPropertyValue(object source, string propertyName)
        {
            PropertyInfo property = source.GetType().GetProperty(propertyName);
            return property.GetValue(source, null);
        }


        public string VM_Height
        {
            get {return height;}
        }
        public string VM_AirSpeed
        {
            get { return airSpeed; }
        }
        public string VM_FlightDirection
        {
            get { return flightDirection; }
        }
        public string VM_Pitch
        {
            get { return pitch; }
        }
        public string VM_Roll
        {
            get { return roll; }
        }
        public string VM_Yaw
        {
            get { return yaw; }
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
