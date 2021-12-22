using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainterBlue : MonoBehaviour, IMaterial //파란물감 재료
{
    public void IncreaseCount(GameObject target)
    {
        int num = PlayerPrefs.GetInt("Blue");
        num++;
        PlayerPrefs.SetInt("Blue", num);
        Destroy(gameObject);
        IncreaseManeger.instance.ChangeCount();
    }
}
