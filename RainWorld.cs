using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRoboLock
{
    public partial class CustomRoboLock
    {
        private void RainWorld_LoadModResources(On.RainWorld.orig_LoadModResources orig, RainWorld self)
        {
            orig(self);

        }

    }
}
