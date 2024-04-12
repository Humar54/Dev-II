using System.Collections.Generic;
using UnityEngine;


public class LeanTweenMove : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> _spritList = new List<SpriteRenderer>();
    [SerializeField] private float _moveDelay = 8f;

    private List<Vector3> _startingPos = new List<Vector3>();
    private int _objectIndex;
    private int _listSize;


    private void Start()
    {
        MoveObjectToZero();
        _listSize = _spritList.Count;
    }

    private void MoveObjectToZero()
    {
        LeanTween.move(_spritList[_objectIndex].gameObject, Vector3.zero, _moveDelay).setEaseInOutExpo().setOnComplete(MoveNextObjectToZeroAndFadeOut);
    }

    private void MoveNextObjectToZeroAndFadeOut()
    {
        LeanTween.alpha(_spritList[_objectIndex].gameObject, 0, _moveDelay/2).setEaseOutExpo();
        Destroy(_spritList[_objectIndex], _moveDelay);
        Debug.Log($"ObjectIndex: {_objectIndex} ListSize:{_listSize}");
        if (_objectIndex < _listSize-1)
        {
            _objectIndex++;
            MoveObjectToZero();
        }
    }
}
