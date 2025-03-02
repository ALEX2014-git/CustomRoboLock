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
using MonoMod.RuntimeDetour.HookGen;
using System.Reflection.Emit;
using MonoMod;
using Unity.Collections.LowLevel.Unsafe;
using On;
using HarmonyLib.Tools;
using System.Runtime.CompilerServices;

#pragma warning disable CS0618
[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
#pragma warning restore CS0618

namespace CustomRoboLock;

[BepInPlugin("ALEX2014.CustomRoboLock", "Custom RoboLock", "1.0.0")]
public partial class CustomRoboLock : BaseUnityPlugin
{
    internal PluginOptions options;
    //public static bool hasDrone, isDroneResynced, rivDroneTalk;
    public static bool HASDRONE_STUB = false;
    public static bool ISDRONERESYNCED_STUB = false;
    public static bool SETTING_NODRONESYNC_STUB = false;

    public static ManualLogSource Logger { get; private set; }

    private static CustomRoboLock _instance;
    public static CustomRoboLock Instance
    {
        get
        {
            if (_instance == null)
            {
                throw new Exception("Instance of CustomRoboLock is not created yet!");
            }
            return _instance;
        }
    }

    public CustomRoboLock()
    {
        try
        {
            _instance = this;
            options = new PluginOptions(this, Logger);
            Logger.LogInfo($"Set up options from CTOR. Is NULL? {options == null}");
        }
        catch (Exception ex)
        {
            Logger.LogError(ex);
            throw;
        }
    }

    private void OnEnable()
    {
        CustomRoboLock.Logger = base.Logger;
        On.RainWorld.OnModsInit += RainWorldOnOnModsInit;
    }

    BindingFlags propFlags = BindingFlags.Instance | BindingFlags.Public;
    BindingFlags myMethodFlags = BindingFlags.Static | BindingFlags.Public;
    private bool IsInit;
    private void RainWorldOnOnModsInit(On.RainWorld.orig_OnModsInit orig, RainWorld self)
    {
        orig(self);
        try
        {
            if (IsInit) return;
            On.RainWorldGame.ShutDownProcess += RainWorldGameOnShutDownProcess;
            On.GameSession.ctor += GameSessionOnctor;

            On.GateKarmaGlyph.InitiateSprites += GateKarmaGlyph_InitiateSprites;
            On.GateKarmaGlyph.DrawSprites += GateKarmaGlyph_DrawSprites;
            On.RainWorld.LoadModResources += RainWorld_LoadModResources;
            On.GateKarmaGlyph.Update += GateKarmaGlyph_Update;
            On.GateKarmaGlyph.ctor += GateKarmaGlyph_ctor1;


            IL.GateKarmaGlyph.DrawSprites += GateKarmaGlyph_DrawSprites1;
            IL.RegionGate.Update += RegionGate_Update;
            IL.HUD.Map.ctor += Map_ctor;

            CustomRoboLockEnums.GateRequirement.RegisterValues();
            CustomRoboLockEnums.GateRequirement.InitExtEnumToIntMap();
            CustomRoboLockEnums.GateRequirement.InitializeHashSets();

            Hook RegionGateHook = new Hook(typeof(RegionGate).GetProperty("MeetRequirement", propFlags).GetGetMethod(), typeof(CustomRoboLock).GetMethod("RegionGate_MeetRequirement_get", myMethodFlags));
            
            MachineConnector.SetRegisteredOI("ALEX2014.CustomRoboLock", options);

            //Logger.LogMessage($"Is enums registered? {(CustomRoboLockEnums.ConversationID.Drone_MeetPlayer != null && CustomRoboLockEnums.ConversationID.Drone_ResyncScene != null && CustomRoboLockEnums.SSOracleBehaviorAction.Drone_MeetPlayer_Init != null && CustomRoboLockEnums.SSOracleBehaviorAction.Drone_MeetPlayer_Talking != null && CustomRoboLockEnums.SSOracleBehaviorAction.Drone_SlumberParty != null && CustomRoboLockEnums.SSOracleBehaviorSubBehavID.Drone_MeetPlayer != null && CustomRoboLockEnums.SSOracleBehaviorSubBehavID.Drone_SlumberParty != null)}");

            CustomRoboLock.LoadModResources();

            IsInit = true;  
        }
        catch (Exception ex)
        {
            Logger.LogError(ex);
            throw;
        }
    }



    private void RainWorld_OnModsDisabled(On.RainWorld.orig_OnModsDisabled orig, RainWorld self, ModManager.Mod[] newlyDisabledMods)
    {
        orig(self, newlyDisabledMods);
        try
        {
            foreach (ModManager.Mod mod in newlyDisabledMods)
            {
                if (mod.id == "ALEX2014.CustomRoboLock")
                {
                    CustomRoboLockEnums.GateRequirement.UnregisterValues();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex);
            throw;
        }
    }

    private static void LoadModResources()
    {
        try
        {
            Futile.atlasManager.LoadAtlas("Atlases/robolockGlyph");

            Futile.atlasManager.LoadAtlas("Atlases/robolockSigns");
            Logger.LogMessage("Loaded atlases");
        }
        catch (Exception)
        {
            Logger.LogError("Couldn't load sprites!");
            throw;
        }
    }

    public static bool CheckDroneGateReqs(RegionGate.GateRequirement CRoboLockEnum, int playerKarma)
    {
        int enumKarmaValue = CustomRoboLockEnums.GateRequirement.GetExtEnumValue(CRoboLockEnum);

        if (CustomRoboLockEnums.GateRequirement.CustomRoboLockSetSynced.Any(x => x.value == CRoboLockEnum.value))
        {
            bool defaultDroneStatus = (CustomRoboLock.HASDRONE_STUB && ((CustomRoboLock.ISDRONERESYNCED_STUB) || (CustomRoboLock.SETTING_NODRONESYNC_STUB)));
            if ((defaultDroneStatus) && (enumKarmaValue - 1 <= playerKarma))
            {
                return true;
            }
            return false;
        }

        if (CustomRoboLockEnums.GateRequirement.CustomRoboLockSetNotSynced.Any(x => x.value == CRoboLockEnum.value))
        {
            if ((CustomRoboLock.HASDRONE_STUB) && (enumKarmaValue - 1 <= playerKarma))
            {
                return true;
            }
            return false;
        }
        return false;
    }

    private static void UnloadModResources()
    {
        //stub
    }

    private void RainWorldGameOnShutDownProcess(On.RainWorldGame.orig_ShutDownProcess orig, RainWorldGame self)
    {
        orig(self);
        ClearMemory();
    }
    private void GameSessionOnctor(On.GameSession.orig_ctor orig, GameSession self, RainWorldGame game)
    {
        orig(self, game);
        ClearMemory();
    }

    #region Helper Methods

    private void ClearMemory()
    {
        //If you have any collections (lists, dictionaries, etc.)
        //Clear them here to prevent a memory leak
        //YourList.Clear();
    }

    #endregion
}
