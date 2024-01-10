using CobaltCoreModding.Definitions;
using HarmonyLib;
using Nanoray.Shrike;
using Nanoray.Shrike.Harmony;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.Extensions.Logging;
using static System.Reflection.BindingFlags;

namespace TheJazMaster.MoreDifficulties.AIPatches;

/*
	Fires breachers every 3 turns
*/

[HarmonyPatch]
public static class OxygenLeakGuyPatch {
	private static Manifest Instance => Manifest.Instance;

	[HarmonyPatch(typeof(OxygenLeakGuy), nameof(OxygenLeakGuy.BuildShipForSelf))]
	[HarmonyPostfix]
	private static void BuildShipForSelf_Postfix(OxygenLeakGuy __instance, Ship __result, State s) {
		if (s.GetDifficulty() >= 5)
			__result.parts[1].damageModifier = PDamMod.armor;
	}
}