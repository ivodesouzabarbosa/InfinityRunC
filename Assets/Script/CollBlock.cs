﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollBlock : MonoBehaviour
{
    // Start is called before the first frame update
    MovePerson _movePerson;
    Transform _transform;
    bool passSet;
    void Start()
    {
        _movePerson = Camera.main.GetComponent<GameControl>()._movePerson;
        _transform = GetComponent<Transform>();
        Physics.IgnoreLayerCollision(9, 10, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (_movePerson.enabled && _movePerson._rig.velocity.x > 0)
        {
            _transform.position = new Vector2(_movePerson.transform.position.x-4, _transform.position.y);
        }
    }
   
}
