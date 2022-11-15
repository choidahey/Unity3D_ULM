using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class LobbyManager : MonoBehaviourPunCallbacks
{

    public Button loginBtn;
    public Text IDText;
    public Text ConnectionStatus;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        loginBtn.interactable = false;
        ConnectionStatus.text = "Connectiong to Master Server...";
    }

    public void Connect()
    {
        if (IDText.text.Equals(""))
        {
            return;
        }
        else
        {
            PhotonNetwork.LocalPlayer.NickName = IDText.text;
            loginBtn.interactable = false;
            if (PhotonNetwork.IsConnected)
            {
                ConnectionStatus.text = "Connectiong to Room";
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                ConnectionStatus.text = "Offline : failed to Connect.\nreconnecetiong...";
                PhotonNetwork.ConnectUsingSettings();
            }
        }
    }

    public override void OnConnectedToMaster()
    {
        loginBtn.interactable = true;
        ConnectionStatus.text = "Online : Connected the Server";
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        loginBtn.interactable = false;
        ConnectionStatus.text = "Offline : failed to Connect.\nreconnecetiong...";
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        ConnectionStatus.text = "No Empty Room. Creating new Room";
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 10 });
    }
    public override void OnJoinedRoom()
    {
        ConnectionStatus.text = "Entering the ULM";
        PhotonNetwork.LoadLevel("MainScene");
    }
}
