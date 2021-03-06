﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Class for input handling.
/// </summary>
namespace General
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] bool _showCursor;

        public event Action<float> OnVerticalAxisChanged = delegate { };
        public event Action<float> OnHorizontalAxisChanged = delegate { };
        public event Action OnSteadyAxis = delegate { };

        public event Action<Vector2> OnMouseMoved = delegate { };

        public event Action OnClick = delegate { };

        public event Action<int> On1Pressed = delegate { };
        public event Action<int> On2Pressed = delegate { };
        public event Action<int> On3Pressed = delegate { };

        public float verticalAxis
        {
            get { return Input.GetAxis("Vertical"); }
        }

        public float horizontalAxis
        {
            get { return Input.GetAxis("Horizontal"); }
        }

        public Vector2 mousePosition
        {
            get { return Input.mousePosition; }
        }

        void Start()
        {
            Cursor.visible = _showCursor;
        }

        void Update()
        {
            if (Input.GetAxis("Vertical") != 0)
                OnVerticalAxisChanged(Input.GetAxis("Vertical"));

            if (Input.GetAxis("Horizontal") != 0)
                OnHorizontalAxisChanged(Input.GetAxis("Horizontal"));

            if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
                OnSteadyAxis();

            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
                OnMouseMoved(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));

            if (Input.GetMouseButtonDown(0))
                OnClick();

            #region AlphaNumerics
            if (Input.GetKeyDown(KeyCode.Alpha1))
                On1Pressed(1);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                On2Pressed(2);

            if (Input.GetKeyDown(KeyCode.Alpha3))
                On3Pressed(3);
            #endregion
        }
    }
}