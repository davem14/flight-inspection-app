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

            model.PropertyChanged +=
                delegate (object sender, PropertyChangedEventArgs e)
                {
                    if (Equals(e.PropertyName, "Step") && (model.Step % 10) == 0)
                    {
                        int currentStep = model.Step / 10;

                        hours = currentStep / 3600;
                        currentStep = currentStep % 3600;
                        minuts = currentStep / 60;
                        currentStep = currentStep % 60;
                        seconds = currentStep;

                        Time =  String.Format("{0:D2}", hours) + ":" + String.Format("{0:D2}", minuts) + ":" + String.Format("{0:D2}", seconds);
                    }
                    this.NotifyPropertyChanged("Time");
                };
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
            get { return model.Range; }
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
            model.pause();
        }
        public void backwards()
        {
            model.Step = model.Step - 100;
        }
        public void forwards()
        {
            model.Step = model.Step + 100;
        }

        public void skip_forward()
        {
            model.Step = model.Step + 300;
        }

        public void skip_backward()
        {
            model.Step = model.Step -300;
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        int seconds = 0;
        int minuts = 0;
        int hours = 0;

        string time;
        public string Time
        {
            get { return this.time; }
            set { this.time = value; }
        }
    }
}
