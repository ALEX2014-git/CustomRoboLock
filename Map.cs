using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoMod.Cil;
using BepInEx.Logging;
using Menu;
using Rewired;
using UnityEngine.SocialPlatforms;
using UnityEngine.Rendering;
using System.Runtime.Serialization;
using Newtonsoft.Json.Serialization;
using Steamworks;
using IL.Menu.Remix.MixedUI;
using Menu.Remix.MixedUI;
using IL;
using On.Menu.Remix.MixedUI;
using System.Runtime.Remoting.Messaging;
using MonoMod.RuntimeDetour;
using UnityEngine;
using static MonoMod.InlineRT.MonoModRule;
using RWCustom;
using System.Runtime.Remoting.Contexts;
using Mono.Cecil.Cil;
using System.Runtime.CompilerServices;
using System.Globalization;
using HUD;

namespace CustomRoboLock
{
    public partial class CustomRoboLock
    {
        private void Map_ctor(ILContext il)
        {
            var c = new ILCursor(il);
            var d = new ILCursor(il);

            c.GotoNext(
                MoveType.After,
                x => x.MatchLdstr("LC/MS gate condition on map"),
                x => x.MatchStelemRef(),
                x => x.MatchDup(),
                x => x.MatchLdcI4(1),
                x => x.MatchLdloca(10),
                x => x.MatchCall(typeof(System.Boolean).GetMethod("ToString", Type.EmptyTypes)),
                x => x.MatchStelemRef(),
                x => x.MatchCall(typeof(RWCustom.Custom).GetMethod("Log", new Type[] { typeof(string[])}))
                );
            c.MoveAfterLabels();

            d.GotoNext(
                MoveType.After,
                x => x.MatchLdstr("LC/MS gate condition on map"),
                x => x.MatchStelemRef(),
                x => x.MatchDup(),
                x => x.MatchLdcI4(1),
                x => x.MatchLdloca(10),
                x => x.MatchCall(typeof(System.Boolean).GetMethod("ToString", Type.EmptyTypes)),
                x => x.MatchStelemRef(),
                x => x.MatchCall(typeof(RWCustom.Custom).GetMethod("Log", new Type[] { typeof(string[])}))
                );
            var endCode = d.DefineLabel();
            d.MarkLabel(endCode);

            c.Emit(OpCodes.Ldarg_2);
            c.Emit(OpCodes.Ldloc, 8);
            bool CheckForCustomRoboLockGateReq(Map.MapData arg_MapData, int k)
            {
                Logger.LogMessage("CheckForCustomRoboLockGateReq started");
                if (CustomRoboLockEnums.GateRequirement.CustomRoboLockSet.Any(x => x.value == arg_MapData.gateData[k].karma.value))
                {
                    Logger.LogMessage("CheckForCustomRoboLockReq returned true");
                    return true;
                }
                Logger.LogMessage("CheckForCustomRoboLockReq returned false");
                return false;
            }
            c.EmitDelegate<Func<Map.MapData, int, bool>>(CheckForCustomRoboLockGateReq);
            c.Emit(OpCodes.Brfalse, endCode);

            c.Emit(OpCodes.Ldarg_2);
            c.Emit(OpCodes.Ldloc, 10);
            c.Emit(OpCodes.Ldloc, 8);
            void SetCRoboLockGateMapStatus(Map.MapData arg_MapData, bool flag, int k)
            {
                Logger.LogMessage("SetCRoboLockGateMapStatus started");
                flag = false;
                flag = CustomRoboLock.CheckDroneGateReqs(arg_MapData.gateData[k].karma, arg_MapData.currentKarma);
                Logger.LogMessage($"Current flag status is {flag}");
            }
            c.EmitDelegate<Action<Map.MapData, bool, int>>(SetCRoboLockGateMapStatus);
        }


    }
}
