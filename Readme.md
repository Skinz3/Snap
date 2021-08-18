<p align="center">
  <img src="Misc/logo.png" />
</p>



# Hi there

  Snap is a framework on top of SFML.NET proving a lot of utility and an architectural proposal to make a 2D game.
  Written in C# .NET Core 3.1, this library is multiplateform. 

  ![](https://www.repostatus.org/badges/latest/wip.svg)

1. [Renderer](#Renderer)
2. [Grids](#Grids)
3. [Pathfinding](#Pathfinding)
4. [Textures](#Textures)  
5. [Maps](#Maps)  
6. [Animations](#Animations)
7. [Fonts](#Fonts)
8. [Lightning](#Lightnings)
9. [Physics](#Physics)
10. [Collisions](#Collisions)
11. [Network](#Network)
12. [Sounds](#Sounds)
13. [Serialization](#Serialization)
14. [Utils](#Utils)

# Renderer

* The Snap.Renderer class encapsulates the render window and how it works. It is an abstract class. Here an example :

```csharp
 public class MyRenderer : Renderer
    {
        public MyRenderer(VideoMode mode, string title, ContextSettings settings, Styles styles = Styles.Default) : base(mode, title, settings, styles)
        {
            // Create your ressources here
        }

        protected override void Draw()
        {
            // Draw your ressources here
        }
    }
```

# Grids

* For each grid, there are events dealing with user inputs. The constructor parameter of Grid handleEvents disables the handling of these events,
  this increases performance on large grids. 

```csharp
public delegate void MouseEvent(T cell);
public event MouseEvent OnMouseEnter;
public event MouseEvent OnMouseLeave;
public event MouseEvent OnMouseRightClick;
public event MouseEvent OnMouseLeftClick;
```
* In order to improve performance, cells are drawn using OpenGL primitives (``` SFML.Graphics.VertexBuffer ```). 
* These grids can be used to represent worldmaps [Maps](#Maps) and perform path find calculations [Pathfinding](#Pathfinding)
* There are several methods for performing geometric calculations in order to recover cells according to their relative position, their position on the   world, or even to cast ray in a given direction.  

## Orthogonal Grid

* Namespace : ```Snap.Grids.GridOrthogonal```

* Represents a two-dimensional orthogonal grid. Used to map tiles in a side scroller or top down game. 

* In order to use the grids properly, we must call ```Grid.Build()``` after its instantation. 
 
![](Misc/orth.png)

## Isometric Grid

* Namespace : ```Snap.Grids.GridIsometric```

* Represents an isometric grid. (The three coordinate axes appear equally foreshortened and the angle between any two of them is 120 degrees.)

![](Misc/isometric.png)

# Pathfinding

* Namespace : ``` Snap.Paths.Pathfinder ```

* Snap contains a pathfinder, working with ```Snap.Grids```. This pathfinder is an optimized implementation of AStar Algorithm (https://en.wikipedia.org/wiki/A*_search_algorithm)

* Pathfinder constructor takes two arguments. ``` public Pathfinder(Grid grid, ICellMetaProvider cellMetaProvider) ```. 
* ``` ICellMetaProvider ``` is an interface that you will need to implement. It provides information on obstacles.

* This pathfinding algorithm assumes that there are eight possible cell-to-cell directions. This parameter can be reduced to 4 depending on the ```diagonal``` parameter of the ``` Pathfinder.FindPath()``` method.

# Textures

  > WIP

# Maps

  > WIP

# Utils

## Camera2D

* Camera2D is what you need if you want to scroll, rotate or zoom your world. They are also the key to creating split screens and mini-maps.
  you can use ``` Move(Vector2f delta) ``` to move the camera. 

  > WIP

## KeyboardCamera

  > WIP