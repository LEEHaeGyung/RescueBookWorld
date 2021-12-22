using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Monster : MonoBehaviour    //괴물 스크립트
{
    public AudioClip hitplayer;
    private AudioSource playerAudioPlayer;

    public Transform player;
    NavMeshAgent agent;
    void Start()
    {
        playerAudioPlayer = GetComponent<AudioSource>();

        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        agent.destination = player.transform.position;
        agent.speed = 1f;
    }

    void Update()
    {
        agent.destination = player.transform.position;
        agent.transform.eulerAngles = Vector3.zero;
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance >= 1)  //플레이어와의 거리가 1 이상이 되면 다시 추적을 시작
        {
            agent.destination = player.transform.position;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        int num1 = PlayerPrefs.GetInt("Paper");
        int num2 = PlayerPrefs.GetInt("Red");
        int num3 = PlayerPrefs.GetInt("Blue");
        int num4 = PlayerPrefs.GetInt("Yellow");

        //몬스터와 충돌하면 가지고 있는 재료를 잃음
        num1 = num1 - 2;
        num2 = num2 - 2;
        num3 = num3 - 2;
        num4 = num4 - 2;

        //0보다 작은 값이면 그냥 0개로 변경
        if (num1 < 0) num1 = 0;
        if (num2 < 0) num2 = 0;
        if (num3 < 0) num3 = 0;
        if (num4 < 0) num4 = 0;

        PlayerPrefs.SetInt("Paper", num1);
        PlayerPrefs.SetInt("Red", num2);
        PlayerPrefs.SetInt("Blue", num3);
        PlayerPrefs.SetInt("Yellow", num4);

        playerAudioPlayer.PlayOneShot(hitplayer);

        IncreaseManeger.instance.ChangeCount();
    }
}
