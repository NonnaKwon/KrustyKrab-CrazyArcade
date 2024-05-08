using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;


namespace pakjungmin
{
    /// <summary>
    /// Class : �÷��̾��� ��� 
    /// </summary>
    public class PlayerMediator : MonoBehaviour
    {
        public PlayerBehavior playerBehavior; //�÷��̾��� �ൿ.
        public PlayerInputHandler playerInputHandler; //ĳ���� ��ǲ �ý��� 
        public CharacterStats characterStats; // ĳ���ͺ� ���� ������ ��ũ���ͺ� ������Ʈ
        public PlayerStats playerStats; //�÷��̾��� ���� ����

        public void InputMove(Vector3 moveDir)
        {
            playerBehavior.Move(moveDir);
        }
        public void InputPlant() { playerBehavior.Plant(); }
        public void InputUse() { playerBehavior.Use(); }
    }
}
