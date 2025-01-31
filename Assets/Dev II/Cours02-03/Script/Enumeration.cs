
using UnityEngine;

public class Enumeration : MonoBehaviour
{
    [SerializeField] private Direction _currentDirection;
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _speed = 2f;

    enum Direction
    {
        Top,
        Down,
        Right,
        Left,
        Front,
        Back
    }


 

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        switch (_currentDirection)
        {
            case Direction.Top:
                _rigidBody.velocity = new Vector3(0, 1, 0) * _speed;
                break;
            case Direction.Down:
                _rigidBody.velocity = new Vector3(0, -1, 0) * _speed;
                break;
            case Direction.Right:
                _rigidBody.velocity = new Vector3(1, 0, 0) * _speed;
                break;
            case Direction.Left:
                _rigidBody.velocity = new Vector3(-1, 0, 0) * _speed;
                break;
            case Direction.Front:
                _rigidBody.velocity = new Vector3(0, 0, 1) * _speed;
                break;
            case Direction.Back:
                _rigidBody.velocity = new Vector3(0, 0, -1) * _speed;
                break;
            default:
                break;
        }
    }

}

