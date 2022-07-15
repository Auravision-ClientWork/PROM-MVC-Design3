using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
public class LinkTraining : MonoBehaviour
{
    int[] numbers = { 2, 12, 5, 15, 28, 31, 17, 16, 42 };

    private void Start()
    {
        //define and initialize a store
        var numsQuery = from n in numbers
                        where n < 20
                        select n;

        var numsMethod = numbers.Where(n => n > 0);

        var foundNumber = Array.Find<int>(numbers, n => n == 2);

        Debug.Log(foundNumber);

    }
}
