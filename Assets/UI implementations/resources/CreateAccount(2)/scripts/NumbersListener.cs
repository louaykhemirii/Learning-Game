using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumbersListener : MonoBehaviour
{
	public InputField input;
    string aux;

	public void add1() { input.text += "1"; }
    public void add2() { input.text += "2"; }
    public void add3() { input.text += "3"; }
    public void add4() { input.text += "4"; }
    public void add5() { input.text += "5"; }
    public void add6() { input.text += "6"; }
    public void add7() { input.text += "7"; }
    public void add8() { input.text += "8"; }
    public void add9() { input.text += "9"; }
    public void add0() { input.text += "0"; }
    public void remove() 
    {
        if(input.text != "")
        {
			aux = input.text;
			aux = aux.Substring(0, aux.Length - 1);
			input.text = aux;
		}
        
	}
    

}
