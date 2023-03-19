using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/New Character")]
public class PlayerSelection : ScriptableObject
{
    [SerializeField] Sprite pickSprite;
    [SerializeField] string playerName;
    [SerializeField] float maxHp;
    [SerializeField] float currentHp;
    [SerializeField] float hpRecovery;

    [SerializeField] float moveSpeed;
    [SerializeField] float attackSpeed;
    [SerializeField] float shootRange;

    [SerializeField] float ammoNumber;
    [SerializeField] float revival;
    [SerializeField] float magnet;

    [SerializeField] float damage;
    [SerializeField] List<WeaponUpgrade> weapons;
    [SerializeField] RuntimeAnimatorController anim;

    public Sprite PickSprite { get => pickSprite; set => pickSprite = value; }
    public float MaxHp { get => maxHp; set => maxHp = value; }
    public float CurrentHp { get => currentHp; set => currentHp = value; }
    public float HpRecovery { get => hpRecovery; set => hpRecovery = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public float ShootRange { get => shootRange; set => shootRange = value; }
    public float AmmoNumber { get => ammoNumber; set => ammoNumber = value; }
    public float Revival { get => revival; set => revival = value; }
    public float Magnet { get => magnet; set => magnet = value; }
    public float Damage { get => damage; set => damage = value; }
    public List<WeaponUpgrade> Weapons { get => weapons; set => weapons = value; }
    public string PlayerName { get => playerName; set => playerName = value; }
    public RuntimeAnimatorController Anim { get => anim; set => anim = value; }
}
