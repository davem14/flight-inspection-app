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
    class VM_Joystick : INotifyPropertyChanged
    {
        private Flight_Model model;
        string throttle, aileron, elevator, rudder, left, top;

        public event PropertyChangedEventHandler PropertyChanged;

        public VM_Joystick(Flight_Model model)
        {
            this.model = model;

            model.PropertyChanged +=
                delegate (object sender, PropertyChangedEventArgs e)
                {
                    int temp;
                    string s = GetPropertyValue(model, e.PropertyName).ToString();
                    if (Equals(e.PropertyName, "Line") && model.Line != null)
                    {
                        string[] words = s.Split(',');
                        throttle = words[6].Substring(0, Math.Min(words[6].Length, 7));
                        NotifyPropertyChanged("VM_Throttle");
                        aileron = words[0].Substring(0, Math.Min(words[0].Length, 7));
                        NotifyPropertyChanged("VM_Aileron");
                        elevator = words[1].Substring(0, Math.Min(words[1].Length, 7));
                        NotifyPropertyChanged("VM_Elevator");
                        rudder = words[2].Substring(0, Math.Min(words[2].Length, 7));
                        NotifyPropertyChanged("VM_Rudder");
                        temp = (int)(70 + float.Parse(aileron) * 70);
                        left = temp.ToString();
                        NotifyPropertyChanged("VM_Left");
                        temp = (int)(59 + float.Parse(elevator) * 70);
                        top = temp.ToString();
                        NotifyPropertyChanged("VM_Top");
                    }
                };
        }

        public static object GetPropertyValue(object source, string propertyName)
        {
            PropertyInfo property = source.GetType().GetProperty(propertyName);
            return property.GetValue(source, null);
        }

        public string VM_Throttle
        {
            get { return throttle; }
        }
        public string VM_Aileron
        {
            get { return aileron; }
        }
        public string VM_Elevator
        {
            get { return elevator; }
        }
        public string VM_Rudder
        {
            get { return rudder; }
        }
        public string VM_Left
        {
            get { return left; }
        }
        public string VM_Top
        {
            get { return top; }
        }


        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
