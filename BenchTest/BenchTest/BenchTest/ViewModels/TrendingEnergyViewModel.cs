using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Workstation.ServiceModel.Ua;
using Xamarin.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace BenchTest.ViewModels
{
    [Subscription(publishingInterval: 250, keepAliveCount: 20)]
    public class TrendingEnergyViewModel : ViewModelBase
    {

        private readonly ILogger<MainPageViewModel> logger;
        private readonly UaTcpSessionClient session;
        public OxyPlot.PlotModel energyTredningChart;
        double pastTime;
        private int maxPlotTimeStep = 300;
        private List<DataPoint> EPU_A_DC_Power_Points;
        private List<DataPoint> EPU_B_DC_Power_Points;
        private List<DataPoint> EPU_C_DC_Power_Points;


        public TrendingEnergyViewModel(UaTcpSessionClient session)
        {
            this.session = session;
            session?.Subscribe(this);
            Device.StartTimer(TimeSpan.FromSeconds(1), onTimeTick);

            energyTredningChart = new OxyPlot.PlotModel();
            energyTredningChart.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = 0, IsPanEnabled = true, IsZoomEnabled = true });
            energyTredningChart.LegendPlacement = LegendPlacement.Outside;
            energyTredningChart.LegendPosition = LegendPosition.LeftBottom;
            energyTredningChart.IsLegendVisible = true;
            energyTredningChart.LegendTitle = "legend";

            EPU_A_DC_Power_Points = new List<DataPoint>();
            EPU_B_DC_Power_Points = new List<DataPoint>();
            EPU_C_DC_Power_Points = new List<DataPoint>();

            energyTredningChart.Series.Add(new LineSeries() { ItemsSource = EPU_A_DC_Power_Points, Color = OxyColor.FromRgb(0, 100, 100) , Title= "Drive A Power" });
            energyTredningChart.Series.Add(new LineSeries() { ItemsSource = EPU_B_DC_Power_Points, Color = OxyColor.FromRgb(100, 0, 100), Title= "Drive B Power" });
            energyTredningChart.Series.Add(new LineSeries() { ItemsSource = EPU_C_DC_Power_Points, Color = OxyColor.FromRgb(100, 100, 0) , Title= "Drive C  Power" });

        }


        public void SetPoint_EPU_A_DC_power(double point)
        {
            EPU_A_DC_Power_Points.Add(new OxyPlot.DataPoint(pastTime, point));
            if (EPU_A_DC_Power_Points.Count > maxPlotTimeStep)
            {
                EPU_A_DC_Power_Points.RemoveAt(0);
            }
            energyTredningChart.InvalidatePlot(true);
        }

        public void SetPoint_EPU_B_DC_power(double point)
        {
            EPU_B_DC_Power_Points.Add(new OxyPlot.DataPoint(pastTime, point));
            if (EPU_B_DC_Power_Points.Count > maxPlotTimeStep)
            {
                EPU_B_DC_Power_Points.RemoveAt(0);
            }
            energyTredningChart.InvalidatePlot(true);
        }

        public void SetPoint_EPU_C_DC_power(double point)
        {
            EPU_C_DC_Power_Points.Add(new OxyPlot.DataPoint(pastTime, point));
            if (EPU_C_DC_Power_Points.Count > maxPlotTimeStep)
            {
                EPU_C_DC_Power_Points.RemoveAt(0);
            }
            energyTredningChart.InvalidatePlot(true);
        }

        #region MLC_EpuArDCPower
        private float _MLC_EpuArDCPower;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvA.rPower")]
        public float MLC_EpuArDCPower
        {
            get { return this._MLC_EpuArDCPower; }
            set
            {
                this.SetProperty(ref this._MLC_EpuArDCPower, value);
                  
            }
        }
        #endregion

        #region MLC_EpuBrDCPower
        private float _MLC_EpuBrDCPower;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvB.rPower")]
        public float MLC_EpuArDCCurrent
        {
            get { return this._MLC_EpuBrDCPower; }
            set
            {
                this.SetProperty(ref this._MLC_EpuBrDCPower, value);
            }
        }
        #endregion

        #region MLC_EpuCrDCPower
        private float _MLC_EpuCrDCPower;
        [MonitoredItem(nodeId: "ns=2;s=Application.DataToHmiWch_DrvC.rPower")]
        public float MLC_EpuCrDCPower
        {
            get { return this._MLC_EpuCrDCPower; }
            set
            {
                this.SetProperty(ref this._MLC_EpuCrDCPower, value);
            }
        }
        #endregion

        bool onTimeTick()
        {
            pastTime += 1;
            SetPoint_EPU_A_DC_power((double)this._MLC_EpuArDCPower);
            SetPoint_EPU_B_DC_power((double)this._MLC_EpuBrDCPower);
            SetPoint_EPU_C_DC_power((double)this._MLC_EpuCrDCPower);
            return true;
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
