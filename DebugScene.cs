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

        public DebugScene() : base("DebugScene") {
            
        }

        public override void Init() {
            Render.ObjectManager.AddObject(new Box(100.0f, 100.0f));
        }

        public override void Update() {
        }

        public override void Draw() {

        }

    }
}
