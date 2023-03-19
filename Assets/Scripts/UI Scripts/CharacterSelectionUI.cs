using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CharacterSelectionUI : MonoBehaviour
{
    [SerializeField] List<GameObject> characterButtons;
    [SerializeField] TextMeshProUGUI playerName, hp, hpRecovery, attackPower, moveSpeed, attackSpeed, Weapon;
    [SerializeField] int selectedPlayer;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject mainUI;


    public int SelectedPlayer { get => selectedPlayer; set => selectedPlayer = value; }

    void Start()
    {
        Time.timeScale = 0f;
        mainUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < GameManager.instance.Characters.Count; i++)
        {
            characterButtons[i].SetActive(true);
            characterButtons[i].GetComponent<Image>().sprite = GameManager.instance.Characters[i].PickSprite;
        }
    }

    public void SelectCharacter(int character)
    {
        PlayerSelection index = GameManager.instance.Characters[character];
        
        playerName.text = index.PlayerName;
        hp.text = "HP: " + index.MaxHp.ToString();
        hpRecovery.text = "Hp Recovery: " + index.HpRecovery.ToString();
        moveSpeed.text = "Move Speed: " + index.MoveSpeed.ToString();
        attackPower.text = "Attack Power: " + index.Damage.ToString();
        attackSpeed.text = "Attack Speed: " + index.AttackSpeed.ToString();
        Weapon.text = "Weapon: " + index.Weapons[0].UpgradeName;
        selectedPlayer = character;
    }

    public void StartGame()
    {
        PlayerSelection selectedCharacter = GameManager.instance.Characters[selectedPlayer];
        PlayerStats.instance.MaxHp = selectedCharacter.MaxHp;
        PlayerStats.instance.HpRecovery = selectedCharacter.HpRecovery;
        PlayerStats.instance.MoveSpeed = selectedCharacter.MoveSpeed;
        PlayerStats.instance.Damage = selectedCharacter.Damage;
        PlayerStats.instance.AttackSpeed = selectedCharacter.AttackSpeed;
        for (int i=0; i < selectedCharacter.Weapons.Count; i++)
        {
            selectedCharacter.Weapons[i].Apply();
        }
        PlayerStats.instance.GetComponent<SpriteRenderer>().sprite = selectedCharacter.PickSprite;
        PlayerStats.instance.GetComponent<Animator>().runtimeAnimatorController = selectedCharacter.Anim;
        mainUI.SetActive(true);
        menu.SetActive(false);
        Time.timeScale = 1f;
    }
}
