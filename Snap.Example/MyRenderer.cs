using SFML.Graphics;
using SFML.Window;
using Snap.Graphical;
using Snap.Graphical.Grids;
using Snap.Graphical.Grids.Isometric;
using Snap.Graphical.Grids.Orthogonal;
using Snap.Graphical.Maps;
using Snap.Graphical.Textures;
using Snap.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Example
{
    public class MyRenderer : Renderer
    {
        Map Map
        {
            get;
            set;
        }

        KeyboardCamera Camera
        {
            get;
            set;
        }

        public MyRenderer(VideoMode mode, string title, ContextSettings settings, Styles styles = Styles.Default) : base(mode, title, settings, styles)
        {
            var grid = new GridOrthogonal(Window, new SFML.System.Vector2f(100, 100), 10, 10, Color.Black, false);
            this.Map = new Map(grid);

            this.Camera = new KeyboardCamera(this.Window, 1f);

            var texture = TextureManager.GetTextureRecord("tile");
            var cell = Map.Grid.GetCell(0);

            Map.AddElement(LayerEnum.Ground, cell, texture);
        }

        protected override void Draw()
        {
            this.Camera.Update();
            this.Map.Draw(Window);
        }
    }
}
