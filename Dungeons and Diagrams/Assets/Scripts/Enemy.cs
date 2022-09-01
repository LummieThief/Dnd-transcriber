using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] Material[] mats = new Material[4];
	[SerializeField] MeshRenderer rendrr;
	public void SetMat(int i)
	{
		rendrr.sharedMaterial = mats[i];
	}
}
