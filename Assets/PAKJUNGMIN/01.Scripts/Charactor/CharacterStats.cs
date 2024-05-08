using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pakjungmin
{
    // Scriptable Object : ��ũ���ͺ� ������Ʈ�� ĳ���ͺ� ���� ����
    [CreateAssetMenu(fileName = "CharactorStats", menuName = "PAKJUNGMIN_ScriptableObject/New_CharactorStats")]
    public class CharacterStats : ScriptableObject
    {

        [Header("ĳ������ �̵��ӵ�")]
        [SerializeField] float speed;
        [Header("ĳ������ �ʱ� ���ٱ� �Ŀ�")]
        [SerializeField] float powerValue;
        [Header("ĳ������ �ʱ� ��ǳ�� ����")]
        [SerializeField] float bombValue;


        public float Speed { get { return speed; } }
        public float Power { get { return powerValue; } }
        public float Bomb { get { return bombValue; } }
    }


}
