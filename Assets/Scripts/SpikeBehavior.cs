using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script to calculate the limits to move up and down the spikes.
 */
public class SpikeBehavior : MonoBehaviour
{
    
    private float parentSpeed;
    private EnemySpikes parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = GetComponentInParent<EnemySpikes>();
        parentSpeed = GetComponentInParent<EnemySpikes>().GetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        parentSpeed *= -1;
        parent.SetSpeed(parentSpeed);
    }
}
