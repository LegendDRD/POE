using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameEngine : MonoBehaviour {
      public Text texts;
 

    public GameObject BlueKnight;
    public GameObject RedKnight;

    public GameObject BlueArcher;
    public GameObject RedArcher;

    public GameObject BlueLance;
    public GameObject RedLance;

    public GameObject RedMusk;
    public GameObject BlueMusk;

    public GameObject RedFactory;
    public GameObject BlueFactory;

    public GameObject RedResource;
    public GameObject BlueResource;

    public GameObject RedEmp;
    public GameObject BLueEmp;
    int count = 0;
    private Map map;
    RaycastHit hit;
    // Use this for initialization
    void Start () {
         map = new Map(75, 20, 28, 10);
        Display();


    }
    
    // Update is called once per frame
    void FixedUpdate () {



        
        
            aaDestroy();

            UpdateMap();
            Display();
        Clickon();


    }

    public void Display()
    {
     

        foreach (Unit u in map.Unit)
        {
            if (u.GetType() == typeof(MeleeUnit))
            {

                MeleeUnit m = (MeleeUnit)u;



                if (m.symbol == "=")
                {

                    if (m.Fact == 1)
                    {
                        
                            GameObject clone = Instantiate(BlueKnight, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                            clone.transform.parent = transform;
                        
                        
                       

                    }
                    else
                    {
                       GameObject clone = Instantiate(RedKnight, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        clone.transform.parent = transform;
                    }
                    if (m.isDead())
                    {
                        
                    }


                }
                else
                {
                    if (m.Fact == 1)
                    {
                       GameObject clone = Instantiate(BlueLance, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        clone.transform.parent = transform;
                    }
                    else
                    {
                        GameObject clone = Instantiate(RedLance, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        clone.transform.parent = transform;
                    }
                    if (m.isDead())
                    {
                        
                    }

                }


            }



        }
        foreach (Unit u in map.Unit)
        {
            if (u.GetType() == typeof(RangedUnits))
            {

                RangedUnits m = (RangedUnits)u;



                if (m.symbol == "}")
                {

                    if (m.Fact == 1)
                    {
                       GameObject clone = Instantiate(BlueArcher, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        clone.transform.parent = transform;
                    }
                    else
                    {
                        GameObject clone =Instantiate(RedArcher, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        clone.transform.parent = transform;

                    }
                    if (m.isDead())
                    {
                      
                    }


                }
                else
                {
                    if (m.Fact == 1)
                    {
                       GameObject clone = Instantiate(BlueMusk, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        clone.transform.parent = transform;
                    }
                    else
                    {
                        GameObject clone =Instantiate(RedMusk, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        clone.transform.parent = transform;
                    }
                    if (m.isDead())
                    {
                   
                    }

                }


            }
        }
    
        
        foreach (Unit u in map.Unit)
        {
            if (u.GetType() == typeof(Emperor))
            {
               
                Emperor emperor = (Emperor)u;
               




                if (emperor.Fact == 1)
                {
                    GameObject clone =Instantiate(BLueEmp, new Vector2(emperor.Xpos, emperor.Ypos), Quaternion.identity);
                    clone.transform.parent = transform;
                }
                else
                {
                    GameObject clone = Instantiate(RedEmp, new Vector2(emperor.Xpos, emperor.Ypos), Quaternion.identity);
                    clone.transform.parent = transform;
                }
                if (emperor.isDead())
                {

                }
               
            }

        }
        foreach (Building b in map.Building)
        {
            if (b.GetType() == typeof(FactoryBuilding))
            {
                
                FactoryBuilding m = (FactoryBuilding)b;
               

               

                if (m.Fact == 1)
                {

                    GameObject clone = Instantiate(BlueFactory, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                    clone.transform.parent = transform;
                }
                else
                {
                    GameObject clone =Instantiate(RedFactory, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                    clone.transform.parent = transform;
                }
                if (m.isDestoryed())
                {
                    
                }
                
            }

        }
        foreach (ResourceBuilding b in map.RB)
        {
            if (b.GetType() == typeof(ResourceBuilding))
            {
                
                ResourceBuilding m = (ResourceBuilding)b;
               

              

                if (m.Fact == 1)
                {
                 GameObject clone =   Instantiate(BlueResource, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                    clone.transform.parent = transform;
                }
                else
                {
                   GameObject clone =  Instantiate(RedResource, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                    clone.transform.parent = transform;
                }
                if (m.isDestoryed())
                {
                  
                }
               
            }

        }
    
    }
    public void Clickon()
    {
    
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            float x = hit.collider.transform.position.x;
            float y = hit.collider.transform.position.y;
           
            foreach (Unit u in map.Unit)
            {
                if (u.GetType() == typeof(RangedUnits))
                {
                    RangedUnits r = (RangedUnits)u;
                    if (r.Xpos == x && r.Ypos == y)
                    {
                        texts.text = r.Tostring();

                    }
                }
                else if (u.GetType() == typeof(MeleeUnit))
                {
                    MeleeUnit m = (MeleeUnit)u;
                    if (m.Xpos == x && m.Ypos == y)
                    {
                        texts.text = m.Tostring();
                    }
                }
            }
            foreach (FactoryBuilding u in map.Building)
            {
                if (u.GetType() == typeof(FactoryBuilding))
                {
                    FactoryBuilding r = (FactoryBuilding)u;
                    if (r.Xpos == x && r.Ypos == y)
                    {
                        texts.text = r.toString();

                    }
                }
                else if (u.GetType() == typeof(FactoryBuilding))
                {
                    FactoryBuilding m = (FactoryBuilding)u;
                    if (m.Xpos == x && m.Ypos == y)
                    {
                        texts.text = m.toString();
                    }
                }
            }
            foreach (ResourceBuilding u in map.RB)
            {
                if (u.GetType() == typeof(ResourceBuilding))
                {
                    ResourceBuilding r = (ResourceBuilding)u;
                    if (r.Xpos == x && r.Ypos == y)
                    {
                        texts.text = r.toString();

                    }
                }
                else if (u.GetType() == typeof(ResourceBuilding))
                {
                    ResourceBuilding m = (ResourceBuilding)u;
                    if (m.Xpos == x && m.Ypos == y)
                    {
                        texts.text = m.toString();
                    }
                }
            }




        }
    }
    private void UpdateMap()
    {

        foreach (Unit u in map.Unit)
        {
            bool inCombat = false;

            if (u.GetType() == typeof(MeleeUnit))
            {
                MeleeUnit m = (MeleeUnit)u;
                if (m.health > 0)
                {
                    foreach (Unit e in map.Unit) // working code
                    {

                        if (u.AttackRange(e))
                        {
                           
                            u.Combat(e);
                            inCombat = true;
                        }
                        if (!inCombat)
                        {
                            Unit c = u.UnitDistance(map.Unit);
                            m.NewMovePos(m.Directionto(c));
                        }
                    }

                    if (m.health < 100)
                    {


                        switch (Random.Range(0, 4))
                        {

                         

                            case 0: ((MeleeUnit)u).NewMovePos(Direction.Nort); break;
                            case 1: ((MeleeUnit)u).NewMovePos(Direction.East); break;
                            case 2: ((MeleeUnit)u).NewMovePos(Direction.South); break;
                            case 3: ((MeleeUnit)u).NewMovePos(Direction.West); break;

                        }
                    }

                }
                else
                {
                    m.isDead();
                    if (m.isDead())
                    {
                       

                    }
                }

            }

        }
        foreach (Unit u in map.Unit)
        {
            
                bool inCombat = false;

                if (u.GetType() == typeof(RangedUnits))
                {
                    RangedUnits ranged = (RangedUnits)u;
                    if (ranged.health > 0)
                    {
                        foreach (Unit e in map.Unit) // working code
                        {

                            if (u.AttackRange(e))
                            {
                                
                                u.Combat(e);
                                inCombat = true;
                            }
                            if (!inCombat)
                            {
                                Unit c = u.UnitDistance(map.Unit);
                                ranged.NewMovePos(ranged.Directionto(c));
                            }
                        }

                        if (ranged.health < 25)
                        {


                            switch (Random.Range(0, 4))
                            {



                                case 0: ((RangedUnits)u).NewMovePos(Direction.Nort); break;
                                case 1: ((RangedUnits)u).NewMovePos(Direction.East); break;
                                case 2: ((RangedUnits)u).NewMovePos(Direction.South); break;
                                case 3: ((RangedUnits)u).NewMovePos(Direction.West); break;

                            }
                        }

                }
                else
                {
                    ranged.isDead();
                    if (ranged.isDead())
                    {
                        
                    }
                }



            }

        }
        foreach (Unit u in map.Unit)
        {
            bool inCombat = false;

            if (u.GetType() == typeof(Emperor))
            {
                Emperor m = (Emperor)u;
                if (m.health > 0)
                {
                    foreach (Unit e in map.Unit) // working code
                    {

                        if (u.AttackRange(e))
                        {
                           
                            u.Combat(e);
                            inCombat = true;
                        }
                        if (!inCombat)
                        {
                            Unit c = u.UnitDistance(map.Unit);
                            m.NewMovePos(m.Directionto(c));
                        }
                    }

                    if (m.health < 25)
                    {


                        switch (Random.Range(0, 4))
                        {



                            case 0: ((Emperor)u).NewMovePos(Direction.Nort); break;
                            case 1: ((Emperor)u).NewMovePos(Direction.East); break;
                            case 2: ((Emperor)u).NewMovePos(Direction.South); break;
                            case 3: ((Emperor)u).NewMovePos(Direction.West); break;

                        }
                    }

                }
                else
                {
                    m.isDead();
                    if (m.isDead())
                    {
                        
                    }
                }



            }

        }

    }
    public void aaDestroy()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
   void TextChange()
    {
        if (Input.GetMouseButton(0))
        {
            texts.text = "ah";
        }
       
    }
  
    public void save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fsout = new FileStream("Save.dat", FileMode.Create, FileAccess.Write, FileShare.None);

        Debug.Log("Save");
        
            using (fsout)
            {
                bf.Serialize(fsout, map);

               


            }


        
        
    }
    public void load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fsin = new FileStream("Save.dat", FileMode.Open, FileAccess.Read, FileShare.None);

        
            using (fsin)
            {

                map = (Map)bf.Deserialize(fsin);

                
            }
        

      

        UpdateMap();
    }
   public void Pause()
    {
        Time.timeScale = 0;
    }
    public void start()
    {
        Time.timeScale = 1;
    }
    
}
