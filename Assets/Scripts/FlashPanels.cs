using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class FlashPanels : MonoBehaviour
{

    public GameObject RedPanel;
    public GameObject BluePanel;
    private ActionTimer _timer;

    public float FlashTime = 0.25f;

    // Methods
    public void HideAll()
    {
        RedPanel.SetActive(false);
        BluePanel.SetActive(false);
    }

    public void ShowRed()
    {
        RedPanel.SetActive(true);
        _timer.Start();
    }

    public void ShowBlue()
    {
        BluePanel.SetActive(true);
        _timer.Start();
    }

    // Start is called before the first frame update
    void Start()
    {
        _timer = new(FlashTime);

        RedPanel = gameObject.GetNamedChild("LightRedPanel");
        BluePanel = gameObject.GetNamedChild("LightBluePanel");

        HideAll();
    }

    // Update is called once per frame
    void Update()
    {
        _timer.Update(Time.deltaTime);
        if (_timer.IsZero)
        {
            HideAll();
            _timer.Pause();
            _timer.Reset();
        }
    }
}
