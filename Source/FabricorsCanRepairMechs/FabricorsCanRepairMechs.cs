using HarmonyLib;
using Verse;
using System.Reflection;

namespace FabricorsCanRepairMechs
{
    [StaticConstructorOnStartup]
    public static class FabricorsCanRepairMechs
    {
        static FabricorsCanRepairMechs()
        {
            Harmony harmony = new Harmony(id: "witek.FabricorsCanRepairMechs");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}