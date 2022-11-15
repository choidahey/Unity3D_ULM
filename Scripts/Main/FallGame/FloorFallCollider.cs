using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFallCollider : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        // CompareTag()를 사용함으로써 최적화
        if (collision.collider.gameObject.CompareTag("FallFloor"))  // 태그가 FallFloor인 오브젝트와 충돌할 때 작동, 밟으면 사라지는 땅
        {
            Debug.Log("블록에 닿음");
            Destroy(collision.gameObject, 1f);  // 1초 뒤에 블록 없애기
        }

        if (collision.collider.gameObject.CompareTag("Ground"))  // 밟아도 사라지지 않는 안전한 땅
        {
            Debug.Log("Ground에 닿음");
        }

        if (collision.collider.gameObject.CompareTag("Frame"))
        {
            transform.position = new Vector3(-500.3f, -951.07f, 904.94f);  // 떨어지면 맵 입장 위치로 돌아가기
        }
    }
}
