// 다혜 작성 중

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject player; // 바라볼 플레이어 오브젝트
    public float xmove = 0;  // X축 누적 이동량
    public float ymove = 0;  // Y축 누적 이동량
    public float distance = 10;  // 플레이어와 카메라 사이 거리
    private float wheelspeed = 10.0f;  // 줌인, 줌아웃 할 때의 스피드


    void Update()
    {
        CameraMove();

    }

    void CameraMove()
    {
        if (Input.GetMouseButton(1))  //  마우스 우클릭 중에만 카메라 무빙 적용
        {
            xmove += Input.GetAxis("Mouse X"); // 마우스 좌우 이동량을 xmove 에 누적
            ymove -= Input.GetAxis("Mouse Y"); // 마우스 상하 이동량을 ymove 에 누적
        }
        transform.rotation = Quaternion.Euler(ymove, xmove, 0); // 이동량에 따라 카메라의 바라보는 방향을 조정
        Vector3 reverseDistance = new Vector3(0.0f, -2.0f, distance); // 카메라가 바라보는 앞방향은 Z 축. 이동량에 따른 Z 축방향의 벡터 구함

        distance -= Input.GetAxis("Mouse ScrollWheel") * wheelspeed;  // 스크롤 사용해서 카메라 줌인, 줌아웃 가능
        if (distance < 1.0f) distance = 1.0f;
        if (distance > 10.0f) distance = 10.0f;

        transform.position = player.transform.position - transform.rotation * reverseDistance; // 플레이어의 위치에서 카메라가 바라보는 방향에 벡터값을 적용한 상대 좌표를 차감
    }
}