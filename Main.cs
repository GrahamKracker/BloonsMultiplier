using BloonMultiplier;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppAssets.Scripts.Models;
using Main = BloonsMultiplier.Main;

[assembly: MelonInfo(typeof(Main), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace BloonsMultiplier;

[HarmonyPatch]
public class Main : BloonsTD6Mod
{
    private static readonly ModSettingDouble Multiplier = new(10)
    {
        displayName = "Multiplier",
        description = "The multiplier for all spawned bloons",
        min = 1
    };

    public override void OnNewGameModel(GameModel result)
    {
        result.roundSet.rounds.ForEach(round =>
        {
            round.groups.ForEach(group =>
            {
                var count = group.count * Multiplier;
                group.count = (int)count;
            });
        });
    }
}