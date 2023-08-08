using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

///
/// Class that creates controls to enable/disable panels
/// so that they can flash in the given timer interval.
///
public class FlashPanels : MonoBehaviour
{
    // Private
    private ActionTimer _timer;

    // Public
    public GameObject RedPanel;  //!< The red panel to hide/show
    public GameObject BluePanel; //!< The blue panel to hide/show
    public float FlashTime = 0.25f; //!< The interval for the flash

    // Methods
    /// <summary>
    /// Hides all the panels for the script.
    /// </summary>
    public void HideAll()
    {
        RedPanel.SetActive(false);
        BluePanel.SetActive(false);
    }

    /// <summary>
    /// Shows the red panel given to the script.
    /// </summary>
    public void ShowRed()
    {
        RedPanel.SetActive(true);
        _timer.Start();
    }

    /// <summary>
    /// Shows the blue panel given to the script.
    /// </summary>
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
