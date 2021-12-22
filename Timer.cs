using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour  //타이머 스크립트
{
    public AudioClip timersound;
    private AudioSource playerAudioPlayer;

    public Text timetext;
    public Text redText;
    Text nowtext;
    bool isPaused;
    int timeremain;
    float starttime = 30;

    string bookname;

    private void Start()
    {
        playerAudioPlayer = GetComponent<AudioSource>();

        starttime = starttime + Time.time;
        bookname = PlayerPrefs.GetString("Book");
        nowtext = timetext;
    }
    void Update()
    {   //타이머가 종료되지 않았고 게임이 시작됐다면 타이머 진행
        if (!isPaused) { CheckTimer(); }
        if (timeremain < 10)
        {
            if (!playerAudioPlayer.isPlaying)
            {
                playerAudioPlayer.PlayOneShot(timersound);
            }
        }
    }
    void CheckTimer()
    {   //시작 시간에서 Time.time을 빼서 남은 시간 계산
        timeremain = (int)(starttime - Time.time);
        if (timeremain == 10)   //10초 미만으로 남으면 색상 변경
        {
            timetext.gameObject.SetActive(false);
            redText.gameObject.SetActive(true);
            nowtext = redText;
        }
        nowtext.text = timeremain.ToString();

        if (timeremain <= 0)
        {   //남은 시간이 0이되면 isPaused를 변경하고 개수 입력 패널을 활성화함
            timeremain = 0;
            isPaused = true;

            if (PlayerPrefs.GetString("Time") == "Day")
                PlayerPrefs.SetString("Time", "Night");
            else
                PlayerPrefs.SetString("Time", "Day");

            SceneManager.LoadScene(bookname);
        }
    }
}
