using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class QuenchingManager : MonoBehaviour
{
    [SerializeField]
    private Slider _scroller;

    [SerializeField]
    private TMP_Text _text;


    private float _negative_rate = 0.3f;

    private float _positive_rate = 0.05f;

    private float _currentVal = 0f;
    // Update is called once per frame
    void Update()
    {
        _currentVal -= _negative_rate * Time.deltaTime;
        if (_currentVal < 0)
            _currentVal = 0;
        _scroller.value = _currentVal;

    }


    public void Hit(InputAction.CallbackContext value)
    {
        if (value.phase == InputActionPhase.Started)
        {
            _currentVal += _positive_rate;
            _scroller.value = _currentVal;
        }

    }
}
