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
    public class MainPageViewModel : ViewModelBase
    {

        #region initialization
        private readonly ILogger<MainPageViewModel> logger;
        private readonly UaTcpSessionClient session;


        public MainPageViewModel(UaTcpSessionClient session)
        {
            this.session = session;
            session?.Subscribe(this);
        }
        #endregion


        #region definition of motor A variables
        #region rTtMotorTempKty1A
        private float _rTtMotorTempKty1A;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvA.rTtMotorTempKty1")]
        public float rTtMotorTempKty1A
        {
            get { return this._rTtMotorTempKty1A; }
            set { this.SetProperty(ref this._rTtMotorTempKty1A, value);
                NotifyPropertyChanged(nameof(ColorA));
            }
        }
        #endregion

        private Color _colorA;
        public Color ColorA
        {
            get
            {
                if (this._rTtMotorTempKty1A >= 100)
                    this._colorA = Color.Red;
                else
                    this._colorA = Color.Blue;
                return this._colorA;
            }
            set { this.SetProperty(ref this._colorA, value); }
        }


        #region rActualpositionA
        private float _rActualpositionA;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvA.rActualposition")]
        public float rActualpositionA
        {
            get { return this._rActualpositionA; }
            set { this.SetProperty(ref this._rActualpositionA, value); }
        }
        #endregion

        #region rActualtorqueA
        private float _rActualtorqueA;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvA.rActualtorque")]
        public float rActualtorqueA
        {
            get { return this._rActualtorqueA; }
            set { this.SetProperty(ref this._rActualtorqueA, value); }
        }
        #endregion

        #region rActualvelocityA
        private float _rActualvelocityA;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvA.rActualvelocity")]
        public float rActualvelocityA
        {
            get { return this._rActualvelocityA; }
            set { this.SetProperty(ref this._rActualvelocityA, value); }
        }
        #endregion

        #region bSynchronA
        private bool _bSynchronA;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvA.bSynchron")]
        public bool bSynchronA
        {
            get { return this._bSynchronA; }
            set { this.SetProperty(ref this._bSynchronA, value);
                NotifyPropertyChanged(nameof(ColorA));
            }
        }
        #endregion

        #region bBrakingResistorA
        private bool _bBrakingResistorA;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuA.bBrakingResistor")]
        public bool bBrakingResistorA
        {
            get { return this._bBrakingResistorA; }
            set { this.SetProperty(ref this._bBrakingResistorA, value); }
        }
        #endregion
        #endregion definition of motor A variables


        #region definition of motor B variables
        #region rTtMotorTempKty1B
        private float _rTtMotorTempKty1B;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvB.rTtMotorTempKty1")]
        public float rTtMotorTempKty1B
        {
            get { return this._rTtMotorTempKty1B; }
            set { this.SetProperty(ref this._rTtMotorTempKty1B, value); }
        }
        #endregion

        #region rActualpositionB
        private float _rActualpositionB;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvB.rActualposition")]
        public float rActualpositionB
        {
            get { return this._rActualpositionB; }
            set { this.SetProperty(ref this._rActualpositionB, value); }
        }
        #endregion

        #region rActualtorqueB
        private float _rActualtorqueB;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvB.rActualtorque")]
        public float rActualtorqueB
        {
            get { return this._rActualtorqueB; }
            set { this.SetProperty(ref this._rActualtorqueB, value); }
        }
        #endregion

        #region rActualvelocityB
        private float _rActualvelocityB;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvB.rActualvelocity")]
        public float rActualvelocityB
        {
            get { return this._rActualvelocityB; }
            set { this.SetProperty(ref this._rActualvelocityB, value); }
        }
        #endregion

        #region bSynchronB
        private bool _bSynchronB;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvB.bSynchron")]
        public bool bSynchronB
        {
            get { return this._bSynchronB; }
            set { this.SetProperty(ref this._bSynchronB, value); }
        }
        #endregion

        #region bBrakingResistorB
        private bool _bBrakingResistorB;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuB.bBrakingResistor")]
        public bool bBrakingResistorB
        {
            get { return this._bBrakingResistorB; }
            set { this.SetProperty(ref this._bBrakingResistorB, value); }
        }
        #endregion

        #endregion definition of motor B variables


        #region definition of motor C variables
        #region rTtMotorTempKty1C
        private float _rTtMotorTempKty1C;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvC.rTtMotorTempKty1")]
        public float rTtMotorTempKty1C
        {
            get { return this._rTtMotorTempKty1C; }
            set { this.SetProperty(ref this._rTtMotorTempKty1C, value);
                NotifyPropertyChanged(nameof(ColorC));
            }
        }
        #endregion

        private Color _colorC;
        public Color ColorC
        {
            get
            {
                if (this.rTtMotorTempKty1C > 100)
                    this._colorC = Color.Red;
                else
                    this._colorC = Color.Blue;
                return this._colorC;
            }
            set { this.SetProperty(ref this._colorC, value); }
        }

        #region rActualpositionC
        private float _rActualpositionC;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvB.rActualvelocity")]
        public float rActualpositionC
        {
            get { return this._rActualpositionC; }
            set { this.SetProperty(ref this._rActualpositionC, value); }
        }
        #endregion

        #region rActualtorqueC
        private float _rActualtorqueC;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvC.rActualtorque")]
        public float rActualtorqueC
        {
            get { return this._rActualtorqueC; }
            set { this.SetProperty(ref this._rActualtorqueC, value); }
        }
        #endregion

        #region rActualvelocityC
        private float _rActualvelocityC;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvC.rActualvelocity")]
        public float rActualvelocityC
        {
            get { return this._rActualvelocityC; }
            set { this.SetProperty(ref this._rActualvelocityC, value); }
        }
        #endregion

        #region bSynchronC
        private bool _bSynchronC;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvC.bSynchron")]
        public bool bSynchronC
        {
            get { return this._bSynchronC; }
            set { this.SetProperty(ref this._bSynchronC, value); }
        }
        #endregion

        #region bBrakingResistorC
        private bool _bBrakingResistorC;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_EpuC.bBrakingResistor")]
        public bool bBrakingResistorC
        {
            get { return this._bBrakingResistorC; }
            set { this.SetProperty(ref this._bBrakingResistorC, value); }
        }
        #endregion

        #endregion definition of motor C variables


        #region rActualForceA
        private float _rActualForceA;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_Sys.rActualForceA")]
        public float rActualForceA
        {
            get { return this._rActualForceA; }
            set { this.SetProperty(ref this._rActualForceA, value); }
        }
        #endregion


        #region rActualForceB
        private float _rActualForceB;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_Sys.rActualForceB")]
        public float rActualForceB
        {
            get { return this._rActualForceB; }
            set { this.SetProperty(ref this._rActualForceB, value); }
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
