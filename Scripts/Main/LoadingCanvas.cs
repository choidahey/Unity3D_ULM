using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCanvas : MonoBehaviour
{

    void Start()
    {
        Invoke("Wait", 4.0f);
    }

    void Wait()
    {
        gameObject.SetActive(false);
    }
}