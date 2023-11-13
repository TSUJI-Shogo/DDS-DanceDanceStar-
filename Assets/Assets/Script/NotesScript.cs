using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesScript : MonoBehaviour
{
    public float notesSp = 5;
    bool start;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
        }
        if(start)
        {
            transform.position += transform.up * Time.deltaTime * Gmanager.instance.noteSpeed;//y²‚É‰ÁZ‚µ‘±‚¯‚ÄÀ•W‚ğã‚ÉˆÚ“®‚µ‘±‚¯‚é
        }
    }
}
