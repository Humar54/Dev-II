using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private ControlDoor _controlDoor;
    [SerializeField] private float _speed = 5f;
    private Vector3 _direction;
    // Start is called before the first frame update
    void Start()
    {
        _controlDoor._toggleDoor += ToggleDoor;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += _direction * _speed * Time.deltaTime;

        if(transform.localScale.y<0.1f)
        {
            _direction = Vector3.zero;
            transform.localScale = new Vector3(1f, 0.1f, 1f);
        }
        else if(transform.localScale.y>1)
        {
            _direction = Vector3.zero;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void ToggleDoor(bool toggle)
    {
        if (toggle)
        {
            _direction = Vector3.up;
        }
        else
        {
            _direction = -Vector3.up;
        }
    }
}
