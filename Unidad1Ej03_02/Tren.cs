using System;
using System.Collections.Generic;

namespace Unidad1Ej03_02
{
    public class Tren
    {
        public Tren()
        {
            this.Vagones = new List<Vagon>() { new Vagon(), new Vagon() };
            this.Maquina = new Maquina();
            this.Color = "azul";
            //this.Largo = 10;
        }

        public string Color { set; get; }

        #region EJERCICIO 3

        public int Largo
        {
            /// EJERCICIO 3:  Largo es privada y devuelde la suma de los largos
            /// de la maquina y los vagones
            get
            {
                int largo = this.Maquina.Largo;
                foreach (Vagon AuxVagon in this.Vagones)
                {
                    largo += AuxVagon.Largo;
                }

                return largo;
            }
        }
        #endregion

        #region EJERCICIO 4
        /// EJERCICIO 4: QUE EL COLOR DEL  TREN CAMBIE EL COLOR DE TODAS LAS PARTES!!
        //private string _Color;
        //public string Color
        //{
        //    set
        //    {
        //        this._Color = value;
        //        this.Maquina.Color = value;
        //        foreach (Rueda aux in this.Maquina.Ruedas)
        //        {
        //            aux.Color = value;
        //        }
        //        foreach (Vagon auxVagon in this.Vagones)
        //        {
        //            auxVagon.Color = value;
        //            foreach (Rueda auxRueda in auxVagon.Ruedas)
        //            {
        //                auxRueda.Color = value;
        //            }
        //        }
        //    }
        //    get { return _Color; }
        //}
        #endregion

        #region EJERCICIO 5

        //public string Color {
        //    get
        //    {
        //        // Indica si todos los colores de los que estan pintado las partes son iguales
        //        bool sonIguales = true;
        //        // se toma como color inicial el color de la maquina
        //        string auxColor = this.Maquina.Color;
        //        // me fijo si todas las rueda de la maquina son del mismo color que la maquina
        //        foreach (Rueda auxRueda in Maquina.Ruedas)
        //        {
        //            if(auxColor != auxRueda.Color)
        //            {
        //                sonIguales = false;
        //                break;
        //            }
        //        }

        //        // me fijo si los vagones y sus ruedas son del mismo color de la maquina
        //        if(sonIguales == true)
        //        {
        //            foreach (Vagon auxVagon in this.Vagones)
        //            {
        //                if(auxVagon.Color != auxColor)
        //                {
        //                    sonIguales = false;
        //                    break;
        //                }
        //                foreach (Rueda auxRueda in auxVagon.Ruedas)
        //                {
        //                    if (auxColor != auxRueda.Color)
        //                    {
        //                        sonIguales = false;
        //                        break;
        //                    }
        //                }
        //            }
        //        }

        //        if(sonIguales == false)
        //        {
        //            auxColor = "";
        //        }
        //        return auxColor;

        //    }
        //}





        #endregion

        public Maquina Maquina { set; get; }
        public List<Vagon> Vagones { set; get; }

        /// <summary>
        /// Pinta el tren entero de una mismo color
        /// </summary>
        /// <param name="color">color del que se quiere pintar el tren</param>
        public void Pintar(string color)
        {
            this.Color = color;
            this.Maquina.Color = color;
            foreach (Rueda ruedaAux in this.Maquina.Ruedas)
            {
                ruedaAux.Color = color;
            }
            foreach (Vagon vagonAux in this.Vagones)
            {
                vagonAux.Color = color;
                foreach (Rueda ruedaAux in vagonAux.Ruedas)
                {
                    ruedaAux.Color = color;
                }
            }
        }


        #region Ejercicio1
        /// <summary>
        /// pinta de verde aquellos vagones que posean por lo menos
        /// una rueda de color rojo
        /// </summary>
        /// <returns>Lista de vagones pintados de verde</returns>
        public List<Vagon> PintarVagonesConRuedasRojas()
        {
            /// creo una lista para guardar los vagones pintados de verde
            List<Vagon> VagonesPintadosDeVerde = new List<Vagon>();
            /// busco en cada vagon del tren
            foreach (Vagon AuxVagon in this.Vagones)
            {
                /// Recorro las ruedas del vagon para ver si tiene alguna roja
                bool tieneRuedaRoja = false;
                foreach (Rueda AuxRueda in AuxVagon.Ruedas)
                {
                    if(AuxRueda.Color == "rojo")
                    {
                        tieneRuedaRoja = true;
                        break;
                    }
                }

                // si tiene alguna roja, pinto el vagon de verde y lo agrego  a la lista
                // de vagones pintados de verde
                if(tieneRuedaRoja == true)
                {
                    AuxVagon.Color = "verde";
                    VagonesPintadosDeVerde.Add(AuxVagon);
                }
                
            }

            return VagonesPintadosDeVerde;
        }

        #endregion


        #region Ejercicio2
        public List<Vagon> RemoverVagonesConRuedaRoja()
        {
            List<Vagon> VagonesRemovidos = new List<Vagon>();
            /// busco en cada vagon del tren
            foreach (Vagon AuxVagon in this.Vagones)
            {
                /// Recorro las ruedas del vagon para ver si tiene alguna roja
                bool tieneRuedaRoja = false;
                foreach (Rueda AuxRueda in AuxVagon.Ruedas)
                {
                    if (AuxRueda.Color == "rojo")
                    {
                        tieneRuedaRoja = true;
                        break;
                    }
                }

                // si tiene alguna roja, la agrego a la lista de removidas y la quito de la lista del tren
                if (tieneRuedaRoja == true)
                {
                    VagonesRemovidos.Add(AuxVagon);
                    Vagones.Remove(AuxVagon);
                }

            }


            return VagonesRemovidos;
        }
        #endregion


        #region EJERCICIO 6
        /// <summary>
        /// Filtrar los trenes que tengan al menos un  vagon de un color especificado
        /// y al menos una rueda de radio distinta al resto
        /// </summary>
        /// <param name="trenes">Lista de trenes a ser filtrado</param>
        /// <param name="colorDelVagon">Color que debe cumplir al menos un vagon</param>
        /// <returns>Lista de trenes que cumple con la comdicion especificada</returns>
        private List<Tren> Filtrar(List<Tren> trenes, string colorDelVagon)
        {
            List<Tren> TrenesFiltrados = new List<Tren>();

            foreach (Tren auxtren in trenes)
            {
                bool cumpleCondicionColor = false;
                bool radioRuedasEsDiferente = false;
                foreach (Vagon AuxVagon in auxtren.Vagones)
                {
                    if(AuxVagon.Color == auxtren.Color)
                    {
                        cumpleCondicionColor = true;
                        break;
                    }
                }

                if (cumpleCondicionColor == true)
                {

                    int radioRuedas = auxtren.Maquina.Ruedas[0].Radio;

                    foreach (Rueda auxRueda in auxtren.Maquina.Ruedas)
                    {
                        if (auxRueda.Radio != radioRuedas)
                        {
                            radioRuedasEsDiferente = true;
                        }
                    }

                    if(radioRuedasEsDiferente == false)
                    {
                        foreach (Vagon auxVagon in auxtren.Vagones)
                        {
                            foreach (Rueda AuxRueda in auxVagon.Ruedas)
                            {
                                if(AuxRueda.Radio  != radioRuedas)
                                {
                                    radioRuedasEsDiferente = true;
                                }
                            }
                        }
                    }
                }

                if(radioRuedasEsDiferente == true)
                {
                    TrenesFiltrados.Add(auxtren);
                }
            }




            return TrenesFiltrados;
        }

        #endregion
    }
}
