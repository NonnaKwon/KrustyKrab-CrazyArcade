using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pakjungmin 
{

    public class PlayerBehavior : MonoBehaviour
    {
        PlayerMediator playerMediator;
        Vector2 moveDir;

        private void Awake()
        {
            playerMediator = GetComponent<PlayerMediator>();
            
        }
        private void Update()
        {
            gameObject.transform.Translate(moveDir * playerMediator.playerStats.Speed * Time.deltaTime, Space.World);
        }

        public void Move(Vector3 moveDir)
        {
            PlayerStats stat = playerMediator.playerStats;
            this.moveDir = moveDir;
        }

        /// <summary>
        /// �÷��̾��� ��ǳ�� ��ġ �ൿ
        /// </summary>
        public void Plant()
        {

        }
        /// <summary>
        /// ��Ƽ�� ������ ���
        /// </summary>
        public void Use()
        {

        }
    }
}
