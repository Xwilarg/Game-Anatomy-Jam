using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sewing : MonoBehaviour
{
    [SerializeField]
    private RectTransform _wall1;

    [SerializeField]
    private RectTransform _wall2;

    [SerializeField]
    private GameObject _ball;

    private float fallingSpeed = 100f;

    private void Update()
    {
        _ball.transform.Translate(new Vector3(0f, -fallingSpeed * Time.deltaTime, 0f));
    }
}
