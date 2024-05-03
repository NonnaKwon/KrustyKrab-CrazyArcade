using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Scriptable Object : ��ũ���ͺ� ������Ʈ�� ĳ���ͺ� ���� ����

[CreateAssetMenu(fileName ="ScriptableObject",menuName ="NewData/NewCharacter")]
public class CharacterStats : ScriptableObject
{

    [Header("ĳ������ �̵��ӵ�")]
    float speed;
    [Header("ĳ������ ��ǳ�� �Ŀ�")]
    float powerValue;
    [Header("ĳ������ �ʱ� ��ǳ�� ����")]
    float bombValue;


    public float Speed { get { return speed; } }
    public float Power{ get { return powerValue; } }
    public float Bomb { get { return bombValue; } }




}

