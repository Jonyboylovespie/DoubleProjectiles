using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using DoubleProjectiles;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Models.Towers.Weapons;

[assembly: MelonInfo(typeof(DoubleProjectiles.DoubleProjectiles), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace DoubleProjectiles
{
    public class DoubleProjectiles : BloonsTD6Mod
    {
        public override void OnApplicationStart() => MelonLogger.Msg(System.ConsoleColor.Blue, "Double Projectiles Loaded");
        public override void OnTitleScreen()
        {
            foreach (TowerModel tower in (Il2CppArrayBase<TowerModel>)Game.instance.model.towers)
            {
                List<AttackModel> behaviors1 = TowerModelBehaviorExt.GetBehaviors<AttackModel>(tower);
                List<AttackAirUnitModel> behaviors2 = TowerModelBehaviorExt.GetBehaviors<AttackAirUnitModel>(tower);
                int tier1 = ((Il2CppArrayBase<int>)tower.tiers)[0];
                int tier2 = ((Il2CppArrayBase<int>)tower.tiers)[1];
                int tier3 = ((Il2CppArrayBase<int>)tower.tiers)[2];
                if (behaviors1 != null)
                {
                    for (int index = 0; index < tier1 + tier2 + tier3; ++index)
                    {
                        List<string> stringList = new List<string>();
                        foreach (AttackModel attackModel in behaviors1)
                        {
                            if (attackModel != null)
                            {
                                foreach (WeaponModel weapon in (Il2CppArrayBase<WeaponModel>)attackModel.weapons)
                                {
                                    if (weapon != null && !stringList.Contains(weapon._name))
                                    {
                                        WeaponModel weaponModel1 = weapon.Clone().Cast<WeaponModel>();
                                        WeaponModel weaponModel2 = weaponModel1;
                                        weaponModel2._name = weaponModel2._name + "_";
                                        stringList.Add(weaponModel1._name);
                                        AttackModelExt.AddWeapon(attackModel, weaponModel1);
                                    }
                                }
                            }
                        }
                    }
                }
                if (behaviors2 != null)
                {
                    for (int index = 0; index < tier1 + tier2 + tier3; ++index)
                    {
                        List<string> stringList = new List<string>();
                        foreach (AttackAirUnitModel attackAirUnitModel in behaviors2)
                        {
                            if (attackAirUnitModel != null)
                            {
                                foreach (WeaponModel weapon in (Il2CppArrayBase<WeaponModel>)attackAirUnitModel.weapons)
                                {
                                    if (weapon != null && !stringList.Contains(weapon._name))
                                    {
                                        WeaponModel weaponModel3 = weapon.Clone().Cast<WeaponModel>();
                                        WeaponModel weaponModel4 = weaponModel3;
                                        weaponModel4._name = weaponModel4._name + "_";
                                        stringList.Add(weaponModel3._name);
                                        AttackModelExt.AddWeapon(attackAirUnitModel, weaponModel3);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
