using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace pakjungmin
{
    public class Bomb : MonoBehaviour
    {
        //��ǳ���� ������. �� ��ġ�� �÷��̾��� ���� �ʵ� ���� �ʿ�.

        //��ġ�� ���� Ÿ�� ��ǥ �ʵ� ���� �ʿ�.

        //��ǳ�� ���ĵǱ���� �ð�.
        [SerializeField] float explodeTime;


        /// <summary>
        /// Coroutine : ��ǳ���� ���� ��� �ð� ����.
        /// </summary>
        /// <returns></returns>
        IEnumerator WaitExplode()
        {
            //���� �ð� ��ƾ ���� �ʿ�
            yield return null;
        }

        private void OnEnable()
        {
            //Ȱ��ȭ �� �ڷ�ƾ ���� ���� �ʿ�
        }
        private void OnDisable()
        {
            //���ٱ� ���� ��ƾ ���� �ʿ�.
        }
        void Explode()
        {

        }
    }
}