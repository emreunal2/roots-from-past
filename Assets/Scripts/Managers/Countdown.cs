using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Countdown : MonoBehaviour
{
    [SerializeField] float countdownTime = 5; // Total time in minutes
    public TextMeshProUGUI countdownText; // UI Text component to display countdown

    private float timeLeft;

    private void Start()
    {
        timeLeft = countdownTime * 60;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timeLeft <= 0)
        {
            Debug.Log("test");
        }
    }
}