using Firebase.Database;
using Firebase.Extensions;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static Define;
using Hashtable = ExitGames.Client.Photon.Hashtable;


public class RoomUserController : MonoBehaviourPunCallbacks
{
    [SerializeField] List<Sprite> sprites;

    private UI_UserToken[] userTokens;
    private List<PlayerEntity> players;
    private int nowPlayer;
    public List<PlayerEntity> Players { get { return players; } }

    private void Awake()
    {
        players = new List<PlayerEntity>();
        for (int i = 0; i < 8; i++)
            players.Add(null);
    }

    private void Start()
    {
        Debug.Log("들어왔을때 플레이어 수 : " + LobbyManager.NowRoom.NowPlayer);
        userTokens = GetComponentsInChildren<UI_UserToken>();
        int maxPlayer = LobbyManager.NowRoom.MaxPlayer;
        for (int i=0;i<userTokens.Length;i++)
        {
            if (i < maxPlayer)
                userTokens[i].SetVisit(true);
            else
                userTokens[i].SetVisit(false);
        }
        InitRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        newPlayer.SetCustomProperties(new Hashtable() { { "Character", 0 } });
        newPlayer.SetCustomProperties(new Hashtable() { { "Ready", false } });
        AddPlayer(newPlayer,LobbyManager.NowRoom.NowPlayer++);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        //초기화 시키기
        RemovePlayer(otherPlayer);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        userTokens[0].SwitchReady(false);
    }

    private void InitRoom()
    {
        for (int i=0;i< PhotonNetwork.PlayerList.Length;i++)
        {
            AddPlayer(PhotonNetwork.PlayerList[i],i);
        }
    } 

    private void UpdatePlayer()
    {
        int maxPlayer = LobbyManager.NowRoom.MaxPlayer;
        for (int i = 0; i < maxPlayer; i++)
        {
            if (players[i] != null)
                userTokens[i].SetPlayer(players[i], sprites[(int)players[i].Character]);
            else
                userTokens[i].OnPlayer(false);
        }
        userTokens[0].SwitchReady(false); //방장은 레디버튼 비활성화
    }

    private void AddPlayer(Player player,int index)
    {
        FirebaseManager.DB
                .GetReference("User")
                .Child(UserDataManager.ToKey(player.NickName))
                .GetValueAsync()
                .ContinueWithOnMainThread(task =>
                {
                    if (task.IsCanceled)
                    {
                        Debug.Log("GetUserData : IsCanceled");
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        Debug.Log("GetUserData : IsFaulted");
                        return;
                    }
                    //플레이어 정보 불러오기
                    DataSnapshot snapshot = task.Result;
                    UserEntity user = JsonUtility.FromJson<UserEntity>(snapshot.GetRawJsonValue());

                    //캐릭터선택 정보 불러오기
                    Hashtable ht = player.CustomProperties;
                    PlayerEntity entity = new PlayerEntity(user, (Characters)(int)ht["Character"], (bool)ht["Ready"]);
                    players[index] = entity;
                    Debug.Log("index " +index + " : "+players.Count);

                    //플레이어 정보를 UI에 저장
                    userTokens[index].SetPlayer(entity, sprites[(int)entity.Character]);
                });
    }

    private void RemovePlayer(Player player)
    {
        int nowCount = LobbyManager.NowRoom.NowPlayer--;
        Debug.Log(nowCount);
        for(int i=0;i< nowCount; i++)
        {
            if (player.NickName.Equals(players[i].User.key))
            {
                Debug.Log(i);
                players[i] = null;
                for(int j=i;j< nowCount; j++)
                {
                    players[j] = players[j + 1];
                }
                break;
            }
        }
        UpdatePlayer();
    }

    public bool IsStart()
    {
        if (players.Count == 1)
            return false;
        foreach(PlayerEntity player in players)
        {
            if (player.IsReady == false)
                return false;
        }
        return true;
    }

    public void CharacterChange(Characters character)
    {
        PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable() { { "Character", (int)character } });

        string key = Manager.Game.Player.User.key;
        photonView.RPC("UpdateCharacterChange", RpcTarget.All, key, character);
    }

    public void ReadyChange(bool isReady)
    {
        PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable() { { "Ready", isReady } });

        string key = Manager.Game.Player.User.key;
        photonView.RPC("UpdateReadyChange", RpcTarget.All, key, isReady);
    }

    //마스터 바뀌면 준비 꺼져야함.
    [PunRPC] 
    public void UpdateCharacterChange(string key,Characters character)
    {
        foreach (PlayerEntity player in players)
        {
            if (player != null && player.Key.Equals(key))
            {
                player.Character = character;
            }
        }
        UpdatePlayer();
    }

    [PunRPC]
    public void UpdateReadyChange(string key, bool isReady)
    {
        foreach (PlayerEntity player in players)
        {
            if (player != null && player.Key.Equals(key))
            {
                player.IsReady = isReady;
            }
        }
        UpdatePlayer();
    }


}
