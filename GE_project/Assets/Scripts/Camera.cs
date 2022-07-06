using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;             // 타겟의 위치
    public float dist = 10.0f;           // 카메라의 거리
    public float height = 5.0f;          // 카메라의 높이
    public float smoothRotate = 5.0f;    // 부드러운 회전
    private Transform cm;                // 카메라 변수생성

    void Start()
    {
        cm = GetComponent<Transform>();
    }

    void Update()
    {
        // Mathf.LerpAngle를 통해 부드럽게 회전하기
        float currYAngle = Mathf.LerpAngle(transform.eulerAngles.y, target.eulerAngles.y, smoothRotate * Time.deltaTime);
        // 오일러를 쿼터니언화
        Quaternion rot = Quaternion.Euler(0, currYAngle, 0);
        // 카메라 위치를 타켓 회전각도 만큼 회전 후
        cm.position = target.position - (rot * Vector3.forward * dist) + (Vector3.up * height);
        cm.LookAt(target);
    }
}
