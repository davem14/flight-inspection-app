using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace flight_inspection_app.model
{
    public class Flight_Model : INotifyPropertyChanged
    {
        public delegate void PlayAction();

        private int step;
        public int Step
        {
            get { return this.step; }
            set
            {
                if (value >= 0 /*&& value <=MAXVALUE*/)
                {
                    step = value;
                    this.NotifyPropertyChanged("Step");
                }
            }
        }

        private float speed;
        public float Speed
        {
            get { return this.speed; }
            set
            {
                if (value >= 0 /*&& value <=MAXSPEED*/)
                {
                    speed = value;
                    this.NotifyPropertyChanged("Speed");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public Flight_Model()
        {
            step = 0;
            speed = 0;
        }
    }
}
