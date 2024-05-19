/*============================================================================== 
Copyright (c) 2021 PTC Inc. All Rights Reserved.

Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.   
==============================================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Vuforia;
using Vuforia.UnityRuntimeCompiled;

public class ARProductPlacement : MonoBehaviour
{
    public bool GroundPlaneHitReceived { get; private set; }
    Vector3 ProductScale
    {
        get
        {
            var augmentationScale = VuforiaRuntimeUtilities.IsPlayMode() ? 1.0f : ProductSize;
            return new Vector3(augmentationScale, augmentationScale, augmentationScale);
        }
    }

    [Header("Augmentation Object")]
    [SerializeField] GameObject ARObjectToPlace = null;

    //[Header("Control Indicators")]
    //[SerializeField] GameObject TranslationIndicator = null;
    //[SerializeField] GameObject RotationIndicator = null;

    [Header("Plane Finde")]
    [SerializeField] private AnchorInputListenerBehaviour _anchorInputListenerBehaviour;

    [Header("Augmentation Size")]
    [Range(0.1f, 2.0f)]
    [SerializeField] float ProductSize = 1.0f;

    [Header("Rotation Slider")]
    [SerializeField] private Slider RotationSlider;

    const string GROUND_PLANE_NAME = "Emulator Ground Plane";
    const string FLOOR_NAME = "Floor";


    private Camera mMainCamera;
    private string mFloorName;
    private Vector3 mOriginalChairScale;
    private bool mIsPlaced;
    private int mAutomaticHitTestFrameCount;

    private bool _isMovable;
    public bool IsMovable { get => _isMovable; set => _isMovable = value; }

    void Start()
    {
        mMainCamera = VuforiaBehaviour.Instance.GetComponent<Camera>();

        _isMovable = false;

        SetupFloor();

        mOriginalChairScale = ARObjectToPlace.transform.localScale;
        Reset();

        InitializeRotationslider();
    }

    public void InitializeRotationslider()
    {
        RotationSlider.value = ARObjectToPlace.transform.localEulerAngles.y;

    }

    void Update()
    {


        if (mIsPlaced)
        {


            //TranslationIndicator.SetActive((TouchHandler.sIsSingleFingerDragging || TouchHandler.sIsSingleFingerStationary)
            //                                && !UnityRuntimeCompiledFacade.Instance.IsUnityUICurrentlySelected());

            if (IsPointerOverUIObject() || !_isMovable)
            {
                return;

            }

            SnapProductToMousePosition();
        }
        else
        {

            //TranslationIndicator.SetActive(false);
        }
    }

    void LateUpdate()
    {
        // The AutomaticHitTestFrameCount is assigned the Time.frameCount in the
        // OnAutomaticHitTest() callback method. When the LateUpdate() method
        // is then called later in the same frame, it sets GroundPlaneHitReceived
        // to true if the frame number matches. For any code that needs to check
        // the current frame value of GroundPlaneHitReceived, it should do so
        // in a LateUpdate() method.
        GroundPlaneHitReceived = mAutomaticHitTestFrameCount == Time.frameCount;

        if (!mIsPlaced)
        {
            // The Chair should only be visible if the following conditions are met:
            // 1. Target Status is Tracked, Extended Tracked or Limited
            // 2. Ground Plane Hit was received for this frame
            var isVisible = VuforiaBehaviour.Instance.DevicePoseBehaviour.TargetStatus.IsTrackedOrLimited() && GroundPlaneHitReceived;
        }
    }

    void SnapProductToMousePosition()
    {
        if (TouchHandler.sIsSingleFingerDragging || VuforiaRuntimeUtilities.IsPlayMode() && Input.GetMouseButton(0))
        {
            if (!UnityRuntimeCompiledFacade.Instance.IsUnityUICurrentlySelected())
            {
                var cameraToPlaneRay = mMainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(cameraToPlaneRay, out var cameraToPlaneHit) &&
                    cameraToPlaneHit.collider.gameObject.name == mFloorName)
                    ARObjectToPlace.transform.position = cameraToPlaneHit.point;
            }
        }
    }

    /// <summary>
    /// Resets the augmentation.
    /// It is called by the UI Reset Button and also by DevicePoseManager.DevicePoseReset callback.
    /// </summary>
    public void Reset()
    {
        ARObjectToPlace.transform.localPosition = Vector3.zero;
        ARObjectToPlace.transform.localEulerAngles = Vector3.zero;
        ARObjectToPlace.transform.localScale = Vector3.Scale(mOriginalChairScale, ProductScale);

        mIsPlaced = false;
    }

    /// <summary>
    /// Adjusts augmentation in a desired way.
    /// Anchor is already placed by ContentPositioningBehaviour.
    /// So any augmentation on the anchor is also placed.
    /// </summary>
    public void OnContentPlaced()
    {
        if (mIsPlaced)
        {
            return;
        }

        Debug.Log("OnContentPlaced() called.");

        // Align content to the anchor
        ARObjectToPlace.transform.localPosition = Vector3.zero;

        //RotateTowardsCamera(ARObjectToPlace);

        mIsPlaced = true;

        DisableAnchorInputLitenerBehaviour();
    }

    /// <summary>
    /// Displays a preview of the chair at the location pointed by the device.
    /// It is registered to PlaneFinderBehaviour.OnAutomaticHitTest.
    /// </summary>
    public void OnAutomaticHitTest(HitTestResult result)
    {
        return;

        mAutomaticHitTestFrameCount = Time.frameCount;

        if (!mIsPlaced)
        {
            // Content is not placed yet. So we place the augmentation at HitTestResult
            // position to provide a visual feedback about where the augmentation will be placed.
            ARObjectToPlace.transform.position = result.Position;
        }
    }

    void SetupFloor()
    {
        if (VuforiaRuntimeUtilities.IsPlayMode())
            mFloorName = GROUND_PLANE_NAME;
        else
        {
            mFloorName = FLOOR_NAME;
            var floor = new GameObject(mFloorName, typeof(BoxCollider));
            floor.transform.SetParent(ARObjectToPlace.transform.parent);
            floor.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            floor.transform.localScale = Vector3.one;
            floor.GetComponent<BoxCollider>().size = new Vector3(100f, 0, 100f);
        }
    }


    void RotateTowardsCamera(GameObject augmentation)
    {

        if (ARObjectToPlace.transform.localEulerAngles != Vector3.zero) return;

        var lookAtPosition = mMainCamera.transform.position - augmentation.transform.position;
        lookAtPosition.y = 0;
        var rotation = Quaternion.LookRotation(lookAtPosition);
        augmentation.transform.rotation = rotation;
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;


    }

    public void RotateARObject()
    {
        ARObjectToPlace.transform.localEulerAngles = new Vector3(0, RotationSlider.value, 0);

        EnableRotateIndicator();

    }

    public void EnableRotateIndicator()
    {
        //RotationIndicator.SetActive(true);

    }

    public void DisableRotateIndicator()
    {
        //RotationIndicator.SetActive(false);

    }

    public void RotateARObjectWithButton(int value)
    {
        RotationSlider.value += value;

        RotateARObject();

    }

    //esto es lo que hac que parpade el objeto si pulsamos la pantalla
    public void DisableAnchorInputLitenerBehaviour()
    {
        _anchorInputListenerBehaviour.enabled = false;
    }

}
