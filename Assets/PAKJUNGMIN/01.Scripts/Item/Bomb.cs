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
            yield return null;
        }

        private void OnEnable()
        {

        }
        /// <summary>
        /// ��ǳ���� ����.
        /// </summary>
        void Explode()
        {

        }
    }
}