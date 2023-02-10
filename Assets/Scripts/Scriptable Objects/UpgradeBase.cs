using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeBase : ScriptableObject
{
    [SerializeField] Sprite sprite;
    [SerializeField] string upgradeName;
    [SerializeField] string description;

    public Sprite Sprite { get => sprite; set => sprite = value; }
    public string UpgradeName { get => upgradeName; set => upgradeName = value; }
    public string Description { get => description; set => description = value; }

    public abstract void Apply();
}
