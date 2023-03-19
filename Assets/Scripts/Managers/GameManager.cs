using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] List<PlayerSelection> characters;
    [SerializeField] int currentCharacter;
    public List<PlayerSelection> Characters { get => characters; set => characters = value; }

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void NewGame(int index)
    {
        currentCharacter = index;
        SceneManager.LoadScene("InGame");
        PlayerSelection selectedCharacter = characters[currentCharacter];
        Debug.Log(selectedCharacter.MaxHp);
        PlayerStats.instance.MaxHp = selectedCharacter.MaxHp;
        PlayerStats.instance.HpRecovery = selectedCharacter.HpRecovery;
        PlayerStats.instance.MoveSpeed = selectedCharacter.MoveSpeed;
        PlayerStats.instance.Damage = selectedCharacter.Damage;
        PlayerStats.instance.AttackSpeed = selectedCharacter.AttackSpeed;
    }
}
