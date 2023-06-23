using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NodeMaker : MonoBehaviour
{
    public RaycastHit2D right;//0
    public RaycastHit2D left;//1
    public RaycastHit2D up;//2
    public RaycastHit2D down;//3
    public Vector2[] dirr= new Vector2[]{ new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1) };
    public float movespeed;
    public float vert;
    public float hor;
    public float vert2;
    public float hor2;
    public List<Vector2> nodeLoc;
    public int dir;

    int roadsize;
    Vector2 freeside;
    void Start()
    {

        right = Physics2D.Raycast(transform.position, dirr[0]);
        left = Physics2D.Raycast(transform.position, dirr[1]);
        up = Physics2D.Raycast(transform.position, dirr[2]);
        down = Physics2D.Raycast(transform.position, dirr[3]);
        vert = up.distance + down.distance;
        hor = left.distance + right.distance;
        if (vert <= hor)
        {
            roadsize = Mathf.FloorToInt(vert/2.1f);
            //transform.position = new Vector2(transform.position.x, transform.position.y) + new Vector2(0, (up.distance - down.distance)/2);
            if (right.distance < left.distance)
            {
                dir = 1;
            }
            else
            {
                dir = 0;
            }
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y) + new Vector2((right.distance - left.distance)/2,0);
            if (up.distance < down.distance)
            {
                dir = 3;
            }
            else
            {
                dir = 2;
            }
        }
        nodeLoc.Add(transform.position);
        vert2 = vert;
        hor2= hor;
    }
    void FixedUpdate()
    {
        CreateNodeMap();
        Move();

    }
    void CreateNodeMap()
    {
        if (dir < 2)
        {

        }      
        else
        {

        }
        //transform.position = Vector2.MoveTowards(transform.position, nodeLoc[path[pointIndex]], movespeed * Time.deltaTime);
    }
    void Move()
    {
        //transform.position = Vector2.MoveTowards(transform.position, nodeLoc[], movespeed * Time.deltaTime);
    }
    void AddNode()
    {
        if (dir<2&& (up.distance+down.distance)<2.1&&Mathf.Abs(up.distance-down.distance)<0.0001&& Mathf.Min(left.distance,right.distance)<1.05)
        {

        }
    }
}
public class Node: MonoBehaviour
{
    public int ID;
    public Vector2 location;
    public List<int> nodeID;
    public List<int> nodeDir;
    public List<int> nodeexplore;
}
