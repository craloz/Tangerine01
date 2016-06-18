﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M2;
using DatosTangerine.Fabrica;

namespace LogicaTangerine.Comandos.M2.ComandosDAORol
{
    class ComandoObtenerRolUsuario : Comando<DominioTangerine.Entidad>
    {
        public int _codigoRol;

        /// <summary>
        /// Constructor que recibe un parametro codigo rol
        /// </summary>
        /// <param name="usuario"></param>
        public ComandoObtenerRolUsuario(int codigoRol)
        {
            _codigoRol = codigoRol;
        }

        /// <summary>
        /// Método para crear la instancia de la clase DaoRol y usar el método Obtener Rol Usuario
        /// </summary>
        /// <returns>Retorna una instancia del tipo DaoUsuario</returns>
        public override DominioTangerine.Entidad Ejecutar()
        {
            DominioTangerine.Entidad resultado;
            IDAORol rolDAO = FabricaDAOSqlServer.crearDaoRol();
            resultado = rolDAO.ObtenerRolUsuario(_codigoRol);
            return resultado;
        }
    }
}