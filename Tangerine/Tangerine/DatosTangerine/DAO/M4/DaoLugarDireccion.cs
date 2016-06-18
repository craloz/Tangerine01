﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M4;
using DominioTangerine.Entidades.M4;
using DominioTangerine;

namespace DatosTangerine.DAO.M4
{
    public class DaoLugarDireccion : DAOGeneral,IDaoLugarDireccion
    {
      
       public bool Agregar(Entidad parametro)
       {
           throw new NotImplementedException();
       }

       public bool Modificar(Entidad parametro)
       {
           throw new NotImplementedException();
       }

       public Entidad ConsultarXId(Entidad parametro)
       {
           throw new NotImplementedException();
       }

       public List<Entidad> ConsultarTodos()
       {
           throw new NotImplementedException();
       }

       public List<Entidad> ConsultCityPlaces()
       {
           List<Parametro> parameters = new List<Parametro>();
           List<Entidad> listPlace = new List<Entidad>();

           try
           {

               //Guardo la tabla que me regresa el procedimiento de consultar contactos
               DataTable dt = EjecutarStoredProcedureTuplas(ResourcePlaceM4.ConsultCityPlaces, parameters);

               //Por cada fila de la tabla voy a guardar los datos 
               foreach (DataRow row in dt.Rows)
               {

                   int lugId = int.Parse(row[ResourcePlaceM4.LugIdPlace].ToString());
                   String lugName = row[ResourcePlaceM4.LugNamePlace].ToString();

                   Entidad thePlace = DominioTangerine.Fabrica.FabricaEntidades.crearLugarDireccionConLugar(lugId, lugName);
                   listPlace.Add(thePlace);
               }
               return listPlace;

           }
           catch (Exception ex)
           {
               throw new ExcepcionesTangerine.M4.NullArgumentException(RecursoGeneralBD.Codigo,
                   RecursoGeneralBD.Mensaje, ex);
           }
       }

     
    }
}
