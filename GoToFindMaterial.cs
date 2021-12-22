using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToFindMaterial : MonoBehaviour   //재료 획득 맵으로 이동
{
    private void OnCollisionEnter(Collision collision)
    {
        if(PlayerPrefs.GetString("Time")=="Day")
            SceneManager.LoadScene("MaterialForest_Day");       //낮버전
        else
            SceneManager.LoadScene("MaterialForest_Night");     //밤버전
    }
}
