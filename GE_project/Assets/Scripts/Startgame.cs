using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;             

public class Startgame : MonoBehaviour
{
    public string Scene_name;                     // 불러올 Scene 입력받기

    void Update()
    {
        if (Input.GetMouseButtonDown(0))          // 마우스가 (Left)클릭될때
        {
            SceneManager.LoadScene(Scene_name);   // Scene 불러오기
        }

    }
}
