using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text ui_text;                 // UI 텍스트
    public GameObject ui_panel;          // UI 패널
    public GameObject ui_panel2;         // UI 패널2
    public bool isAction;                // On/Off 기능 변수 추가
    new AudioSource audio;               // 오디오 추가 

    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Action()
    {
        if (Input.GetKeyDown(KeyCode.F)){  
            if (isAction){                     // 액션이 실행중이라면
                isAction = false;              // false로 변경
            }
            else{                                                            // 실행중이지 않다면
                isAction = true;                                             // 액션을 실행함
                ui_text.text = "이곳에 섬 이름은 '비 내리는 호남'섬 이야!";  // 텍스트 출력
                ui_panel2.SetActive(false);                                  // 상호작용 키 비활성화
                audio.Play();                                                // 목소리 재생
            }
        }
        ui_panel.SetActive(isAction);      // 패널 활성화
        
    }
    public void Idle()
    {
        ui_panel2.SetActive(true);         // 상호작용 키 활성화         
    }
    public void Exit()
    {
        ui_panel2.SetActive(false);        // 상호작용 키 비활성화
    }



}
