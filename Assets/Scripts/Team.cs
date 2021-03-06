﻿using System;
using System.Collections.Generic;

public class Team
{
    public static readonly int MAX_SIZE = 5;
    private List<Creature> creatures;

    public Team(List<Creature> creatures)
    {
        if (creatures.Count > MAX_SIZE)
            throw new System.Exception("Cannot have a team of size " + creatures.Count);

        this.creatures = creatures;
    }

    public List<Creature> getCreatures()
    {
        return creatures;
    }
    public Creature getFirst()
    {
        return creatures[0];
    }

    public Creature getSecond()
    {
        return creatures[1];
    }

    public Creature getCreatureInPosition(int pos)
    {
        if (!posExists(pos))
            return null;

        return creatures[pos];
    }

    public void swapPosition(int pos1, int pos2)
    {
        if (!(posExists(pos1) && posExists(pos2)))
            throw new System.Exception("Cannot swap when positions are out of bounds");

        Creature first = creatures[pos1];
        Creature second = creatures[pos2];
        creatures[pos1] = second;
        creatures[pos2] = first;
    }

    public bool posExists(int pos)
    {
        return pos >= 0 && pos <= creatures.Count;
    }


}
