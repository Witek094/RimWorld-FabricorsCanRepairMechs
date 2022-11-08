using HarmonyLib;
using RimWorld;
using System;
using Verse;

namespace FabricorsCanRepairMechs
{
    [HarmonyPatch(typeof(WorkGiver_RepairMech))]
    [HarmonyPatch(nameof(WorkGiver_RepairMech.ShouldSkip))]
    public static class WorkGiver_RepairMech_ShouldSkip_Patch
    {
        public static bool Prefix(ref bool __result,  Pawn pawn, bool forced = false)
        {
            bool result = true;
            bool ismech = pawn.RaceProps.IsMechanoid;
            Log.Message("isMech: " + ismech.ToString());
            if (ismech)
            {
                __result = false;
                result = false;
            }
            return result;
        }
    }
}
