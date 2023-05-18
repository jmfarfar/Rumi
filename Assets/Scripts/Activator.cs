using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField]
    private GameObject puzzle;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    Debug.Log("Activation");
    //    puzzle.SetActive(true);

    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Activation");
            puzzle.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        puzzle.SetActive(false);
    }
}
