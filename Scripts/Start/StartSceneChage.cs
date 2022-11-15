using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class StartSceneChage : MonoBehaviour
{
    public void Change()
    {
        PhotonNetwork.LoadLevel("SelectCharacter");
    }
}
