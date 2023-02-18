using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/StatUpgrade")]
public class StatUpgrade : UpgradeBase
{
    [SerializeField]float buffAmount;
    [SerializeField]float debuffAmount;
    public enum Stats {MaxHp, HpRecover, MoveSpeed, AttackSpeed, AmmoNumber, Revival, Magnet, Damage, CritChange, ShootRange, Nothing }
    [SerializeField] Stats buffStats;
    [SerializeField] Stats debuffStats;
    public override void Apply()
    {
        switch (buffStats)
        {
            case Stats.MaxHp:
                PlayerStats.instance.MaxHp += buffAmount;
                PlayerStats.instance.CurrentHp += buffAmount;
                break;
            case Stats.HpRecover:
                PlayerStats.instance.HpRecovery += PlayerStats.instance.HpRecovery * buffAmount / 100;
                break;
            case Stats.MoveSpeed:
                PlayerStats.instance.MoveSpeed += PlayerStats.instance.MoveSpeed * buffAmount / 100;
                break;
            case Stats.AttackSpeed:
                PlayerStats.instance.AttackSpeed += PlayerStats.instance.AttackSpeed * buffAmount / 100;
                break;
            case Stats.AmmoNumber:
                PlayerStats.instance.AmmoNumber += buffAmount;
                break;
            case Stats.Revival:
                PlayerStats.instance.Revival += buffAmount;
                break;
            case Stats.Magnet:
                PlayerStats.instance.Magnet+= PlayerStats.instance.Magnet* buffAmount / 100;
                break;
            case Stats.Damage:
                PlayerStats.instance.Damage+= PlayerStats.instance.Magnet * buffAmount / 100;
                break;
            case Stats.ShootRange:
                PlayerStats.instance.ShootRange += PlayerStats.instance.ShootRange * buffAmount / 100;
                break;
            case Stats.Nothing:
                break;
        }

        switch (debuffStats)
        {
            case Stats.MaxHp:
                PlayerStats.instance.MaxHp -= debuffAmount;
                break;
            case Stats.HpRecover:
                PlayerStats.instance.HpRecovery -= PlayerStats.instance.HpRecovery * debuffAmount / 100;
                break;
            case Stats.MoveSpeed:
                PlayerStats.instance.MoveSpeed -= PlayerStats.instance.MoveSpeed * debuffAmount / 100;
                break;
            case Stats.AttackSpeed:
                PlayerStats.instance.AttackSpeed -= PlayerStats.instance.AttackSpeed * debuffAmount / 100;
                break;
            case Stats.AmmoNumber:
                PlayerStats.instance.AmmoNumber -= debuffAmount;
                break;
            case Stats.Revival:
                PlayerStats.instance.Revival -= debuffAmount;
                break;
            case Stats.Magnet:
                PlayerStats.instance.Magnet -= PlayerStats.instance.Magnet * debuffAmount / 100;
                break;
            case Stats.Damage:
                PlayerStats.instance.Damage -= PlayerStats.instance.Magnet * debuffAmount / 100;
                break;
            case Stats.ShootRange:
                PlayerStats.instance.ShootRange -= PlayerStats.instance.ShootRange * debuffAmount / 100;
                break;
            case Stats.Nothing:
                break;
        }
    }
}