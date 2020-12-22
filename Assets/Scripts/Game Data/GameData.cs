using UnityEngine;

namespace GameMainData
{
    [CreateAssetMenu(fileName = "New game data", menuName = "Game data")]
    public class GameData : ScriptableObject
    {
        [SerializeField] private int _observableTime;

        public int ObservableTime => _observableTime;
    }
}