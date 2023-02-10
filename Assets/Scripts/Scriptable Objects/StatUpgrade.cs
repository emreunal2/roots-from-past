using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/StatUpgrade")]
public class StatUpgrade : UpgradeBase
{
    [SerializeField]float amount;
    public enum Stats {MaxHp, HpRecover, MoveSpeed, AttackSpeed, AmmoNumber, Revival, Magnet, Damage, CritChange, ShootRange }
    [SerializeField] Stats stats;
    public override void Apply()
    {
        switch (stats)
        {
            case Stats.MaxHp:
                PlayerStats.instance.MaxHp += amount;
                PlayerStats.instance.CurrentHp += amount;
                break;
            case Stats.HpRecover:
                PlayerStats.instance.HpRecovery += PlayerStats.instance.HpRecovery * amount / 100;
                break;
            case Stats.MoveSpeed:
                PlayerStats.instance.MoveSpeed += PlayerStats.instance.MoveSpeed * amount / 100;
                break;
            case Stats.AttackSpeed:
                PlayerStats.instance.AttackSpeed += PlayerStats.instance.AttackSpeed * amount / 100;
                break;
            case Stats.AmmoNumber:
                PlayerStats.instance.AmmoNumber += amount;
                break;
            case Stats.Revival:
                PlayerStats.instance.Revival += amount;
                break;
            case Stats.Magnet:
                PlayerStats.instance.Magnet+= PlayerStats.instance.Magnet* amount / 100;
                break;
            case Stats.Damage:
                PlayerStats.instance.Damage+= PlayerStats.instance.Magnet * amount / 100;
                break;
            case Stats.ShootRange:
                PlayerStats.instance.ShootRange += PlayerStats.instance.ShootRange * amount / 100;
                break;

        }
    }
}