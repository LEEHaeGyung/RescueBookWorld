using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainterYellow : MonoBehaviour, IMaterial   //노란물간 재료
{
    public void IncreaseCount(GameObject target)
    {
        int num = PlayerPrefs.GetInt("Yellow");
        num++;
        PlayerPrefs.SetInt("Yellow", num);
        Destroy(gameObject);
        IncreaseManeger.instance.ChangeCount();
    }
}
