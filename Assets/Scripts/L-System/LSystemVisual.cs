using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSystemVisual:MonoBehaviour {
	private bool drawing = false;
	public struct State {
		public Vector3 pos;
		public Quaternion rot;
	}
	public bool spin;
	public bool animate;
	public string command;
	public float length, angle;
	Stack<State> stateStack;
	void Start() {
		command = StringGenerator.GenerateCommand();
	}
	private void Update() {
		if(!drawing) {
			if(animate) {
				length += Time.deltaTime*0.075f;
				angle -= Time.deltaTime;
			}
			stateStack = new Stack<State>();
			transform.position = new Vector3(0,5,0);
			if(!spin) transform.rotation = new Quaternion(0,0,0,0);
			Generate();
		}
	}

	public void Generate() {
		drawing = true;
		foreach(char c in command) {
			switch(c) {
				case 'F':
					Vector3 pos = transform.position;
					transform.Translate(Vector3.up * length);
					Debug.DrawLine(pos,transform.position,Color.black,0.025f,false);
					break;
				case 'f':
					transform.Translate(Vector3.up * length);
					break;
				case '+':
					transform.Rotate(Vector3.right,angle);
					break;
				case '-':
					transform.Rotate(Vector3.left,angle);
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
				default:
					Vector3 posA = transform.position;
					transform.Translate(Vector3.up * length);
					Debug.DrawLine(posA,transform.position,Color.cyan,0.025f,false);
					break;
			}
		}
		drawing = false;
	}
}
