using Microsoft.DirectX;
using Microsoft.DirectX.DirectInput;
using System.Collections.Generic;
using TGC.Core.Direct3D;
using TGC.Core.Example;
using TGC.Core.Geometries;
using TGC.Core.Textures;
using TGC.Util;
using TGC.Util.Input;

namespace TGC.Group.MiGrupo
{
    /// <summary>
    ///     Ejemplo del alumno
    /// </summary>
    public class EjemploAlumno : TgcExample
    {
        //Caja que se muestra en el ejemplo
        private TgcBox box;

        /// <summary>
        ///     Categor�a a la que pertenece el ejemplo.
        ///     Influye en donde se va a haber en el �rbol de la derecha de la pantalla.
        /// </summary>
        public override string getCategory()
        {
            return "AlumnoEjemplos";
        }

        /// <summary>
        ///     Completar nombre del grupo en formato Grupo NN
        /// </summary>
        public override string getName()
        {
            return "Grupo 99";
        }

        /// <summary>
        ///     Completar con la descripci�n del TP
        /// </summary>
        public override string getDescription()
        {
            return "MiIdea - Descripcion de la idea";
        }

        /// <summary>
        ///     M�todo que se llama una sola vez,  al principio cuando se ejecuta el ejemplo.
        ///     Escribir aqu� todo el c�digo de inicializaci�n: cargar modelos, texturas, modifiers, uservars, etc.
        ///     Borrar todo lo que no haga falta
        /// </summary>
        public override void init()
        {
            //GuiController.Instance: acceso principal a todas las herramientas del Framework

            //Device de DirectX para crear primitivas
            var d3dDevice = D3DDevice.Instance.Device;

            //Carpeta de archivos Media del alumno
            var alumnoMediaFolder = GuiController.Instance.AlumnoMediaDir;

            ///////////////USER VARS//////////////////

            //Crear una UserVar
            GuiController.Instance.UserVars.addVar("variablePrueba");

            //Cargar valor en UserVar
            GuiController.Instance.UserVars.setValue("variablePrueba", 5451);

            ///////////////MODIFIERS//////////////////

            //Crear un modifier para un valor FLOAT
            GuiController.Instance.Modifiers.addFloat("valorFloat", -50f, 200f, 0f);

            //Crear un modifier para un ComboBox con opciones
            string[] opciones = { "opcion1", "opcion2", "opcion3" };
            GuiController.Instance.Modifiers.addInterval("valorIntervalo", opciones, 0);

            //Crear un modifier para modificar un v�rtice
            GuiController.Instance.Modifiers.addVertex3f("valorVertice", new Vector3(-100, -100, -100),
                new Vector3(50, 50, 50), new Vector3(0, 0, 0));

            ///////////////CONFIGURAR CAMARA ROTACIONAL//////////////////
            //Es la camara que viene por default, asi que no hace falta hacerlo siempre
            GuiController.Instance.RotCamera.Enable = true;
            //Configurar centro al que se mira y distancia desde la que se mira
            GuiController.Instance.RotCamera.setCamera(new Vector3(0, 0, 0), 100);

            /*
            ///////////////CONFIGURAR CAMARA PRIMERA PERSONA//////////////////
            //Camara en primera persona, tipo videojuego FPS
            //Solo puede haber una camara habilitada a la vez. Al habilitar la camara FPS se deshabilita la camara rotacional
            //Por default la camara FPS viene desactivada
            GuiController.Instance.FpsCamera.Enable = true;
            //Configurar posicion y hacia donde se mira
            GuiController.Instance.FpsCamera.setCamera(new Vector3(0, 0, -20), new Vector3(0, 0, 0));
            */

            ///////////////LISTAS EN C#//////////////////
            //crear
            var lista = new List<string>();

            //agregar elementos
            lista.Add("elemento1");
            lista.Add("elemento2");

            //obtener elementos
            var elemento1 = lista[0];

            //bucle foreach
            foreach (var elemento in lista)
            {
                //Loggear por consola del Framework
                GuiController.Instance.Logger.log(elemento);
            }

            //bucle for
            for (var i = 0; i < lista.Count; i++)
            {
                var element = lista[i];
            }

            //Cargamos una textura
            var texture = TgcTexture.createTexture(GuiController.Instance.AlumnoMediaDir + "cajaMadera4.jpg");

            //Creamos una caja 3D ubicada en (0, -3, 0), dimensiones (5, 10, 5) y la textura como color.
            var center = new Vector3(0, -3, 0);
            var size = new Vector3(5, 10, 5);
            box = TgcBox.fromSize(center, size, texture);
        }

        /// <summary>
        ///     M�todo que se llama cada vez que hay que refrescar la pantalla.
        ///     Escribir aqu� todo el c�digo referido al renderizado.
        ///     Borrar todo lo que no haga falta
        /// </summary>
        /// <param name="elapsedTime">Tiempo en segundos transcurridos desde el �ltimo frame</param>
        public override void render(float elapsedTime)
        {
            //Device de DirectX para renderizar
            var d3dDevice = D3DDevice.Instance.Device;

            //Obtener valor de UserVar (hay que castear)
            var valor = (int)GuiController.Instance.UserVars.getValue("variablePrueba");

            //Obtener valores de Modifiers
            var valorFloat = (float)GuiController.Instance.Modifiers["valorFloat"];
            var opcionElegida = (string)GuiController.Instance.Modifiers["valorIntervalo"];
            var valorVertice = (Vector3)GuiController.Instance.Modifiers["valorVertice"];

            ///////////////INPUT//////////////////
            //conviene deshabilitar ambas camaras para que no haya interferencia

            //Capturar Input teclado
            if (GuiController.Instance.D3dInput.keyPressed(Key.F))
            {
                //Tecla F apretada
            }

            //Capturar Input Mouse
            if (GuiController.Instance.D3dInput.buttonPressed(TgcD3dInput.MouseButtons.BUTTON_LEFT))
            {
                //Boton izq apretado
            }

            //Render de la caja
            box.render();
        }

        /// <summary>
        ///     M�todo que se llama cuando termina la ejecuci�n del ejemplo.
        ///     Hacer dispose() de todos los objetos creados.
        /// </summary>
        public override void close()
        {
            //Dispose de la caja
            box.dispose();
        }
    }
}