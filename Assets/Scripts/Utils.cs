using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {

	public static Color getRandomColor() {
		return new Color( Random.value, Random.value, Random.value, 1.0f );
	}

}
