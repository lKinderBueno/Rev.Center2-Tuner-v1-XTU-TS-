// Decompiled with JetBrains decompiler
// Type: Rev.Center2_Tuner.MonitorInfo
// Assembly: CPU_DRAM_OC, Version=5.1.1.38, Culture=neutral, PublicKeyToken=null
// MVID: D8F216A9-8907-47CF-9097-3A01D6CBF3A5
// Assembly location: C:\Program Files (x86)\Hotkey\CPU_DRAM_OC.exe

using Intel.Overclocking.SDK.Monitoring;
using System.Collections.Generic;

namespace Rev.Center2_Tuner
{
  public class MonitorInfo
  {
    private readonly IMonitoringLibrary monitors;

    public MonitorInfo()
    {
      this.monitors = (IMonitoringLibrary) MonitoringLibrary.Instance;
      this.monitors.Initialize();
    }

    public List<ClientMonitor> GetAvailableMonitors()
    {
      if (this.monitors != null)
        return this.monitors.GetAvailableMonitors();
      return (List<ClientMonitor>) null;
    }

    public string GetMonitorValue(uint id)
    {
      return this.monitors.GetValue(id).ToString();
    }

    public void Start()
    {
      this.monitors.Start();
    }

    public void Stop()
    {
      this.monitors.Stop();
    }
  }
}
