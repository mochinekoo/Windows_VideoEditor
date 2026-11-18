using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Media.Effects;
using Vortice.Direct3D11;
using Vortice.Mathematics;
using VorticeDirectX11_Template;
using Windows_VideoEditor;
using static VorticeDirectX_Sample.Manager.DX3D;
using Box = VorticeDirectX11_Template.Box;

namespace VorticeDirectX_Sample.Scene {
    public class DebugScene : BaseScene {

        private Box? box = null;

        public DebugScene() : base("DebugScene") {
            
        }

        public override void Init() {
            box = new Box(100.0f, 100.0f);
            Render.ObjectManager.AddObject(box);
        }

        public override void Update() {
            box.Transform.location_.X = ((MainViewModel)Render.DrawWindow.DataContext).ObjectX * 100;
            box.Transform.location_.Y = ((MainViewModel)Render.DrawWindow.DataContext).ObjectY * 100;
            box.Transform.location_.Z = ((MainViewModel)Render.DrawWindow.DataContext).ObjectZ * 100;

            box.Transform.scale_.X = ((MainViewModel)Render.DrawWindow.DataContext).ScaleX;
            box.Transform.scale_.Y = ((MainViewModel)Render.DrawWindow.DataContext).ScaleY;
            box.Transform.scale_.Z = ((MainViewModel)Render.DrawWindow.DataContext).ScaleZ;

            box.Transform.rotation_.X = ((MainViewModel)Render.DrawWindow.DataContext).RotationX;
            box.Transform.rotation_.Y = ((MainViewModel)Render.DrawWindow.DataContext).RotationY;
            box.Transform.rotation_.Z = ((MainViewModel)Render.DrawWindow.DataContext).RotationZ;
        }

        public override void Draw() {

        }

    }
}
