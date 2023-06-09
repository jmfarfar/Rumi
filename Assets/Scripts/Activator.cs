using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField]
    private GameObject puzzle;


    private void OnTriggerStay2D(Collider2D collision)
    {
        // check if the puzzle to activate is the Order one
        if (collision.tag == TagManager.PLAYER && Input.GetKey(KeyCode.E) && this.tag == TagManager.ORDER_PUZZLE)
        {
            Debug.Log("Order Activation");
            puzzle.SetActive(true);
        }
        // check if the puzzle to aactivate is the Switch one
        else if (collision.tag == TagManager.PLAYER && Input.GetKey(KeyCode.E) && this.tag == TagManager.SWITCH_PUZZLE)
        {
            Debug.Log("Switch Activation");
            puzzle.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        puzzle.SetActive(false);
    }
}
