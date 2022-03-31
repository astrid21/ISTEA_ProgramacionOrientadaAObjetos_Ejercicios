using System;
using System.Collections.Generic;


namespace ParcialUTN
{
    class Program
    {
        static void Main(string[] args)
        {

            Marvel.Personaje = new Avenger("Anthony Stark", new List<EHabilidades>() { EHabilidades.InteligenciaSuperior }, EEquipamiento.Armadura);
            Marvel.Personaje = new Avenger("Anthony Stark", new List<EHabilidades>() { EHabilidades.InteligenciaSuperior }, EEquipamiento.Armadura);
            Marvel.Personaje = new Avenger("Dr Banner", new List<EHabilidades>() { EHabilidades.InteligenciaSuperior }, EEquipamiento.Transformacion);
            Marvel.Personaje = new Avenger("Dr Banner", new List<EHabilidades>() { EHabilidades.InteligenciaSuperior }, EEquipamiento.Transformacion);
            Marvel.Personaje = new Avenger("Natasha Romanoff ", new List<EHabilidades>() { EHabilidades.Sigilo, EHabilidades.Astucia }, EEquipamiento.ArtesMarciales);
            Marvel.Personaje = new Avenger("Thor", new List<EHabilidades>() { EHabilidades.Rayos, EHabilidades.Volar }, EEquipamiento.Martillo);

            Marvel.Personaje = new Enemigo("Thanos", new List<EHabilidades>() { EHabilidades.SuperFuerza, EHabilidades.Astucia, EHabilidades.Resistencia }, "Obtener las infinity stones y un te de vainilla");
            Marvel.Personaje = new Enemigo("Ultron", new List<EHabilidades>() { EHabilidades.SuperFuerza, EHabilidades.Astucia, EHabilidades.Volar }, "Exterminar a los humanos");
            Marvel.Personaje = new Enemigo("Loki", new List<EHabilidades>() { EHabilidades.Astucia }, "Dominar los 9 reinos");

            Marvel.MostrarInformacion();
            Console.ReadLine();
        }
    }
}
