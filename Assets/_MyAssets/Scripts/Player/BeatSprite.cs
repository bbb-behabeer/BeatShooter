using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace _MyAssets.Scripts.Player
{
    /// <summary>
    /// スプライトの管理
    /// </summary>
    public class BeatSprite : MonoBehaviour
    {
        [SerializeField] private GameObject _canShotSprite;
        [SerializeField] private GameObject _canAimSprite;
        [SerializeField] private GameObject _defaultSprite;
        [SerializeField] private GameObject _hitStopSprite;
        
        private Shooter _shooter;
        
        private SpriteRenderer _renderer;

        public bool CanShot => _canShotSprite != null;
        public bool CanAim => _canAimSprite != null;

        private bool _hitStop = false;

        protected void Start()
        {
            _shooter = GameObject.Find("Shooter").GetComponent<Shooter>();
        }

        protected void Update()
        {
            InitSprite();

            if (_hitStop && _hitStopSprite != null)
            {
                _hitStopSprite.SetActive(true);
                return;
            }

            UpdateSprite();

        }

        protected void HitStopSprite()
        {
            _hitStop = true;
            
            InitSprite();
            if (_hitStopSprite != null)
                _hitStopSprite.SetActive(true);
        }

        protected void InitSprite()
        {
            if (_canShotSprite != null)
                _canShotSprite.SetActive(false);
            if (_canAimSprite != null)
                _canAimSprite.SetActive(false);
            if (_defaultSprite != null)
                _defaultSprite.SetActive(false); 
            if (_hitStopSprite != null)
                _hitStopSprite.SetActive(false);
        }

        protected void UpdateSprite()
        {
            if (_shooter.CanShot() && _canShotSprite != null)
            {
                _canShotSprite.SetActive(true);;
            }
            else if (_shooter.CanAim() && _canAimSprite != null)
            {
                _canAimSprite.SetActive(true);
            }
            else if (_defaultSprite != null)
            {
                _defaultSprite.SetActive(true);
            }
        }
    }
}