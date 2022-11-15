using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInMap : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MainFall"))   // 메인 맵에서 떨어졌을 때 정문으로 리스폰
        {
            transform.position = new Vector3(0, 2, 0);
        }
    }
    private void OnTriggerStay(Collider other)   // 페이드 인 아웃 부분 캔버스 트리거
    {
        switch (other.gameObject.tag)
        {
            // position in
            case "LibraryPosition":   // 들어가는 콜라이더 박스 태그 (position out)
                {
                    Invoke("EnterFade_Lib", 0.7f);
                    break;
                }
            case "GymPosition":
                {
                    Invoke("EnterFade_Gym", 0.7f);
                    break;
                }
            case "LecturePosition":
                {
                    Invoke("EnterFade_Lect", 0.7f);
                    break;
                }
            case "HeadQuaterPosition":
                {
                    Invoke("EnterFade_Head", 0.7f);
                    break;
                }
            // position out 게임에서 나오는거 이어서하기
            case "ExitInterview":
                {
                    Invoke("ExitFade_Head", 0.7f);
                    break;
                }
            case "ExitFallGame":
                {
                    Invoke("ExitFade_Lect", 0.7f);
                    break;
                }
            case "ExitMazeGame":
                {
                    Invoke("ExitFade_Lib", 0.7f);
                    break;
                }
            case "ExitHuddleGame":
                {
                    Invoke("ExitFade_Gym", 0.7f);
                    break;
                }
        }
    }

    // position in
    void EnterFade_Lib()
    {
        transform.position = new Vector3(-1.04f, -663.1f, -44.5f); // 도서관의 미로 맵으로 이동
    }
    void ExitFade_Lib()
    {
        transform.position = new Vector3(-200, 1.83f, -254);  // 도서관의 문 앞으로 이동
    }

    void EnterFade_Gym()
    {
        transform.position = new Vector3(-7.17f, -1355.22f, -87.6f);  // 체육관의 허들 맵으로 이동
    }
    void ExitFade_Gym()
    {
        transform.position = new Vector3(-105, 0.88f, -74.84f);;  // 체육관의 문 앞 이동
        //transform.localScale = gymPos.position += new Vector3(0, 0, -10);
    }

    void EnterFade_Lect()
    {
        transform.position = new Vector3(-500.3f, -951, 904);  // 종합강의동의 바닥 떨어지는 게임맵으로 이동
    }
    void ExitFade_Lect()
    {
        transform.position = new Vector3(-400.5f, 14.63f, -78); // 종합강의동의 문 앞으로 이동
    }

    void EnterFade_Head()
    {
        transform.position = new Vector3(1.7f, -488.5f, -6.69f);  // 본부 안의 면접장으로 이동
    }
    void ExitFade_Head()
    {
        transform.position = new Vector3(-570, 59.7f, 126.5f);  // 본부 엘리베이터 앞으로 이동
    }
}
