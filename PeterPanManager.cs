using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PeterPanManager : MonoBehaviour    //동화책 입장 시 나타나는 화면의 게임매니저
{
    public static PeterPanManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<PeterPanManager>();
            }
            return m_instance;
        }
    }
    private static PeterPanManager m_instance;

    public GameObject[] bookchar;       //책의 캐릭터들
    public Material[] bookcharnot;      //그림을 완성 못한 상태
    public Material[] bookcharclear;    //그림을 완성한 상태

    public GameObject needpanel;    //필요한 재료 목록
    public Image[] checkChar;   //재료를 확인할 캐릭터

    public Image settingImg;    //설정 이미지
    public Text paperText;      //종이개수 택스트
    public Text redText;        //빨간물감개수 텍스트
    public Text yellowText;     //노란물감개수 텍스트
    public Text blueText;       //파란물감개수 텍스트

    public Text needpapertext;   //필요한 종이개수 텍스트
    public Text needredtext;     //필요한 빨간물감개수 텍스트
    public Text needbluetext;    //필요한 파란물감개수 텍스트
    public Text needyellowtext;  //필요한 노란물감개수 텍스트

    public int needpaper;      //필요한 종이개수
    public int needred;        //필요한 빨간물감개수
    public int needblue;       //필요한 파란물감개수
    public int needyellow;     //필요한 노란물감개수

    public string charname;

    public int type;

    private bool isopen = false;

    int paper;  //종이개수
    int red;    //빨간물감개수
    int yellow; //노란물감개수
    int blue;   //파란물감개수
    private void Start()
    {
        if (PlayerPrefs.GetInt("Peter") == 1)   //1은 완성한 상태를 의미
            bookchar[0].GetComponent<Renderer>().material = bookcharclear[0];   //완성한 모습으로 재질 변경
        if (PlayerPrefs.GetInt("Wendy") == 1)
            bookchar[1].GetComponent<Renderer>().material = bookcharclear[1];
        if (PlayerPrefs.GetInt("TinkerBell") == 1)
            bookchar[2].GetComponent<Renderer>().material = bookcharclear[2];

        paper = PlayerPrefs.GetInt("Paper");
        red = PlayerPrefs.GetInt("Red");
        yellow = PlayerPrefs.GetInt("Yellow");
        blue = PlayerPrefs.GetInt("Blue");

        if (!PlayerPrefs.HasKey("Time"))
            PlayerPrefs.SetString("Time", "Day");

        changeMaterialText(); //소유한 재료 개수 변경
    }
    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("LoadingScene");
    }
    public void ShowSetting()
    {
        isopen = !isopen;
        settingImg.gameObject.SetActive(isopen);
    }
    public void ChooseBook()
    {
        PlayerPrefs.SetInt("ChangeBook", 1);
        SceneManager.LoadScene("LoadingScene");
    }
    public void ShowNeedMaterialCount()
    {
        needpapertext.text = "X "+needpaper;
        needredtext.text = "X " + needred;
        needyellowtext.text = "X " + needyellow;
        needbluetext.text = "X " + needblue ;
    }
    public void CompleteCharImg()
    {
        if (PlayerPrefs.GetInt(charname) != 1)
        {
            if (needpaper <= paper && needred <= red && needyellow <= yellow && needblue <= blue)
            {
                bookchar[type].GetComponent<Renderer>().material = bookcharclear[type];

                paper = paper - needpaper;
                red = red - needred;
                yellow = yellow - needyellow;
                blue = blue - needblue;

                PlayerPrefs.SetInt("Paper", paper);
                PlayerPrefs.SetInt("Red", red);
                PlayerPrefs.SetInt("Blue", blue);
                PlayerPrefs.SetInt("Yellow", yellow);

                PlayerPrefs.SetInt(charname, 1);

                changeMaterialText();
            }
        }
    }
    public void changeMaterialText()
    {
        paperText.text = paper.ToString();
        redText.text = red.ToString();
        yellowText.text = yellow.ToString();
        blueText.text = blue.ToString();
    }
}
