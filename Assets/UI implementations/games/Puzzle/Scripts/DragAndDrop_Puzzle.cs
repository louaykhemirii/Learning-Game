using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;

public class DragAndDrop_Puzzle : MonoBehaviour
{
    private Vector3 _rightPosition;
    private Vector3 _theRandomPosition;
    private Vector3 _dragOffset;
    private Camera _cam;
    [SerializeField] GameManager2 _gameManager;
    public Vector2 max,min;
    private bool _moveable=true;
    SortingGroup _sortingGroup;
    

    [SerializeField] private float _speed = 30;
    

    void Awake() {
        _cam = Camera.main;
        max.x=9.2f;
        max.y=2.5f;
        min.x=-7.5f;
        min.y=-9.2f;
    }

    void Start(){
        _rightPosition = transform.position;
        transform.position = new Vector3(Random.Range(1.5f,7f),Random.Range(-0.5f,-6f));
        _theRandomPosition=transform.position;
    }

    void OnMouseDown() {
        
        _dragOffset = transform.position - GetMousePos();
        _sortingGroup = GetComponent<SortingGroup>();
        _sortingGroup.sortingOrder = 2;
        
    }
	void OnMouseUp()
	{
		_sortingGroup.sortingOrder = 1;
		if (Vector3.Distance(transform.position, _rightPosition) < 0.5f)
		{
			transform.position = _rightPosition;
			_sortingGroup.sortingOrder = 0;
			if (_moveable)
			{
				_gameManager.pieceCounter++;
				_moveable = false;
				GetComponent<BoxCollider2D>().enabled = false;
			}
		}

	}
	void OnMouseDrag() {
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime) ;
       
    }

    Vector3 GetMousePos() {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    void Update(){
        CantMove();
    }

    void CantMove(){
        if(!_moveable){
        transform.position=_rightPosition;
        }
    }

}
