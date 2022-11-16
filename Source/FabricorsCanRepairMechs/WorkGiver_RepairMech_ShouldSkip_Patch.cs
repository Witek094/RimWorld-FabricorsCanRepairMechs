using HarmonyLib;
using RimWorld;
using Verse;

namespace FabricorsCanRepairMechs
{
    [HarmonyPatch(typeof(WorkGiver_RepairMech), "ShouldSkip")]
    public static class WorkGiver_RepairMech_ShouldSkip_Patch
    {
        public static bool Prefix(ref bool __result, Pawn pawn, bool forced = false)
        {
            bool result = true;
            bool ismech = pawn.RaceProps.IsMechanoid;
            bool damaged = MechRepairUtility.CanRepair(pawn);
            if (ismech && !damaged)
            {
                __result = false;
                result = false;
            }
            return result;
        }
    }

    [HarmonyPatch(typeof(WorkGiver_RepairMech), "HasJobOnThing")]
    public static class WorkGiver_RepairMech_HasJobOnThing_Patch
    {
        public static bool Prefix(ref bool __result, Pawn pawn, Thing t, bool forced = false)
        {
            bool result = true;
            Pawn pawn2 = (Pawn)t;
            if (pawn == pawn2)
            {
                __result = false;
                result = false;
            }
            return result;
        }
    }
}
