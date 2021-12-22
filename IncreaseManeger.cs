using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseManeger : MonoBehaviour    //제료 획득 화면에서의 게임 매니저
{
    public static IncreaseManeger instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<IncreaseManeger>();
            }
            return m_instance;
        }
    }
    private static IncreaseManeger m_instance;

    public Text paperText;      //종이개수
    public Text redText;        //빨간물감개수
    public Text yellowText;     //노란물감개수
    public Text blueText;       //파란물감개수
    public void ChangeCount()
    {
        paperText.text = PlayerPrefs.GetInt("Paper") + "";
        redText.text = PlayerPrefs.GetInt("Red") + "";
        yellowText.text = PlayerPrefs.GetInt("Yellow") + "";
        blueText.text = PlayerPrefs.GetInt("Blue") + "";
    }

    private void Start()
    {
        ChangeCount();
    }
}
