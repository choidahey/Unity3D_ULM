using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public bool isConnect = false;
    public Transform[] spawnPoints;

    int CharIndex;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        // CharacterManager의 변수를 불러오기 위해 선언
        CharacterManager characterManager = GameObject.Find("CharacterManager").GetComponent<CharacterManager>();
        CharIndex = characterManager.selectedCharIndex;

        isConnect = true;

        StartCoroutine(CreatePlayer());
    }

    void Update()
    {
        
    }

    public IEnumerator CreatePlayer()
    {

        string[] players = new string[] {"Boy", "Girl", "Princess"};

        yield return new WaitUntil(() => isConnect);

        spawnPoints = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();

        string pla = players[CharIndex];
        Vector3 pos = spawnPoints[PhotonNetwork.CurrentRoom.PlayerCount].position;
        Quaternion rot = spawnPoints[PhotonNetwork.CurrentRoom.PlayerCount].rotation;

        GameObject playerTemp = PhotonNetwork.Instantiate(pla, pos, rot, 0);
    }
}
