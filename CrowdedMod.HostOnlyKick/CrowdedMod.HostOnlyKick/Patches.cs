using HarmonyLib;

namespace CrowdedMod.HostOnlyKick;

internal static class Patches
{
    [HarmonyPatch(typeof(VoteBanSystem), nameof(VoteBanSystem.AddVote))]
    public static class VoteBanSystemAddVotePatch
    {
        private static bool Prefix()
        {
            return false;
        }
    }

    [HarmonyPatch(typeof(VoteBanSystem), nameof(VoteBanSystem.CmdAddVote))]
    public static class VoteBanSystemCmdAddVotePatch
    {
        private static bool Prefix([HarmonyArgument(0)] int clientId)
        {
            if (AmongUsClient.Instance.AmHost)
            {
                AmongUsClient.Instance.KickPlayer(clientId, false);
            }

            return false;
        }
    }
}