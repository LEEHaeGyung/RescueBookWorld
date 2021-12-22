using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMaterial : MonoBehaviour  //실루엣의 재료 확인 스크립트
{
    int type = 0;   //충돌한 실루엣의 종류
    private void OnTriggerEnter(Collider collider)
    {
        IBookChar bookchar = collider.GetComponent<IBookChar>();

        if (bookchar != null)
        {
            type = bookchar.ShowNeedMaterials();
            PeterPanManager.instance.ShowNeedMaterialCount();
        }

        PeterPanManager.instance.needpanel.gameObject.SetActive(true);      //재료 확인 이미지 활성화
        PeterPanManager.instance.checkChar[type].gameObject.SetActive(true);//완성된 모습 활성화
        PeterPanManager.instance.type = type;
    }

    private void OnTriggerExit(Collider collider)
    {
        //충돌에서 벗어나면 비활성화
        PeterPanManager.instance.needpanel.gameObject.SetActive(false);
        PeterPanManager.instance.checkChar[type].gameObject.SetActive(false);
    }
}
