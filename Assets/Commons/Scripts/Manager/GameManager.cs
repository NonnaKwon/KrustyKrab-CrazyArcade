using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private PlayerEntity player; //현재 Local 플레이어. (나)
    public PlayerEntity Player { get { return player; } set { player = value; } }
    public List<PlayerEntity> GamePlayers { get; set; } //게임에 참여하는 전체 게임 플레이어 정보
    
    public void Test()
    {
        Debug.Log(GetInstanceID());
    }

    private void OnApplicationQuit()
    {
        Debug.Log("애플리케이션 종료됨");
        Logout();
    }

    public void Logout()
    {
        UserDataManager.LocalUserSetConnect(false);
    }
}
