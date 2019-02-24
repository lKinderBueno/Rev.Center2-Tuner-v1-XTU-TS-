// Decompiled with JetBrains decompiler
// Type: Rev.Center2_Tuner.ServiceInfoData
// Assembly: CPU_DRAM_OC, Version=5.1.1.38, Culture=neutral, PublicKeyToken=null
// MVID: D8F216A9-8907-47CF-9097-3A01D6CBF3A5
// Assembly location: C:\Program Files (x86)\Hotkey\CPU_DRAM_OC.exe

namespace Rev.Center2_Tuner
{
  public class ServiceInfoData
  {
    public string Id { get; set; }

    public string Data { get; set; }

    public static ServiceInfoData CreateServiceInfoData(string id, string data)
    {
      return new ServiceInfoData() { Id = id, Data = data };
    }
  }
}
