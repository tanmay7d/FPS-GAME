using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    [SerializeField] Transform CamChildForFloor = null;
    [SerializeField] Transform CamChildForWallAndStairs = null;
    RaycastHit Hit;
    [SerializeField] Transform FloorBuild = null;
    [SerializeField] Transform FloorPrefab = null;
    [SerializeField] int range = 50;
    public Transform WallPrebuild = null;
    public Transform WallPrefab = null;
    public Transform StairPrebuild = null;
    public Transform StairPrefab = null;
    public bool floorBool;
    public bool stairBool;
    public bool wallBool;
    public Image FloorInventory;
    public Image WallInventory;
    public Image StairInventory;

    public void Update()
    {     
        BuildingMethod();
    }
    void BuildingMethod()
    {
        CheckBools();
        if (floorBool)
        {
            BuildFloor();
            FloorInventory.rectTransform.sizeDelta = new Vector2(50, 50);
            WallInventory.rectTransform.sizeDelta = new Vector2(30, 30);
            StairInventory.rectTransform.sizeDelta = new Vector2(30, 30);
            

        }

        if (stairBool)
        {
            BuildStair();
            StairInventory.rectTransform.sizeDelta = new Vector2(50, 50);
            FloorInventory.rectTransform.sizeDelta = new Vector2(30, 30);
            WallInventory.rectTransform.sizeDelta = new Vector2(30, 30);

        }
        if (wallBool)
        {
            BuildWall();
            WallInventory.rectTransform.sizeDelta = new Vector2(50, 50);
            FloorInventory.rectTransform.sizeDelta = new Vector2(30, 30);
            StairInventory.rectTransform.sizeDelta = new Vector2(30, 30);
        }
    }

    void CheckBools()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            floorBool = true;
            wallBool = false;
            stairBool = false;
        };
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            wallBool = true;
            stairBool = false;
            floorBool = false;
        };
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            stairBool = true;
            wallBool = false;
            floorBool = false;

        }

    }
    void BuildFloor()
    {
        if (Physics.Raycast(CamChildForFloor.position, CamChildForFloor.forward, out Hit, range))
        {


            FloorBuild.position = new Vector3(Mathf.RoundToInt(Hit.point.x) != 0 ? Mathf.RoundToInt(Hit.point.x / 6f) * 6f : 6f,
                (Mathf.RoundToInt(Hit.point.y) != 0 ? Mathf.RoundToInt(Hit.point.y / 6f) * 6f : 0f),
                Mathf.RoundToInt(Hit.point.z) != 0 ? Mathf.RoundToInt(Hit.point.z / 6f) * 6f : 6f);


            FloorBuild.eulerAngles = new Vector3(0, 0, 0);

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(FloorPrefab, FloorBuild.position, FloorBuild.rotation);
                

            }
        }
    }
    void BuildStair()
    {
        
        if (Physics.Raycast(CamChildForWallAndStairs.position, CamChildForWallAndStairs.forward, out Hit, range))
        {

            StairPrebuild.GetChild(0).transform.localPosition = new Vector3(3, 3, 3);
            StairPrebuild.GetChild(0).transform.localScale = new Vector3(6, 11, 6);
            StairPrefab.GetChild(0).transform.localScale = new Vector3(6, 11, 6);
            
            StairPrebuild.position = new Vector3(Mathf.RoundToInt(Hit.point.x) != 0 ? Mathf.RoundToInt(Hit.point.x / 6f) * 6f : 6f,
                (Mathf.RoundToInt(Hit.point.y) != 0 ? Mathf.RoundToInt(Hit.point.y / 6f) * 6f : 0f),
                Mathf.RoundToInt(Hit.point.z) != 0 ? Mathf.RoundToInt(Hit.point.z / 6f) * 6f : 6f);
            StairPrebuild.eulerAngles = new Vector3(45, Mathf.RoundToInt(transform.eulerAngles.y) != 0 ? Mathf.RoundToInt(transform.eulerAngles.y / 90) * 90 : 0, 0);

            StairPrefab.GetChild(0).transform.localPosition = StairPrebuild.GetChild(0).transform.localPosition;
            if (Mathf.RoundToInt(StairPrebuild.eulerAngles.y) == 90)
            {
                StairPrebuild.GetChild(0).transform.localPosition = new Vector3(0, 4.3f, 0);
                StairPrefab.GetChild(0).transform.localPosition = new Vector3(0, 4.3f, 0);
                
            }
            if (Mathf.RoundToInt(StairPrebuild.eulerAngles.y) == 0)
            {
                StairPrebuild.GetChild(0).transform.localPosition = new Vector3(3f, 6.3f, 2f);
                StairPrefab.GetChild(0).transform.localPosition = new Vector3(3f, 6.3f, 2f);
                
            }
            if (Mathf.RoundToInt(StairPrebuild.eulerAngles.y) == 180)
            {
                StairPrebuild.GetChild(0).transform.localPosition = new Vector3(3f, 6.3f, 2f);
                StairPrefab.GetChild(0).transform.localPosition = new Vector3(3f, 6.3f, 2f);
                
            }
            else if (Mathf.RoundToInt(StairPrebuild.eulerAngles.y) == 270)
            {
                StairPrebuild.GetChild(0).transform.localPosition = new Vector3(0, 4.3f, 0);
                StairPrefab.GetChild(0).transform.localPosition = new Vector3(0, 4.3f, 0);
                

            }
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(StairPrefab, StairPrebuild.position, StairPrebuild.rotation);
               

            }
        }
    }
    void BuildWall()
    {   

        if (Physics.Raycast(CamChildForWallAndStairs.position, CamChildForWallAndStairs.forward, out Hit, range))
        {

            WallPrebuild.GetChild(0).transform.localPosition = new Vector3(3, 3, 3);
            WallPrebuild.GetChild(0).transform.localScale = new Vector3(6, 7.7f, 6);
            WallPrefab.GetChild(0).transform.localScale = new Vector3(6, 7.7f, 6);
            WallPrebuild.position = new Vector3(Mathf.RoundToInt(Hit.point.x) != 0 ? Mathf.RoundToInt(Hit.point.x / 6f) * 6f : 6f,
                (Mathf.RoundToInt(Hit.point.y) != 0 ? Mathf.RoundToInt(Hit.point.y / 6f) * 6f : 0f),
                Mathf.RoundToInt(Hit.point.z) != 0 ? Mathf.RoundToInt(Hit.point.z / 6f) * 6f : 6f);
            WallPrebuild.eulerAngles = new Vector3(0, Mathf.RoundToInt(transform.eulerAngles.y) != 0 ? Mathf.RoundToInt(transform.eulerAngles.y / 90) * 90 : 0, 0);


            WallPrefab.GetChild(0).transform.localPosition = WallPrebuild.GetChild(0).transform.localPosition;

            if (Mathf.RoundToInt(WallPrebuild.eulerAngles.y) == 90)
            {
                WallPrebuild.GetChild(0).transform.localPosition = new Vector3(0, 3, 0);
                WallPrefab.GetChild(0).transform.localPosition = new Vector3(0, 3, 0);
            }
            else if (Mathf.RoundToInt(WallPrebuild.eulerAngles.y) == 270)
            {
                WallPrebuild.GetChild(0).transform.localPosition = new Vector3(0, 3, 0);
                WallPrefab.GetChild(0).transform.localPosition = new Vector3(0, 3, 0);

            }
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(WallPrefab, WallPrebuild.position, WallPrebuild.rotation);

            }
        }
    }

    
}