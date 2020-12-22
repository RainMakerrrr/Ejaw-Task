using System;
using GameMainData;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class GeometryObjectModel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int _clickCount;
    [SerializeField] private Color _color;

    [SerializeField] private GeometryObjectData _objectData;
    
    private TextAsset _textAsset;
    private GameData _gameData;
    private MeshRenderer _meshRenderer;
    
    private void Start()
    {
        LoadGameData();
        SaveColor();
        ParseModelName();
        ChangeColorWithDelay();
    }

    private void LoadGameData() => _gameData = Resources.Load<GameData>("Game Data");

    private void SaveColor()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _color = _meshRenderer.material.color;
    }

    private void ParseModelName()
    {
        _textAsset = Resources.Load<TextAsset>("GeometryModelName");

        var modelName = JsonUtility.FromJson<ModelName>(_textAsset.text);
        gameObject.name = modelName.Name;
    }
    
    private void ChangeColorWithDelay()
    {
        Observable
            .Timer(TimeSpan.FromSeconds(_gameData.ObservableTime))
            .Repeat()
            .Subscribe(_ => _meshRenderer.material.color = Random.ColorHSV());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_clickCount < _objectData.MaxClicksCount)
        {
            _clickCount++;
            _color = _objectData.Colors[_clickCount];

           _meshRenderer.material.color = _color;
        }
    }
}

public class ModelName
{
    public string Name;
}
