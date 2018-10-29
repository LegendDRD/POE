using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[System.Serializable]

public class Map
    {

    Random r = new Random();

    private ResourceBuilding[] rb;
    int buildingx;
    public ResourceBuilding[] RB
    {
        get { return rb; }
        set { rb = value; }
    }




    private Unit[] unit;


    public Unit[] Unit
    {
        get { return unit; }
        set { unit = value; }
    }

    private Building[] building;

    public Building[] Building
    {
        get { return building; }
        set { building = value; }
    }


    public Map(int maxX, int maxY, int numUnits, int numbuilding)
    {
        building = new Building[numbuilding];
        rb = new ResourceBuilding[numbuilding];
        unit = new Unit[numUnits];
        for (int i = 0; i < numUnits; i++)
        {
          

            if (i <= 10)
            {
                
                MeleeUnit M = new MeleeUnit(r.Next(0, maxX), r.Next(0, maxY), r.Next(60, 100) * 10, r.Next(5, 20), 1, 1, i % 2, "=", "Knight");
                Unit[i] = M;
            }


            if (i > 10 && i < 20)
            {
                RangedUnits R = new RangedUnits(r.Next(0, maxX), r.Next(0, maxY), r.Next(10, 20) * 10, r.Next(5, 20), 1, 1, i % 2, "}", "Archer");
                Unit[i] = R;
            }

            if (i >= 20 && i < 22)
            {
                Emperor E = new Emperor(r.Next(0, maxX), r.Next(0, maxY), r.Next(10, 20) * 10, r.Next(5, 20), 1, 1, i % 2, "#", "Emperor");
                unit[i] = E;
            }
            if (i >= 22 && i < 27)
            {
                RangedUnits E = new RangedUnits(r.Next(0, maxX), r.Next(0, maxY), r.Next(10, 20) * 10, r.Next(5, 20), 1, 1, i % 2, "->", "Muksmen");
                unit[i] = E;
            }
            if (i > 26)
            {
                MeleeUnit Lance = new MeleeUnit(r.Next(0, maxX), r.Next(0, maxY), r.Next(10, 20) * 10, r.Next(5, 20), 1, 1, i % 2, ">", "Lance");
                unit[i] = Lance;
            }

        }
        for (int i = 0; i < numbuilding; i++)
        {


            if (i <= 5)
            {
                FactoryBuilding fb = new FactoryBuilding(r.Next(-14, 20), r.Next(-22, maxY), r.Next(5, 20), 1, "F", r.Next(0, 1), r.Next(5, 10), buildingx);
                building[i] = fb;
            }


            if (i > 5)
            {
                FactoryBuilding fbr = new FactoryBuilding(r.Next(50, maxX), r.Next(-22,maxY ), r.Next(5, 20), 0, "F", r.Next(0, 1), r.Next(5, 10), buildingx);
                building[i] = fbr;
            }
        }
        for (int i = 0; i < numbuilding; i++)
        {


            if (i <= 5)
            {
                ResourceBuilding fb = new ResourceBuilding(r.Next(-14, 20), r.Next(-22, maxY), r.Next(5, 20), 1, "RB", r.Next(0, 1), r.Next(5, 10), 400);
                rb[i] = fb;
            }


            if (i > 5)
            {
                ResourceBuilding fbr = new ResourceBuilding(r.Next(50,80), r.Next(-22, maxY), r.Next(5, 20), 0, "RB", r.Next(0, 1), r.Next(5, 10), 400);
                rb[i] = fbr;
            }
        }


    }
}

    

