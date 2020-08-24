using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkGroup : MonoBehaviour
{
    public Transform link1;
    public Transform link2;
    private LineRenderer line;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, link1.position);
        line.SetPosition(1, link2.position);
    }
}
