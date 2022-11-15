// ´ÙÇý ÀÛ¼º Áß

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Change()
    {
        PhotonNetwork.LoadLevel("LobbyScene");
    }
}
