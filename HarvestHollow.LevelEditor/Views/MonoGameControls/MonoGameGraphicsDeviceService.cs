using System;
using System.Windows;
using System.Windows.Interop;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;

namespace HarvestHollow.LevelEditor.Views.MonoGameControls;

public class MonoGameGraphicsDeviceService : IGraphicsDeviceService, IDisposable
{
    private bool _disposed = false;

    public MonoGameGraphicsDeviceService()
    {
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                DeviceDisposing?.Invoke(this, EventArgs.Empty);
                GraphicsDevice.Dispose();
                Direct3DDevice?.Dispose();
                Direct3DContext?.Dispose();
            }

            _disposed = true;
        }
    }

    ~MonoGameGraphicsDeviceService()
    {
        Dispose(false);
    }

    public Direct3DEx Direct3DContext { get; private set; } = default!;
    public DeviceEx Direct3DDevice { get; private set; } = default!;

    public event EventHandler<EventArgs>? DeviceCreated;
    public event EventHandler<EventArgs>? DeviceDisposing;
    public event EventHandler<EventArgs>? DeviceReset;
    public event EventHandler<EventArgs>? DeviceResetting;

    public void StartDirect3D(Window window)
    {
        Direct3DContext = new Direct3DEx();

        var presentParameters = new PresentParameters
        {
            Windowed = true,
            SwapEffect = SwapEffect.Discard,
            DeviceWindowHandle = new WindowInteropHelper(window).Handle,
            PresentationInterval = SharpDX.Direct3D9.PresentInterval.Default
        };

        Direct3DDevice = new DeviceEx(Direct3DContext, 0, DeviceType.Hardware, IntPtr.Zero,
            CreateFlags.HardwareVertexProcessing | CreateFlags.Multithreaded | CreateFlags.FpuPreserve,
            presentParameters);

        GraphicsDevice = CreateGraphicsDevice(new WindowInteropHelper(window).Handle, 1, 1);
        DeviceCreated?.Invoke(this, EventArgs.Empty);
    }

    private PresentationParameters _parameters = default!;

    public GraphicsDevice GraphicsDevice { get; private set; } = default!;

    public GraphicsDevice CreateGraphicsDevice(IntPtr windowHandle, int width, int height)
    {
        _parameters = new PresentationParameters
        {
            BackBufferWidth = Math.Max(width, 1),
            BackBufferHeight = Math.Max(height, 1),
            BackBufferFormat = SurfaceFormat.Color,
            DepthStencilFormat = DepthFormat.Depth24,
            DeviceWindowHandle = windowHandle,
            PresentationInterval = Microsoft.Xna.Framework.Graphics.PresentInterval.Immediate,
            IsFullScreen = false
        };

        return new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.HiDef, _parameters);
    }

    public void ResetDevice(int width, int height)
    {
        var newWidth = Math.Max(_parameters.BackBufferWidth, width);
        var newHeight = Math.Max(_parameters.BackBufferHeight, height);

        if (newWidth != _parameters.BackBufferWidth || newHeight != _parameters.BackBufferHeight)
        {
            DeviceResetting?.Invoke(this, EventArgs.Empty);

            _parameters.BackBufferWidth = newWidth;
            _parameters.BackBufferHeight = newHeight;

            GraphicsDevice.Reset(_parameters);

            DeviceReset?.Invoke(this, EventArgs.Empty);
        }
    }
}
