﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.M6;
using LogicaTangerine.M6;
using DominioTangerine;

namespace PruebasUnitarias.M6
{
    public class PruebasDAORequerimiento
    {
        #region Atributos

        private DominioTangerine.Entidades.M6.Propuesta laPropuesta, laPropuesta2, laPropuesta3;
        private DateTime Date1, Date2;
        private List<DominioTangerine.Entidad> listaRequerimientos;
        private DominioTangerine.Entidades.M6.Requerimiento elRequerimiento, elRequerimiento2, elRequerimiento3;
        Boolean confirmacion;
        #endregion


        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            Date1 = new DateTime(2016, 6, 4);
            Date2 = new DateTime(2016, 7, 4);
            laPropuesta = new DominioTangerine.Entidades.M6.Propuesta("NombrePropuestaPrueba", "DescripcionProPuestaPrueba", "Meses", "2", "acuerdo", "PendientePrueba", "Dolar", 1, Date1, Date2, 100, "1");


            elRequerimiento = new DominioTangerine.Entidades.M6.Requerimiento("NombreRequerimiento1", "DescripcionRequerimientoPrueba1", "NombrePropuestaPrueba");
        }
        [TearDown]
        public void Clean()
        {
            laPropuesta = null;
            laPropuesta2 = null;
            elRequerimiento = null;
            elRequerimiento2 = null;
        }


        #endregion

        // <summary>
        //Prueba que se agrega un requerimiento
        // </summary>

        [Test]
        public void TestAgregarRequerimiento()
        {
            //Se crea un objeto DAO para poder realizar la inserción.
            DatosTangerine.InterfazDAO.M6.IDAOPropuesta dao = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPropuesta();
            DatosTangerine.InterfazDAO.M6.IDAORequerimiento daor = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAORequerimiento();
            //Se inserta la propuesta
            Assert.IsTrue(dao.Agregar(laPropuesta));
            //Agregar un Requerimiento y pruebo que se agregó
            Assert.IsTrue(daor.Agregar(elRequerimiento));
            //Pruebo que el requerimiento pertenece a la propuesta que acabo de agregar
            listaRequerimientos = daor.ConsultarRequerimientosXPropuesta("NombrePropuestaPrueba");
            Assert.AreEqual("NombreRequerimiento1", ((DominioTangerine.Entidades.M6.Requerimiento)listaRequerimientos.ElementAt(0)).CodigoRequerimiento);
            Assert.AreEqual("DescripcionRequerimientoPrueba1", ((DominioTangerine.Entidades.M6.Requerimiento)listaRequerimientos.ElementAt(0)).Descripcion);
            Assert.AreEqual("NombrePropuestaPrueba", ((DominioTangerine.Entidades.M6.Requerimiento)listaRequerimientos.ElementAt(0)).CodigoPropuesta);

            //Elimino la propuesta de prueba junto con el requerimiento
            confirmacion = dao.BorrarPropuesta("NombrePropuestaPrueba");
        }

        // <summary>
        //Prueba que se modifique un requerimiento
        // </summary>
        [Test]
        public void TestModificarRequerimiento()
        {
            //Se crea un objeto DAO para poder realizar la inserción.
            DatosTangerine.InterfazDAO.M6.IDAOPropuesta dao = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPropuesta();
            DatosTangerine.InterfazDAO.M6.IDAORequerimiento daor = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAORequerimiento();
            elRequerimiento2 = new DominioTangerine.Entidades.M6.Requerimiento("NombreRequerimiento1", "DescripcionRequerimientoPrueba1Modificado", "NombrePropuestaPrueba");
            //Se inserta la propuesta
            Assert.IsTrue(dao.Agregar(laPropuesta));
            //Agregar un Requerimiento y pruebo que se agregó
            Assert.IsTrue(daor.Agregar(elRequerimiento));
            //Modifico el requerimiento
            Assert.IsTrue(daor.Modificar(elRequerimiento2));
            //Consulto el requerimiento modificado 
            listaRequerimientos = daor.ConsultarRequerimientosXPropuesta("NombrePropuestaPrueba");
            Assert.AreEqual("NombreRequerimiento1", ((DominioTangerine.Entidades.M6.Requerimiento)listaRequerimientos.ElementAt(0)).CodigoRequerimiento);
            Assert.AreEqual("DescripcionRequerimientoPrueba1Modificado", ((DominioTangerine.Entidades.M6.Requerimiento)listaRequerimientos.ElementAt(0)).Descripcion);
            Assert.AreEqual("NombrePropuestaPrueba", ((DominioTangerine.Entidades.M6.Requerimiento)listaRequerimientos.ElementAt(0)).CodigoPropuesta);

            //Elimino la propuesta de prueba junto con el requerimiento
            confirmacion = dao.BorrarPropuesta("NombrePropuestaPrueba");

        }

        // <summary>
        //Prueba que se consulten requerimientos por propuesta
        // </summary>
        [Test]
        public void ConsultarRequerimientosXPropuesta()
        {
            //Se crea un objeto DAO para poder realizar la inserción.
            DatosTangerine.InterfazDAO.M6.IDAOPropuesta dao = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPropuesta();
            DatosTangerine.InterfazDAO.M6.IDAORequerimiento daor = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAORequerimiento();
            elRequerimiento2 = new DominioTangerine.Entidades.M6.Requerimiento("NombreRequerimiento1", "DescripcionRequerimientoPrueba", "NombrePropuestaPrueba");
            elRequerimiento3 = new DominioTangerine.Entidades.M6.Requerimiento("NombreRequerimiento2", "DescripcionRequerimientoPrueba2", "NombrePropuestaPrueba");
            //Se inserta la propuesta
            Assert.IsTrue(dao.Agregar(laPropuesta));
            //Agregar un Requerimiento y pruebo que se agregó
            Assert.IsTrue(daor.Agregar(elRequerimiento));
            Assert.IsTrue(daor.Agregar(elRequerimiento2));
            Assert.IsTrue(daor.Agregar(elRequerimiento3));
            listaRequerimientos = daor.ConsultarRequerimientosXPropuesta("NombrePropuestaPrueba");
            foreach (Entidad requerimiento in listaRequerimientos)
            {
                Assert.AreEqual(((DominioTangerine.Entidades.M6.Requerimiento)requerimiento).CodigoPropuesta, "NombrePropuestaPrueba");
            }
            //Elimino la propuesta de prueba junto con los requerimientos
            confirmacion = dao.BorrarPropuesta("NombrePropuestaPrueba");
        }
    }
}