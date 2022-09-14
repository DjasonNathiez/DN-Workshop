using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilitaire;

public class GenerationModulo : MonoBehaviour
{
    private int[,] _table;
    public GameObject cube;

    private readonly GameObject[,] _tableGo = new GameObject[10,10];

    private Dictionary<Classes, int> itemInventory;
    public int bagSlots;
    
    private void Update()
    {
        itemInventory.Add(new Classes(), 3);
    }


    //identity cubes generates each 3 or 5.
    
    private void Start()
    {
        Generation();
    }

    void Generation()
    {
        _table = new int[10, 10];
            
        for (int i = 0; i < _table.GetLength(0); i++)
        {
            for (int j = 0; j < _table.GetLength(1); j++)
            {
                _tableGo[i,j] = Instantiate(cube, new Vector3(i, j), Quaternion.identity);
                _tableGo[i,j].name = j + "," + i + " (" + (i+j) + ")";
            }
        }
        
        InitializeBagSlots();
        //CheckGeneration();
    }

    void InitializeBagSlots()
    {
        for (int i = 0; i < bagSlots; i++)
        {
            _tableGo[i, i].GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }

    void CheckGeneration()
    {
        for (int i = 0; i < _tableGo.GetLength(0); i++)
        { 
            for (int j = 0; j < _tableGo.GetLength(1); j++)
            {
                _tableGo[i,j].GetComponent<MeshRenderer>().material.color = Check(_tableGo.GetLength(0) * j + i) ? Color.red : Color.white;
            }
        }
    }

    bool Check(int id)
    {
        return id % 3 == 0 || id % 5 == 0;
    }
}
