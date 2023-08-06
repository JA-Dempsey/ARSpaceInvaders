using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemeyTrackingUI : MonoBehaviour
{
    // Find enemies by tag name
    public string enemyTag = "Enemy";
    public Image enemyTrackerLeft;
    public Image enemyTrackerRight;
    public Image enemyTrackerAbove;
    public Image enemyTrackerBelow;

    void Update()
    {
        // Find all enemy objects with the specified tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        // Enemy tracker color
        float transparency = 0.5f;
        Color redWithTransparency = new Color(1f, 0f, 0f, transparency);

        // Enemy positions
        bool enemyOnLeft = false;
        bool enemyOnRight = false;
        bool enemyAbove = false;
        bool enemyBelow = false;

        // Calculate the positions relative to the camera
        foreach (GameObject enemy in enemies)
        {
            Vector3 enemyScreenPos = Camera.main.WorldToScreenPoint(enemy.transform.position);

            if (enemyScreenPos.x < 0.5f)
            {
                enemyOnLeft = true;
            }
            else
            {
                enemyOnRight = true;
            }

            if (enemyScreenPos.y < 0.5f)
            {
                enemyBelow = true;
            }
            else
            {
                enemyAbove = true;
            }
        }

        if (enemyTrackerLeft != null)
        {
            Color illuminationColor = enemyOnLeft ? redWithTransparency : Color.clear;
            enemyTrackerLeft.color = Color.Lerp(enemyTrackerLeft.color, illuminationColor, Time.deltaTime * 5f);
        }

        if (enemyTrackerRight != null)
        {
            Color illuminationColor = enemyOnRight ? redWithTransparency : Color.clear;
            enemyTrackerRight.color = Color.Lerp(enemyTrackerRight.color, illuminationColor, Time.deltaTime * 5f);
        }

        if (enemyTrackerAbove != null)
        {
            Color illuminationColor = enemyAbove ? redWithTransparency : Color.clear;
            enemyTrackerAbove.color = Color.Lerp(enemyTrackerAbove.color, illuminationColor, Time.deltaTime * 5f);
        }

        if (enemyTrackerBelow != null)
        {
            Color illuminationColor = enemyBelow ? redWithTransparency : Color.clear;
            enemyTrackerBelow.color = Color.Lerp(enemyTrackerBelow.color, illuminationColor, Time.deltaTime * 5f);
        }
    }
}
