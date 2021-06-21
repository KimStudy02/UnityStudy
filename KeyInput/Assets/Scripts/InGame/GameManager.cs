using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AirCraftType
{
    Player,
    Enemy,
}


public class GameManager : SingletonBase<GameManager>
{
    public float spawnFreq;
    public bool isPause;
    public float autoSaveFreq;
    public int playScore;
    public float playTime;

    public void AddScore(int score)
    {
        playScore += score;
        ShootingGameUI gameUi = UIManager.Instance.GetUI<ShootingGameUI>(UIList.ShootingGameUI);
        gameUi.SetScore(playScore);
    }

    public void SetTimer()
    {
        if (isPause)
            return;

        playTime += Time.deltaTime;
        
        ShootingGameUI gameUi = UIManager.Instance.GetUI<ShootingGameUI>(UIList.ShootingGameUI);
        gameUi.SetTimer(playTime);
    }

    private void Start()
    {
        LoadSaveData();

        ShootingGameUI gameUi = UIManager.Instance.GetUI<ShootingGameUI>(UIList.ShootingGameUI);
        gameUi.Show();

        StartCoroutine(CoSpawn());
        StartCoroutine(CoAutoSave());

    }

    private void Update()
    {
        SetTimer();
    }

    IEnumerator CoSpawn()
    {
        while(true)
        {
            GameObject enemy = ObjectManager.Instance.GetObject(ObjectType.AirCraft);
            EnemyAirCraft ai = enemy.GetComponent<EnemyAirCraft>();
            EnemyAirCraft.AIpattern randPattern = (EnemyAirCraft.AIpattern)Random.Range((int)EnemyAirCraft.AIpattern.Pattern_A, (int)EnemyAirCraft.AIpattern.Pattern_MAX);
            switch(randPattern)
            {
                case EnemyAirCraft.AIpattern.Pattern_A:
                    ai.Init(randPattern, 20, 3);
                    break;
                case EnemyAirCraft.AIpattern.Pattern_B:
                    ai.Init(randPattern, 5, 3);
                    break;
                case EnemyAirCraft.AIpattern.Pattern_C:
                    ai.Init(randPattern, 3, 3);
                    break;
            }            
            enemy.transform.position = new Vector3(Random.Range(-40, 40), 0.5f, 25.0f);
            enemy.SetActive(true);
            yield return new WaitForSeconds(spawnFreq);
        }
    }

    IEnumerator CoAutoSave()
    {
        while(isPause == false)
        {
            UserDataModel.Instance.SetData(PlayerPrefsKey.Score, playScore.ToString());
            UserDataModel.Instance.SetData(PlayerPrefsKey.PlayTime, playTime.ToString());
            Debug.Log("AutoSave");

            yield return new WaitForSeconds(autoSaveFreq);
        }
        
    }

    private void LoadSaveData()
    {
        string strPlaytime = UserDataModel.Instance.GetData(PlayerPrefsKey.PlayTime);
        string strPlayscore = UserDataModel.Instance.GetData(PlayerPrefsKey.Score);
        
        playTime = string.IsNullOrEmpty(strPlaytime) ? 0 : float.Parse(strPlaytime);
        playScore = string.IsNullOrEmpty(strPlayscore) ? 0 : int.Parse(strPlayscore);
    }
}
