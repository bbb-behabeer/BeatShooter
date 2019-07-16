using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    /// <summary>
    /// コントローラーのUI
    /// </summary>
    public class ControllerUi : MonoBehaviour
    {
        [SerializeField] private Sprite _canShotSprite;
        [SerializeField] private Sprite _canLaserSprite;
        private Shooter _shooter;
        
        private SpriteRenderer _renderer;

        private void Start()
        {
            _shooter = GameObject.Find("Shooter").GetComponent<Shooter>();
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            if (_shooter.CanShot())
                _renderer.sprite = _canShotSprite;
            else if (_shooter.CanLaser())
                _renderer.sprite = _canLaserSprite;
            else
                _renderer.sprite = null;
        }
    }
}