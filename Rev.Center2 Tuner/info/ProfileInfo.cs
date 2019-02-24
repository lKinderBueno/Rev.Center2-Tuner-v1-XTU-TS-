// Decompiled with JetBrains decompiler
// Type: Rev.Center2_Tuner.ProfileInfo
// Assembly: CPU_DRAM_OC, Version=5.1.1.38, Culture=neutral, PublicKeyToken=null
// MVID: D8F216A9-8907-47CF-9097-3A01D6CBF3A5
// Assembly location: C:\Program Files (x86)\Hotkey\CPU_DRAM_OC.exe

using Intel.Overclocking.SDK.Profile;
using System.Collections.Generic;
using System.IO;

namespace Rev.Center2_Tuner
{
  public class ProfileInfo
  {
    private readonly IProfileLibrary profile;

    public ProfileInfo()
    {
      this.profile = (IProfileLibrary) ProfileLibrary.Instance;
      this.profile.Initialize();
    }

    public List<XtuTuningProfile> GetAvailableProfiles()
    {
      if (this.profile != null)
        return this.profile.GetProfiles();
      return (List<XtuTuningProfile>) null;
    }

    public ImportState AddProfile(string fullFilePath)
    {
      return this.profile.AddProfile(fullFilePath);
    }

    public bool ApplyProfile(string profilename)
    {
      return this.profile.ProposeProfile(Path.GetFileName(profilename)) && this.profile.ApplyProfile(false);
    }

    public bool ExportProfile(string profilename, string filepath)
    {
      return this.profile.ExportProfile(profilename, filepath) == ExportState.ExportSucceeded;
    }
  }
}
