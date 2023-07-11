using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyCounter : MonoBehaviour
{
    [System.Serializable]
    public class EnemyData
    {
        public string enemyType;
        public int enemyCount;
        public TMP_Text enemyCountText;
    }

    public EnemyData[] enemyData;

    private void Start()
    {
        foreach (EnemyData data in enemyData)
        {
            data.enemyCount = 0;
            UpdateEnemyCountText(data);
        }
    }

    public void EnemyKilled(string enemyType)
    {
        EnemyData data = GetEnemyData(enemyType);
        if (data != null)
        {
            data.enemyCount++;
            UpdateEnemyCountText(data);
        }
    }

    private void UpdateEnemyCountText(EnemyData data)
    {
        data.enemyCountText.text = data.enemyType + "Death enemy: " + data.enemyCount;
    }

    private EnemyData GetEnemyData(string enemyType)
    {
        foreach (EnemyData data in enemyData)
        {
            if (data.enemyType == enemyType)
            {
                return data;
            }
        }
        return null;
    }
}
