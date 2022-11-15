// 다혜 작성 중

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SelectCharacter : MonoBehaviour
{
    public Character character;
    Animator anim;
    public SelectCharacter[] chars;

    void Start()
    {
        anim = GetComponent<Animator>();

        if (CharacterManager.instance.select_character == character) { OnSelect(); }  //선택 초기화
        else { OnDeSelect(); }
    }

    public void OnMouseUpAsButton()  //GUI Element or Collider 위에서 마우스 눌렀다가 놓을 때만 호출됨
    {
        CharacterManager.instance.select_character = character;  // CharacterManager에 있는 select_character를 character로 초기화
        OnSelect();

        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] != this) { chars[i].OnDeSelect(); }  //선택한 캐릭터 아니면 false 처리
        }
    }

    void OnSelect()
    {

        anim.SetBool("boyIsDance", true);
        anim.SetBool("girlIsDance", true);
        anim.SetBool("princessIsDance", true);  //애니메이션 전환 파라미터

    }
    void OnDeSelect()
    {
        anim.SetBool("boyIsDance", false);
        anim.SetBool("girlIsDance", false);
        anim.SetBool("princessIsDance", false);
    }
}
