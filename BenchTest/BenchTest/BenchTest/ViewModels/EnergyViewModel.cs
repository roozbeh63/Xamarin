using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Workstation.ServiceModel.Ua;
using System.ComponentModel;
using Xamarin.Forms;

namespace BenchTest.ViewModels
{
    [Subscription(publishingInterval: 250, keepAliveCount: 20)]
    public class EnergyViewModel : ViewModelBase
    {
        #region initialization
        private readonly ILogger<MainPageViewModel> logger;
        private readonly UaTcpSessionClient session;

        public EnergyViewModel(UaTcpSessionClient session)
        {
            this.session = session;
            session?.Subscribe(this);
        }
        #endregion
        
        private double _boxHightDrvCrDCPowerNegative;
        public double BoxHightDrvCrDCPowerNegative
        {
            get
            {
                if (this._DrvCrDCPower >= 0)
                    return 0;
                else
                {
                    return (double)this._DrvCrDCPower * -10;
                }
            }
            set
            {
                this.SetProperty(ref this._boxHightDrvCrDCPowerNegative, value);
            }
        }

        private double _boxHightDrvCrDCPowerPositive;
        public double BoxHightDrvCrDCPowerPositive
        {
            get
            {
                if (this._DrvCrDCPower < 0)
                    return 0;
                else
                    return (double)this._DrvCrDCPower * 10;
            }
            set
            {

                this.SetProperty(ref this._boxHightDrvCrDCPowerPositive, 0);

            }
        }

        private double _boxHightDrvArDCPowerNegative;
        public double BoxHightDrvArDCPowerNegative
        {
            get
            {
                if (this._DrvArDCPower >= 0)
                    return 0;
                else
                {
                    return (double)this._DrvArDCPower * -10;
                }
            }
            set
            {
                this.SetProperty(ref this._boxHightDrvArDCPowerNegative, value);
            }
        }

        private double _boxHightDrvArDCPowerPositive;
        public double BoxHightDrvArDCPowerPositive
        {
            get
            {
                if (this._DrvArDCPower < 0)
                    return 0;
                else
                    return (double)this._DrvArDCPower * 10;
            }
            set
            {

                this.SetProperty(ref this._boxHightDrvArDCPowerPositive, 0);

            }
        }

        private double _boxHightDrvBrDCPowerNegative;
        public double BoxHightDrvBrDCPowerNegative
        {
            get
            {
                if (this._DrvBrDCPower >= 0)
                    return 0;
                else
                {
                    return (double)this._DrvBrDCPower * -10;
                }
            }
            set
            {
                this.SetProperty(ref this._boxHightDrvBrDCPowerNegative, value);
            }
        }

        private double _boxHightDrvBrDCPowerPositive;
        public double BoxHightDrvBrDCPowerPositive
        {
            get
            {
                if (this._DrvBrDCPower < 0)
                    return 0;
                else
                    return (double)this._DrvBrDCPower * 10;
            }
            set
            {

                this.SetProperty(ref this._boxHightDrvBrDCPowerPositive, 0);

            }
        }

        private double _boxHightEpuCrACPower;
        public double BoxHightEpuCrACPower
        {
            get
            {
                if (this._EpuCrACPower < 0)
                    return 0;
                else
                    return (double)this._EpuCrACPower * 10;
            }
            set
            {

                this.SetProperty(ref this._boxHightEpuCrACPower, 0);

            }
        }

        private double _boxHightEpuArACPower;
        public double BoxHightEpuArACPower
        {
            get
            {
                if (this._EpuArACPower < 0)
                    return 0;
                else
                    return (double)this._EpuArACPower * 10;
            }
            set
            {

                this.SetProperty(ref this._boxHightEpuArACPower, 0);

            }
        }

        private double _boxHightEpuBrACPower;
        public double BoxHightEpuBrACPower
        {
            get
            {
                if (this._EpuBrACPower < 0)
                    return 0;
                else
                    return (double)this._EpuBrACPower * 10;
            }
            set
            {

                this.SetProperty(ref this._boxHightEpuBrACPower, 0);

            }
        }

        #region EpuC.rDCCurrent
        private float _EpuCrDCCurrentr;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuC.rDCCurrent")]
        public float EpuCrDCCurrent
        {
            get { return this._EpuCrDCCurrentr; }
            set
            {
                this.SetProperty(ref this._EpuCrDCCurrentr, value);
            }
        }
        #endregion

        #region EpuC.rDCVoltage
        private float _EpuCrDCVoltage;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuC.rDCVoltage")]
        public float EpuCrDCVoltage
        {
            get { return this._EpuCrDCVoltage; }
            set
            {
                this.SetProperty(ref this._EpuCrDCVoltage, value);
            }
        }
        #endregion

        #region DrvCrDCPower
        private float _DrvCrDCPower;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvC.rDCPower")]
        public float DrvCrDCPower
        {
            get { return this._DrvCrDCPower; }
            set
            {
                this.SetProperty(ref this._DrvCrDCPower, value);
                NotifyPropertyChanged(nameof(BoxHightDrvCrDCPowerPositive));
                NotifyPropertyChanged(nameof(BoxHightDrvCrDCPowerNegative));
            }
        }
        #endregion

        #region EpuCrDCPower
        private float _EpuCrDCPower;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuC.rDCPower")]
        public float EpuCrDCPower
        {
            get { return this._EpuCrDCPower; }
            set
            {
                this.SetProperty(ref this._EpuCrDCPower, value);
            }
        }
        #endregion

        #region DrvCrPower
        private float _DrvCrPower;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvC.rPower")]
        public float DrvCrPower
        {
            get { return this._DrvCrPower; }
            set
            {
                this.SetProperty(ref this._DrvCrPower, value);
            }
        }
        #endregion

        #region EpuCrACCurrent
        private float _EpuCrACCurrent;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuC.rACCurrent")]
        public float EpuCrACCurrent
        {
            get { return this._EpuCrACCurrent; }
            set
            {
                this.SetProperty(ref this._EpuCrACCurrent, value);
            }
        }
        #endregion

        #region EpuCrACVoltage
        private float _EpuCrACVoltage;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuC.rACVoltage")]
        public float EpuCrACVoltage
        {
            get { return this._EpuCrACVoltage; }
            set
            {
                this.SetProperty(ref this._EpuCrACVoltage, value);
            }
        }
        #endregion

        #region EpuCrACPower
        private float _EpuCrACPower;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuC.rACPower")]
        public float EpuCrACPower
        {
            get { return this._EpuCrACPower; }
            set
            {
                this.SetProperty(ref this._EpuCrACPower, value);
                NotifyPropertyChanged(nameof(BoxHightEpuCrACPower));
            }
        }
        #endregion




        #region EpuB.rDCCurrent
        private float _EpuBrDCCurrentr;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuB.rDCCurrent")]
        public float EpuBrDCCurrent
        {
            get { return this._EpuBrDCCurrentr; }
            set
            {
                this.SetProperty(ref this._EpuCrDCCurrentr, value);
            }
        }
        #endregion

        #region EpuB.rDCVoltage
        private float _EpuBrDCVoltage;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuB.rDCVoltage")]
        public float EpuBrDCVoltage
        {
            get { return this._EpuBrDCVoltage; }
            set
            {
                this.SetProperty(ref this._EpuBrDCVoltage, value);
            }
        }
        #endregion

        #region DrvBrDCPower
        private float _DrvBrDCPower;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvB.rDCPower")]
        public float DrvBrDCPower
        {
            get { return this._DrvBrDCPower; }
            set
            {
                this.SetProperty(ref this._DrvBrDCPower, value);
                NotifyPropertyChanged(nameof(BoxHightDrvBrDCPowerPositive));
                NotifyPropertyChanged(nameof(BoxHightDrvBrDCPowerNegative));
            }
        }
        #endregion

        #region EpuBrDCPower
        private float _EpuBrDCPower;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuB.rDCPower")]
        public float EpuBrDCPower
        {
            get { return this._EpuBrDCPower; }
            set
            {
                this.SetProperty(ref this._EpuBrDCPower, value);
            }
        }
        #endregion

        #region DrvBrPower
        private float _DrvBrPower;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvB.rPower")]
        public float DrvBrPower
        {
            get { return this._DrvBrPower; }
            set
            {
                this.SetProperty(ref this._DrvBrPower, value);
            }
        }
        #endregion

        #region EpuBrACCurrent
        private float _EpuBrACCurrent;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuB.rACCurrent")]
        public float EpuBrACCurrent
        {
            get { return this._EpuBrACCurrent; }
            set
            {
                this.SetProperty(ref this._EpuBrACCurrent, value);
            }
        }
        #endregion

        #region EpuBrACVoltage
        private float _EpuBrACVoltage;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuB.rACVoltage")]
        public float EpuBrACVoltage
        {
            get { return this._EpuBrACVoltage; }
            set
            {
                this.SetProperty(ref this._EpuBrACVoltage, value);
            }
        }
        #endregion

        #region EpuBrACPower
        private float _EpuBrACPower;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuB.rACPower")]
        public float EpuBrACPower
        {
            get { return this._EpuBrACPower; }
            set
            {
                this.SetProperty(ref this._EpuBrACPower, value);
                NotifyPropertyChanged(nameof(BoxHightEpuBrACPower));
            }
        }
        #endregion





        #region EpuA.rDCCurrent
        private float _EpuArDCCurrentr;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuA.rDCCurrent")]
        public float EpuArDCCurrent
        {
            get { return this._EpuArDCCurrentr; }
            set
            {
                this.SetProperty(ref this._EpuArDCCurrentr, value);
            }
        }
        #endregion

        #region EpuA.rDCVoltage
        private float _EpuArDCVoltage;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuA.rDCVoltage")]
        public float EpuArDCVoltage
        {
            get { return this._EpuArDCVoltage; }
            set
            {
                this.SetProperty(ref this._EpuArDCVoltage, value);
            }
        }
        #endregion

        #region DrvArDCPower
        private float _DrvArDCPower;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvA.rDCPower")]
        public float DrvArDCPower
        {
            get { return this._DrvArDCPower; }
            set
            {
                this.SetProperty(ref this._DrvArDCPower, value);
                NotifyPropertyChanged(nameof(BoxHightDrvArDCPowerPositive));
                NotifyPropertyChanged(nameof(BoxHightDrvArDCPowerNegative));
            }
        }
        #endregion

        #region EpuArDCPower
        private float _EpuArDCPower;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuA.rDCPower")]
        public float EpuArDCPower
        {
            get { return this._EpuArDCPower; }
            set
            {
                this.SetProperty(ref this._EpuArDCPower, value);
            }
        }
        #endregion

        #region DrvArPower
        private float _DrvArPower;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvA.rPower")]
        public float DrvArPower
        {
            get { return this._DrvArPower; }
            set
            {
                this.SetProperty(ref this._DrvArPower, value);
            }
        }
        #endregion

        #region EpuArACCurrent
        private float _EpuArACCurrent;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuA.rACCurrent")]
        public float EpuArACCurrent
        {
            get { return this._EpuArACCurrent; }
            set
            {
                this.SetProperty(ref this._EpuArACCurrent, value);
            }
        }
        #endregion

        #region EpuArACVoltage
        private float _EpuArACVoltage;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuA.rACVoltage")]
        public float EpuArACVoltage
        {
            get { return this._EpuArACVoltage; }
            set
            {
                this.SetProperty(ref this._EpuArACVoltage, value);
            }
        }
        #endregion

        #region EpuArACPower
        private float _EpuArACPower;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuA.rACPower")]
        public float EpuArACPower
        {
            get { return this._EpuArACPower; }
            set
            {
                this.SetProperty(ref this._EpuArACPower, value);
                NotifyPropertyChanged(nameof(BoxHightEpuArACPower));
            }
        }
        #endregion

        internal class MainViewModelDesignInstance : MainPageViewModel
        {
            public MainViewModelDesignInstance()
                : base(null)
            {
            }
        }
    }
}
