using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GenericGrab : MonoBehaviour
{
    // GenericGrab => Grab objects that are grabbable by using the mouse!

    // When grabbed, it should appear to player
    // when not grabbed, hide the shadow
    // only show the shadow when grabbing
    // also offset the shadow and the object

    [SerializeField]
    public Vector3 OffsetPosition = new Vector3();
    private Animator myAnimator;


    public bool IsGrabbed = false;

    public GameObject MyShadow;

    public Vector3 InflatedScale;
    private Vector3 NormalScale = Vector3.one;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();

        MyShadow = transform.GetChild(0).gameObject;
        NormalScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void OnMouseDown()
    {
        myAnimator.Play("wiggle");
        MyShadow.SetActive(true);
        IsGrabbed = true;
        transform.localScale = new Vector3(InflatedScale.x, InflatedScale.y, InflatedScale.z);

    }

    private void OnMouseUp()
    {
        myAnimator.Play("idle");
        MyShadow.SetActive(false);
        IsGrabbed = false;
        transform.localScale = new Vector3(NormalScale.x, NormalScale.y, NormalScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(IsGrabbed)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 1;

            this.transform.position = new Vector3(pos.x, pos.y, pos.z);
            MyShadow.transform.position = new Vector3(pos.x, pos.y + OffsetPosition.y, pos.z);
        }


    }
}
