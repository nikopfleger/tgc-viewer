using System.Drawing;
using TgcViewer;
using TgcViewer.Utils.TgcSceneLoader;
using TGC.Core.Example;

namespace Examples.Otros
{
    /// <summary>
    ///     EjemploDisposeMesh2
    /// </summary>
    public class EjemploDisposeMesh2 : TgcExample
    {
        private TgcScene scene1;

        public override string getCategory()
        {
            return "Otros";
        }

        public override string getName()
        {
            return "Dispose Mesh 2";
        }

        public override string getDescription()
        {
            return "Dispose Mesh 2";
        }

        public override void init()
        {
            var d3dDevice = GuiController.Instance.D3dDevice;

            for (var i = 0; i < 100; i++)
            {
                var loader = new TgcSceneLoader();
                var scene =
                    loader.loadSceneFromFile(GuiController.Instance.ExamplesMediaDir +
                                             "MeshCreator\\Meshes\\Vegetacion\\Palmera\\Palmera-TgcScene.xml");
                scene.disposeAll();
            }

            var loader1 = new TgcSceneLoader();
            scene1 =
                loader1.loadSceneFromFile(GuiController.Instance.ExamplesMediaDir +
                                          "MeshCreator\\Meshes\\Vegetacion\\Palmera\\Palmera-TgcScene.xml");
        }

        public override void render(float elapsedTime)
        {
            var d3dDevice = GuiController.Instance.D3dDevice;

            GuiController.Instance.Text3d.drawText("ok", 100, 100, Color.Red);
            scene1.renderAll();
        }

        public override void close()
        {
            scene1.disposeAll();
        }
    }
}