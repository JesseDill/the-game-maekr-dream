using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatingTileBehavior : MonoBehaviour
{
    [SerializeField] float amplitudeX = 10.0f;
    [SerializeField] float amplitudeY = 5.0f;
    [SerializeField] float omegaX = 1.0f;
    [SerializeField] float omegaY = 5.0f;
    private Vector3 anchor;
    float index;
    private void Start()
    {
        anchor = transform.localPosition;
    }
    public void FixedUpdate()
    {
        index += Time.deltaTime;
        float x = amplitudeX * Mathf.Cos(omegaX * index);
        float y = Mathf.Abs(amplitudeY * Mathf.Sin(omegaY * index));
        transform.localPosition = anchor + new Vector3(x, y, 0);
    }
}
