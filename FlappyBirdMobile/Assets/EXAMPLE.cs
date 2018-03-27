using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXAMPLE : MonoBehaviour {

    int Score;
    float HP = 10.0f;
    bool c = true;

    int a = 1, b = 2;


    
    int Sum(int a, int b)
    {
        return a + b;
    }
    // Use this for initialization
    void Start () {
        Score = 0;
        Score = Sum(6,8);

       Increment(a, b);
        //b = ++a;
        int newA = 2;
        int newB = 3;

        Increment(newA, newB);

        int newValue = postfixIncrement(newA, newB);
        Debug.Log(newValue);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

   void Increment(int _a, int _b)
    {
        _b = _a++;
        Debug.Log("a: " + _a);
        Debug.Log("b: " + _b);
    }
    int postfixIncrement(int _a, int _b)
    {
        _b = ++_a;
        return _b;
    }
}
