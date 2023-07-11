using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{

    public Text enemyCountText;
    private int enemyCount;

    private void Start()
    {
        enemyCount = 0;
        UpdateEnemyCountText();
    }

    public void EnemyKilled()
    {
        enemyCount++;
        UpdateEnemyCountText();
    }

    private void UpdateEnemyCountText()
    {
        enemyCountText.text = "Nemici uccisi: " + enemyCount;
    }
}
