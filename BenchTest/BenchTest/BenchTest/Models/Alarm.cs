using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BenchTest.Models
{
    public enum AlarmType
    {
        WARNING, ERROR
    }
    public class Alarm : ObservableObject
    {
        public Alarm(AlarmType type)
        {
            AlarmType = type;
        }

        DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }
        
        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value);}
        }

        AlarmType alarmType;
        public AlarmType AlarmType
        {
            get { return alarmType; }
            set { SetProperty(ref alarmType, value); NotifyPropertyChanged(nameof(AlarmColor)); }
        }

        string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        int position;
        public int Position
        {
            get { return position; }
            set { SetProperty(ref position, value); }
        }

        Color alarmColor;
        public Color AlarmColor
        {
            get {
                switch (AlarmType)
                {
                    case AlarmType.WARNING:
                        alarmColor = Color.Blue;
                        break;
                    case AlarmType.ERROR:
                        alarmColor = Color.Red;
                        break;
                    default:
                        AlarmColor = Color.Black;
                        break;
                }
                return alarmColor; }
            set { SetProperty(ref alarmColor, value); }
        }

        int catergory;
        public int Category
        {
            get { return catergory; }
            set { SetProperty(ref catergory, value); }
        }
    }
}
