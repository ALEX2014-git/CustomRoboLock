using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomRoboLock;
using HUD;
using Menu;
using OverseerHolograms;
using VoidSea;
using MoreSlugcats;

namespace CustomRoboLock
{
    public static class CustomRoboLockEnums
    {
        public class GateRequirement
        {
            public static void RegisterValues()
            {
                CustomRoboLockEnums.GateRequirement.CustomRoboLock = new RegionGate.GateRequirement("CRoboLock", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockNoSync = new RegionGate.GateRequirement("CRoboLockNS", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma1 = new RegionGate.GateRequirement("CRoboLockK1", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma1NoSync = new RegionGate.GateRequirement("CRoboLockK1NS", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma2 = new RegionGate.GateRequirement("CRoboLockK2", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma2NoSync = new RegionGate.GateRequirement("CRoboLockK2NS", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma3 = new RegionGate.GateRequirement("CRoboLockK3", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma3NoSync = new RegionGate.GateRequirement("CRoboLockK3NS", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma4 = new RegionGate.GateRequirement("CRoboLockK4", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma4NoSync = new RegionGate.GateRequirement("CRoboLockK4NS", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma5 = new RegionGate.GateRequirement("CRoboLockK5", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma5NoSync = new RegionGate.GateRequirement("CRoboLockK5NS", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma6 = new RegionGate.GateRequirement("CRoboLockK6", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma6NoSync = new RegionGate.GateRequirement("CRoboLockK6NS", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma7 = new RegionGate.GateRequirement("CRoboLockK7", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma7NoSync = new RegionGate.GateRequirement("CRoboLockK7NS", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma8 = new RegionGate.GateRequirement("CRoboLockK8", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma8NoSync = new RegionGate.GateRequirement("CRoboLockK8NS", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma9 = new RegionGate.GateRequirement("CRoboLockK9", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma9NoSync = new RegionGate.GateRequirement("CRoboLockK9NS", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma10 = new RegionGate.GateRequirement("CRoboLockK10", true);
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma10NoSync = new RegionGate.GateRequirement("CRoboLockK10NS", true);
            }

            public static void UnregisterValues()
            {
                RegionGate.GateRequirement crlock = CustomRoboLockEnums.GateRequirement.CustomRoboLock;
                if (crlock != null)
                {
                    crlock.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLock = null;

                RegionGate.GateRequirement crlock_nosync = CustomRoboLockEnums.GateRequirement.CustomRoboLockNoSync;
                if (crlock_nosync != null)
                {
                    crlock_nosync.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockNoSync = null;

                RegionGate.GateRequirement crlock_karma1 = CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma1;
                if (crlock_karma1 != null)
                {
                    crlock_karma1.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma1 = null;

                RegionGate.GateRequirement crlock_karma1_nosync = CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma1NoSync;
                if (crlock_karma1_nosync != null)
                {
                    crlock_karma1_nosync.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma1NoSync = null;

                RegionGate.GateRequirement crlock_karma2 = CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma2;
                if (crlock_karma2 != null)
                {
                    crlock_karma2.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma2 = null;

                RegionGate.GateRequirement crlock_karma2_nosync = CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma2NoSync;
                if (crlock_karma2_nosync != null)
                {
                    crlock_karma2_nosync.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma2NoSync = null;

                RegionGate.GateRequirement crlock_karma3 = CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma3;
                if (crlock_karma3 != null)
                {
                    crlock_karma3.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma3 = null;

                RegionGate.GateRequirement crlock_karma3_nosync = CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma3NoSync;
                if (crlock_karma3_nosync != null)
                {
                    crlock_karma3_nosync.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma3NoSync = null;

                RegionGate.GateRequirement crlock_karma4 = CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma4;
                if (crlock_karma4 != null)
                {
                    crlock_karma4.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma4 = null;

                RegionGate.GateRequirement crlock_karma4_nosync = CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma4NoSync;
                if (crlock_karma4_nosync != null)
                {
                    crlock_karma4_nosync.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma4NoSync = null;

                RegionGate.GateRequirement crlock_karma5 = CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma5;
                if (crlock_karma5 != null)
                {
                    crlock_karma5.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma5 = null;

                RegionGate.GateRequirement crlock_karma5_nosync = CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma5NoSync;
                if (crlock_karma5_nosync != null)
                {
                    crlock_karma5_nosync.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma5NoSync = null;

                RegionGate.GateRequirement crlock_karma6 = CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma6;
                if (crlock_karma6 != null)
                {
                    crlock_karma6.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma6 = null;

                RegionGate.GateRequirement crlock_karma6_nosync = CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma6NoSync;
                if (crlock_karma6_nosync != null)
                {
                    crlock_karma6_nosync.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma6NoSync = null;

                RegionGate.GateRequirement crlock_karma7 = CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma7;
                if (crlock_karma7 != null)
                {
                    crlock_karma7.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma7 = null;

                RegionGate.GateRequirement crlock_karma7_nosync = CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma7NoSync;
                if (crlock_karma7_nosync != null)
                {
                    crlock_karma7_nosync.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma7NoSync = null;

                RegionGate.GateRequirement crlock_karma8 = CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma8;
                if (crlock_karma8 != null)
                {
                    crlock_karma8.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma8 = null;

                RegionGate.GateRequirement crlock_karma8_nosync = CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma8NoSync;
                if (crlock_karma8_nosync != null)
                {
                    crlock_karma8_nosync.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma8NoSync = null;

                RegionGate.GateRequirement crlock_karma9 = CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma9;
                if (crlock_karma9 != null)
                {
                    crlock_karma9.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma9 = null;

                RegionGate.GateRequirement crlock_karma9_nosync = CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma9NoSync;
                if (crlock_karma9_nosync != null)
                {
                    crlock_karma9_nosync.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma9NoSync = null;

                RegionGate.GateRequirement crlock_karma10 = CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma10;
                if (crlock_karma10 != null)
                {
                    crlock_karma10.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma10 = null;

                RegionGate.GateRequirement crlock_karma10_nosync = CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma10NoSync;
                if (crlock_karma10_nosync != null)
                {
                    crlock_karma10_nosync.Unregister();
                }
                CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma10NoSync = null;
            }

            public static RegionGate.GateRequirement CustomRoboLock;
            public static RegionGate.GateRequirement CustomRoboLockNoSync;
            public static RegionGate.GateRequirement CustomRoboLockKarma1;
            public static RegionGate.GateRequirement CustomRoboLockKarma1NoSync;
            public static RegionGate.GateRequirement CustomRoboLockKarma2;
            public static RegionGate.GateRequirement CustomRoboLockKarma2NoSync;
            public static RegionGate.GateRequirement CustomRoboLockKarma3;
            public static RegionGate.GateRequirement CustomRoboLockKarma3NoSync;
            public static RegionGate.GateRequirement CustomRoboLockKarma4;
            public static RegionGate.GateRequirement CustomRoboLockKarma4NoSync;
            public static RegionGate.GateRequirement CustomRoboLockKarma5;
            public static RegionGate.GateRequirement CustomRoboLockKarma5NoSync;
            public static RegionGate.GateRequirement CustomRoboLockKarma6;
            public static RegionGate.GateRequirement CustomRoboLockKarma6NoSync;
            public static RegionGate.GateRequirement CustomRoboLockKarma7;
            public static RegionGate.GateRequirement CustomRoboLockKarma7NoSync;
            public static RegionGate.GateRequirement CustomRoboLockKarma8;
            public static RegionGate.GateRequirement CustomRoboLockKarma8NoSync;
            public static RegionGate.GateRequirement CustomRoboLockKarma9;
            public static RegionGate.GateRequirement CustomRoboLockKarma9NoSync;
            public static RegionGate.GateRequirement CustomRoboLockKarma10;
            public static RegionGate.GateRequirement CustomRoboLockKarma10NoSync;

            public static HashSet<ExtEnum<RegionGate.GateRequirement>> CustomRoboLockSet;
            public static HashSet<ExtEnum<RegionGate.GateRequirement>> CustomRoboLockSetSynced;
            public static HashSet<ExtEnum<RegionGate.GateRequirement>> CustomRoboLockSetNotSynced;


            public static void InitializeHashSets()
            {
                CustomRoboLockSet = new HashSet<ExtEnum<RegionGate.GateRequirement>>
            {
            CustomRoboLockEnums.GateRequirement.CustomRoboLock,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockNoSync,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma1,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma1NoSync,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma2,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma2NoSync,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma3,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma3NoSync,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma4,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma4NoSync,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma5,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma5NoSync,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma6,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma6NoSync,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma7,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma7NoSync,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma8,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma8NoSync,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma9,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma9NoSync,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma10,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma10NoSync
            };

            CustomRoboLockSetSynced = new HashSet<ExtEnum<RegionGate.GateRequirement>>
            {
            CustomRoboLockEnums.GateRequirement.CustomRoboLock,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma1,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma2,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma3,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma4,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma5,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma6,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma7,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma8,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma9,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma10
            };

           CustomRoboLockSetNotSynced = new HashSet<ExtEnum<RegionGate.GateRequirement>>
            {
            CustomRoboLockEnums.GateRequirement.CustomRoboLockNoSync,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma1NoSync,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma2NoSync,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma3NoSync,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma4NoSync,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma5NoSync,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma6NoSync,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma7NoSync,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma8NoSync,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma9NoSync,
            CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma10NoSync
            };
            }
             


             

            private static Dictionary<string, int>? ExtEnumToIntMap;

            public static void InitExtEnumToIntMap()
            {
                if (ExtEnumToIntMap != null) return; // Не создавать повторно

                ExtEnumToIntMap = new Dictionary<string, int>
    {
                { CustomRoboLockEnums.GateRequirement.CustomRoboLock.ToString(), -1 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockNoSync.ToString(), -1 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma1.ToString(), 1 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma2.ToString(), 2 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma3.ToString(), 3 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma4.ToString(), 4 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma5.ToString(), 5 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma6.ToString(), 6 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma7.ToString(), 7 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma8.ToString(), 8 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma9.ToString(), 9 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma10.ToString(), 10 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma1NoSync.ToString(), 1 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma2NoSync.ToString(), 2 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma3NoSync.ToString(), 3 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma4NoSync.ToString(), 4 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma5NoSync.ToString(), 5 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma6NoSync.ToString(), 6 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma7NoSync.ToString(), 7 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma8NoSync.ToString(), 8 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma9NoSync.ToString(), 9 },
                { CustomRoboLockEnums.GateRequirement.CustomRoboLockKarma10NoSync.ToString(), 10 }
            };

                Console.WriteLine("ExtEnumToIntMap инициализирован.");
            }


            public static int GetExtEnumValue(ExtEnum<RegionGate.GateRequirement> extEnum)
            {
                return ExtEnumToIntMap.TryGetValue(extEnum.ToString(), out int value) ? value : -1;
            }
        }
    }
}