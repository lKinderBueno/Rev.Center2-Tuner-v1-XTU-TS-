// Decompiled with JetBrains decompiler
// Type: Rev.Center2_Tuner.ServiceInfo
// Assembly: CPU_DRAM_OC, Version=5.1.1.38, Culture=neutral, PublicKeyToken=null
// MVID: D8F216A9-8907-47CF-9097-3A01D6CBF3A5
// Assembly location: C:\Program Files (x86)\Hotkey\CPU_DRAM_OC.exe

using Intel.Overclocking.SDK.ServiceInfo;
using System.Collections.Generic;

namespace Rev.Center2_Tuner
{
  public class ServiceInfo
  {
    private readonly List<ServiceInfoData> serviceinfoList = new List<ServiceInfoData>();
    private readonly IServiceInfoLibrary serviceInfo;

    public ServiceInfo()
    {
      this.serviceInfo = (IServiceInfoLibrary) ServiceInfoLibrary.Instance;
      this.serviceInfo.Initialize();
      this.UpdateserviceinfoList();
    }

    public List<ServiceInfoData> GetServiceInfoList()
    {
      return this.serviceinfoList;
    }

    private void UpdateserviceinfoList()
    {
      if (this.serviceInfo == null)
        return;
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("BrandString", this.serviceInfo.Processor.GetBrandString()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("Cpu Feature Flags", this.serviceInfo.Processor.GetCpuFeatureFlags()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("Logical Cpu CoreCount", this.serviceInfo.Processor.GetLogicalCpuCoreCount().ToString()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("Microcode Update Version", this.serviceInfo.Processor.GetMicrocodeUpdateVersion().ToString()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("Overclockable TurboBins", this.serviceInfo.Processor.GetOverclockableTurboBins().ToString()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("Physical Cpu Core Count", this.serviceInfo.Processor.GetPhysicalCpuCoreCount().ToString()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("Integrated Graphics Present", this.serviceInfo.Processor.IsIntegratedGraphicsPresent().ToString()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("Is System Overclock Supported", this.serviceInfo.Processor.IsOverclockSupported().ToString()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("Clr OCEnabled", this.serviceInfo.Processor.IsProcessorClrOCEnabled().ToString()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("Gfx OCEnabled", this.serviceInfo.Processor.IsProcessorClrOCEnabled().ToString()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("IACore OCEnabled", this.serviceInfo.Processor.IsProcessorIACoreOCEnabled().ToString()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("System Unlocked", this.serviceInfo.Processor.IsSystemUnlocked().ToString()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("TurboBoost Technology Enabled", this.serviceInfo.Processor.IsTurboBoostTechnologyEnabled().ToString()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("NumAllowed OC TurboBins", this.serviceInfo.Processor.NumAllowedOCTurboBins()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("Processor Family", this.serviceInfo.Processor.ProcessorFamily()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("Eist Is Enabled", this.serviceInfo.Processor.IsEistIsEnabled().ToString()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("Client Version", this.serviceInfo.ServiceInfo.GetOverclockingClientVersion()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("Overclocking Driver Version", this.serviceInfo.ServiceInfo.GetOverclockingClientVersion()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("Sdk Version", this.serviceInfo.ServiceInfo.GetOverclockingSdkVersion()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("Service SessionId", this.serviceInfo.ServiceInfo.GetOverclockingServiceSessionId().ToString()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("Service Version:", this.serviceInfo.ServiceInfo.GetOverclockingServiceVersion()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("IsEngineeringSample", this.serviceInfo.ServiceInfo.IsEngineeringSample()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("Watchdog Timer Present", this.serviceInfo.WatchdogTimer.IsWatchdogTimerPresent().ToString()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("Watchdog Timer Running", this.serviceInfo.WatchdogTimer.IsWatchdogTimerRunning().ToString()));
      this.serviceinfoList.Add(ServiceInfoData.CreateServiceInfoData("Watchdog Timer Failed", this.serviceInfo.WatchdogTimer.HasWatchdogTimerFailed().ToString()));
    }
  }
}
