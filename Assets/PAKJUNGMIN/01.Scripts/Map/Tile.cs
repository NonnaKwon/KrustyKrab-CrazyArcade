using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;



namespace pakjungmin
{
    public class Tile : MonoBehaviour
    {
        public enum TileStyle 
        {
            Normal, //�Ϲ� �ٴ�
            Thorny, //���ù�
            Swamp, //������
        }
        bool isWallhere; //�� Ÿ�� ���� ���� ������ ����
        [SerializeField] TileNode tileNode; //Ÿ���� ��ǥ.

        TileStyle tileStyle; //�ٴ��� ����
        
    }
    [Serializable]
    public struct TileNode
    {
        public int posY;
        public int posX;
    }


}

