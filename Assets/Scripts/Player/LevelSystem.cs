using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem instance;
    [SerializeField] int playerLevel = 1;
    [SerializeField] int maxLevel = 50;

    [SerializeField] float currentXP;
    [SerializeField] float[] neededXP;
    private int baseNeededXP = 100;

    public int PlayerLevel { get => playerLevel; set => playerLevel = value; }
    public float[] NeededXP { get => neededXP; set => neededXP = value; }
    public float CurrentXP { get => currentXP; set => currentXP = value; }

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        neededXP = new float[maxLevel];
        neededXP[1] = baseNeededXP;
        for (int i = 2; i < neededXP.Length; i++)
        {
            neededXP[i] = (int)(0.02f * i * i * i + 3.06f * i * i + 105.6f * i/2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainXP(float amount)
    {
        currentXP += amount;
        if (currentXP > neededXP[playerLevel])
        {
            currentXP -= neededXP[playerLevel];
            playerLevel++;
            UpgradeMenu.instance.OpenUpdateMenu();
        }
    }
}
