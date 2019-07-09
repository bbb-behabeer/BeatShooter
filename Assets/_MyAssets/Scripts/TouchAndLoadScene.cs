using System;
using _MyAssets.Scripts.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _MyAssets.Scripts
{
    public class TouchAndLoadScene: MonoBehaviour
    {
        [SerializeField] private string _scene;

        public void Update()
        {
            if (PlayerInput.ButtonDown)
            {
                SceneManager.LoadScene(_scene);
            }
        }
    }
}