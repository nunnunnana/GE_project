using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipAction : MonoBehaviour
{
    GameObject player;            // 플레이어 캐릭터 설정
    GameObject player_Equip;      // 잡기 설정
    bool isPlayerEnter;           // 트리거 설정
    new AudioSource audio;       

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");           // Player 태그에서 찾기
        player_Equip = GameObject.FindGameObjectWithTag("EquipPoint"); // EquipPoint 태그에서 찾기
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && isPlayerEnter){      // 영역안에 들어와있고 G를 눌렀을 때
            transform.SetParent(player_Equip.transform);        // player_Equip를 부모로 설정
            transform.localPosition = Vector3.zero;             // 위치값은 (0,0,0)
            transform.rotation = new Quaternion(0, 0, 0, 0);    // 회전값도 (0,0,0,0)
            Destroy(gameObject, 2f);                            // 2초뒤에 오브젝트가 사라짐
            isPlayerEnter = false;                              // 트리거 제거
            audio.Play();                                       // 오디오 실행
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player){   // 플레이어가 들어왔을 때
            isPlayerEnter = true;          // 트리거 활성화
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player){  // 플레이어가 나갔을 때
            isPlayerEnter = false;        // 트리거 비활성화
        }
    }
}
