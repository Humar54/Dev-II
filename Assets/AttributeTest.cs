using NaughtyAttributes;
using UnityEngine;

public class AttributeTest : MonoBehaviour
{
    [SerializeField] private bool _canAttack;
    [ShowIf("_canAttack")]
    [SerializeField] private float _attackRange;
    [ShowIf("_canAttack")]
    [SerializeField] private float _attackSpeed;
    [ShowIf("_canAttack")]
    [SerializeField] private float _attackDamage;


}
