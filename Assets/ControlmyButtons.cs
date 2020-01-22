using UnityEngine;
using DG.Tweening;

public class ControlmyButtons : MonoBehaviour {

	public bool isChanged;

	public DOTweenAnimation mDOTMenu;

	void Start(){
	
		isChanged = false;
	}

	public void changeText(){

		if (isChanged) {
			
			mDOTMenu.DOPlayBackwards();
		
		} else {
		
			mDOTMenu.DOPlayForward();
	
		}

		isChanged = !isChanged;
	}
}