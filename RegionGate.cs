﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using UnityEngine;
using RWCustom;
using BepInEx;
using Debug = UnityEngine.Debug;
using System.Data.SqlClient;
using BepInEx.Logging;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CoralBrain;
using Expedition;
using HUD;
using JollyCoop;
using JollyCoop.JollyMenu;
using MoreSlugcats;
using Noise;
using static UpdatableAndDeletable;
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
using MonoMod.Cil;
using System.Runtime.Remoting.Lifetime;
using System.Xml;
using System.Reflection;
using static MonoMod.InlineRT.MonoModRule;
using HarmonyLib.Tools;
using Mono.Cecil.Cil;
using On;

namespace CustomRoboLock
{
    public partial class CustomRoboLock
    {

        public delegate bool orig_MeetRequirement(RegionGate self);

        private bool RegionGate_KarmaBlinkRed(On.RegionGate.orig_KarmaBlinkRed orig, RegionGate self)
        {
            if (ModManager.MSC && CustomRoboLockEnums.GateRequirement.CustomRoboLockSet.Any(x => x.value == self.karmaRequirements[self.letThroughDir ? 0 : 1].value)) return false;
            return orig(self);
        }

        public static bool RegionGate_MeetRequirement_get(orig_MeetRequirement orig, RegionGate self)
        {
            bool origData = orig(self);
            
            Logger.LogMessage($"Current gate requirement: {self.karmaRequirements[(!self.letThroughDir) ? 1 : 0].value}");
            if (ModManager.MSC && !CustomRoboLockEnums.GateRequirement.CustomRoboLockSet.Any(x => x.value == self.karmaRequirements[self.letThroughDir ? 0 : 1].value)) return origData;
            AbstractCreature firstAlivePlayer = self.room.game.FirstAlivePlayer;
            if (self.room.game.Players.Count == 0 || firstAlivePlayer == null || (firstAlivePlayer.realizedCreature == null && ModManager.CoopAvailable))
            {
                return false;
            }
            Player player;
            if (ModManager.CoopAvailable && self.room.game.AlivePlayers.Count > 0)
            {
                player = (firstAlivePlayer.realizedCreature as Player);
            }
            else
            {
                player = (self.room.game.Players[0].realizedCreature as Player);
            }
            int karma = GetPlayerKarma(player);
            Logger.LogError($"Current meetRequirement value: {CheckDroneGateReqs(self.karmaRequirements[self.letThroughDir ? 0 : 1], karma)}");
            return CheckDroneGateReqs(self.karmaRequirements[self.letThroughDir ? 0 : 1], karma);
        }

        private void RegionGate_ctor(ILContext il)
        {
            var c = new ILCursor(il);
            var d = new ILCursor(il);

            c.GotoNext(
            MoveType.After,
            x => x.MatchCall(typeof(System.Text.RegularExpressions.Regex).GetMethod("Split", new[] { typeof(string), typeof(string) })), // IL_0106: call Regex::Split
            x => x.MatchLdcI4(2), // IL_010B: ldc.i4.2
            x => x.MatchLdelemRef(), // IL_010C: ldelem.ref
            x => x.MatchCallvirt(typeof(string).GetMethod("Trim", Type.EmptyTypes)), // IL_010D: callvirt string::Trim
            x => x.MatchLdcI4(0), // IL_0112: ldc.i4.0
            x => x.MatchNewobj(typeof(RegionGate.GateRequirement).GetConstructor(new[] { typeof(string), typeof(bool) })), // IL_0113: newobj GateRequirement::.ctor
            x => x.MatchStelemRef(), // IL_0118: stelem.ref
            x => x.MatchBr(out _), // IL_0119: br.s IL_0125
            x => x.MatchLdloc(2), // IL_011B: ldloc.2
            x => x.MatchLdcI4(1), // IL_011C: ldc.i4.1
            x => x.MatchAdd(), // IL_011D: add
            x => x.MatchStloc(2), // IL_011E: stloc.2
            x => x.MatchLdloc(2), // IL_011F: ldloc.2
            x => x.MatchLdloc(0), // IL_0120: ldloc.0
            x => x.MatchLdlen(), // IL_0121: ldlen
            x => x.MatchConvI4(), // IL_0122: conv.i4
            x => x.MatchBlt(out _) // IL_0123: blt.s IL_00B4
           );

            c.MoveAfterLabels();

            d.GotoNext(
            MoveType.After,
            x => x.MatchCall(typeof(System.Text.RegularExpressions.Regex).GetMethod("Split", new[] { typeof(string), typeof(string) })), // IL_0106: call Regex::Split
            x => x.MatchLdcI4(2), // IL_010B: ldc.i4.2
            x => x.MatchLdelemRef(), // IL_010C: ldelem.ref
            x => x.MatchCallvirt(typeof(string).GetMethod("Trim", Type.EmptyTypes)), // IL_010D: callvirt string::Trim
            x => x.MatchLdcI4(0), // IL_0112: ldc.i4.0
            x => x.MatchNewobj(typeof(RegionGate.GateRequirement).GetConstructor(new[] { typeof(string), typeof(bool) })), // IL_0113: newobj GateRequirement::.ctor
            x => x.MatchStelemRef(), // IL_0118: stelem.ref
            x => x.MatchBr(out _), // IL_0119: br.s IL_0125
            x => x.MatchLdloc(2), // IL_011B: ldloc.2
            x => x.MatchLdcI4(1), // IL_011C: ldc.i4.1
            x => x.MatchAdd(), // IL_011D: add
            x => x.MatchStloc(2), // IL_011E: stloc.2
            x => x.MatchLdloc(2), // IL_011F: ldloc.2
            x => x.MatchLdloc(0), // IL_0120: ldloc.0
            x => x.MatchLdlen(), // IL_0121: ldlen
            x => x.MatchConvI4(), // IL_0122: conv.i4
            x => x.MatchBlt(out _) // IL_0123: blt.s IL_00B4
            );
            var origCode = d.DefineLabel();
            d.MarkLabel(origCode);



        }

        private void RegionGate_Update(ILContext il)
        {
            var c = new ILCursor(il);
            var d = new ILCursor(il);
            var e = new ILCursor(il);
            var f = new ILCursor(il);

            c.GotoNext(
                    MoveType.After,
                    x => x.MatchLdarg(0),
                    x => x.MatchCallvirt(typeof(RegionGate).GetMethod("get_MeetRequirement")),
                    x => x.MatchBrfalse(out _)
                    );

            c.MoveAfterLabels();

            f.GotoNext(
                    MoveType.After,
                    x => x.MatchLdarg(0),
                    x => x.MatchCall(typeof(RegionGate).GetMethod("Unlock")),
                    x => x.MatchBr(out _)
                    );
            var endCode = f.DefineLabel();
            f.MarkLabel(endCode);

            e.GotoNext(
                 MoveType.After,
                 x => x.MatchLdloc(1),
                 x => x.MatchLdfld(typeof(GateKarmaGlyph).GetField("animationFinished")),
                 x => x.MatchBrfalse(out _)
                 );
            var execCode = e.DefineLabel();
            e.MarkLabel(execCode);

            d.GotoNext(
            MoveType.After,
            x => x.MatchLdarg(0),
            x => x.MatchCallvirt(typeof(RegionGate).GetMethod("get_MeetRequirement")),
            x => x.MatchBrfalse(out _)
            );
            var origCode = d.DefineLabel();
            d.MarkLabel(origCode);

            c.Emit(OpCodes.Ldloc_1);

            bool CheckIfShouldUseCustomAnimation(GateKarmaGlyph arg_glyph)
            {
                Logger.LogWarning("Checking if animation check should be crobolock");
                if (CustomRoboLockEnums.GateRequirement.CustomRoboLockSet.Any(x => x.value == arg_glyph.requirement.value))
                {
                    Logger.LogWarning("Custom animation should be crobolock");
                    return true;
                }
                Logger.LogWarning("Custom animation should not be crobolock");
                return false;
            }
            c.EmitDelegate<Func<GateKarmaGlyph, bool>>(CheckIfShouldUseCustomAnimation);
            c.Emit(OpCodes.Brfalse, origCode);

            c.Emit(OpCodes.Ldloc_1);
            bool AnimationFinishedCustomCheck(GateKarmaGlyph arg_glyph)
            {
                Logger.LogWarning("Using custom gate animation check");
                if (arg_glyph.ShouldPlayDroneLockAnimation() == 0 || arg_glyph.GetCustomData().myAnimationFinished)
                {
                    Logger.LogWarning("Custom gate animation check returned true");
                    return true;
                }
                Logger.LogWarning("Custom gate animation check returned false");
                return false;                  
            }
            c.EmitDelegate<Func<GateKarmaGlyph, bool>>(AnimationFinishedCustomCheck);
            c.Emit(OpCodes.Brtrue, execCode);
            c.Emit(OpCodes.Br, endCode);
        }
    }
}
