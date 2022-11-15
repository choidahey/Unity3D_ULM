using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Character  // 열거형으로 캐릭터 이름 정의(0부터 자동으로 숫자 매겨짐)
    {
        Boy, Girl, Princess
    }


public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;

    // 캐릭터의 인덱스를 저장할 딕셔너리 선언
    public Dictionary<Character, int> selected = new Dictionary<Character, int>(); 
    
    // 선택된 캐릭터의 인덱스를 저장할 변수
    public int selectedCharIndex; 


    private void Awake()
    {
        if (instance == null) instance = this;  //instance 값이 초기화 되어있는지 체크
        else if (instance != null) return;
        DontDestroyOnLoad(gameObject);  // 씬 전환 후에도 오브젝트 파괴 x
    }

    public Character select_character;  // 선택한 캐릭터 값 저장 (캐릭터 선택하면 다른 씬으로도 전달)

    void Start()
    {
        // 캐릭터마다 인덱스 번호 부여
        selected[Character.Boy] = 0;
        selected[Character.Girl] = 1;
        selected[Character.Princess] = 2;
    }

    void Update()
    {
        // 선택한 값의 인덱스 번호를 변수에 저장
        selectedCharIndex = selected[select_character]; 
    }

}
