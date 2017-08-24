using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateTxtScript : MonoBehaviour {

	// Use this for initialization
	void Start ( ) {
		StartCoroutine(this.Show());
	}
	
	IEnumerator Show ( ) {
		for ( float f = 0.0f; f < 5.0; f += 1.0f ) {
			Color currentColor = this.GetComponent<Text>().color;
			this.GetComponent<Text>().color = new Color
				(
					currentColor.r,
					currentColor.g,
					currentColor.b,
					currentColor.a + 0.2f
				);
			this.GetComponent<Transform>().localScale = new Vector3(0.5f * f, 0.5f * f, 0.5f * f);
			if ( f == 1.0f ) {
				StartCoroutine(this.Hide());
			}
			yield return new WaitForSeconds(0.1f);
		}
	}

	IEnumerator Hide ( ) {
		for ( float f = 0.0f; f < 5.0; f += 1.0f ) {
			Color currentColor = this.GetComponent<Text>().color;
			this.GetComponent<Text>().color = new Color
				(
					currentColor.r,
					currentColor.g,
					currentColor.b,
					currentColor.a - 0.2f
				);
			this.GetComponent<Transform>().localScale = new Vector3(0.5f * (f + 2.0f), 0.5f * (f + 2.0f), 0.2f * (f + 2.0f));
			yield return new WaitForSeconds(0.1f);
		}
	}
}
