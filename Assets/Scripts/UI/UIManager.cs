using minyee2913.Utils;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    protected override bool UseDontDestroyOnLoad => false;
    [SerializeField]
    Image atkCoolIndicator;
    [SerializeField]
    Text cooltime;

    void Update()
    {
        atkCoolIndicator.fillAmount = PlayerController.Local.battle.atkCool.timeLeft() / PlayerController.Local.battle.atkCool.time;
        if (PlayerController.Local.battle.atkCool.IsIn())
        {
            cooltime.text = (Mathf.Floor(PlayerController.Local.battle.atkCool.timeLeft() * 10) / 10).ToString() + "s";
        }
        else
            cooltime.text = "";

    }
}
