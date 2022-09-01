using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class GridController : MonoBehaviour
{
    [SerializeField] GameObject numberParent;
    [SerializeField] GameObject enemyParent;
	[SerializeField] Text text;

	private Enemy[] enemies;
	private Number[] numbers;

	private StreamReader reader;

	private void Awake()
	{
		string path = "Assets/Puzzles/dnd.txt";
		reader = new StreamReader(path);
		enemies = enemyParent.GetComponentsInChildren<Enemy>();
		numbers = numberParent.GetComponentsInChildren<Number>();
		
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			string[] puzzle = ReadNextPuzzle(reader);
			text.text = puzzle[0];
			for (int i = 1; i < 9; i++)
			{
				for (int k = 0; k < puzzle[i].Length; k++)
				{
					enemies[(i - 1) * 8 + k].SetMat(Int32.Parse("" + puzzle[i][k]));
				}
			}
			for (int i = 9; i < 11; i++)
			{
				for (int k = 0; k < puzzle[i].Length; k++)
				{
					numbers[(i - 9) * 8 + k].SetMat(Int32.Parse("" + puzzle[i][k]));
				}
			}
		}
	}

	private string ReadRawString()
	{
		string path = "Assets/Puzzles/test.txt";
		//Read the text from directly from the test.txt file
		StreamReader reader = new StreamReader(path);
		string s = reader.ReadToEnd();
		reader.Close();
		string ot = "";
		for (int i = 0; i < s.Length; i++)
		{
			if (s[i] != '\r' && s[i] != '\n')
			{
				ot += s[i];
			}
		}
		return ot;
	}

	private string[] ReadNextPuzzle(StreamReader reader)
	{
		string[] puzzle = new string[11];
		for (int i = 0; i < puzzle.Length; i++)
		{
			puzzle[i] = reader.ReadLine();
		}
		return puzzle;
	}
}
