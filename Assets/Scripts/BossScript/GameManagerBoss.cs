using UnityEngine;
using UnityEngine.UI;

public class GameManagerBoss : MonoBehaviour
{
    public static GameManagerBoss Instance { get; private set; }

    public Text congratsText;
    public BossEnemy bossEnemy;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        congratsText.gameObject.SetActive(false);
    }

    public void ShowCongrats()
    {
        congratsText.gameObject.SetActive(true);
    }
}
