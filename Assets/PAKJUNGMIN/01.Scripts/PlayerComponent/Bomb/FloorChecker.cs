using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pakjungmin;

namespace pakjungmin
{
    /// <summary>
    /// Class : �÷��̾ ���� �� �ִ� ���ǰ� ��ź ��ġ ��ġ ���� ����Ѵ�.
    /// </summary>
    public class FloorChecker : MonoBehaviour
    {
        public Tile nowTile; //���� �÷��̾ �� �ִ� Ÿ�� == ����Ÿ�� ����Ʈ �� ���� ����� �Ÿ��� Ÿ��.
        List<Tile> touchedTiles = new List<Tile>(); // ���� Ÿ�� ����Ʈ
        public void OnTriggerEnter2D(Collider2D collision)
        {
            AddList(collision);
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            AddList(collision);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            RemoveList(collision);
        }
        void AddList(Collider2D collision)
        {
            //������ Ÿ���� ����Ÿ�� ����Ʈ�� �߰�
        }
        void RemoveList(Collider2D collision)
        {
            //��� Ÿ���� ����Ÿ�� ����Ʈ���� ����.
        }
        //Method : �÷��̾��� ��ġ�� ����Ʈ �� Ÿ���� �������� �Ÿ��� ���� ����Ͽ�, ���� ����� Ÿ���� ���� Ÿ�Ϸ� ����Ѵ�.
        void LocatePlayer()
        {
            //�÷��̾��� ��ġ�� ����Ʈ �� Ÿ���� ������ ����Ͽ�, ���� ����� Ÿ���� ���� Ÿ�Ϸ� ����ϴ� ����.
        }

    }
}
