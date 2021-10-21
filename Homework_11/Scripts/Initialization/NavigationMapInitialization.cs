using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationMapInitialization: IInitialize
{

    private NavMeshSurface _navMeshSurfaces;
    
    public NavigationMapInitialization(NavMeshSurface navMeshSurface)
    {
        _navMeshSurfaces = navMeshSurface;
        _navMeshSurfaces.BuildNavMesh();
    }
    
    public void Initialize()
    {
        
    }
    
}
