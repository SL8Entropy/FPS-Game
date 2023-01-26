using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBlock : Interactable
{
    [SerializeField]
    private GameObject MoveCube;
    private bool MoveCubeUp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //this function is where we will design our interaction using code.
    protected override void Interact()
    {
        MoveCubeUp = !MoveCubeUp;
        MoveCube.GetComponent<Animator>().SetBool("cubeUp", MoveCubeUp);
    }
}
