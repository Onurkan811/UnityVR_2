using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Move : MonoBehaviour
{
    private Rigidbody rb;
    enum Yon
    {
        sag,
        sol,
    }
    Yon yon = Yon.sag;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 4)
        {
            yon = Yon.sol;
        }
        if(transform.position.x < -4)
        {
            yon = Yon.sag;
        }
        switch(yon){
            case Yon.sag:
                transform.position += new Vector3(5 * Time.deltaTime, 0, 0);
                break;
            case Yon.sol:
                transform.position += new Vector3(5 * Time.deltaTime, 0, 0);
                break;

        }
    }
}
