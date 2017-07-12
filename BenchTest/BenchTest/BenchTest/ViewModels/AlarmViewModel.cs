using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Microsoft.Extensions.Logging;
using Workstation.ServiceModel.Ua;
using Xamarin.Forms;
using BenchTest.Models;
using System.Resources;
using System.Threading.Tasks;

namespace BenchTest.ViewModels
{
    class AlarmCatergorized
    {
        public UInt16 binaryValue;
        public int category;
    }
    [Subscription(publishingInterval: 250, keepAliveCount: 20)]
    public class AlarmViewModel : ViewModelBase
    {

        private readonly ILogger<AlarmViewModel> logger;
        private readonly UaTcpSessionClient session;
        public ObservableRangeCollection<Alarm> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command ShowNotificationCommandWarning{get;set;}
        public Command ShowNotificationCommandError { get; set; }
        public Command AddNewItemCommand { get; set; }
        public Command RemoveItemCommand { get; set; }
        Services.IDataStore<Models.Alarm> DataStore;
        public AlarmViewModel(UaTcpSessionClient session)
        {
            this.session = session;
            session?.Subscribe(this);
            Items = new ObservableRangeCollection<Alarm>();
            LoadItemsCommand = new Command(() => ExecuteLoadItemsCommand());
            AddNewItemCommand = new Command<AlarmCatergorized>(arg =>  AddNewItemMethod(arg));
            RemoveItemCommand = new Command<Alarm>(arg => RemoveItemMethod(arg));
            ShowNotificationCommandWarning = new Command<string>(arg => ShowNotificationMethodWarning(arg));
            ShowNotificationCommandError = new Command<string>(arg => ShowNotificationMethodError(arg));
            DataStore = new Services.AlarmDataStore();
    }

          void AddNewItemMethod(AlarmCatergorized Value)
        {
            List<Alarm> temp = DataStore.GetItems(Value.binaryValue, Value.category);
            Items.Clear();
            foreach (var item in temp)
            {
                item.Date = DateTime.Now;
                switch (item.AlarmType)
                {
                    case AlarmType.WARNING:
                        ShowNotificationCommandWarning.Execute(item);
                        break;
                    case AlarmType.ERROR:
                        ShowNotificationCommandError.Execute(item);
                        break;
                    default:
                        break;
                }  
                Items.Add(item);
            }
        }
            
        void RemoveItemMethod(Alarm alarm)
        {
            Items.Remove(Items.FirstOrDefault(s => s.Position == alarm.Position));
        }

        void ShowNotificationMethodWarning(string message)
        {
            App.Notification.NotifyWarning(message);
        }


        void ShowNotificationMethodError(string message)
        {
            App.Notification.NotifyError(message);
        }
        #region aAlarmsSys1
        private UInt16 _aAlarmsSys1;
        [MonitoredItem(nodeId: "ns=2;s=Application.Alarms.AlarmHmi.aAlarmAct[1]")]
        public UInt16 aAlarmsSys1
        {
            get { return this._aAlarmsSys1; }
            set
            {
                this.SetProperty(ref this._aAlarmsSys1, value);
                AddNewItemCommand.Execute(new AlarmCatergorized { binaryValue = value, category = 1 });
            }
        }
        #endregion

        #region aAlarmsSys2
        private UInt16 _aAlarmsSys2;
        [MonitoredItem(nodeId: "ns=2;s=Application.Alarms.AlarmHmi.aAlarmAct[2]")]
        public UInt16 aAlarmsSys2
        {
            get { return this._aAlarmsSys2; }
            set
            {
                this.SetProperty(ref this._aAlarmsSys2, value);
                AddNewItemCommand.Execute(new AlarmCatergorized { binaryValue = value, category = 2 });
            }
        }
        #endregion

        #region aAlarmsSys6
        private UInt16 _aAlarmsSys6;
        [MonitoredItem(nodeId: "ns=2;s=Application.Alarms.AlarmHmi.aAlarmAct[6]")]
        public UInt16 aAlarmsSys6
        {
            get { return this._aAlarmsSys6; }
            set
            {
                this.SetProperty(ref this._aAlarmsSys6, value);
                AddNewItemCommand.Execute(new AlarmCatergorized { binaryValue = value, category = 6 });
            }
        }
        #endregion

        #region aAlarmsSys7
        private UInt16 _aAlarmsSys7;
        [MonitoredItem(nodeId: "ns=2;s=Application.Alarms.AlarmHmi.aAlarmAct[7]")]
        public UInt16 aAlarmsSys7
        {
            get { return this._aAlarmsSys7; }
            set
            {
                this.SetProperty(ref this._aAlarmsSys7, value);
                AddNewItemCommand.Execute(new AlarmCatergorized { binaryValue = value, category = 7 });
            }
        }
        #endregion

        #region aAlarmsSys9
        private UInt16 _aAlarmsSys9;
        [MonitoredItem(nodeId: "ns=2;s=Application.Alarms.AlarmHmi.aAlarmAct[9]")]
        public UInt16 aAlarmsSys9
        {
            get { return this._aAlarmsSys9; }
            set
            {
                this.SetProperty(ref this._aAlarmsSys9, value);
                AddNewItemCommand.Execute(new AlarmCatergorized { binaryValue = value, category = 9 });
            }
        }
        #endregion

        #region aAlarmsSys8
        private UInt16 _aAlarmsSys8;
        [MonitoredItem(nodeId: "ns=2;s=Application.Alarms.AlarmHmi.aAlarmAct[8]")]
        public UInt16 aAlarmsSys8
        {
            get { return this._aAlarmsSys8; }
            set
            {
                this.SetProperty(ref this._aAlarmsSys8, value);
                AddNewItemCommand.Execute(new AlarmCatergorized { binaryValue = value, category = 8 });
            }
        }
        #endregion

        #region aAlarmsSys10
        private UInt16 _aAlarmsSys10;
        [MonitoredItem(nodeId: "ns=2;s=Application.Alarms.AlarmHmi.aAlarmAct[10]")]
        public UInt16 aAlarmsSys10
        {
            get { return this._aAlarmsSys10; }
            set
            {
                this.SetProperty(ref this._aAlarmsSys10, value);
                AddNewItemCommand.Execute(new AlarmCatergorized { binaryValue = value, category = 10 });
            }
        }
        #endregion

        #region aAlarmsSys11
        private UInt16 _aAlarmsSys11;
        [MonitoredItem(nodeId: "ns=2;s=Application.Alarms.AlarmHmi.aAlarmAct[11]")]
        public UInt16 aAlarmsSys11
        {
            get { return this._aAlarmsSys11; }
            set
            {
                this.SetProperty(ref this._aAlarmsSys11, value);
                AddNewItemCommand.Execute(new AlarmCatergorized { binaryValue = value, category = 11 });
            }
        }
        #endregion

        #region aAlarmsSys12
        private UInt16 _aAlarmsSys12;
        [MonitoredItem(nodeId: "ns=2;s=Application.Alarms.AlarmHmi.aAlarmAct[12]")]
        public UInt16 aAlarmsSys12
        {
            get { return this._aAlarmsSys12; }
            set
            {
                this.SetProperty(ref this._aAlarmsSys12, value);
                AddNewItemCommand.Execute(new AlarmCatergorized { binaryValue = value, category = 12 });
            }
        }
        #endregion

        #region aAlarmsSys15
        private UInt16 _aAlarmsSys15;
        [MonitoredItem(nodeId: "ns=2;s=Application.Alarms.AlarmHmi.aAlarmAct[15]")]
        public UInt16 aAlarmsSys15
        {
            get { return this._aAlarmsSys15; }
            set
            {
                this.SetProperty(ref this._aAlarmsSys15, value);
                AddNewItemCommand.Execute(new AlarmCatergorized { binaryValue = value, category = 15 });
            }
        }
        #endregion

        #region aAlarmsSys16
        private UInt16 _aAlarmsSys16;
        [MonitoredItem(nodeId: "ns=2;s=Application.Alarms.AlarmHmi.aAlarmAct[16]")]
        public UInt16 aAlarmsSys16
        {
            get { return this._aAlarmsSys16; }
            set
            {
                this.SetProperty(ref this._aAlarmsSys16, value);
                AddNewItemCommand.Execute(new AlarmCatergorized { binaryValue = value, category = 16 });
            }
        }
        #endregion
        void ExecuteLoadItemsCommand()
        {
            DataStore.InitializeAsync();
        }

        internal class MainViewModelDesignInstance : MainPageViewModel
        {
            public MainViewModelDesignInstance()
                : base(null)
            {
            }
        }
    }
}
