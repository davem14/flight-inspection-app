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

        public event PropertyChangedEventHandler PropertyChanged;

        public VM_PlayBar(Flight_Model model)
        {
            this.model = model;
            model.PropertyChanged +=
                delegate (object sender, PropertyChangedEventArgs e) { this.NotifyPropertyChanged("VM_" + e.PropertyName); };
        }

        public int VM_Step
        {
            get { return this.model.Step; }
            set { this.model.Step = value; }
        }
        public float VM_Speed
        {
            get { return this.model.Speed; }
            set { this.model.Speed = value; }
        }

        public int VM_Range
        {
            get { return model.range(); }
        }

        public void play()
        {
            model.play();
        }
        public void pause()
        {
            model.pause();
        }
        public void stop()
        {
            model.Step = 0;
        }
        public void backwards()
        {
            model.Step = model.Step - 100;
        }
        public void forwards()
        {
            model.Step = model.Step + 100;
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
