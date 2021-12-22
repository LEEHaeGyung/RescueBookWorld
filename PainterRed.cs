using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainterRed : MonoBehaviour, IMaterial  //빨간물감 재료
{
    public void IncreaseCount(GameObject target)
    {
        int num = PlayerPrefs.GetInt("Red");
        num++;
        PlayerPrefs.SetInt("Red", num);
        Destroy(gameObject);
        IncreaseManeger.instance.ChangeCount();
    }
}
