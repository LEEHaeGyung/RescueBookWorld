using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tinkerbell : MonoBehaviour, IBookChar  //팅커벨 실루엣
{
    private int needred = 1;      //필요한 빨간 물감
    private int needblue = 3;    //필요한 파란 물감
    private int needyellow = 5;   //필요한 노란 물감
    private int needpaper = 5;   //필요한 종이 수
    public int ShowNeedMaterials()
    {
        PeterPanManager.instance.needpaper= needpaper;
        PeterPanManager.instance.needred = needred;
        PeterPanManager.instance.needyellow = needyellow;
        PeterPanManager.instance.needblue = needblue;
        PeterPanManager.instance.charname = "TinkerBell";
        return 2;
    }
}
