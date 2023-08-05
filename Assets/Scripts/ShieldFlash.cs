using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldFlash : MonoBehaviour
{

    private ActionTimer _timer;
    private MeshRenderer _shield;
    public float FlashTime = 0.25f;

    public void FlashShield()
    {
        _shield.enabled = true;
        _timer.Start();
    }

    public void HideShield()
    {
        _shield.enabled = false;
        _timer.Pause();
        _timer.Reset();
    }

    // Start is called before the first frame update
    void Start()
    {
        _timer = new(FlashTime);
        _shield = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer.Update(Time.deltaTime);
        if (_timer.IsZero)
        {
            HideShield();
        }
    }
}
