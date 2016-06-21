﻿using DatosTangerine.InterfazDAO.M7;
using DatosTangerine.M7;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosTangerine.DAO.M7
{
    public class DaoProyecto : DAOGeneral, IDaoProyecto
    {
        #region IDAO Proyecto

        public bool DeleteProyecto(Entidad proyecto)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ContactProyectoxAcuerdoPago()
        {
        List<Parametro> parameters = new List<Parametro>();
           List<Entidad> listProyecto = new List<Entidad>();

            try
            {
                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceProyecto.ContactProyectosxAcuerdoPago, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    Entidad proyecto = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Id = int.Parse(row[ResourceProyecto.ProyIdProyecto].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Nombre = row[ResourceProyecto.ProyNombre].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Codigo = row[ResourceProyecto.ProyCodigo].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechainicio = DateTime.Parse(row[ResourceProyecto.ProyFechaInicio].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechaestimadafin = DateTime.Parse(row[ResourceProyecto.ProyFechaEstFin].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Costo = double.Parse(row[ResourceProyecto.ProyCosto].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Descripcion = row[ResourceProyecto.ProyDescripcion].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Realizacion = row[ResourceProyecto.ProyRealizacion].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus = row[ResourceProyecto.ProyEstatus].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Razon = row[ResourceProyecto.ProyRazon].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Acuerdopago = row[ResourceProyecto.ProyAcuerdoPago].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idpropuesta = int.Parse(row[ResourceProyecto.ProyIdPropuesta].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idresponsable = int.Parse(row[ResourceProyecto.ProyIdCompania].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idgerente = int.Parse(row[ResourceProyecto.ProyIdCompania].ToString());

                    listProyecto.Add(proyecto);

                }


            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listProyecto;
        }
        
        public List<Entidad> ContactProyectoPorEmpleado(Entidad empleado)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ContactProyectoPorGerente(Entidad empleado)
        {
            throw new NotImplementedException();
        }

        public Entidad ContactNombrePropuestaId(Entidad parametro)
        {

            Entidad propuesta = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPropuesta();
            try
            {
                List<Parametro> parameters = new List<Parametro>();

                Parametro theParam = new Parametro(ResourceProyecto.ParamIdPropuestaPrpu, SqlDbType.Int, ((DominioTangerine.Entidades.M7.Proyecto)parametro).Id.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar Proyecto
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceProyecto.ContactNombrePropuestaID, parameters);

                //Guardar los datos 
                DataRow row = dt.Rows[0];
                ((DominioTangerine.Entidades.M7.Propuesta)propuesta).Nombre = row[ResourceProyecto.PrpuNombre].ToString();

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return propuesta;
        }

        public int ContactMaxIdProyecto()
        {
            throw new NotImplementedException();
        }

        public Double CalcularPagoMensual(Entidad parametro)
        {
            DominioTangerine.Entidades.M7.Proyecto P = (DominioTangerine.Entidades.M7.Proyecto)parametro;

            int dias = Int32.Parse((P.Fechaestimadafin - P.Fechainicio).Days.ToString());
            if (dias > 31)
            {
                return (P.Costo / dias) * 30;
            }
            else
            {
                return P.Costo;
            }
        }

        public String GenerarCodigoProyecto(Entidad parametro)
        {
            DominioTangerine.Entidades.M6.Propuesta P = (DominioTangerine.Entidades.M6.Propuesta)parametro;
            String nombre = P.Nombre;
            return "Proy-" + nombre[0] + nombre[1] + nombre[2] + nombre[3] + DateTime.Today.Year;
        }

        #endregion

        #region DAO

        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para modificar un proyecto en la base de datos.
        /// </summary>
        ///  <param name="parametro">objeto de tipo proyecto para agregar en BD</param>
        ///  <param name="parametros">objeto de tipo lista parametro para la captura de los campos</param>
        /// <returns>true si fue agregado</returns>
        public bool Modificar(Entidad parametro)
        {

            List<Parametro> parameters = new List<Parametro>();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                Parametro theParam = new Parametro(ResourceProyecto.ParamId_Proyecto, SqlDbType.Int, ((DominioTangerine.Entidades.M7.Proyecto)parametro).Id.ToString(), false);
                parameters.Add(theParam);

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceProyecto.ParamNombre, SqlDbType.VarChar, ((DominioTangerine.Entidades.M7.Proyecto)parametro).Nombre.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamCodigo, SqlDbType.VarChar, ((DominioTangerine.Entidades.M7.Proyecto)parametro).Codigo.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamFechaInicio, SqlDbType.Date, ((DominioTangerine.Entidades.M7.Proyecto)parametro).Fechainicio.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamFechaEstFin, SqlDbType.Date, ((DominioTangerine.Entidades.M7.Proyecto)parametro).Fechaestimadafin.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamCosto, SqlDbType.Int, ((DominioTangerine.Entidades.M7.Proyecto)parametro).Costo.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamDescripcion, SqlDbType.VarChar, ((DominioTangerine.Entidades.M7.Proyecto)parametro).Descripcion.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamRealizacion, SqlDbType.VarChar, ((DominioTangerine.Entidades.M7.Proyecto)parametro).Realizacion.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamEstatus, SqlDbType.VarChar, ((DominioTangerine.Entidades.M7.Proyecto)parametro).Estatus.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamRazon, SqlDbType.VarChar, ((DominioTangerine.Entidades.M7.Proyecto)parametro).Razon.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamAcuerdoPago, SqlDbType.VarChar, ((DominioTangerine.Entidades.M7.Proyecto)parametro).Acuerdopago.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamIdPropuesta, SqlDbType.Int, ((DominioTangerine.Entidades.M7.Proyecto)parametro).Idpropuesta.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamIdCompania, SqlDbType.Int, ((DominioTangerine.Entidades.M7.Proyecto)parametro).Idresponsable.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamIdGerente, SqlDbType.Int, ((DominioTangerine.Entidades.M7.Proyecto)parametro).Idgerente.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M7_ModificarProyecto y todos los parametros que recibe
                List<Resultado> results = EjecutarStoredProcedure(ResourceProyecto.ChangeProyecto, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }

        /// <summary>
        /// Metodo para consultar un poryecto por su ID en la base de datos.
        /// </summary>
        ///  <param name="parametro">objeto de tipo proyecto obtener el ID y buscar en la BD</param>
        ///  <param name="parametros">objeto de tipo lista parametro para la captura de los campos</param>
        /// <returns>Entidad Proyecto con todos los atributos</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            // AQUI VA EL LOGGER!
            Entidad proyecto = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();
            try
            {
                List<Parametro> parameters = new List<Parametro>(); 

                Parametro theParam = new Parametro(ResourceProyecto.ParamId_Proyecto, SqlDbType.Int, ((DominioTangerine.Entidades.M7.Proyecto)parametro).Id.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar Proyecto
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceProyecto.ContactProyecto, parameters);
                //Guardar los datos 
                DataRow row = dt.Rows[0];
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Id = int.Parse(row[ResourceProyecto.ProyIdProyecto].ToString());
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Nombre = row[ResourceProyecto.ProyNombre].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Codigo = row[ResourceProyecto.ProyCodigo].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechainicio = DateTime.Parse(row[ResourceProyecto.ProyFechaInicio].ToString());
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechaestimadafin = DateTime.Parse(row[ResourceProyecto.ProyFechaEstFin].ToString());
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Costo = double.Parse(row[ResourceProyecto.ProyCosto].ToString());
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Descripcion = row[ResourceProyecto.ProyDescripcion].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Realizacion = row[ResourceProyecto.ProyRealizacion].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus = row[ResourceProyecto.ProyEstatus].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Razon = row[ResourceProyecto.ProyRazon].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Acuerdopago = row[ResourceProyecto.ProyAcuerdoPago].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idpropuesta = int.Parse(row[ResourceProyecto.ProyIdPropuesta].ToString());
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idresponsable = int.Parse(row[ResourceProyecto.ProyIdCompania].ToString());
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idgerente = int.Parse(row[ResourceProyecto.ProyIdCompania].ToString());
            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return proyecto;
        }

        /// <summary>
        /// Metodo para consultar todos los proyectos en la base de datos.
        /// </summary>
        ///  <param name="parametros">objeto de tipo lista parametro para la captura de los campos</param>
        /// <returns>Lista de Proyectos</returns>
        public List<Entidad> ConsultarTodos()
        {
           List<Parametro> parameters = new List<Parametro>();
           List<Entidad> listProyecto = new List<Entidad>();

            try
            {
                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceProyecto.ContactProyectos, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    Entidad proyecto = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Id = int.Parse(row[ResourceProyecto.ProyIdProyecto].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Nombre = row[ResourceProyecto.ProyNombre].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Codigo = row[ResourceProyecto.ProyCodigo].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechainicio = DateTime.Parse(row[ResourceProyecto.ProyFechaInicio].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechaestimadafin = DateTime.Parse(row[ResourceProyecto.ProyFechaEstFin].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Costo = double.Parse(row[ResourceProyecto.ProyCosto].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Descripcion = row[ResourceProyecto.ProyDescripcion].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Realizacion = row[ResourceProyecto.ProyRealizacion].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus = row[ResourceProyecto.ProyEstatus].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Razon = row[ResourceProyecto.ProyRazon].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Acuerdopago = row[ResourceProyecto.ProyAcuerdoPago].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idpropuesta = int.Parse(row[ResourceProyecto.ProyIdPropuesta].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idresponsable = int.Parse(row[ResourceProyecto.ProyIdCompania].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idgerente = int.Parse(row[ResourceProyecto.ProyIdCompania].ToString());

                    listProyecto.Add(proyecto);

                }


            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listProyecto;
        }

        #endregion
    }
}
