using Bundles;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerController
{
    public class PrefabSpawner : MonoBehaviour
    {
        [SerializeField] private float _rayLenght = 30f;
        private BundleWebLoader _bundleLoader;
        private Camera _camera;
        
        private void Start()
        {
            _bundleLoader = FindObjectOfType<BundleWebLoader>();
            _camera = Camera.main;
        }

        private void Update()
        {
            var buttonControl = Mouse.current.leftButton;
            
            if (buttonControl.wasPressedThisFrame)
            {
                var ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());

                if (Physics.Raycast(ray, out var hit, _rayLenght))
                {
                    if(hit.collider.GetComponent<MeshCollider>())
                        StartCoroutine(_bundleLoader.LoadAndCreateBundle(hit.point + Vector3.back * 5));
                }
            }
        }
    }
}