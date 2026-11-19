using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Media.Effects;
using Vortice.D3DCompiler;
using Vortice.Direct3D11;
using Vortice.Mathematics;
using Vortice.Wpf;
using VorticeDirectX_Sample.Manager;
using Windows_VideoEditor;
using static VorticeDirectX_Sample.Manager.DX3D;

namespace VorticeDirectX_Sample {
    public class Render {

        public static DX3D DX3D {
            get;
        } = new DX3D();

        public static SceneManager SceneManager {
            get;
        } = new SceneManager();

        public static ObjectManager ObjectManager {
            get;
        } = new ObjectManager();

        public static MainWindow? DrawWindow {
            get; private set;
        } = null;

        public static FFMpegEncoder? Encoder {
            get; private set;
        } = new FFMpegEncoder();

        public static byte[] NowPixel {
            get; private set;
        }

        public void Init(MainWindow window, DrawingSurfaceEventArgs e) {
            DrawWindow = window;
            DX3D.Init(e);
            ObjectManager.Init();
            SceneManager.Init();   
        }

        public void Draw(DrawEventArgs e) {
            e.Context.OMSetRenderTargets(e.Surface.ColorTextureView, null);
            e.Context.ClearRenderTargetView(e.Surface.ColorTextureView, new Vortice.Mathematics.Color4(0.0f, 0.0f, 0.0f, 1.0f));
            e.Context.OMSetBlendState(null);
            e.Context.OMSetDepthStencilState(DX3D.DepthStencilState, 0);
            e.Context.IASetInputLayout(DX3D.InputLayout);
            e.Context.RSSetState(DX3D.RasterizerState);
            e.Context.VSSetShader(DX3D.VetexShader);
            e.Context.PSSetShader(DX3D.PixelShader);

            using var resource = e.Surface.ColorTextureView.Resource;
            using var texture = resource.QueryInterface<ID3D11Texture2D>();
            var desc = texture.Description;
            e.Context.RSSetViewport(0, 0, desc.Width, desc.Height);

            SceneManager.Update();

            ObjectManager.UpdateAllObject();
            ObjectManager.DrawAllObject();

            DX3D.InitTexture2D((int) desc.Width, (int) desc.Height);
            e.Context.CopyResource(DX3D.Texture2D, texture);
            var mapped = e.Context.Map(DX3D.Texture2D, 0, MapMode.Read, MapFlags.None);
            int width = (int) desc.Width;
            int height = (int) desc.Height;
            NowPixel = new byte[width * height * 4];
            try {
                for (int y = 0; y < height; y++) {
                    Marshal.Copy(
                        IntPtr.Add(mapped.DataPointer, y * (int)mapped.RowPitch), 
                        NowPixel, 
                        y * width * 4, 
                        width * 4
                        );
                }
            } finally {
                e.Context.Unmap(DX3D.Texture2D, 0);
            }

            e.Context.RSSetState(null);
        }

    }
}
