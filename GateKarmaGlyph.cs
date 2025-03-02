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

namespace CustomRoboLock
{

    public partial class CustomRoboLock
    {


        private void GateKarmaGlyph_InitiateSprites(On.GateKarmaGlyph.orig_InitiateSprites orig, GateKarmaGlyph self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
        {
            orig(self, sLeaser, rCam);
            Logger.LogMessage("Started GateKarmaGlyph_InitiateSprites hook");
            Logger.LogMessage($"Checking requirement: {self.requirement}, HashCode: {self.requirement.GetHashCode()}");
            Logger.LogMessage($"Checking set contains: {CustomRoboLockEnums.GateRequirement.CustomRoboLockSet.Contains(self.requirement)}"); Logger.LogMessage($"Checking requirement: {self.requirement}, HashCode: {self.requirement.GetHashCode()}");
            Logger.LogMessage($"Checking set contains: {CustomRoboLockEnums.GateRequirement.CustomRoboLockSet.Contains(self.requirement)}");
            Logger.LogMessage($"Does gate contains customrobolock? {CustomRoboLockEnums.GateRequirement.CustomRoboLockSet.Any(x => x.value == self.requirement.value)}");
                if (!CustomRoboLockEnums.GateRequirement.CustomRoboLockSet.Any(x => x.value == self.requirement.value))
                {
                    Logger.LogMessage("Requirement not in set, aborting hook InitiateSprites method");
                    return;
                }


            Logger.LogMessage("Pre CWT operation");
            self.GetCustomData().startSpriteIndex = sLeaser.sprites.Length;

            Logger.LogMessage($"Sprites array length is: {sLeaser.sprites.Length}");

            Array.Resize(ref sLeaser.sprites, sLeaser.sprites.Length + 2);
            self.GetCustomData().endSpriteIndex = sLeaser.sprites.Length;
            Logger.LogMessage($"Resized sprites array, now it's length is: {sLeaser.sprites.Length}");

            if (self.requirement.value == "CRoboLock")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("sign5P");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign0");
            }
            else if (self.requirement.value == "CRoboLockNS")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("signF");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign0");
            }
            else if (self.requirement.value == "CRoboLockK1")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("sign5P");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign1");
            }
            else if (self.requirement.value == "CRoboLockK1NS")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("signF");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign1");
            }
            else if (self.requirement.value == "CRoboLockK2")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("sign5P");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign2");
            }
            else if (self.requirement.value == "CRoboLockK2NS")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("signF");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign2");
            }
            else if (self.requirement.value == "CRoboLockK3")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("sign5P");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign3");
            }
            else if (self.requirement.value == "CRoboLockK3NS")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("signF");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign3");
            }
            else if (self.requirement.value == "CRoboLockK4")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("sign5P");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign4");
            }
            else if (self.requirement.value == "CRoboLockK4NS")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("signF");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign4");
            }
            else if (self.requirement.value == "CRoboLockK5")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("sign5P");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign5");
            }
            else if (self.requirement.value == "CRoboLockK5NS")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("signF");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign5");
            }
            else if (self.requirement.value == "CRoboLockK6")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("sign5P");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign6");
            }
            else if (self.requirement.value == "CRoboLockK6NS")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("signF");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign6");
            }
            else if (self.requirement.value == "CRoboLockK7")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("sign5P");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign7");
            }
            else if (self.requirement.value == "CRoboLockK7NS")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("signF");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign7");
            }
            else if (self.requirement.value == "CRoboLockK8")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("sign5P");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign8");
            }
            else if (self.requirement.value == "CRoboLockK8NS")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("signF");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign8");
            }
            else if (self.requirement.value == "CRoboLockK9")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("sign5P");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign9");
            }
            else if (self.requirement.value == "CRoboLockK9NS")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("signF");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign9");
            }
            else if (self.requirement.value == "CRoboLockK10")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("sign5P");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign10");
            }
            else if (self.requirement.value == "CRoboLockK10NS")
            {
                sLeaser.sprites[self.GetCustomData().startSpriteIndex] = new FSprite("signF");
                sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1] = new FSprite("sign10");
            }
            self.GetCustomData().customRoboLockSpriteSync = sLeaser.sprites[self.GetCustomData().startSpriteIndex];
            self.GetCustomData().customRoboLockSpriteKarma = sLeaser.sprites[self.GetCustomData().startSpriteIndex + 1];
            self.GetCustomData().customRoboLockSpriteSync.shader = rCam.game.rainWorld.Shaders["GateHologram"];
            self.GetCustomData().customRoboLockSpriteKarma.shader = rCam.game.rainWorld.Shaders["GateHologram"];


            Logger.LogMessage($"Finished sprite preparation.");
            Logger.LogMessage($"Sync sprite: {self.GetCustomData().customRoboLockSpriteSync}");
            Logger.LogMessage($"Karma sprite: {self.GetCustomData().customRoboLockSpriteKarma}");

            self.AddToContainer(sLeaser, rCam, rCam.ReturnFContainer("Foreground"));
            Logger.LogMessage($"Added to the container");

        }

        private void GateKarmaGlyph_DrawSprites(On.GateKarmaGlyph.orig_DrawSprites orig, GateKarmaGlyph self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            Logger.LogMessage("Attemtpting to draw gateSprites from method start");
            orig(self, sLeaser, rCam, timeStacker, camPos);

            if (!CustomRoboLockEnums.GateRequirement.CustomRoboLockSet.Any(x => x.value == self.requirement.value))
            {
                Logger.LogMessage("Requirement not in set, aborting hook DrawSprites method");
                return;
            }
            Logger.LogMessage("Attemtpting to draw gateSprites from hook start");

            float num = Mathf.Lerp(self.lastFade, self.fade, timeStacker);
            for (int i = self.GetCustomData().startSpriteIndex; i < self.GetCustomData().endSpriteIndex; i++)
            {
                sLeaser.sprites[i].x = Mathf.Lerp(self.lastPos.x, self.pos.x, timeStacker) - camPos.x;
                sLeaser.sprites[i].y = Mathf.Lerp(self.lastPos.y, self.pos.y, timeStacker) - camPos.y;
                sLeaser.sprites[i].isVisible = (num > 0f);
                sLeaser.sprites[i].color = Color.Lerp(self.lastCol, self.col, timeStacker);
                sLeaser.sprites[i].alpha = num * 0.9f;
            }

            Vector2 vector = new Vector2(sLeaser.sprites[0].x - 16f, sLeaser.sprites[0].y - 41f);
            self.GetCustomData().customRoboLockSpriteSync.x = vector.x - 1;
            self.GetCustomData().customRoboLockSpriteSync.y = vector.y ;
            self.GetCustomData().customRoboLockSpriteKarma.x = vector.x + 32f;
            self.GetCustomData().customRoboLockSpriteKarma.y = vector.y;
            self.GetCustomData().customRoboLockSpriteKarma.color = Color.Lerp(self.GetCustomData().myLastColSync, self.GetCustomData().myColSync, timeStacker);
            self.GetCustomData().customRoboLockSpriteSync.color = Color.Lerp(self.GetCustomData().myLastColKarma, self.GetCustomData().myColKarma, timeStacker);

            Logger.LogWarning($"DroneLockBlinkRed returned value: {self.DroneLockBlinkRed()}");
            self.GetCustomData().customRoboLockSpriteSync.color = self.GetMyCustomColorSync();
            self.GetCustomData().customRoboLockSpriteKarma.color = self.GetMyCustomColorKarma(); 

            Logger.LogMessage("Ending GateKamraGlyps_DrawSprites co-routine");
        }

        private void GateKarmaGlyph_ctor1(On.GateKarmaGlyph.orig_ctor orig, GateKarmaGlyph self, bool side, RegionGate gate, RegionGate.GateRequirement requirement)
        {
            orig(self, side, gate, requirement);
            Logger.LogMessage("Started GateKarmaGlyph_ctor hook");
            self.GetCustomData().myColSync = self.GetToColor;
            self.GetCustomData().myLastColSync = self.GetCustomData().myColSync;

            self.GetCustomData().myColKarma = self.GetToColor;
            self.GetCustomData().myLastColKarma = self.GetCustomData().myColKarma;
            Logger.LogMessage("Ended GateKarmaGlyph_ctor hook");
        }

        private void GateKarmaGlyph_Update(On.GateKarmaGlyph.orig_Update orig, GateKarmaGlyph self, bool eu)
        {
            orig(self, eu);
            self.GetCustomData().myLastColSync = self.GetCustomData().myColSync;
            self.GetCustomData().myColSync = Color.Lerp(self.col, GateKarmaGlyphExtensions.GetMyCustomColorSync(self), 0.2f);

            self.GetCustomData().myLastColKarma = self.GetCustomData().myColKarma;
            self.GetCustomData().myColKarma = Color.Lerp(self.col, GateKarmaGlyphExtensions.GetMyCustomColorKarma(self), 0.2f);

            if (!self.gate.EnergyEnoughToOpen || (self.GetCustomData().myAnimationFinished && self.ShouldPlayDroneLockAnimation() < 0))
            {
                self.GetCustomData().mySinAdder += 1f;
            }

            if (!CustomRoboLockEnums.GateRequirement.CustomRoboLockSet.Any(x => x.value == self.requirement.value)) return;
            if (ModManager.MSC && self.ShouldPlayDroneLockAnimation() != 0)
            {
                for (int i = 0; i < self.gate.room.game.Players.Count; i++)
                {
                    if (self.gate.room.game.Players[i].realizedCreature != null && (self.gate.room.game.Players[i].realizedCreature as Player).myRobot != null)
                    {
                        (self.gate.room.game.Players[i].realizedCreature as Player).myRobot.lockTarget = new Vector2?(new Vector2(self.pos.x + 1, self.pos.y + 5f));
                        self.GetCustomData().myControllingRobo = true;
                    }
                }
                if (CustomRoboLock.HASDRONE_STUB)
                {
                    self.GetCustomData().myAnimationTicker++;
                    if (self.GetCustomData().myAnimationTicker % 3 == 0 && !self.GetCustomData().myAnimationFinished)
                    {
                        self.GetCustomData().myAnimationIndex++;
                    }
                    if (self.GetCustomData().myAnimationTicker % 15 == 0)
                    {
                        self.GetCustomData().myGlyphIndex++;
                        if (self.GetCustomData().myGlyphIndex < 10)
                        {
                            self.room.PlaySound(MoreSlugcats.MoreSlugcatsEnums.MSCSoundID.Data_Bit, self.pos, 1f, 0.5f + UnityEngine.Random.value * 2f);
                        }
                    }
                    if (self.GetCustomData().myAnimationIndex > 9)
                    {
                        self.GetCustomData().myAnimationIndex = 0;
                    }
                    if (self.GetCustomData().myGlyphIndex >= 10)
                    {
                        self.GetCustomData().myAnimationFinished = true;
                    }
                }
                else
                {
                    self.GetCustomData().myAnimationFinished = true;
                }
                if (self.GetCustomData().myAnimationFinished && self.GetCustomData().myMismatchLabel == null && self.ShouldPlayDroneLockAnimation() < 0)
                {
                    self.GetCustomData().myMismatchLabel = new OracleChatLabel(null);
                    self.GetCustomData().myMismatchLabel.color = Color.red;
                    self.GetCustomData().myMismatchLabel.inverted = true;
                    self.GetCustomData().myMismatchLabel.pos = new Vector2(self.pos.x + (float)(self.side ? 150 : -150), self.pos.y - 50f);
                    if (!CustomRoboLock.HASDRONE_STUB)
                    {
                        self.GetCustomData().myMismatchLabel.NewPhrase(50);
                    }
                    else
                    {
                        self.GetCustomData().myMismatchLabel.NewPhrase(51);
                    }
                    self.gate.room.AddObject(self.GetCustomData().myMismatchLabel);
                    return;
                }
            }
            else if (ModManager.MSC)
            {
                if (self.GetCustomData().myControllingRobo)
                {
                    for (int j = 0; j < self.gate.room.game.Players.Count; j++)
                    {
                        if (self.gate.room.game.Players[j].realizedCreature != null && (self.gate.room.game.Players[j].realizedCreature as Player).myRobot != null)
                        {
                            (self.gate.room.game.Players[j].realizedCreature as Player).myRobot.lockTarget = null;
                            self.GetCustomData().myControllingRobo = false;
                        }
                    }
                }
                if (self.GetCustomData().myMismatchLabel != null)
                {
                    self.GetCustomData().myMismatchLabel.Destroy();
                    self.GetCustomData().myMismatchLabel = null;
                }
                self.GetCustomData().myAnimationTicker = 0;
                self.GetCustomData().myGlyphIndex = -1;
                self.GetCustomData().myAnimationFinished = false;
            }
        }


        private void GateKarmaGlyph_DrawSprites1(ILContext il)
        {
            var c = new ILCursor(il);
            var d = new ILCursor(il);
            var e = new ILCursor(il);

            d.GotoNext(
                MoveType.After,
                x => x.MatchLdsfld(typeof(Futile).GetField("atlasManager")),
                x => x.MatchLdstr("gateSymbol"),
                x => x.MatchLdarg(0),
                x => x.MatchLdfld(typeof(GateKarmaGlyph).GetField("requirement")),
                x => x.MatchLdfld(typeof(ExtEnumBase).GetField("value")),
                x => x.MatchCall(typeof(System.String).GetMethod("Concat", new Type[] { typeof(string), typeof(string) })),
                x => x.MatchCallvirt(typeof(FAtlasManager).GetMethod("GetElementWithName")),
                x => x.MatchCallvirt(typeof(FFacetElementNode).GetMethod("set_element"))
                );
            var endCode = d.DefineLabel();
            d.MarkLabel(endCode);

            c.GotoNext(
                MoveType.After,
                x => x.MatchLdsfld(typeof(Futile).GetField("atlasManager")),
                x => x.MatchLdstr("gateSymbol0"),
                x => x.MatchCallvirt(typeof(FAtlasManager).GetMethod("GetElementWithName")),
                x => x.MatchCallvirt(typeof(FFacetElementNode).GetMethod("set_element")),
                x => x.MatchBr(out _)
                );
            c.MoveAfterLabels();

            e.GotoNext(
            MoveType.After,
            x => x.MatchLdsfld(typeof(Futile).GetField("atlasManager")),
            x => x.MatchLdstr("gateSymbol0"),
            x => x.MatchCallvirt(typeof(FAtlasManager).GetMethod("GetElementWithName")),
            x => x.MatchCallvirt(typeof(FFacetElementNode).GetMethod("set_element")),
            x => x.MatchBr(out _)
            );
            var origCode = e.DefineLabel();
            e.MarkLabel(origCode);

            c.Emit(OpCodes.Ldarg_0);
            bool CheckForCustomRoboLockReq(GateKarmaGlyph this_arg)
            {
                Logger.LogMessage("CheckForCustomRoboLockReq started");
                if (CustomRoboLockEnums.GateRequirement.CustomRoboLockSet.Any(x => x.value == this_arg.requirement.value))
                {
                    Logger.LogMessage("CheckForCustomRoboLockReq returned true");
                    return true;                   
                }
                Logger.LogMessage("CheckForCustomRoboLockReq returned false");
                return false;
            }
            c.EmitDelegate<Func<GateKarmaGlyph, bool>>(CheckForCustomRoboLockReq);
            c.Emit(OpCodes.Brfalse, origCode);
            c.Emit(OpCodes.Ldarg_1);
            void SetRoboLockGlyphSprite(RoomCamera.SpriteLeaser sLeaser_arg)
            {
                Logger.LogMessage("Setting RoboLock Value");
                sLeaser_arg.sprites[1].element = Futile.atlasManager.GetElementWithName("gateSymbolCRoboLock");
            }
            c.EmitDelegate<Action<RoomCamera.SpriteLeaser>>(SetRoboLockGlyphSprite);
            c.Emit(OpCodes.Br, endCode);

        }
    }

    public static class GateKarmaGlyphExtensions
    {
        public static Color GetMyCustomColorSync(this GateKarmaGlyph glyph)
        {
            if ((DroneLockBlinkRed(glyph) == 1 || DroneLockBlinkRed(glyph) == 3) && (!glyph.gate.EnergyEnoughToOpen || (glyph.GetCustomData().myAnimationFinished && glyph.ShouldPlayDroneLockAnimation() < 0)))
            {     
                return Color.Lerp(glyph.myDefaultColor, new Color(1f, 0f, 0f), 0.4f + 0.5f * Mathf.Sin(glyph.GetCustomData().mySinAdder / 12f));             
            }
            return glyph.myDefaultColor;
        }

        public static Color GetMyCustomColorKarma(this GateKarmaGlyph glyph)
        {
            if ((DroneLockBlinkRed(glyph) == 2 || DroneLockBlinkRed(glyph) == 3) && (!glyph.gate.EnergyEnoughToOpen || (glyph.GetCustomData().myAnimationFinished && glyph.ShouldPlayDroneLockAnimation() < 0)))
            {
                return Color.Lerp(glyph.myDefaultColor, new Color(1f, 0f, 0f), 0.4f + 0.5f * Mathf.Sin(glyph.GetCustomData().mySinAdder / 12f));
            }
            return glyph.myDefaultColor;
        }

        public static int DroneLockBlinkRed(this GateKarmaGlyph glyph) //0 - DEFAULT, 1 - SYNC, 2 - KARMA, 3 - BOTH, -1 - NONE
        {
            if (!CustomRoboLockEnums.GateRequirement.CustomRoboLockSet.Any(x => x.value == glyph.requirement.value)) return -1;
            AbstractCreature firstAlivePlayer = glyph.gate.room.game.FirstAlivePlayer;
            if (glyph.gate.room.game.Players.Count == 0 || firstAlivePlayer == null || (firstAlivePlayer.realizedCreature == null && ModManager.CoopAvailable))
            {
                return 0;
            }
            Player player;
            if (ModManager.CoopAvailable && glyph.gate.room.game.AlivePlayers.Count > 0)
            {
                player = (firstAlivePlayer.realizedCreature as Player);
            }
            else
            {
                player = (glyph.gate.room.game.Players[0].realizedCreature as Player);
            }
            int pKarma = player.Karma;
            if (ModManager.MSC && player.SlugCatClass == MoreSlugcats.MoreSlugcatsEnums.SlugcatStatsName.Artificer && player.grasps.Length != 0)
            {
                for (int i = 0; i < player.grasps.Length; i++)
                {
                    if (player.grasps[i] != null && player.grasps[i].grabbedChunk != null && player.grasps[i].grabbedChunk.owner is Scavenger)
                    {
                        pKarma = (glyph.gate.room.game.session as StoryGameSession).saveState.deathPersistentSaveData.karma + (player.grasps[i].grabbedChunk.owner as Scavenger).abstractCreature.karmicPotential;
                        break;
                    }
                }
            }
            bool flag2 = false;
            var karmaRequirement = glyph.gate.karmaRequirements[(!glyph.gate.letThroughDir) ? 1 : 0];
            int karmaValue = CustomRoboLockEnums.GateRequirement.GetExtEnumValue(karmaRequirement);

            if ((flag2 = (karmaValue - 1 > pKarma)) && (!CustomRoboLock.ISDRONERESYNCED_STUB)) return 3;
            if (flag2 = (karmaValue - 1 > pKarma)) return 2;
            if (!CustomRoboLock.ISDRONERESYNCED_STUB) return 1;
            return 0;    
        }

        public static int ShouldPlayDroneLockAnimation(this GateKarmaGlyph glyph)
        {
            if (!ModManager.MSC || !CustomRoboLockEnums.GateRequirement.CustomRoboLockSet.Any(x => x.value == glyph.requirement.value))
            {
                return 0;
            }
            if (glyph.gate.mode != RegionGate.Mode.MiddleClosed || !glyph.gate.EnergyEnoughToOpen || glyph.gate.unlocked || glyph.gate.letThroughDir == glyph.side)
            {
                return 0;
            }
            int num = glyph.gate.PlayersInZone();
            if (num <= 0 || num >= 3)
            {
                return 0;
            }
            glyph.gate.letThroughDir = (num == 1);
            if (glyph.gate.dontOpen || glyph.gate.MeetRequirement)
            {
                return 1;
            }
            return -1;
        }
    }

    public static class GateKarmaGlyphCWT
    {
        static ConditionalWeakTable<GateKarmaGlyph, Data> table = new ConditionalWeakTable<GateKarmaGlyph, Data>();

        public static Data GetCustomData(this GateKarmaGlyph self) => table.GetOrCreateValue(self);

        public class Data
        {
            public string originalSprite;
            public int startSpriteIndex;
            public int endSpriteIndex;
            public FSprite customRoboLockSpriteSync;
            public FSprite customRoboLockSpriteKarma;
            public Color myColSync;
            public Color myLastColSync;
            public Color myColKarma;
            public Color myLastColKarma;
            public float mySinAdder;
            public bool myAnimationFinished = true;
            public int myAnimationTicker;
            public int myAnimationIndex;
            public int myGlyphIndex;
            public bool myControllingRobo = false;
            public OracleChatLabel myMismatchLabel;
        }
    }
}









