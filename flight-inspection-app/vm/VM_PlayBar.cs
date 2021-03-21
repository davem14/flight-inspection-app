using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using flight_inspection_app.model;

namespace flight_inspection_app.vm
{
    class VM_PlayBar : INotifyPropertyChanged
    {
        private Flight_Model model;
        public int VM_Step { get { return this.model.Step; } }
        public float VM_Speed { get { return this.model.Speed; } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public VM_PlayBar(Flight_Model model)
        {
            this.model = model;
            model.PropertyChanged +=
                delegate (object sender, PropertyChangedEventArgs e) { this.NotifyPropertyChanged("VM_" + e.PropertyName); };
        }
    }
}
