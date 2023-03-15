using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Characters", menuName ="ScriptableObjects/Character", order =1)]
public class ScriptableCharacter :ScriptableObject
{
    public Sprite _sprite;
    public int _HitPoint;
    public int _damage;

    public Vector3 _position;
}
