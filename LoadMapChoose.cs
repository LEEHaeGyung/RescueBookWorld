using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMapChoose : MonoBehaviour  //게임 첫 화면에서 실행되는 스크립트
{
    public GameObject startpanel;   //타이틀과 시작하기 버튼이 있는 패널
    public GameObject mappanel;     //맵 선택이 가능할 패널
   public void LoadMap()                //시작 화면에서 게임시작하기를 누르면 실행되는 함수
    {
        startpanel.SetActive(false);    //게임시작하기 패널 비활성화
        mappanel.SetActive(true);       //맵 선택 화면 활성화
    }

    public void GotoPeterPan()      //피터팬 책 버튼을 누르면 실행 피터팬 맵으로 이동
    {
        SceneManager.LoadScene("PeterPan");
        PlayerPrefs.SetString("Book", "PeterPan");
    }
    public void GotoCinderella()    //신데렐레 맵으로 이동
    {
        //구현이 되지 않았으므로 기능은 없는 상태
    }
    public void GotoTangled()       //라푼젤 맵으로 이동
    {
        //구현이 되지 않았으므로 기능은 없는 상태
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt("ChangeBook") == 1)  //씬을 접속한 이유가 책을 다시 고르기 위해서 일 때
        {
            startpanel.SetActive(false);    //게임시작하기 패널 비활성화
            mappanel.SetActive(true);       //맵 선택 화면 활성화
            PlayerPrefs.SetInt("ChangeBook", 0);
        }
    }
}
