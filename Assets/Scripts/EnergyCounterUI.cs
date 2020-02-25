using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyCounterUI : MonoBehaviour
{
    private BallController _ballController;
    private RectTransform _rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        _ballController = GameObject.Find("ball").GetComponent<BallController>();
        _rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        _rectTransform.sizeDelta = new Vector2(_ballController.Energy, _rectTransform.sizeDelta.y);
        
    }
}
