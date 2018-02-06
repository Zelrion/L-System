using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSystemVisual:MonoBehaviour {
	public struct State {
		public Vector3 pos;
		public Quaternion rot;
	}
	public string command;
	public float length, angle;
	Stack<State> stateStack;
	void Start() {
		stateStack = new Stack<State>();
		command = StringGenerator.GenerateCommand();
		Generate();
	}
	public void Generate() { 
		foreach(char c in command) {
			switch(c) {
				case 'F':
					Vector3 pos = transform.position;
					transform.Translate(Vector3.forward*length);
					Debug.DrawLine(pos,transform.position,Color.green,10000f,false);
					break;
				case 'f':
					transform.Translate(Vector3.forward * length);
					break;
				case '+':
					transform.Rotate(Vector3.up,-angle);
					break;
				case '-':
					transform.Rotate(Vector3.up,angle);
					break;
				case '[':
					stateStack.Push(new State {
						pos = transform.position,
						rot = transform.rotation
					});
					break;
				case ']':
					State prevST = stateStack.Pop();
					transform.position = prevST.pos;
					transform.rotation = prevST.rot;
					break;
			}
		}
	}
}
