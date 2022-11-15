using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InputDetec : MonoBehaviour
{

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        InputClick();  
    }
    public void InputClick()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        void OnMouseOver()
        {
            if (collision.collider.gameObject.CompareTag("InputField"))
            {
                Debug.Log("채팅창 위에 마우스 올라감");
            }
        }
    }
}
