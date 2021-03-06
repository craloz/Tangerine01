﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO;
using DatosTangerine.InterfazDAO;
using DatosTangerine.InterfazDAO.M7;
using DatosTangerine.InterfazDAO.M2;
using DatosTangerine.InterfazDAO.M5;
using DatosTangerine.InterfazDAO.M4;
using DatosTangerine.InterfazDAO.M10;
using DatosTangerine.InterfazDAO.M8;
using DatosTangerine.InterfazDAO.M3;
using DatosTangerine.InterfazDAO.M9;

namespace DatosTangerine.Fabrica
{
    public class FabricaDAOSqlServer
    {
        #region Modulo 1
        
        #endregion

        #region Modulo 2

        /// <summary>
        /// Método que crea la instancia de DAO Usuario
        /// </summary>
        /// <returns>Retorna la instancia a la clase DaoUsuario</returns>
        static public IDAOUsuarios crearDaoUsuario()
        {
            return new DAO.M2.DAOUsuario();
        }

        /// <summary>
        /// Método que crea la instancia de DAO Rol
        /// </summary>
        /// <returns>Retorna la instancia a la clase DaoRol</returns>
        static public IDAORol crearDaoRol()
        {
            return new DAO.M2.DAORol();
        }

        #endregion

        #region Modulo 3
        /// <summary>
        /// Método que crea la instancia de DAO ClientePotencial
        /// </summary>
        /// <returns>Retorna la instancia a la clase DaoClientePotencial</returns>
        static public IDAOClientePotencial CrearDaoClientePotencial()
        {
            return new DAO.M3.DaoClientePotencial();
        }
        #endregion

        #region Modulo 4

        /// <summary>
        /// Metodo que crea la instancia de DAO Compania
        /// </summary>
        /// <returns>Retorna la instancia a la clase DaoCompania</returns>

        static public IDaoCompania crearDaoCompania()
        {
            return new DAO.M4.DaoCompania();
        }

        /// <summary>
        /// Metodo que crea la instancia de DAO LugarDireccion
        /// </summary>
        /// <returns>Retorna la instancia a la clase DaoLugarDireccion</returns>

        static public IDaoLugarDireccion crearDaoLugarDireccion()
        {
            return new DAO.M4.DaoLugarDireccion();
        }


        #endregion

        #region Modulo 5
        /// <summary>
        /// Método para instancear DAOContacto
        /// </summary>
        /// <returns></returns>
        public static IDAOContacto crearDAOContacto() 
        {
            return new DAO.M5.DAOContacto();
        }
        #endregion

        #region Modulo 6

        /// <summary>
        /// Metodo que crea la instancia de DAO Propuesta
        /// </summary>
        /// <returns>La instancia</returns>
        public static InterfazDAO.M6.IDAOPropuesta CrearDAOPropuesta()
        {
            return new DAO.M6.DAOPropuesta();
        }

        /// <summary>
        /// Metodo que crea la instancia de DAO Requerimiento
        /// </summary>
        /// <returns>La instancia</returns>
        public static InterfazDAO.M6.IDAORequerimiento CrearDAORequerimiento()
        {
            return new DAO.M6.DAORequerimiento();
        }

        #endregion

        #region Modulo 7

        /// <summary>
        /// Metodo que crea la instancia de DAO Proyecto
        /// </summary>
        /// <returns>La instancia</returns>
        public static IDaoProyecto ObetenerDaoProyecto()
        {
            return new DAO.M7.DaoProyecto();
        }

        /// <summary>
        /// Metodo que crea la instancia de DAO Proyecto Contacto
        /// </summary>
        /// <returns>La instancia</returns>
        public static IDaoProyectoContacto ObetenerDaoProyectoContacto()
        {
            return new DAO.M7.DaoProyectoContacto();
        }

        /// <summary>
        /// Metodo que crea la instancia de DAO Proyecto Empleado
        /// </summary>
        /// <returns>La instancia</returns>
        public static IDaoProyectoEmpleado ObetenerDaoProyectoEmpleado()
        {
            return new DAO.M7.DaoProyectoEmpleado();
        }
        #endregion

        #region Modulo 8

        /// <summary>
        /// Método que crea la instancia de DAO Factura
        /// </summary>
        /// <returns>Retorna la instancia a la clase DaoFactura</returns>
        public static IDaoFactura ObtenerDAOFactura()
        {
            IDaoFactura _IDaoFactura = new DAO.M8.DAOFactura();
            return _IDaoFactura;
        }

        #endregion

        #region Modulo 9
        /// <summary>
        /// Metodo que instancia al objeto DAOPago
        /// </summary>
        /// <returns>Retorna el objeto DAOPago</returns>
        public static IDAOPago CrearDAOPago()

        {
            return new DAO.M9.DAOPago();
        }

        #endregion

        #region Modulo 10

        /// <summary>
        /// Metodo que crea la instacia de DAO Empleado
        /// </summary>
        /// <returns></returns>
        public static IDAOEmpleado  ConsultarDAOEmpleado()
        {
            return new DAO.M10.DAOEmpleado();
        }

        /// <summary>
        /// Metodo que crea la instacia de DAO Empleado consultar por id
        /// </summary>
        /// <returns></returns>
        public static IDAOEmpleado ConsultarDAOEmpleadoId()
        {
            return new DAO.M10.DAOEmpleado(); 
        }

        /// <summary>
        ///Metodo que crea la instacia de DAO Empleado para habilitar/inhabilitar un empleado
        /// </summary>
        /// <returns></returns>
        public static IDAOEmpleado EstatusDAOEmpleado()
        {
            return new DAO.M10.DAOEmpleado();
        }

        /// <summary>
        ///Metodo que crea la instacia de DAO Empleado Obtener paises
        /// </summary>
        /// <returns></returns>
        public static IDAOEmpleado ObtenerIDaoPaises()
        {
            return new DAO.M10.DAOEmpleado();
        }       

         /// <summary>
        ///Metodo que crea la instacia de DAO Empleado para los cargos
        /// </summary>
        /// <returns></returns>
        public static IDAOEmpleado ObtenerIDaoCargo()
        {
            return new DAO.M10.DAOEmpleado();
        }

        /// <summary>
        /// Metodo que crea la instacia de DAO Empleado para los estados
        /// </summary>
        /// <returns></returns>
        public static IDAOEmpleado ObtenerIDaoEstados()

        {
            return new DAO.M10.DAOEmpleado();
        }

        /// <summary>
        /// Metodo que trae el usuario
        /// </summary>
        /// <returns></returns>
        public static IDAOEmpleado ObtenerUsuarioCorreo()
        {
            return new DAO.M10.DAOEmpleado();
        }

        /// Metodo que agrega un empleado
        /// </summary>
        /// <returns></returns>

        public static IDAOEmpleado CrearDAOEmpleado()
        {
            return new DAO.M10.DAOEmpleado();
        }

        #endregion

    }
}
