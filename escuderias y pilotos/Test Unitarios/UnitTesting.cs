using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Entidades;
using System.Collections.Generic;

namespace Test_Unitarios
{
    [TestClass]
    public class UnitTesting
    {
        [TestMethod]
        [ExpectedException(typeof(CaracteresInvalidoException))]
        public void TestCaracteresInvalidos()
        {
            Piloto piloto = new Piloto(" ", " ", 20, ESexo.Masculino, 50, true);
        }

        [TestMethod]
        [ExpectedException(typeof(PilotoRepetidoException))]
        public void TestAgregarPilotoRepetido()
        {
            Piloto p1 = new Piloto("Luciano", "Crocco", 21, ESexo.Masculino, 67, true);
            Piloto p2 = new Piloto("Luciano", "Crocco", 21, ESexo.Masculino, 67, true);
            List<Piloto> pilotos = new List<Piloto>();

            pilotos += p1;
            pilotos += p2;
        }

        [TestMethod]
        public void TestMismoPiloto()
        {
            Piloto p1 = new Piloto("Luciano", "Crocco", 21, ESexo.Masculino, 67, true);
            Piloto p2 = new Piloto("Luciano", "Crocco", 21, ESexo.Masculino, 67, true);
            List<Piloto> pilotos = new List<Piloto>();

            bool estaRepetido = p1 == p2;

            Assert.IsTrue(estaRepetido);
        }

        [TestMethod]
        public void TestDistintoPiloto()
        {
            Piloto p1 = new Piloto("Luciano", "Crocco", 20, ESexo.Masculino, 50, true);
            Piloto p2 = new Piloto("Luciano", "Crocco", 20, ESexo.Masculino, 67, true);
            List<Piloto> pilotos = new List<Piloto>();

            bool estaRepetido = p1 == p2;

            Assert.IsFalse(estaRepetido);
        }

        [TestMethod]
        [ExpectedException(typeof(EscuderiaRepetidaException))]
        public void TestAgregarEscuderiaRepetida()
        {
            EscuderiaTC e1 = new EscuderiaTC("Torino Racing", 5, EMarcaVehiculoTC.Torino);
            EscuderiaTC e2 = new EscuderiaTC("Torino Racing", 5, EMarcaVehiculoTC.Torino);
            List<Escuderia> escuderias = new List<Escuderia>();

            escuderias += e1;
            escuderias += e2;
        }

        [TestMethod]
        [ExpectedException(typeof(EscuderiaNoEncontradaException))]
        public void TestBuscarEscuderiaNoCargada()
        {
            EscuderiaTC e1 = new EscuderiaTC("Torino Racing", 5, EMarcaVehiculoTC.Torino);
            List<Escuderia> escuderias = new List<Escuderia>();

            escuderias -= e1;
        }

        [TestMethod]
        [ExpectedException(typeof(PilotoRepetidoException))]
        public void TestAñadirMismoPiloto()
        {
            bool aux;
            EscuderiaTC e1 = new EscuderiaTC("Torino Racing", 5, EMarcaVehiculoTC.Torino);
            Piloto p1 = new Piloto("Luciano", "Crocco", 20, ESexo.Masculino, 67, true);
            Piloto p2 = new Piloto("Luciano", "Crocco", 20, ESexo.Masculino, 67, true);

            aux = e1 + p1;
            aux = e1 + p2;
        }

        [TestMethod]
        public void TestMismaEscuderia()
        {
            EscuderiaTC e1 = new EscuderiaTC("Torino Racing", 5, EMarcaVehiculoTC.Torino);
            EscuderiaTC e2 = new EscuderiaTC("Torino Racing", 3, EMarcaVehiculoTC.Torino);
            List<Escuderia> escuderias = new List<Escuderia>();

            escuderias += e1;
            bool estaRepetido = escuderias == e2;

            Assert.IsTrue(estaRepetido);
        }
    }
}
