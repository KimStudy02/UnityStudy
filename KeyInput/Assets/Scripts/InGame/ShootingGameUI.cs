using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingGameUI : UIBase
{
    
    public Text timerText;
    public Text scoreText;

    public Image skill_Fill_1;
    public Image skill_Fill_2;
    public Text skillCoolTimeText_1;
    public Text skillCoolTimeText_2;
    public float skillCoolTime_1;
    public float skillCoolTime_2;
    public float skillTotalTime_1;
    public float skillTotalTime_2;

    private void OnEnable()
    {        
        skill_Fill_1.gameObject.SetActive(false);
        skill_Fill_2.gameObject.SetActive(false);
        skillCoolTimeText_1.gameObject.SetActive(false);
        skillCoolTimeText_2.gameObject.SetActive(false);
    }

    public void SetScore(int score)
    {        
        scoreText.text = score.ToString();
    }

    public void SetTimer(float time)
    {
        string strTime = string.Format("{0:0.00}", time);
        timerText.text = strTime;
    }

    public void UseSkill(SkillType type, float totalCoolTime)
    {
        switch(type)
        {
            case SkillType.Bomber:
                skillCoolTime_1 = 0;
                skillTotalTime_1 = totalCoolTime;
                break;
            case SkillType.Tornado:
                skillCoolTime_2 = 0;
                skillTotalTime_2 = totalCoolTime;
                break;
        }        
        StartCoroutine(CoCoolTime(type));
    }    

    IEnumerator CoCoolTime(SkillType type)
    {
        switch(type)
        {
            case SkillType.Bomber:
                skill_Fill_1.gameObject.SetActive(true);
                skillCoolTimeText_1.gameObject.SetActive(true);
                while (skillCoolTime_1 < skillTotalTime_1)
                {
                    skillCoolTime_1 += Time.deltaTime;

                    skill_Fill_1.fillAmount = skillCoolTime_1 / skillTotalTime_1;

                    string strTime = string.Format("{0:0.00}", (skillTotalTime_1 - skillCoolTime_1));

                    skillCoolTimeText_1.text = strTime;

                    yield return null;
                }
                skill_Fill_1.gameObject.SetActive(false);
                skillCoolTimeText_1.gameObject.SetActive(false);
                break;
            case SkillType.Tornado:
                skill_Fill_2.gameObject.SetActive(true);
                skillCoolTimeText_2.gameObject.SetActive(true);
                while (skillCoolTime_2 < skillTotalTime_2)
                {
                    skillCoolTime_2 += Time.deltaTime;

                    skill_Fill_2.fillAmount = skillCoolTime_2 / skillTotalTime_2;

                    string strTime = string.Format("{0:0.00}", (skillTotalTime_2 - skillCoolTime_2));

                    skillCoolTimeText_2.text = strTime;

                    yield return null;
                }
                skill_Fill_2.gameObject.SetActive(false);
                skillCoolTimeText_2.gameObject.SetActive(false);
                break;
        }
        
    }
}


//"{0:##,##}"