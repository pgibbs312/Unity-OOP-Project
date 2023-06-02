using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text txtHealth;
    [SerializeField] TMP_Text txtScore;
    [SerializeField] TMP_Text txtHighScore;
    [SerializeField] Player player;
    private ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameManager.GetInstance().scoreManager;
        player.health.OnHealthUpdate += UpdateHealth;
    }

    private void OnDisable()
    {
        player.health.OnHealthUpdate -= UpdateHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(float currentHealth)
    {
        txtHealth.SetText(currentHealth.ToString());
    }

    public void UpdateScore()
    {
        txtScore.SetText(GameManager.GetInstance().scoreManager.GetScore().ToString());
    }

    // public void UpdateHighScore()
    // {
    //     txtHighScore.SetText(ScoreManager.GetHighScore().ToString());
    // }
}
