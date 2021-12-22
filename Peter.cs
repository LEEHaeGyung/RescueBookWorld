using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Peter : MonoBehaviour, IBookChar   //피터팬 실루엣
{
    private int needred = 5;      //필요한 빨간 물감
    private int needblue = 10;    //필요한 파란 물감
    private int needyellow = 20;   //필요한 노란 물감
    private int needpaper = 15;   //필요한 종이 수
    public int ShowNeedMaterials()
    {
        PeterPanManager.instance.needpaper = needpaper;
        PeterPanManager.instance.needred = needred;
        PeterPanManager.instance.needyellow = needyellow;
        PeterPanManager.instance.needblue = needblue;
        PeterPanManager.instance.charname = "Peter";
        return 0;
    }
}
