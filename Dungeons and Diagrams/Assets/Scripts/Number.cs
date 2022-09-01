using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour
{
    [SerializeField] Material[] mats = new Material[8];
	[SerializeField] MeshRenderer rendrr;
    public void SetMat(int i)
	{
		rendrr.sharedMaterial = mats[i];
	}
}
