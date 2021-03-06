﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioTangerine;
using ExcepcionesTangerine;
using DominioTangerine.Entidades.M8;
using DatosTangerine.InterfazDAO.M8;
using DominioTangerine.Entidades.M4;

namespace DatosTangerine.DAO.M8
{
    public class DAOFactura : DAOGeneral, IDaoFactura
    {
        Parametro theParam = new Parametro();

        #region IDAO

        /// <summary>
        /// Metodo para agregar una factura nuevo en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Facturacion para agregar en bd</param>
        /// <returns>true si fue agregado</returns>
        public bool Agregar(Entidad parametro)
        {
            List<Parametro> parameters = new List<Parametro>();
            Parametro theParam = new Parametro();
            Facturacion theFactura = (Facturacion) parametro;

            try
            {
                theParam = new Parametro
                    (ResourceFactura.ParamFecha_Emision, SqlDbType.DateTime, theFactura.fechaFactura.ToString(), 
                        false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamFecha_Ultimo_Pago, SqlDbType.DateTime, 
                        theFactura.fechaUltimoPagoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Total, SqlDbType.Int,
                    theFactura.montoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Restante, SqlDbType.Int,
                    theFactura.montoRestanteFactura.ToString(),
                        false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamTipo_Moneda, SqlDbType.VarChar,
                    theFactura.tipoMoneda, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamDescripcion, SqlDbType.VarChar,
                    theFactura.descripcionFactura, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamEstatus, SqlDbType.Int,
                    theFactura.estatusFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdProyecto, SqlDbType.Int,
                    theFactura.idProyectoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdCompania, SqlDbType.Int,
                    theFactura.idCompaniaFactura.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar el stored procedure M8_AgregarFactura y todos los parametros que recibe
                EjecutarStoredProcedure(ResourceFactura.AddNewFactura, parameters);

            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceFactura.Codigo,
                     ResourceFactura.MensajeFormato, ex);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(ResourceFactura.Codigo,
                    ResourceFactura.MensajeNull, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceFactura.Codigo,
                   ResourceFactura.MensajeSQL, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceFactura.Codigo,
                    ResourceFactura.MensajeOtro, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceFactura.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return true;
        }

        /// <summary>
        /// Metodo para modificar un factura en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Facturacion para modificar en bd</param>
        /// <returns>true si fue modificado</returns>
        public bool Modificar(Entidad parametro)
        {
            List<Parametro> parameters = new List<Parametro>();
            Facturacion theFactura = (Facturacion)parametro;
            Parametro theParam = new Parametro();

            try
            {
                theParam = new Parametro(ResourceFactura.ParamIdFactura, SqlDbType.Int,
                    theFactura.Id.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamFecha_Emision, SqlDbType.DateTime,
                    theFactura.fechaFactura.ToString(),
                        false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamFecha_Ultimo_Pago, SqlDbType.DateTime, 
                        theFactura.fechaUltimoPagoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Total, SqlDbType.Int,
                    theFactura.montoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Restante, SqlDbType.Int,
                    theFactura.montoRestanteFactura.ToString(), 
                        false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamTipo_Moneda, SqlDbType.VarChar,
                    theFactura.tipoMoneda, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamDescripcion, SqlDbType.VarChar,
                    theFactura.descripcionFactura, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamEstatus, SqlDbType.Int,
                    theFactura.estatusFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdProyecto, SqlDbType.Int,
                    theFactura.idProyectoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdCompania, SqlDbType.Int,
                    theFactura.idCompaniaFactura.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar el stored procedure M8_ModificarFactura y todos los parametros que recibe
                EjecutarStoredProcedure(ResourceFactura.ChangeFactura, parameters);

            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceFactura.Codigo,
                     ResourceFactura.MensajeFormato, ex);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(ResourceFactura.Codigo,
                    ResourceFactura.MensajeNull, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceFactura.Codigo,
                   ResourceFactura.MensajeSQL, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceFactura.Codigo,
                    ResourceFactura.MensajeOtro, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceFactura.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return true;
        }

        /// <summary>
        /// Funcion que permite obtener los datos de una factura en especifico
        /// </summary>
        /// <param name="idFactura"></param>
        /// <returns>Retorna la factura en cuestion</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            List<Parametro> parameters = new List<Parametro>();
            Facturacion theFactura = (Facturacion)parametro;
            Parametro theParam = new Parametro();

            try
            {
                theParam = new Parametro(ResourceFactura.ParamIdFactura, SqlDbType.Int,
                    theFactura.Id.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceFactura.ContactFactura, parameters);

                //Guardar los datos 
                DataRow row = dt.Rows[0];

                int facId = int.Parse(row[ResourceFactura.FacIdFactura].ToString());
                DateTime facFecha = DateTime.Parse(row[ResourceFactura.FacFechaEmision].ToString());
                DateTime facFechaUltimoPago = DateTime.Parse(row[ResourceFactura.FacFechaUltimoPago].ToString());
                double facMonto = double.Parse(row[ResourceFactura.FacMontoTotal].ToString());
                double facMontoRestante = double.Parse(row[ResourceFactura.FacMontoRestante].ToString());
                String facTipoMoneda = row[ResourceFactura.FacTipoMoneda].ToString();
                String facDescripcion = row[ResourceFactura.FacDescripcion].ToString();
                int facEstatus = int.Parse(row[ResourceFactura.FacEstatus].ToString());
                int facIdProyecto = int.Parse(row[ResourceFactura.FacIdProyecto].ToString());
                int facIdCompania = int.Parse(row[ResourceFactura.FacIdCompania].ToString());

                //Creo un objeto de tipo Compania con los datos de la fila y lo guardo.
                theFactura = new Facturacion(facId, facFecha, facFechaUltimoPago, facMonto, facMontoRestante,
                    facTipoMoneda, facDescripcion, facEstatus, facIdProyecto, facIdCompania);
                theFactura.Id = facId;

            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceFactura.Codigo,
                     ResourceFactura.MensajeFormato, ex);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(ResourceFactura.Codigo,
                    ResourceFactura.MensajeNull, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceFactura.Codigo,
                   ResourceFactura.MensajeSQL, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceFactura.Codigo,
                    ResourceFactura.MensajeOtro, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceFactura.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return theFactura;
        }

        /// <summary>
        /// Funcion que permite buscar todas las facturas en la base de datos
        /// </summary>
        /// <returns>Retorna la lista con todas las facturas</returns>
        public List<Entidad> ConsultarTodos()
        {
            List<Parametro> parameters = new List<Parametro>();
            Parametro theParam = new Parametro();
            List<Entidad> listFactura = new List<Entidad>();

            try
            {
                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceFactura.ConsultFacturas, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {

                    int facId = int.Parse(row[ResourceFactura.FacIdFactura].ToString());
                    DateTime facFecha = DateTime.Parse(row[ResourceFactura.FacFechaEmision].ToString());
                    DateTime facFechaUltimoPago = DateTime.Parse(row[ResourceFactura.FacFechaUltimoPago].ToString());
                    double facMonto = double.Parse(row[ResourceFactura.FacMontoTotal].ToString());
                    double facMontoRestante = double.Parse(row[ResourceFactura.FacMontoRestante].ToString());
                    String facTipoMoneda = row[ResourceFactura.FacTipoMoneda].ToString();
                    String facDescripcion = row[ResourceFactura.FacDescripcion].ToString();
                    int facEstatus = int.Parse(row[ResourceFactura.FacEstatus].ToString());
                    int facIdProyecto = int.Parse(row[ResourceFactura.FacIdProyecto].ToString());
                    int facIdCompania = int.Parse(row[ResourceFactura.FacIdCompania].ToString());

                    //Creo un objeto de tipo Compania con los datos de la fila y lo guardo.
                    Facturacion theFactura = new Facturacion(facId, facFecha, facFechaUltimoPago, facMonto,
                        facMontoRestante, facTipoMoneda, facDescripcion, facEstatus, facIdProyecto, facIdCompania);
                    theFactura.Id = facId;

                    listFactura.Add(theFactura);
                }


            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceFactura.Codigo,
                     ResourceFactura.MensajeFormato, ex);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(ResourceFactura.Codigo,
                    ResourceFactura.MensajeNull, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceFactura.Codigo,
                   ResourceFactura.MensajeSQL, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceFactura.Codigo,
                    ResourceFactura.MensajeOtro, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceFactura.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
         
            return listFactura;
        }

        #endregion

        #region IDaoFactura

        /// <summary>
        /// Metodo para eliminar un factura de la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Facturacion a eliminar en bd</param>
        /// <returns>true si fue eliminado</returns>
        public bool DeleteFactura(Entidad parametro)
        {
            List<Parametro> parameters = new List<Parametro>();
            Facturacion theFactura = (Facturacion)parametro;
            Parametro theParam = new Parametro();

            try
            {
                theParam = new Parametro(ResourceFactura.ParamIdFactura, SqlDbType.Int,
                    theFactura.Id.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar el stored procedure M8_AgregarFactura y todos los parametros que recibe
                EjecutarStoredProcedure(ResourceFactura.DeleteFactura, parameters);

            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceFactura.Codigo,
                     ResourceFactura.MensajeFormato, ex);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(ResourceFactura.Codigo,
                    ResourceFactura.MensajeNull, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceFactura.Codigo,
                   ResourceFactura.MensajeSQL, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceFactura.Codigo,
                    ResourceFactura.MensajeOtro, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceFactura.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return true;
        }

        /// <summary>
        /// Metodo para anular una factura de la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Facturacion a eliminar en bd</param>
        /// <returns>true si fue anulada</returns>
        public bool AnnularFactura(Entidad parametro)
        {
            List<Parametro> parameters = new List<Parametro>();
            Facturacion theFactura = (Facturacion)parametro;
            Parametro theParam = new Parametro();

            try
            {
                theParam = new Parametro(ResourceFactura.ParamIdFactura, SqlDbType.Int,
                    theFactura.Id.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamFecha_Emision, SqlDbType.DateTime,
                    theFactura.fechaFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamFecha_Ultimo_Pago, SqlDbType.DateTime, 
                        theFactura.fechaUltimoPagoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Total, SqlDbType.Int,
                    theFactura.montoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Restante, SqlDbType.Int,
                    theFactura.montoRestanteFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamTipo_Moneda, SqlDbType.VarChar,
                    theFactura.tipoMoneda, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamDescripcion, SqlDbType.VarChar,
                    theFactura.descripcionFactura, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamEstatus, SqlDbType.Int,
                    theFactura.estatusFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdProyecto, SqlDbType.Int,
                    theFactura.idProyectoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdCompania, SqlDbType.Int,
                    theFactura.idCompaniaFactura.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar el stored procedure M8_AnnularFactura y todos los parametros que recibe
                EjecutarStoredProcedure(ResourceFactura.AnnularFactura, parameters);

            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceFactura.Codigo,
                     ResourceFactura.MensajeFormato, ex);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(ResourceFactura.Codigo,
                    ResourceFactura.MensajeNull, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceFactura.Codigo,
                   ResourceFactura.MensajeSQL, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceFactura.Codigo,
                    ResourceFactura.MensajeOtro, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceFactura.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return true;
        }

        /// <summary>
        /// Funcion que permite buscar todas las facturas asociadas a una compañia
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns>Retorna la lista con todas las facturas</returns>
        public List<Entidad> ContactFacturasCompania(Entidad parametro)
        {
            List<Parametro> parameters = new List<Parametro>();
            CompaniaM4 theCompany = (CompaniaM4)parametro;
            Parametro theParam = new Parametro();
            Facturacion theFactura = new Facturacion();
            List<Entidad> listFactura = new List<Entidad>();

            try
            {
                theParam = new Parametro(ResourceFactura.ParamIdCompania, SqlDbType.Int,
                    theCompany.Id.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceFactura.ContactFacturasCompania, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {

                    int facId = int.Parse(row[ResourceFactura.FacIdFactura].ToString());
                    DateTime facFecha = DateTime.Parse(row[ResourceFactura.FacFechaEmision].ToString());
                    DateTime facFechaUltimoPago = DateTime.Parse(row[ResourceFactura.FacFechaUltimoPago].ToString());
                    double facMonto = double.Parse(row[ResourceFactura.FacMontoTotal].ToString());
                    double facMontoRestante = double.Parse(row[ResourceFactura.FacMontoRestante].ToString());
                    String facTipoMoneda = row[ResourceFactura.FacTipoMoneda].ToString();
                    String facDescripcion = row[ResourceFactura.FacDescripcion].ToString();
                    int facEstatus = int.Parse(row[ResourceFactura.FacEstatus].ToString());
                    int facIdProyecto = int.Parse(row[ResourceFactura.FacIdProyecto].ToString());
                    int facIdCompania = int.Parse(row[ResourceFactura.FacIdCompania].ToString());

                    theFactura = new Facturacion(facId, facFecha, facFechaUltimoPago, facMonto, facMontoRestante,
                        facTipoMoneda, facDescripcion, facEstatus, facIdProyecto, facIdCompania);
                    theFactura.Id = facId;

                    listFactura.Add(theFactura);
                }


            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceFactura.Codigo,
                     ResourceFactura.MensajeFormato, ex);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(ResourceFactura.Codigo,
                    ResourceFactura.MensajeNull, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceFactura.Codigo,
                   ResourceFactura.MensajeSQL, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceFactura.Codigo,
                    ResourceFactura.MensajeOtro, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceFactura.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
         
            return listFactura;
        }

        /// <summary>
        /// Funcion que permite buscar todas las facturas pagadas asociadas a una compañia
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns>Retorna la lista con todas las facturas</returns>
        public List<Entidad> ContactFacturasPagadasCompania(Entidad parametro)
        {
            List<Parametro> parameters = new List<Parametro>();
            CompaniaM4 theCompany = (CompaniaM4)parametro;
            Parametro theParam = new Parametro();
            List<Entidad> listFactura = new List<Entidad>();

            try
            {
                theParam = new Parametro(ResourceFactura.ParamIdCompania, SqlDbType.Int,
                    theCompany.Id.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceFactura.ContactFacturasPagadasCompania,
                    parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {

                    int facId = int.Parse(row[ResourceFactura.FacIdFactura].ToString());
                    DateTime facFecha = DateTime.Parse(row[ResourceFactura.FacFechaEmision].ToString());
                    DateTime facFechaUltimoPago = DateTime.Parse(row[ResourceFactura.FacFechaUltimoPago].ToString());
                    double facMonto = double.Parse(row[ResourceFactura.FacMontoTotal].ToString());
                    double facMontoRestante = double.Parse(row[ResourceFactura.FacMontoRestante].ToString());
                    String facTipoMoneda = row[ResourceFactura.FacTipoMoneda].ToString();
                    String facDescripcion = row[ResourceFactura.FacDescripcion].ToString();
                    int facEstatus = int.Parse(row[ResourceFactura.FacEstatus].ToString());
                    int facIdProyecto = int.Parse(row[ResourceFactura.FacIdProyecto].ToString());
                    int facIdCompania = int.Parse(row[ResourceFactura.FacIdCompania].ToString());

                    Facturacion theFactura = new Facturacion(facId, facFecha, facFechaUltimoPago, facMonto,
                        facMontoRestante, facTipoMoneda, facDescripcion, facEstatus, facIdProyecto, facIdCompania);
                    theFactura.Id = facId;

                    listFactura.Add(theFactura);
                }


            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceFactura.Codigo,
                     ResourceFactura.MensajeFormato, ex);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(ResourceFactura.Codigo,
                    ResourceFactura.MensajeNull, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceFactura.Codigo,
                   ResourceFactura.MensajeSQL, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceFactura.Codigo,
                    ResourceFactura.MensajeOtro, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceFactura.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return listFactura;
        }

        /// <summary>
        /// Metodo para consultar el monto restante de una factura por id
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns>Devuelve el monto restante de una factura por id</returns>
        public double ContactMontoRestanteFactura(Entidad parametro)
        {
            List<Parametro> parameters = new List<Parametro>();
            Facturacion theFactura = (Facturacion)parametro;
            Parametro theParam = new Parametro();
            double montoRestante = 0;

            try
            {
                theParam = new Parametro(ResourceFactura.ParamIdFactura, SqlDbType.Int,
                    theFactura.Id.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar el monto restante de la factura
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceFactura.ConsultMontoRestanteFactura, parameters);

                //Guardar los datos 
                DataRow row = dt.Rows[0];

                montoRestante = double.Parse(row[ResourceFactura.FacMontoRestante].ToString());
 
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceFactura.Codigo,
                     ResourceFactura.MensajeFormato, ex);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(ResourceFactura.Codigo,
                    ResourceFactura.MensajeNull, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceFactura.Codigo,
                   ResourceFactura.MensajeSQL, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceFactura.Codigo,
                    ResourceFactura.MensajeOtro, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceFactura.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return montoRestante;
        }

        /// <summary>
        /// Metodo que permite buscar si ya existe una factura para una fecha, proyecto y compañia dada
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns>Retorna un valor booleano para saber si ya existe la factura especifica</returns>
        public bool CheckExistingInvoice(Entidad parametro)
        {
            List<Parametro> parameters = new List<Parametro>();
            Facturacion TheFactura = (Facturacion)parametro;
            Parametro theParam = new Parametro();

            bool resultado = false;

            try
            {
                theParam = new Parametro(ResourceFactura.ParamFecha_Emision, SqlDbType.Date,
                    TheFactura.fechaFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdProyecto, SqlDbType.Int,
                    TheFactura.idProyectoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdCompania, SqlDbType.Int,
                    TheFactura.idCompaniaFactura.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceFactura.VerifyExistingInvoice, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    resultado = true;
                }
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceFactura.Codigo,
                     ResourceFactura.MensajeFormato, ex);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(ResourceFactura.Codigo,
                    ResourceFactura.MensajeNull, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceFactura.Codigo,
                   ResourceFactura.MensajeSQL, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceFactura.Codigo,
                    ResourceFactura.MensajeOtro, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceFactura.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
         
            return resultado;
        }

        #endregion

    }
}
