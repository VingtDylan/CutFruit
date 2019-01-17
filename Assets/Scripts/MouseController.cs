using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

	[SerializeField]
	private LineRenderer lineRenderer;

	private bool firstMouseDown=false;
	private bool mouseDown=false;

	private Vector3[] positions=new Vector3[10];
	private Vector3 head;
	private Vector3 tail;
	private int posCount=0;

	void Update () {
		if(Input.GetMouseButtonDown(0)){
			firstMouseDown=true;
			mouseDown=true;
		}
		if(Input.GetMouseButtonUp(0)){
			mouseDown=false;
		}
		onDrawLine();
		firstMouseDown=false;
	}

	private void onDrawLine(){
		if(firstMouseDown){
			posCount=0;
			head=Camera.main.ScreenToWorldPoint(Input.mousePosition);
			tail=head;
		}
		if(mouseDown){
			head=Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if(Vector3.Distance(head,tail)>0.01f){
				SavePosition(head);
				posCount++;
			}
			tail=head;
		}else{
			this.positions=new Vector3[10];
		}
		ChangePositions(positions);
	}

	private void SavePosition(Vector3 pos){
		pos.z=0.0f;
		if(posCount<=9){
			for(int i=posCount;i<10;i++){
				positions[i]=pos;
			}
		}else{
			for(int i=0;i<10;i++){
				positions[i]=positions[i+1];
			}
			positions[9]=pos;
		}
	}

	private void ChangePositions(Vector3[] positions){
		lineRenderer.SetPositions(positions);
	}
}
