using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Snap;
using Snap.Grids;
using Snap.Grids.Isometric;
using Snap.Grids.Orthogonal;
using Snap.Maps;
using Snap.Paths;
using Snap.Textures;
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
            var grid = new GridOrthogonal(Window, new Vector2f(100, 100), new Vector2i(10, 10), Color.Black, 50, false);
            grid.Build();

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
