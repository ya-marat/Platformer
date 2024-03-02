using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Dependencies
{

    public interface IHealth
    {
        public int GetHealth();
    }
    
    public class Hero : IHealth
    {
        public int GetHealth()
        {
            return 4;
        }
    }

    public class Enemy : IHealth
    {
        public int GetHealth()
        {
            return 6;
        }
    }

}
