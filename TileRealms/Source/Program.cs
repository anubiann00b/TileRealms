using System;

namespace TileRealms
{
    public static class Program
    {
        static void Main()
        {
            var factory = new MonoGame.Framework.GameFrameworkViewSource<MainGame>();
            Windows.ApplicationModel.Core.CoreApplication.Run(factory);
        }
    }
}
