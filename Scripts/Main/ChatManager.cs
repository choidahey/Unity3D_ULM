using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class ChatManager : MonoBehaviourPunCallbacks
{
    //public Text chatList;
    public Button sendBtn;
    public Text chatLog;
    //public Text chattingList;
    public InputField input;
    string chatters;
    ScrollRect scroll_rect = null;

    void Start()
    {
        PhotonNetwork.IsMessageQueueRunning = true;
        scroll_rect = GameObject.FindObjectOfType<ScrollRect>();
        input.characterLimit = 30;
    }

    public void SendButtonOnClicked()
    {
        if (input.text.Equals("")) { Debug.Log("Empty"); return; }
        string msg = string.Format("[{0}] {1}", PhotonNetwork.LocalPlayer.NickName, input.text);
        photonView.RPC("ReceiveMsg", RpcTarget.OthersBuffered, msg);
        ReceiveMsg(msg);
        input.ActivateInputField();
        input.text = "";
    }

    void Update()
    {
        chatterUpdate();
        if (Input.GetKeyDown(KeyCode.Return) && !input.isFocused) SendButtonOnClicked();
    }

    void chatterUpdate()
    {
        chatters = "Player List\n";
        foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerList)
        {
            chatters += p.NickName + "\n";
        }
    }

    [PunRPC]

    public void ReceiveMsg(string msg)
    {
        chatLog.text += "\n" + msg;
        scroll_rect.verticalNormalizedPosition = 0.0f;
    }

}