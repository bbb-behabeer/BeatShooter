using System;
using _MyAssets.Scripts.Base;
using _MyAssets.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;

namespace _MyAssets.Scripts.Character.Enemy
{
    /// <summary>
    /// 削除ステート
    /// 自身を削除する
    /// </summary>
    [Serializable]
    public class DestroyState : StateBase
    {
        public override void OnStateEnter()
        {
            Destroy(gameObject);
        }
    }
}