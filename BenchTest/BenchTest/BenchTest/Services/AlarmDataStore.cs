using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BenchTest.Models;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace BenchTest.Services
{
    public class AlarmDataStore : IDataStore<Models.Alarm>
    {
        bool isInitialized;
        List<Alarm> alarms;

        public bool AddItemAsync(Alarm item)
        {
            InitializeAsync();

            alarms.Add(item);

            return true;
        }

        public bool DeleteItemAsync(Alarm item)
        {
            InitializeAsync();

            var _item = alarms.Where((Alarm arg) => arg.Name == item.Name).FirstOrDefault();
            alarms.Remove(_item);

            return true;
        }

        public List<Alarm> GetItems(int id, int cat)
        {
            InitializeAsync();
            List<Alarm> tempAlarm = new List<Alarm>();
            string temp = Convert.ToString(id, 2);
            var num = temp.ToArray<char>().Reverse();

            for (int i = 0; i < num.Count(); i++)
            {
                if (num.ElementAt(i) == '1')
                {
                    tempAlarm.Add(alarms.FirstOrDefault(s => s.Position == i + 1 && s.Category == cat));
                }
            }
            return tempAlarm;
        }


        public void InitializeAsync()
        {
            if (isInitialized)
                return;

            alarms = new List<Alarm>();
            var _items = new List<Alarm>
            {
                new Alarm (AlarmType.WARNING){Description = "XM warning active",                                        Position = 1, Name = "W_Sys.XmWarning" ,                            Category=1},
                new Alarm (AlarmType.WARNING){ Description = "Out of range force measuring shaft A",       Position = 2, Name = "W_Sys.OutOfRangeActualForceA"  ,   Category=1},
                new Alarm (AlarmType.WARNING){Description = "Out of range force measuring shaft B",        Position = 3, Name = "W_Sys.OutOfRangeActualForceB" ,     Category=1},
                new Alarm (AlarmType.WARNING){ Description = "DC coupling is activated",                              Position = 4, Name = "W_Sys.DcCouplingOn" ,                       Category=1},
                new Alarm (AlarmType.ERROR){ Description = "XM error active",                                                   Position = 9, Name = "F_Sys.XmError"  ,                                        Category=1},
                new Alarm (AlarmType.ERROR) { Description = "E-Stop button at desk pressed",                        Position= 10, Name = "F_Sys.EStopDesk"  ,                                 Category=1},
                new Alarm (AlarmType.ERROR){  Description = "E-Stop button at MCC pressed",                         Position = 11, Name = "F_Sys.EStopMcc" ,                                  Category=1},
                new Alarm (AlarmType.ERROR){ Description = "E-Stop button at motor frame pressed",           Position = 12, Name = "F_Sys.EStopField"  ,                                  Category=1},
                new Alarm(AlarmType.ERROR) { Description = "Safety system E-stop active",                               Position = 13, Name = "F_Sys.EstopErrorActive"  ,                         Category=1},

                new Alarm (AlarmType.WARNING){ Description = "W9: CCD, Out of range potmeter A",            Position = 1, Name = "W_Ccd.OutOfRangeForcePotmeterA"  ,     Category=2},
                new Alarm (AlarmType.WARNING){ Description = "W10: CCD, Out of range potmeter B",            Position = 2, Name = "W_Ccd.OutOfRangeForcePotmeterB"  ,     Category=2},
                new Alarm (AlarmType.WARNING){ Description = "W11: CCD, Out of range joystick 1",            Position = 3, Name = "W_Ccd.OutOfRangeJoystick1"  ,     Category=2},
                new Alarm (AlarmType.WARNING){ Description = "W12: CCD, Out of range joystick 2A",            Position = 4, Name = "W_Ccd.OutOfRangeJoystick2A"  ,     Category=2},
                new Alarm (AlarmType.WARNING){ Description = "W13: CCD, Out of range joystick 2B",            Position = 5, Name = "W_Ccd.OutOfRangeJoystick2B"  ,     Category=2},
                new Alarm (AlarmType.WARNING){ Description = "W14: CCD, Out of range joystick 3",            Position = 6, Name = "W_Ccd.OutOfRangeJoystick3"  ,     Category=2},
                new Alarm (AlarmType.ERROR){ Description = "F9: CCD, Control Desk one or more critical circuit breakers are off",            Position = 9, Name = "F_Ccd.CriticalCircuitBreaker"  ,     Category=2},

                new Alarm (AlarmType.WARNING){ Description = "W41: EPU A, HMU Warning, check display or Diagnose screen",            Position = 1,  Name = "W_EpuA.Warning"  ,              Category=6},
                new Alarm (AlarmType.WARNING){ Description = "W42: EPU A, HNA Module warning active",                                               Position =2,    Name = "W_EpuA.HnaWarning"  ,     Category=6},
                new Alarm (AlarmType.WARNING){ Description = "W43: EPU A, One or more critical circuit breakers are off",                   Position = 3,       Name = "W_EpuA.NonCriticalCircuitBreaker"  ,     Category=6},
                new Alarm (AlarmType.WARNING){ Description = "W44: EPU A, One of 24VDC supplies is not OK",                                      Position = 4,      Name = "W_EpuA.NotOk24Vdc"  ,     Category=6},

                new Alarm (AlarmType.WARNING){ Description = "W49: EPU B, HMU Warning, check display or Diagnose screen",            Position = 1,  Name = "W_EpuB.Warning"  ,              Category=7},
                new Alarm (AlarmType.WARNING){ Description = "W50: EPU B, HNA Module warning active",                                               Position =2,    Name = "W_EpuB.HnaWarning"  ,     Category=7},
                new Alarm (AlarmType.WARNING){ Description = "W51: EPU B, One or more critical circuit breakers are off",                   Position = 3,       Name = "W_EpuB.NonCriticalCircuitBreaker"  ,     Category=7},
                new Alarm (AlarmType.WARNING){ Description = "W52: EPU B, One of 24VDC supplies is not OK",                                      Position = 4,      Name = "W_EpuB.NotOk24Vdc"  ,     Category=7},

                new Alarm (AlarmType.WARNING){ Description = "W57: EPU C, HMU Warning, check display or Diagnose screen",            Position = 1,  Name = "W_EpuC.Warning"  ,              Category=9},
                new Alarm (AlarmType.WARNING){ Description = "W58: EPU C, HNA Module warning active",                                               Position =2,    Name = "W_EpuC.HnaWarning"  ,     Category=9},
                new Alarm (AlarmType.WARNING){ Description = "W59: EPU C, One or more critical circuit breakers are off",                   Position = 3,       Name = "W_EpuC.NonCriticalCircuitBreaker"  ,     Category=9},
                new Alarm (AlarmType.WARNING){ Description = "W60: EPU C, One of 24VDC supplies is not OK",                                      Position = 4,      Name = "W_EpuC.NotOk24Vdc"  ,     Category=9},

                new Alarm (AlarmType.WARNING){ Description = "W65: DRV A, HMU Warning, check display or Diagnose screen",            Position = 9,  Name = "W_DrvA.Warning"  ,              Category=10},
                new Alarm (AlarmType.WARNING){ Description = "W66: DRV A, Manual brake override is selected",                                               Position =10,    Name = "W_DrvA.ManualBrakeOverride"  ,     Category=10},
                new Alarm (AlarmType.WARNING){ Description = "W67: DRV A, Cool unit warning active",                   Position = 11,       Name = "W_DrvA.CoolUnitWarning"  ,     Category=10},

                new Alarm (AlarmType.WARNING){ Description = "W73: DRV B, HMU Warning, check display or Diagnose screen",            Position = 9,  Name = "W_DrvB.CoolUnitWarning"  ,              Category=11},
                new Alarm (AlarmType.WARNING){ Description = "W74: DRV B, Manual brake override is selected",                                               Position =10,    Name = "W_DrvB.ManualBrakeOverride"  ,     Category=11},
                new Alarm (AlarmType.WARNING){ Description = "W75: DRV B, Cool unit warning active",                   Position = 11,       Name = "W_DrvB.Warning"  ,     Category=11},

                new Alarm (AlarmType.WARNING){ Description = "W81: DRV C, HMU Warning, check display or Diagnose screen",            Position = 9,  Name = "W_DrvC.CoolUnitWarning"  ,              Category=12},
                new Alarm (AlarmType.WARNING){ Description = "W82: DRV C, Manual brake override is selected",                                               Position =10,    Name = "W_DrvC.ManualBrakeOverride"  ,     Category=12},
                new Alarm (AlarmType.WARNING){ Description = "W83: DRV C, Cool unit warning active",                   Position = 11,       Name = "W_DrvC.Warning"  ,     Category=12},

               new Alarm (AlarmType.WARNING){ Description = "W105: CLU, Cooler 1 warning",            Position = 1,  Name = "W_Clu.WarningCooler1"  ,              Category=15},
                new Alarm (AlarmType.WARNING){ Description = "W106: CLU, Cooler 2 warning",           Position =2,    Name = "W_Clu.WarningCooler2"  ,     Category=15},

                new Alarm (AlarmType.ERROR){ Description = "F41: EPU A, HMU Error, check display or Diagnose screen",                                                   Position = 9, Name = "F_EpuA.Error"  ,                                        Category=6},
                new Alarm (AlarmType.ERROR) { Description = "F42: EPU A, HNA Module error active, BB contact open",                        Position= 10, Name = "F_EpuA.HnaModuleError"  ,                                 Category=6},
                new Alarm (AlarmType.ERROR){  Description = "F43: EPU A, HMU infeedmodule error active, BB contact open",                         Position = 11, Name = "F_EpuA.InfeedModuleError" ,                                  Category=6},
                new Alarm (AlarmType.ERROR){ Description = "F44: EPU A, 230VAC trafo is not working, optional brake engaged",           Position = 12, Name = "F_EpuA.NotOk230Vac"  ,                                  Category=6},
                new Alarm(AlarmType.ERROR) { Description = "F45: EPU A, Main contactor time out during closing",                               Position = 13, Name = "F_EpuA.MainContactorTimeOut"  ,                         Category=6},
                new Alarm (AlarmType.ERROR){  Description = "F46: EPU A, One or more critical circuit breakers are off",                         Position = 14, Name = "F_EpuA.CriticalCircuitBreaker" ,                                  Category=6},
                new Alarm (AlarmType.ERROR){ Description = "F47: EPU A, Choke temperature too high",           Position = 15, Name = "F_EpuA.ChokeTempTooHigh"  ,                                  Category=6},
                new Alarm(AlarmType.ERROR) { Description = "F48: EPU A, HLT brake chopper error active, BB contact open",                               Position = 16, Name = "F_EpuA.Brakechopper"  ,                         Category=6},

                new Alarm (AlarmType.ERROR){ Description = "F57: EPU B, HMU Error, check display or Diagnose screen",                                                   Position = 9, Name = "F_EpuB.Error"  ,                                        Category=8},
                new Alarm (AlarmType.ERROR) { Description = "F58: EPU B, HNA Module error active, BB contact open",                        Position= 10, Name = "F_EpuB.HnaModuleError"  ,                                 Category=8},
                new Alarm (AlarmType.ERROR){  Description = "F59: EPU B, HMU infeedmodule error active, BB contact open",                         Position = 11, Name = "F_EpuB.InfeedModuleError" ,                                  Category=8},
                new Alarm (AlarmType.ERROR){ Description = "F60: EPU B, 230VAC trafo is not working, optional brake engaged",           Position = 12, Name = "F_EpuB.NotOk230Vac"  ,                                  Category=8},
                new Alarm(AlarmType.ERROR) { Description = "F61: EPU B, Main contactor time out during closing",                               Position = 13, Name = "F_EpuB.MainContactorTimeOut"  ,                         Category=8},
                new Alarm (AlarmType.ERROR){  Description = "F62: EPU B, One or more critical circuit breakers are off",                         Position = 14, Name = "F_EpuB.CriticalCircuitBreaker" ,                                  Category=8},
                new Alarm (AlarmType.ERROR){ Description = "F63: EPU B, Choke temperature too high",           Position = 15, Name = "F_EpuB.ChokeTempTooHigh"  ,                                  Category=8},
                new Alarm(AlarmType.ERROR) { Description = "F64: EPU B, HLT brake chopper error active, BB contact open",                               Position = 16, Name = "F_EpuB.Brakechopper"  ,                         Category=8},

                new Alarm (AlarmType.ERROR){ Description = "F41: EPU C, HMU Error, check display or Diagnose screen",                                                   Position = 9, Name = "F_EpuC.Error"  ,                                        Category=9},
                new Alarm (AlarmType.ERROR) { Description = "F42: EPU C, HNA Module error active, BB contact open",                        Position= 10, Name = "F_EpuC.HnaModuleError"  ,                                 Category=9},
                new Alarm (AlarmType.ERROR){  Description = "F43: EPU C, HMU infeedmodule error active, BB contact open",                         Position = 11, Name = "F_EpuC.InfeedModuleError" ,                                  Category=9},
                new Alarm (AlarmType.ERROR){ Description = "F44: EPU C, 230VAC trafo is not working, optional brake engaged",           Position = 12, Name = "F_EpuC.NotOk230Vac"  ,                                  Category=9},
                new Alarm(AlarmType.ERROR) { Description = "F45: EPU C, Main contactor time out during closing",                               Position = 13, Name = "F_EpuC.MainContactorTimeOut"  ,                         Category=9},
                new Alarm (AlarmType.ERROR){  Description = "F46: EPU C, One or more critical circuit breakers are off",                         Position = 14, Name = "F_EpuC.CriticalCircuitBreaker" ,                                  Category=9},
                new Alarm (AlarmType.ERROR){ Description = "F47: EPU C, Choke temperature too high",           Position = 15, Name = "F_EpuC.ChokeTempTooHigh"  ,                                  Category=9},
                new Alarm(AlarmType.ERROR) { Description = "F48: EPU C, HLT brake chopper error active, BB contact open",                               Position = 16, Name = "F_EpuC.Brakechopper"  ,                         Category=9},

               new Alarm (AlarmType.ERROR){ Description = "F89: DRV A, HMU Error, check display or Diagnose screen",                                                   Position = 1, Name = "F_DrvA.Error"  ,                                        Category=11},
                new Alarm (AlarmType.ERROR) { Description = "F90: DRV A, Fan contactor time out during closing",                        Position= 2, Name = "F_DrvA.FanContactorTimeOut"  ,                                 Category=11},
                new Alarm (AlarmType.ERROR){  Description = "F91: DRV A, Motor temperature too high",                         Position = 3, Name = "F_DrvA.MotorTempTooHigh" ,                                  Category=11},

                 new Alarm (AlarmType.ERROR){ Description = "F97: DRV B, HMU Error, check display or Diagnose screen",                                                   Position = 1, Name = "F_DrvB.Error"  ,                                        Category=12},
                new Alarm (AlarmType.ERROR) { Description = "F98: DRV B, Fan contactor time out during closing",                        Position= 2, Name = "F_DrvB.FanContactorTimeOut"  ,                                 Category=12},
                new Alarm (AlarmType.ERROR){  Description = "F99: DRV B, Motor temperature too high",                         Position = 3, Name = "F_DrvB.MotorTempTooHigh" ,                                  Category=12},

               new Alarm (AlarmType.ERROR){ Description = "F105: DRV C, HMU Error, check display or Diagnose screen",                                                   Position = 1, Name = "F_DrvC.Error"  ,                                        Category=13},
                new Alarm (AlarmType.ERROR) { Description = "F106: DRV C, Fan contactor time out during closing",                        Position= 2, Name = "F_DrvC.FanContactorTimeOut"  ,                                 Category=13},
                new Alarm (AlarmType.ERROR){  Description = "F107: DRV C, Motor temperature too high",                         Position = 3, Name = "F_DrvC.MotorTempTooHigh" ,                                  Category=13},

               new Alarm (AlarmType.ERROR){ Description = "F129: CLU, Water detected in cabinet by sensor 2100AT11",                                                   Position = 1, Name = "F_Clu.WaterDetection2100At11"  ,                                        Category=16},
                new Alarm (AlarmType.ERROR) { Description = "F130: CLU, Water detected in cabinet by sensor 2100AT21",                        Position= 2, Name = "F_Clu.WaterDetection2100At21"  ,                                 Category=16},
                new Alarm (AlarmType.ERROR){  Description = "F131: CLU, Water detected in cabinet by sensor 2100AT31",                         Position = 3, Name = "F_Clu.WaterDetection2100At31" ,                                  Category=16},
                new Alarm (AlarmType.ERROR) { Description = "F132: CLU, Cooler 1 error",                        Position= 4, Name = "F_Clu.ErrorCooler1"  ,        Category=16},
                new Alarm (AlarmType.ERROR){  Description = "F133: CLU, Cooler 2 error",                         Position = 5, Name = "F_Clu.ErrorCooler2" ,                                  Category=16}
             };

            foreach (Alarm item in _items)
            {
                alarms.Add(item);
            }

            isInitialized = true;
        }



        public bool UpdateItemAsync(Alarm item)
        {
            InitializeAsync();

            var _item = alarms.Where((Alarm arg) => arg.Name == item.Name).FirstOrDefault();
            alarms.Remove(_item);
            alarms.Add(item);

            return true;
        }
    }
}
