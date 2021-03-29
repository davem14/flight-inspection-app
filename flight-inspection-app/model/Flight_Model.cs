using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using flight_inspection_app.model;


namespace flight_inspection_app.model
{
    public class Flight_Model : INotifyPropertyChanged
    {
        public delegate void PlayAction();

        int numberOfLines;
        public Flight_Model(List<string> file)
        {
            this.file = file;
            numberOfLines = file.Count;
            step = 0;
            speed = 1;
        }

        // property of step time
        // gets and sets the current step and updats the observers
        private int step;
        public int Step
        {
            get { return this.step; }
            set
            {
                if (value >= 0 /*&& value <=MAXVALUE*/)
                {
                    if (Equals(this.step, numberOfLines - 1) && !Equals(value, numberOfLines))
                        eventWaitHandle.Set();
                    step = value;
                    this.NotifyPropertyChanged("Step");
                }
            }
        }

        // property of speed
        // gets and sets the current speed and updats the observers
        private float speed;
        public float Speed
        {
            get { return this.speed; }
            set
            {
                if (value >= 0 /*&& value <=MAXSPEED*/)
                {
                    this.speed = value;
                    if (this.speed != 0 && stop == false)
                        eventWaitHandle.Set();
                    this.NotifyPropertyChanged("Speed");
                }
            }
        }

        // property of line
        // gets and sets the current line's content and updats the observers
        private string line;
        public string Line
        {
            get { return line; }
            set
            {
                line = value;
                this.NotifyPropertyChanged("Line");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        EventWaitHandle eventWaitHandle = new EventWaitHandle(true, EventResetMode.AutoReset);

        public void start()
        {
            new Thread(delegate ()
            {
                while (true)
                {
                    // updats the current line and step
                    Line = file[this.step];
                    if (this.step < numberOfLines - 1)
                        Step = this.step + 1;
                    Console.WriteLine(this.step);

                    if (Equals(this.step, numberOfLines - 1))
                        eventWaitHandle.WaitOne();

                    // if the speed is 0 or the command 'pause' executed, then wait. 
                    if (stop == true || this.speed == 0)
                        //Thread.Sleep(5000);
                        eventWaitHandle.WaitOne();

                    // the default speed is 100 ms and the variable speed determines the current speed
                    if (this.speed != 0)
                        Thread.Sleep((int)(100 / this.speed));
                }
            }).Start();

        }

        // default value
        bool stop = false;

        // command to run
        public void play()
        {
            stop = false;
            if (this.speed != 0)
                eventWaitHandle.Set();
        }

        // command to stop
        public void pause()
        {
            stop = true;
        }

        // the file (list of lines)
        private List<string> file;

        public int range()
        {
            return numberOfLines - 1;
        }
    }
}
