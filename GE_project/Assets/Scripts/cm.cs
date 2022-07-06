using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cm : MonoBehaviour
{
    public GameObject PC;        // 오브젝트 설정
    public float setX = 0.0f;      // X 값 설정 
    public float setY = 2.0f;      // Y 값 설정
    public float setZ = -2.0f;     // Z 값 설정

    Vector3 cm_position;

    void Update()
    {
        cm_position.x = PC.transform.position.x + setX;     // 오브젝트 x값 + setX
        cm_position.y = PC.transform.position.y + setY;     // 오브젝트 y값 + setY
        cm_position.z = PC.transform.position.z + setZ;     // 오브젝트 z값 + setZ
        transform.position = cm_position;
    }
}
