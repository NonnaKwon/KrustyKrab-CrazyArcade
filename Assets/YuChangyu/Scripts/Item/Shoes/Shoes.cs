using pakjungmin;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoes : Item, IAcquirable
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckWater(collision.gameObject))
        {
            if (WaterProof <= 0)
            {
                //권새롬 추가 --> 아이템 삭제는 마스터 클라이언트만. (룸오브젝트이기 때문)
                if (PhotonNetwork.IsMasterClient)
                    PhotonNetwork.Destroy(gameObject);
                return;
            }
            WaterProof--;
        }

        if (!CheckPlayer(collision.gameObject))
            return;

        Player = Player = collision.gameObject.GetComponent<PlayerMediator>();

        // 플레이어에게 물풍선을 발로 미는 기능 활성화 시키기

        Player.playerInventory.Inven.Add(ItemManager.ItemData.itemDir["Shoes"]);
        gameObject.SetActive(false);
    }
}
