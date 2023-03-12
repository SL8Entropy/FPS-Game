using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    [SerializeField] private GameObject persist;
    // Start is called before the first frame update
    void Start()
    {
        _slider.onValueChanged.AddListener((v) => {
            persist.GetComponent<persistantObject>().sensitivity = v;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
