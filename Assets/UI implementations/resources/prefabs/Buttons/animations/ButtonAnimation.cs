using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    public Animator AnimButton;

    // Start is called before the first frame update
    void Start()
    {
        AnimButton = GetComponent<Animator>();
    }
    public void Click()
    {
        AnimButton.Play("ButtonClick");
        StartCoroutine(noneAnimation());
    }
    IEnumerator noneAnimation()
    {
        yield return new WaitForSeconds(0.6f);
        AnimButton.Play("none");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
