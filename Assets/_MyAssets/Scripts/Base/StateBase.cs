using UnityEngine;

namespace _MyAssets.Scripts.Base
{
    /// <summary>
    /// 基底ステート
    /// </summary>
    public class StateBase : MonoBehaviour
    {
        /// <summary>
        /// ステート開始時
        /// </summary>
        public virtual void OnStateEnter()
        {
        }

        /// <summary>
        /// ステート滞在時
        /// </summary>
        public virtual void OnStateUpdate()
        {
        }

        /// <summary>
        /// ステート滞在時
        /// </summary>
        public virtual void OnStateFixedUpdate()
        {
        }

        /// <summary>
        /// ステート脱出時
        /// </summary>
        public virtual void OnStateExit()
        {
        }
    }
}