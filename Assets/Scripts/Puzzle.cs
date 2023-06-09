using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private Transform[] images;
    [SerializeField] private Image[] objects;
    private int[] _correctAnswer = { 8, 1, 2, 3, 4, 5, 6, 7, 0 };
    private int[] _ids = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    private Transform _empty;
    private int _emptyId = 0;

    private bool hasPreviousSelection;
    private int firstSelectionId;
    private int secondSelectionId;

    // Start is called before the first frame update
    void Start()
    {
        //images = GetComponentsInChildren<Transform>();
        objects = GetComponentsInChildren<Image>();
        _empty = GameObject.FindGameObjectWithTag("EmptyPuzzle").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeTilePositions(int id)
    {
        // Change position with the empty space
        var temp = images[id].transform.position;
        images[id].transform.position = _empty.transform.position;
        _empty.transform.position = temp;

        // modify the IDs arrangement in array
        var tmpID = _ids[id];
        _ids[id] = _ids[_emptyId];
        _ids[_emptyId] = tmpID;
    }

    public void SwitchSelectedTiles(int id)
    {
        if (!hasPreviousSelection)
        {
            firstSelectionId = id;
            hasPreviousSelection = !hasPreviousSelection;
            objects[id].color = Color.red;
        }
        else
        {
            secondSelectionId = id;
            hasPreviousSelection = !hasPreviousSelection;

            var tmp = images[secondSelectionId].transform.position;
            images[secondSelectionId].transform.position = images[firstSelectionId].transform.position;
            images[firstSelectionId].transform.position = tmp;
            objects[firstSelectionId].color = Color.white;
        }
    }

    public void Confirm()
    {
        if (Evaluate())
        {
            Debug.Log("Passed");
        }
        else
        {
            Debug.Log("Wrong Code");
        }
    }

    public bool Evaluate()
    {
        Debug.Log("Evaluation...");
        for (int i = 0; i < _correctAnswer.Length; i++)
        {
            if (_correctAnswer[i] != _ids[i])
            {
                //Debug.Log("Wrong code");
                return false;
            }
        }

        //Debug.Log("OK. Passed!");
        return true;
    }
}
