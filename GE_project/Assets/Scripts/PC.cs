using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    public GameManager manager;    // 게임매니저 생성
    public float speed = 10.0f;    // 캐릭터 이동속도 
    Rigidbody rigdbody;            // 리지드바디 선언
    Animator animator;             // 애니메이터 선언
    new AudioSource audio;         // 오디오 선언
    GameObject penguin;            // 펭귄 생성

    Vector3 move;
    float h_move;                  // Horizontal_move
    float v_move;                  // Vertical_move
    float rotation_speed = 10.0f;

    void Awake ()
    {
        rigdbody = GetComponent<Rigidbody>();                // 리지드바디 가져오기
        animator = GetComponent<Animator>();                 // 애니메이터 가져오기
        audio = GetComponent<AudioSource>();                 // 오디오 가져오기
        penguin = GameObject.FindGameObjectWithTag("npc");   // npc 태그에서 찾기
    }
   
    void Update ()                                // 키 입력
    {
        h_move = Input.GetAxisRaw ("Horizontal"); // 캐릭터 이동 함수 호출 
        v_move = Input.GetAxisRaw ("Vertical");   // 캐릭터 이동 함수 호출   
        
        AnimationUpdate();           // AnimationUpdate 함수 실행
        Sound();                     // Sound 함수 실행
        manager.Action();            // Actioin 함수 실행
    }
    void OnTriggerEnter(Collider other)    // 영역 안으로 들어왔을 때
    {
        if (other.gameObject == penguin){  // other이 펭귄이면
            manager.Idle();                // Idle 함수 실행
        }
    }
    void OnTriggerExit(Collider other)     // 영역 밖으로 나갔을 때
    {
        if (other.gameObject == penguin){  // other이 펭귄이면
            manager.Exit();                // Exit 함수 실행
        }
    }
    void FixedUpdate()      // 물리적 처리
    { 
        Run();              // Run 함수 실행
        Turn();             // Turn 함수 실행
    }
    void Run()                                             // 달리기 함수
    {
        move.Set(h_move, 0, v_move);                       // 이동 벡터값
        move = move.normalized * speed * Time.deltaTime;   // normalized를 통해 대각선 이동

        rigdbody.MovePosition(transform.position + move);  // MovePosition 함수 적용
        
    }
    void Turn()                                                   // 캐릭터 회전 함수
    {
        if(h_move == 0 && v_move == 0){                           // 컨트롤값이 없을때 반환
            return;
        }
        Quaternion cm_rotation = Quaternion.LookRotation(move);   // 벡터 방향으로 회전

        // Quaternion.Slerp을 사용해 부드러운 회전가능
        rigdbody.rotation = Quaternion.Slerp(rigdbody.rotation, cm_rotation, rotation_speed * Time.deltaTime); 
    }
    void AnimationUpdate()                    // 애니메이션 함수
    {
        
        if (Input.GetKeyDown(KeyCode.G)){
                animator.SetBool("isPick", true);  // isPick 실행   
        }
        else if (h_move == 0 && v_move == 0){  // 움직임이 없을때          
            animator.SetBool("isRun", false);  // isRun 실행하지 않음
        } else {
            animator.SetBool("isRun", true);   // isRun 실행
            animator.SetBool("isPick", false); // isPick 실행하지 않음
        }
        

    }
    void Sound()                             // Sound() 함수
    {
        if (!audio.isPlaying){                // audio가 실행중이지 않을때
            if (h_move != 0 || v_move != 0)   // 움직임이 있을때
                audio.Play();                 // audio 실행
        }
        else if (h_move == 0 && v_move == 0){ // 움직임이 없을때
            audio.Stop();                     // audio 중지
        }
    }
}
