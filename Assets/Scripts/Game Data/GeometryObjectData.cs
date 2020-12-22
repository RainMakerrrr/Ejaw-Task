using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameMainData
{
    [CreateAssetMenu(fileName = "New geometry object data", menuName = "Geometry Object Data")]
    public class GeometryObjectData : ScriptableObject
    {
        [SerializeField] private int _minClicksCount;
        [SerializeField] private int _maxClicksCount;

        [SerializeField] private List<Color> _setupColors = new List<Color>();
        
        public Dictionary<int, Color> Colors { get; } = new Dictionary<int, Color>();

        public int MinClicksCount => _minClicksCount;
        public int MaxClicksCount => _maxClicksCount;


        private void OnEnable()
        {
            if (Colors.Count != 0 && _setupColors.Count != 0) return;
            
            for (int i = 0; i < _maxClicksCount; i++)
            {
                _setupColors.Add(Random.ColorHSV());
                Colors.Add(i, _setupColors[i]);
            }

        }

        private void OnDisable()
        {
            _setupColors.Clear();
            Colors.Clear();
        }
    }
    
}