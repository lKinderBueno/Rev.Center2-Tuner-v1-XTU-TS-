// Decompiled with JetBrains decompiler
// Type: Rev.Center2_Tuner.TuningInfo
// Assembly: CPU_DRAM_OC, Version=5.1.1.38, Culture=neutral, PublicKeyToken=null
// MVID: D8F216A9-8907-47CF-9097-3A01D6CBF3A5
// Assembly location: C:\Program Files (x86)\Hotkey\CPU_DRAM_OC.exe

using Intel.Overclocking.SDK.Tuning;
using System;
using System.Collections.Generic;

namespace Rev.Center2_Tuner
{
  public class TuningInfo
  {
    private ITuningLibrary tuning;

    public TuningInfo()
    {
      this.tuning = (ITuningLibrary) TuningLibrary.Instance;
      this.tuning.Initialize();
    }

    public List<ClientTuningControl> GetAvailableControls()
    {
      if (this.tuning == null)
        return (List<ClientTuningControl>) null;
      List<ClientTuningControl> availableControls = this.tuning.GetAvailableControls();
      List<ClientTuningControl> clientTuningControlList = new List<ClientTuningControl>();
      foreach (ClientTuningControl clientTuningControl in availableControls)
      {
        if (clientTuningControl.Enabled)
          clientTuningControlList.Add(clientTuningControl);
      }
      return clientTuningControlList;
    }

    public ClientTuningControl GetClientTuningControl(uint controlId)
    {
      if (this.tuning != null)
        return this.tuning.GetControl(controlId);
      return (ClientTuningControl) null;
    }

    //public bool Tune(uint id, Decimal value, out bool rebootRequired)
    //{
     // return this.tuning.Tune(id, value, out rebootRequired);
    //}
  }
}
