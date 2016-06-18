﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesTangerine;
using DominioTangerine;
using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M8;

namespace LogicaTangerine.Comandos.M8
{
    /// <summary>
    /// Comando para consultar una factura
    /// </summary>
    public class ComandoConsultarXIdFactura : Comando<Entidad>
    {
        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="parametro">Factura a consultar</param>
        public ComandoConsultarXIdFactura(Entidad parametro)
        {
            LaEntidad = parametro;
        }

        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <returns>booleano que refleja el exito de la ejecucion del comando</returns>
        public override Entidad Ejecutar()
        {
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                , ResourceLogicaM8.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                IDaoFactura daoFactura = FabricaDAOSqlServer.ObtenerDAOFactura();
                return daoFactura.ConsultarXId(this.LaEntidad);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceLogicaM8.Codigo_Error_Formato,
                     ResourceLogicaM8.Mensaje_Error_Formato, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceLogicaM8.Mensaje_Generico_Error, ex);
            }
        }
    }
}