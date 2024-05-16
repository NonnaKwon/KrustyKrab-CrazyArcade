using pakjungmin;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 아이템 UltraBomb
/// 플레이어의 파워가 최대치까지 상승한다
/// </summary>
public class UltraBomb : Item,IAcquirable
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckWater(collision.gameObject))
        {
            if (WaterProof <= 0)
            {
                Destroy(gameObject);
                return;
            }
            WaterProof--;
        }

        if (!CheckPlayer(collision.gameObject))
            return;                                                         // 레이어마스크 체크

        Player = collision.gameObject.GetComponent<PlayerMediator>();

        //if (Player.characterStats.MaxPower == Player.playerStats.Power)     // 스크립터블오브젝트에서 설정된 물풍선 최대갯수랑 현재 플레이어의 물풍선 갯수가 같으면
        //    return;                                                         // 리턴

        Player.playerStats.OwnPower = Player.characterStats.maxPower; //박정민 추가 : 필드명 재조정으로 인한 필드명 변경

        Destroy(gameObject);
    }
}
