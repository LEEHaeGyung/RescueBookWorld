using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour, IMaterial //종이 재료
{
    public void IncreaseCount(GameObject target)
    {
        int num = PlayerPrefs.GetInt("Paper");
        num++;
        PlayerPrefs.SetInt("Paper", num);
        Destroy(gameObject);
        IncreaseManeger.instance.ChangeCount();
    }
}
