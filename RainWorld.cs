using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CustomRoboLock
{
    public partial class CustomRoboLock
    {
        private void RainWorldGame_Update(On.RainWorldGame.orig_Update orig, RainWorldGame self)
        {
            orig(self);
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (CustomRoboLock.ISDRONERESYNCED_STUB)
                {
                    ISDRONERESYNCED_STUB = false;
                    self.cameras[0].hud.PlaySound(SoundID.UI_Slugcat_Exit_Stun);
                }
                else
                {
                    ISDRONERESYNCED_STUB = true;
                    self.cameras[0].hud.PlaySound(SoundID.UI_Slugcat_Die);
                }

                Logger.LogMessage($"Changed DroneSync to {ISDRONERESYNCED_STUB}");
            }

        }

    }
}
