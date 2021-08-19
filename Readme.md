<p align="center">
  <img src="Misc/logo.png" />
</p>

# Hi there

  Snap is a game engine on top of SFML.NET proving a lot of utility and an architectural proposal to make a 2D game.
  Written in C# .NET Core 3.1, this library is multiplatform. 

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

* The Renderer class is a parent node of your game. It manages the render window (or the targeted handle) and the gameloop. This is an abstract class that you need to implement. 

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
* Grids can be used to represent worldmaps ([Maps](#Maps)) and perform path find calculations ([Pathfinding](#Pathfinding))
* For each grid, there are events dealing with user inputs. The constructor parameter of Grid handleEvents disables the handling of these events,
  this increases performance on large grids. 

```csharp
public delegate void MouseEvent(T cell);
public event MouseEvent OnMouseEnter;
public event MouseEvent OnMouseLeave;
public event MouseEvent OnMouseRightClick;
public event MouseEvent OnMouseLeftClick;
```
* In order to improve performance, cells are drawn using **OpenGL primitives** (``` SFML.Graphics.VertexBuffer ```). 
* There are several methods for performing geometric calculations in order to recover cells according to their relative position, their position on the   world, or even to cast ray in a given direction.  
* In order to use the grids properly, we must call ```Grid.Build()``` after its instantation. 

## Orthogonal Grid

* Namespace : ```Snap.Grids.GridOrthogonal```

* Represents a two-dimensional orthogonal grid. Used to map tiles in a side scroller or top down game. 
 
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

## Texture Manager

* Namespace : ``` Snap.Textures.TextureManager ```

* TextureManager is a singleton allowing to manage the textures of all renderers. This class works as a cache during program execution. . 
  The class must be initialized when the program is started. The path to the textures must be specified in parameters of the ```TextureManager.Initialize(String path,bool pixelInterpolation = false)``` method. 

* It is possible to retrieve all the textures thanks to the ```TextureManager.FindAll()``` method 
* The ```TextureManager.GetRecord(String name)``` function loads a texture into memory if it has not been loaded and returns the result. It is also possible to unload it using the ```TextureManager.Unload(String name)``` function.

# Maps

  * Namespace : ```Snap.Maps.Map ```

  * As the name suggests, Maps are a way to map tiles onto a grid. 
  * In Snap, a map is built from a grid. (Isometric or Orthogonal) and is divided into several layers. 
    The layers drawn one on top of the other. ```LayerEnum``` is used to enumerate them. It is possible to add up to 8 layers to a 2D map. 

  * It is possible to add a tile to the map using the ```Map.AddElement(LayerEnum layer, Cell cell, ElementRecord element)``` method. 
    The element is automatically placed in the center of the cell but will not be resized. You can perform resizing operations beforehand on the affected sprites.  

# Utils

## Camera2D

* Camera2D is what you need if you want to scroll, rotate or zoom your world. They are also the key to creating split screens and mini-maps.
  you can use ``` Move(Vector2f delta) ``` to move the camera. 

  > WIP

## KeyboardCamera

  > WIP
