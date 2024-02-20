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

    public class Game : IInitializable
    {
        [Inject] private IHealth _health;
        
        public void Initialize()
        {
            Debug.Log($"Game init {_health.GetHealth()}");
        }
    }
    
    public class Scene : IInitializable
    {
        [Inject] private IHealth _health;
        
        public void Initialize()
        {
            Debug.Log($"Game init {_health.GetHealth()}");
        }
    }
}
