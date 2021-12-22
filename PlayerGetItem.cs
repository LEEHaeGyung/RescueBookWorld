using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetItem : MonoBehaviour  //플레이어가 아이템 획득할 때 스크립트
{
    public AudioClip getitem;
    private AudioSource playerAudioPlayer;

    private void Start()
    {
        playerAudioPlayer = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        IMaterial imate = collider.GetComponent<IMaterial>();

        if (imate != null)
        {
            imate.IncreaseCount(gameObject);
            playerAudioPlayer.PlayOneShot(getitem);
        }
    }
}
